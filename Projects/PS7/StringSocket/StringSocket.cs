/// Skeleten implemented by Camille Rasmussen and Jessie Delacenserie
/// CS 3500 Fall 2014

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomNetworking
{
	/// <summary> 
	/// A StringSocket is a wrapper around a Socket.  It provides methods that
	/// asynchronously read lines of text (strings terminated by newlines) and 
	/// write strings. (As opposed to Sockets, which read and write raw bytes.)  
	///
	/// StringSockets are thread safe.  This means that two or more threads may
	/// invoke methods on a shared StringSocket without restriction.  The
	/// StringSocket takes care of the synchonization.
	/// 
	/// Each StringSocket contains a Socket object that is provided by the client.  
	/// A StringSocket will work properly only if the client refrains from calling
	/// the contained Socket's read and write methods.
	/// 
	/// If we have an open Socket s, we can create a StringSocket by doing
	/// 
	///    StringSocket ss = new StringSocket(s, new UTF8Encoding());
	/// 
	/// We can write a string to the StringSocket by doing
	/// 
	///    ss.BeginSend("Hello world", callback, payload);
	///    
	/// where callback is a SendCallback (see below) and payload is an arbitrary object.
	/// This is a non-blocking, asynchronous operation.  When the StringSocket has 
	/// successfully written the string to the underlying Socket, or failed in the 
	/// attempt, it invokes the callback.  The parameters to the callback are a
	/// (possibly null) Exception and the payload.  If the Exception is non-null, it is
	/// the Exception that caused the send attempt to fail.
	/// 
	/// We can read a string from the StringSocket by doing
	/// 
	///     ss.BeginReceive(callback, payload)
	///     
	/// where callback is a ReceiveCallback (see below) and payload is an arbitrary object.
	/// This is non-blocking, asynchronous operation.  When the StringSocket has read a
	/// string of text terminated by a newline character from the underlying Socket, or
	/// failed in the attempt, it invokes the callback.  The parameters to the callback are
	/// a (possibly null) string, a (possibly null) Exception, and the payload.  Either the
	/// string or the Exception will be non-null, but nor both.  If the string is non-null, 
	/// it is the requested string (with the newline removed).  If the Exception is non-null, 
	/// it is the Exception that caused the send attempt to fail.
	/// </summary>

	public class StringSocket
	{
		// the underlying socket
		private Socket socket;
		// the encoder sent over by the user
		private Encoding encoding;

		// delegates for both send and receiving callbacks
		public delegate void SendCallback(Exception e, object payload);
		public delegate void ReceiveCallback(String s, Exception e, object payload);

		// queue member vairables to hold current requests and received messages
		private Queue<Tuple<String, SendCallback, object>> toSend;
		private Queue<String> receivedMessages;
		private Queue<Tuple<ReceiveCallback, object>> receiveRequests;

		// booleans to control spinning of threads
		private bool currentlySending;
		private bool spin;

		// strings to hold messages outgoing and incoming
		private string outgoingMessage;
		private string incomingMessage;

		// lock object
		private readonly object sendSync = new object();

		// buffer for BeginReceive
		private byte[] buffer;

		/// <summary>
		/// Creates a StringSocket from a regular Socket, which should already be connected.  
		/// The read and write methods of the regular Socket must not be called after the
		/// LineSocket is created.  Otherwise, the StringSocket will not behave properly.  
		/// The encoding to use to convert between raw bytes and strings is also provided.
		/// </summary>
		public StringSocket(Socket s, Encoding e)
		{
			// initialize all variables
			socket = s;
			encoding = e;
			currentlySending = false;
			toSend = new Queue<Tuple<string, SendCallback, object>>();
			receivedMessages = new Queue<String>();
			receiveRequests = new Queue<Tuple<ReceiveCallback, object>>();
			outgoingMessage = "";
			incomingMessage = "";

			// begin receiving bytes from the socket
			buffer = new byte[1024];
			socket.BeginReceive(buffer, 0, buffer.Length,
									SocketFlags.None, MessageReceivedCallback, buffer);

			// begin the spinning of threads to constantly check if messages need to go out
			//      or if messages are available to receive
			spin = true;
            new Thread(() => SpinSendThread()).Start();
            new Thread(() => SpinReceiveThread()).Start();

			// begin receiving bytes from the socket
			buffer = new byte[1024];
			socket.BeginReceive(buffer, 0, buffer.Length,
									SocketFlags.None, MessageReceived, buffer);

		}

		/// <summary>
		/// We can write a string to a StringSocket ss by doing
		/// 
		///    ss.BeginSend("Hello world", callback, payload);
		///    
		/// where callback is a SendCallback (see below) and payload is an arbitrary object.
		/// This is a non-blocking, asynchronous operation.  When the StringSocket has 
		/// successfully written the string to the underlying Socket, or failed in the 
		/// attempt, it invokes the callback.  The parameters to the callback are a
		/// (possibly null) Exception and the payload.  If the Exception is non-null, it is
		/// the Exception that caused the send attempt to fail. 
		/// 
		/// This method is non-blocking.  This means that it does not wait until the string
		/// has been sent before returning.  Instead, it arranges for the string to be sent
		/// and then returns.  When the send is completed (at some time in the future), the
		/// callback is called on another thread.
		/// 
		/// This method is thread safe.  This means that multiple threads can call BeginSend
		/// on a shared socket without worrying around synchronization.  The implementation of
		/// BeginSend must take care of synchronization instead.  On a given StringSocket, each
		/// string arriving via a BeginSend method call must be sent (in its entirety) before
		/// a later arriving string can be sent.
		/// </summary>
		public void BeginSend(String s, SendCallback callback, object payload)
		{
            if (s.Length != 0)
			{
                // add this request to the queue
				toSend.Enqueue(Tuple.Create(s, callback, payload));
			}
		}

		/// <summary>
		/// A helper method that runs on it's own thread at the start of the StringSocket object.
		/// This thread constantly checks if there are any messages that need to be sent, and if
		/// there are and we are not currently sending one, it prepares the next available message
		/// and calls SendBytes to start attempting to send the bytes. This spinning loop is 
		/// terminated when Close() is called by the user.
		/// </summary>
		private void SpinSendThread()
		{			
            // Spin as long as program is active
			while (spin)
			{
                // if there is at least one send request containing a message and there nothing is currently being sent
                if (toSend.Count > 0 && !currentlySending)
                {
                    // prepare to send the next available message
					outgoingMessage = toSend.Peek().Item1;

                    // Get exclusive access to send mechanism
                    lock (sendSync)
                    {
						currentlySending = true;
                        SendBytes();
                    }
                }
				Thread.Sleep(300);
			}
		}

		/// <summary>
		/// Checks to see if there is any part of the message left to send, and if there
		/// is, converts it to bytes and calls the underlying Socket's BeginSend to start
		/// sending the bytes.
		/// </summary>
		private void SendBytes()
		{
			// if there is no outgoingMessage left to send, stop sending
			if (outgoingMessage == "")
			{
				// we've stopped sending
				currentlySending = false;

 				// if this message was initially "", it will never be sent. 
			}
			
            // otherwise send next piece of message to socket
			else
			{
				// convert the message to bytes
				byte[] outgoingBuffer = encoding.GetBytes(outgoingMessage);
				// reset the outgoingMessage
				outgoingMessage = "";
				// begin sending on the underlying socket, MessageSentCallback will follow this
				socket.BeginSend(outgoingBuffer, 0, outgoingBuffer.Length,
								 SocketFlags.None, MessageSentCallback, outgoingBuffer);
			}
		}


		/// <summary>
		/// The underlying Socket's callback that is called by Socket on a separate thread when bytes have 
		/// been sent. This callback checks to make sure that all bytes of the current message have successfully
		/// been sent and if not, attempts to send them again. If they have all been successfully sent, 
		/// the current request's callback is invoked on a new thread and we are done sending.
		/// </summary>
		private void MessageSentCallback(IAsyncResult result)
		{
			lock (sendSync)
			{	
				// Find out how many bytes were actually sent
				int bytes = socket.EndSend(result);

				// Get the bytes that we attempted to send
				byte[] outgoingBuffer = (byte[])result.AsyncState;

				// if there were less sent than we tried to send, add the ones that didn't go out
				// to the outgoingMessage and attempt sending agiain.
				// outgoingMessage was already erased, so it should just contain the unsent bytes.
				if (bytes < outgoingBuffer.Length) // this is an iffy change if(bytes != 0)
				{
					outgoingMessage = encoding.GetString(outgoingBuffer, bytes,
												  outgoingBuffer.Length - bytes);
					SendBytes();
				}
				// else if the entire message was successfully sent, we invoke callback on its own thread
				else
				{
					// dequeue the request that attempted to be sent
					Tuple<String, SendCallback, object> tupleSent = toSend.Dequeue();

					// invoke callback
					SendCallback callback = tupleSent.Item2;
					object payload = tupleSent.Item3;
					new Thread(() => callback.Invoke(null, payload)).Start();

					// make sure it knows we are done sending
					currentlySending = false;
				}
			}
		}

		/// <summary>
		/// 
		/// <para>
		/// We can read a string from the StringSocket by doing
		/// </para>
		/// 
		/// <para>
		///     ss.BeginReceive(callback, payload)
		/// </para>
		/// 
		/// <para>
		/// where callback is a ReceiveCallback (see below) and payload is an arbitrary object.
		/// This is non-blocking, asynchronous operation.  When the StringSocket has read a
		/// string of text terminated by a newline character from the underlying Socket, or
		/// failed in the attempt, it invokes the callback.  The parameters to the callback are
		/// a (possibly null) string, a (possibly null) Exception, and the payload.  Either the
		/// string or the Exception will be non-null, but nor both.  If the string is non-null, 
		/// it is the requested string (with the newline removed).  If the Exception is non-null, 
		/// it is the Exception that caused the send attempt to fail.
		/// </para>
		/// 
		/// <para>
		/// This method is non-blocking.  This means that it does not wait until a line of text
		/// has been received before returning.  Instead, it arranges for a line to be received
		/// and then returns.  When the line is actually received (at some time in the future), the
		/// callback is called on another thread.
		/// </para>
		/// 
		/// <para>
		/// This method is thread safe.  This means that multiple threads can call BeginReceive
		/// on a shared socket without worrying around synchronization.  The implementation of
		/// BeginReceive must take care of synchronization instead.  On a given StringSocket, each
		/// arriving line of text must be passed to callbacks in the order in which the corresponding
		/// BeginReceive call arrived.
		/// </para>
		/// 
		/// <para>
		/// Note that it is possible for there to be incoming bytes arriving at the underlying Socket
		/// even when there are no pending callbacks.  StringSocket implementations should refrain
		/// from buffering an unbounded number of incoming bytes beyond what is required to service
		/// the pending callbacks.        
		/// </para>
		/// 
		/// <param name="callback"> The function to call upon receiving the data</param>
		/// <param name="payload"> 
		/// The payload is "remembered" so that when the callback is invoked, it can be associated
		/// with a specific Begin Receiver....
		/// </param>  
		/// 
		/// <example>
		///   Here is how you might use this code:
		///   <code>
		///                    client = new TcpClient("localhost", port);
		///                    Socket       clientSocket = client.Client;
		///                    StringSocket receiveSocket = new StringSocket(clientSocket, new UTF8Encoding());
		///                    receiveSocket.BeginReceive(CompletedReceive1, 1);
		/// 
		///   </code>
		/// </example>
		/// </summary>
		/// 
		/// 
		public void BeginReceive(ReceiveCallback callback, object payload)
		{
			// add request to queue
<<<<<<< .mine
			receiveRequests.Enqueue(new Tuple<ReceiveCallback, object>(callback, payload));
			

=======
			receiveRequests.Enqueue(Tuple.Create(callback, payload));
>>>>>>> .r278
		}

		/// <summary>
		/// This method constantly spins a thread looking for new BeginReceive requests.
		/// When it receives a request, it checks to make sure there have been some
		/// messages received. If there are, it dequeues the request and invokes the 
		/// callback on this request with the next message in line.
		/// This loop is controlled by a boolean which will be set to false to end spinning
		/// when the Close() method is called by the user.
		/// </summary>
		private void SpinReceiveThread()
		{
			// create variables
			Tuple<ReceiveCallback, object> request;
			string message;

			// continue thread spin loop until Close() is called
			while (spin)
			{
				
                // if there is a request to process and a message to be returned
				//		dequeue these and invoke the callback on a new thread
				if (receiveRequests.Count != 0 && receivedMessages.Count != 0)
				{
					request = receiveRequests.Dequeue();
					message = receivedMessages.Dequeue();
                    ReceiveCallback callback = request.Item1;
                    object payload = request.Item2;
					new Thread( () => callback.Invoke(message, null, payload)).Start();
				}
				Thread.Sleep(300);
			}
		}

		/// <summary>
		/// This Callback is called upon completion of receiving bytes from the Socket. The initial receiving
		/// of bytes from the underlying Socket begins in the constructor and continues here. This method
		/// checks for new line characters and splits the string according to the placement of them. The 
		/// messages are added to the queue to wait for receive requests.
		/// </summary>
		private void MessageReceivedCallback(IAsyncResult result)
		{
			// Get the buffer to which the data was written.
			byte[] buffer = (byte[])(result.AsyncState);

			// Figure out how many bytes have come in
			int bytes = socket.EndReceive(result);

			// If no bytes were received, it means the client closed its side of the socket.
			if (bytes == 0)
			{
				Close();
			}
			
            // Otherwise,  process
			else
			{
				// Convert the bytes into a string
				incomingMessage += encoding.GetString(buffer, 0, bytes);

				int index;
				// process separate messages according to placement of \n characters
				while ((index = incomingMessage.IndexOf('\n')) >= 0)
				{
					// take the string from beginning to where \n occurs
					String line = incomingMessage.Substring(0, index);
					
					// add this completed message to the queue of received messages
					receivedMessages.Enqueue(line);

					// delete the completed message from what we received
					incomingMessage = incomingMessage.Substring(index + 1);
				}

				// Ask for some more data
				socket.BeginReceive(buffer, 0, buffer.Length,
					SocketFlags.None, MessageReceivedCallback, buffer);
			}
		}

		/// <summary>
		/// Calling the close method will close the String Socket (and the underlying
		/// standard socket).  The close method  should make sure all 
		///
		/// Note: ideally the close method should make sure all pending data is sent
		///       
		/// Note: closing the socket should discard any remaining messages and       
		///       disable receiving new messages
		/// 
		/// Note: Make sure to shutdown the socket before closing it.
		///
		/// Note: the socket should not be used after closing.
		/// </summary>
		public void Close()
		{
			// send any remaining bytes
			SendBytes();

			// stop spinning the threads and clear the queues
			spin = false;
			receivedMessages.Clear();
			toSend.Clear();

			// shutdown and close the socket
			socket.Shutdown(SocketShutdown.Both);
			socket.Close();
		}
	}
}
