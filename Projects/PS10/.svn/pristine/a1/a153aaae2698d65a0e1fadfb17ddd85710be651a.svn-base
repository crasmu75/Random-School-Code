// Authors: Camille Rasmussen & Jessie Delacenserie
// Class: CS 3500, fall 2014
// PS9 -- Boggle Client Model

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using CustomNetworking;
using System.Text.RegularExpressions;

namespace BoggleClient
{
    public class BoggleClientModel
    {
		/// <summary>
		/// Socket used to communicate with server
		/// </summary>
        private StringSocket socket;

        /// <summary>
        /// Action to handle command for an incoming score
        /// </summary>
        public event Action<String> IncomingScoreEvent;

        /// <summary>
        /// Action to handle incoming ignoring command
        /// </summary>
        public event Action<String> IncomingIgnoringEvent;

        /// <summary>
        /// ACtion to handle incoming start command
        /// </summary>
        public event Action<String> IncomingStartEvent;

        /// <summary>
        /// ACtion to handle incoming time command
        /// </summary>
        public event Action<String> IncomingTimeEvent;

        /// <summary>
        /// Action to handle incoming stop command
        /// </summary>
        public event Action<String> IncomingStopEvent;

        /// <summary>
        /// Action to handle incoming terminated command
        /// </summary>
        public event Action IncomingTerminatedEvent;

        /// <summary>
        /// Action to handle if a connection cannot be made
        /// </summary>
        public event Action<String> CannotConnectEvent;

		/// <summary>
        ///  Register for this event to be notified when we are connected to server. 
		/// </summary>
		public event Action ConnectedEvent;

        /// <summary>
        /// Regex to identify incoming score command
        /// </summary>
        Regex scoreCommand = new Regex(@"(SCORE)\s+[0-9]+\s+[0-9]+");

        /// <summary>
        /// Regex to identify incoming ignoring command
        /// </summary>
        Regex ignoringCommand = new Regex(@"(IGNORING)\s+.+");

        /// <summary>
        /// Regex to identify incoming start command
        /// </summary>
        Regex startCommand = new Regex(@"(START)\s+[A-Z]{16}\s+[0-9]+\s+.+");

        /// <summary>
        /// Regex to identify incoming time command
        /// </summary>
        Regex timeCommand = new Regex(@"(TIME)\s+[0-9]+");

        /// <summary>
        /// Regex to identify incoming stop command
        /// </summary>
        Regex stopCommand = new Regex(@"(STOP).+");

        /// <summary>
        /// Regex to identify incoming score command
        /// </summary>
        Regex terminatedCommand = new Regex(@"(TERMINATED)");

        /// <summary>
        /// Boolean to check if game is still going on
        /// </summary>
        private bool acceptingCommands = true;

        /// <summary>
        /// Creates a not yet connected client model.
        /// </summary>
        public BoggleClientModel()
        {
            socket = null;
        }

        /// <summary>
        /// Connect to the server at the given hostname and port and with the give name.
        /// </summary>
        public void Connect(string hostname, int port, String name)
        {
            // If socket is null, connect by sending the START command and begin to receive commands from server
            if (socket == null)
            {
                try
                {
                    acceptingCommands = true;
                    TcpClient client = new TcpClient(hostname, port);
                    socket = new StringSocket(client.Client, UTF8Encoding.Default);
                    // Before receiving anything the socket must send the PLAY command to notify server that it is ready
                    socket.BeginSend("PLAY " + name + "\n", ConnectedCallback, null);
                    socket.BeginReceive(CommandReceived, null);
                }
                catch (Exception e)
                {
                    acceptingCommands = false;
                    CannotConnectEvent(e.ToString());
                }
            }
        }

        /// <summary>
        /// Send a line of text to the server.
        /// </summary>
        /// <param name="line"></param>
        public void SendMessage(String line)
        {
            if (socket != null)
            {
                // Send desired text plus a new line character, empty callback
                socket.BeginSend(line + "\n", (e, p) => { }, null);
            }
        }

		/// <summary>
		/// Called once we are connected to the server to execute proper action
		/// </summary>
		/// <param name="e"></param>
		/// <param name="payload"></param>
		private void ConnectedCallback(Exception e, object payload)
		{
			if (ConnectedEvent != null)
			{
                // Call the connected event action
				ConnectedEvent();
			}
		}

        /// <summary>
        /// Deal with an arriving line of text.
        /// </summary>
        private void CommandReceived(String s, Exception e, object p)
        {
            if (acceptingCommands)
            {
                // If a null message has been received, the game has ended and the socket must be closed
                if (s == null)
                {
                    // Call terminated event to shut down connection and restart GUI
                    IncomingTerminatedEvent();
                    // Must close the socket so it can be reconnected for new game
                    CloseSocket();
                }
                else
                {
                    // Conventions so our client can receive messages from any server
                    s = s.Trim();
                    s = s.ToUpper();

                    // Call proper event action based on Regex match
                    if (scoreCommand.IsMatch(s))
                        IncomingScoreEvent(s);

                    else if (ignoringCommand.IsMatch(s))
                        IncomingIgnoringEvent(s);

                    else if (startCommand.IsMatch(s))
                        IncomingStartEvent(s);

                    else if (timeCommand.IsMatch(s))
                        IncomingTimeEvent(s);

                    else if (stopCommand.IsMatch(s))
                        IncomingStopEvent(s);

                    else if (terminatedCommand.IsMatch(s))
                    {
                        IncomingTerminatedEvent();
                        CloseSocket();
                    }

                    // If socket is not null, keep receiving
                    if (socket != null)
                        socket.BeginReceive(CommandReceived, null);
                }
            }
        }  
       
        /// <summary>
        /// Helper method to close the current socket and stop receiving commands
        /// </summary>
        public void CloseSocket()
        {
            if (socket != null)
                socket.Close();
            socket = null;
            acceptingCommands = false;
        }
    }
}
