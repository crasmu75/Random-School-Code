using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Sockets;
using System.Net;
using System.Text;
using CustomNetworking;

namespace StringSocketTestCase
{
	[TestClass]
	public class UnitTest1
	{
/// <summary>
/// Written by Camille Rasmussen and Jessie Delacenserie
/// 
/// This Test Method tests the behavior of the Close() method upon no calls to the BeginSend or
/// BeginReceive methods. This test makes sure that the client socket is not disconnected when
/// you invoke Close() on the sendSocket, but that the server socket is successfully disconnected
/// when you do so.
/// 
/// We also test to make sure you can't access the Socket after it's StringSocket's Close() has 
/// been invoked, by calling a Socket's Available property, which throws an exception if the
/// Socket has been closed properly.
/// </summary>
[TestMethod]
public void TestMethod1()
{
	new CloseWithoutReceieveOrSend().run(4001);
}

public class CloseWithoutReceieveOrSend
{
	public void run(int port)
	{
		TcpListener server = null;
		TcpClient client = null;

		// set up random encoder to use
		Encoding encoder = new ASCIIEncoding();

		// to check if exception was thrown and handled
		bool caught = false;

		try
		{
			// create and start the server
			server = new TcpListener(IPAddress.Any, port);
			server.Start();
			// create the client
			client = new TcpClient("localhost", port);

			// set up the server and client sockets
			Socket serverSocket = server.AcceptSocket();
			Socket clientSocket = client.Client;

			// set up string sockets with sockets
			StringSocket sendSocket = new StringSocket(serverSocket, encoder);
			StringSocket receiveSocket = new StringSocket(clientSocket, encoder);

			// make sure the sockets are connected initially
			Assert.IsTrue(serverSocket.Connected);
			Assert.IsTrue(clientSocket.Connected);

			// close the sendSocket String Socket
			sendSocket.Close();
			// make sure wrapped Socket specified is disconnected accordingly
			Assert.IsFalse(serverSocket.Connected);
			// and the other wrapped Socket isn't affected
			Assert.IsTrue(clientSocket.Connected);

			// close the receiveSocket String Socket
			receiveSocket.Close();
			// make sure wrapped socket specified is disconnected accordingly
			Assert.IsFalse(clientSocket.Connected);

			// this should throw an exception if the Socket was closed properly
			int amount = serverSocket.Available;
		}
		// exception caught here
		catch (ObjectDisposedException e)
		{
			caught = true;
		}
		finally
		{
			// close up your resources and stop the server
			server.Stop();
			client.Close();

			// make sure proper exception was thrown and caught
			Assert.IsTrue(caught);
		}
	}
}
	}
}
