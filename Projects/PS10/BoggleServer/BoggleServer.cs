﻿// BoggleServer
// Authors: Camille Rasmussen and Jessie Delacenserie
// CS 3500 -- PS10
// Modified from PS9 to communicate with database and web server
// 12/12/14

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using CustomNetworking;
using System.Net;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace BoggleServer
{
	/// <summary>
	/// Boggle Server creates a TCPListener to provide a server for clients to connect
	/// to and play Boggle. Two clients are required for one Boggle came to commence and 
	/// finish completely.
	/// </summary>
	public class BoggleServer
	{
		/// <summary>
		/// Listens for incoming connections for games
		/// </summary>
		private TcpListener gameServer;

		/// <summary>
		/// Listens for incoming connections for web browser
		/// </summary>
		private TcpListener webServer;

		/// <summary>
		/// One StringSocket per connected client
		/// </summary>
		private List<StringSocket> allSockets;

		/// <summary>
		/// the name associated with the socket
		/// </summary>
		private List<string> user_names;

		/// <summary>
		/// list of boggle playing pairs (tuple of 2 sockets)
		/// </summary>
        private List<Game> games;

		/// <summary>
		/// socket that is currently waiting for a partner
		/// </summary>
        Tuple<StringSocket, string> singleSocket;

		/// <summary>
		/// Regex to be used for incoming commands
		/// </summary>
		Regex playCommand = new Regex(@"(PLAY)\s+[a-zA-Z0-9]+");
		Regex wordCommand = new Regex(@"(WORD)\s+[a-zA-Z]+");
		Regex gameInfoCommand = new Regex(@"(GET /game\?id\=)[0-9]+( HTTP/1.1)");
		Regex playerInfoCommand = new Regex(@"(GET /games\?player\=)[a-zA-Z0-9]+( HTTP/1.1)");
		Regex serverStatsCommand = new Regex(@"(GET /players HTTP/1.1)");

		/// <summary>
		/// Length of game
		/// </summary>
		static int gameLength = 0;

		/// <summary>
		/// Holds all legal words
		/// </summary>
		static List<string> dictionary;

		/// <summary>
		/// Optional parameter of 16 letters
		/// </summary>
		static string providedBoardLetters = null;

		/// <summary>
		/// Booleans to check if players are ready to play
		/// </summary>
		private bool p1ready, p2ready = false;

		/// <summary>
		/// Boolean to check if game is still going on
		/// </summary>
		private bool acceptingGameCommands = true;

        /// <summary>
        /// Boolean to check if web page is still connected and commands can be received
        /// </summary>
        private bool acceptingWebCommands = true;

		/// <summary>
		/// Lock object used for locking to prevent data problems due to multi-threading
		/// </summary>
		private Object lockObj;

        /// <summary>
        /// Constant string to hold the SQL connection information
        /// </summary>
        private const string connectionString = "server=atr.eng.utah.edu;database=cs3500_camiller;uid=cs3500_camiller;password=862900629";

		/// <summary>
		///  Main arguments are passed by the OS from command line into here.
		///  Seconds are initialized, dictionary gets populated, and the third
		///  parameter as well.
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
            // Store the time length of the game
			gameLength = Convert.ToInt32(args[0]);

			// Populate dictionary of valid words
			PopulateDictionary(args[1]);

			// Check for and store third parameter
			if (args.Length == 3)
				providedBoardLetters = args[2];

            // Create a new server in port 2000
			new BoggleServer(2000);

            // Create a new server on port 2500
            new BoggleServer(2500);

			Console.Read();
		}

        /// <summary>
        /// CONSTRUCTOR
        /// 
        /// Create a new BoggleServer given an input port
        /// </summary>
        /// <param name="port"></param>
		public BoggleServer(int port)
		{
            // Port 2000 to communicate with client
            if (port == 2000)
            {
				// Create new tcp listener for server
				gameServer = new TcpListener(IPAddress.Any, port);

                // Set up the server
                allSockets = new List<StringSocket>();
                user_names = new List<string>();
                gameServer.Start();
                gameServer.BeginAcceptSocket(ConnectionReceived, null);

                // The single socket needs to be null to begin
                singleSocket = null;

                // Create a new empty list of games
                games = new List<Game>();

                // instantiate object for locking
                lockObj = new Object();
            }

            // Port 2500 to communicate with webpage
            else if (port == 2500)
            {
				// Create new tcp listener for server
				webServer = new TcpListener(IPAddress.Any, port);

                // Set up server
                webServer.Start();
                webServer.BeginAcceptSocket(WebConnectionReceived, null);
            }
		}

        /// <summary>
        /// CONSTRUCTOR (for testing)
        /// This constructor is used in the unit tests in place of the Main method.
        /// Create a new BoggleServer given an input port
        /// </summary>
        /// <param name="port"></param>
		/// <param name="boggleBoardInput"></param>
		/// <param name="dictionaryFile"></param>
		/// <param name="time"></param>
        public BoggleServer(int port, int time, string dictionaryFile, string boggleBoardInput)
        {
            // Set up the server
            gameServer = new TcpListener(IPAddress.Any, port);
            allSockets = new List<StringSocket>();
            user_names = new List<string>();
            gameServer.Start();
            gameServer.BeginAcceptSocket(ConnectionReceived, null);

            // The single socket needs to be null to begin
            singleSocket = null;

            // Create a new empty list of games
            games = new List<Game>();

            // Store the time length of the game
            gameLength = time;

            // Populate dictionary of valid words
            PopulateDictionary(dictionaryFile);

            // Check for and store third parameter
            providedBoardLetters = boggleBoardInput;
        }

        /// <summary>
        /// ConnectionReceived
        /// 
        /// Server callback for BeginAcceptSocket on port 2000
        /// </summary>
        /// <param name="ar"></param>
        public void ConnectionReceived(IAsyncResult ar)
        {
            // Create a new Socket and StringSocket
			Socket socket = gameServer.EndAcceptSocket(ar);
            StringSocket ss = new StringSocket(socket, UTF8Encoding.Default);

            acceptingGameCommands = true;

            // Begin receiving from SS and continue accepting new sockets
			ss.BeginReceive(CommandReceived, ss);
			gameServer.BeginAcceptSocket(ConnectionReceived, null);

			// Feedback of successfull connection
			Console.WriteLine("Received successful connection from game client!");
        }

        /// <summary>
        /// WebConnectionReceived
        /// Server callback for BeginAcceptSocket on port 2500
        /// </summary>
        /// <param name="ar"></param>
        public void WebConnectionReceived(IAsyncResult ar)
        {
            // Create a new Socket and StringSocket
            Socket socket = webServer.EndAcceptSocket(ar);
            StringSocket ss = new StringSocket(socket, UTF8Encoding.Default);

            acceptingWebCommands = true;

            // Begin receiving from SS and continue accepting new sockets
            ss.BeginReceive(WebCommandReceived, ss);
            webServer.BeginAcceptSocket(WebConnectionReceived, null);

            // Feedback of successfull connection
            Console.WriteLine("Received request from web browser!");
        }

		/// <summary>
		/// Method that serves as a callbak for receiving messages. This method goes
		/// through and attempts to parse the message into a command according to the 
		/// protocol. If it is an invalid command, it sends a message back to the socket
		/// indicating that it is ignoring.
		/// </summary>
		/// <param name="incomingCommand"></param>
		/// <param name="e"></param>
		/// <param name="p"></param>
		public void CommandReceived(String incomingCommand, Exception e, object p)
		{
			if (acceptingGameCommands)
			{
				// create a string socket from the input object
				StringSocket ss = (StringSocket)p;

				// Connection is lost or socket is closed
				if(incomingCommand == null || ss == null)
				{
					GameTerminated(ss);
				}
				else
				{
                    incomingCommand = incomingCommand.Trim();
                    incomingCommand = incomingCommand.ToUpper();

					// if the command from client is a PLAY command, call helper method to create a new game
					if (playCommand.IsMatch(incomingCommand))
						ProcessPlayCommand(ss, incomingCommand);

					// if the command from client is a WORD command, call helper method to process and score the word
					else if (wordCommand.IsMatch(incomingCommand))
						ProcessWordCommand(ss, incomingCommand);

					// else an illegal command has been received, send IGNORING message
					else
					{
						ss.BeginSend("IGNORING " + incomingCommand + '\n', (ee, pp) => { }, null);
					}

					// Continue to receive from socket
					ss.BeginReceive(CommandReceived, p);

				}
			}
		}

		/// <summary>
		///  Method that serves as a callbak for receiving messages. This method goes
		/// through and attempts to parse the message into a command according to the 
		/// protocol. If it is an invalid command, it sends a message back to the socket
		/// indicating that it is ignoring. Same as the method above but for the web
		/// browser stringsocket.
		/// </summary>
		/// <param name="incomingCommand"></param>
		/// <param name="e"></param>
		/// <param name="p"></param>
        public void WebCommandReceived(String incomingCommand, Exception e, object p)
        {
			if(acceptingWebCommands)
			{
				// create a string socket from the input object
				StringSocket ss = (StringSocket)p;

				// Connection is lost or socket is closed
				if (incomingCommand == null || ss == null)
				{
					// TODO Close the connection
				}
				else
				{
                    // Send the initial command, then send command for what requests asks for
					incomingCommand = incomingCommand.Trim();
					ss.BeginSend("HTTP/1.1 200 OK\r\nConnection: close\r\nContent-Type: text/html; charset=UTF-8\r\n", (ee, pp) => { }, null);
					ss.BeginSend("\r\n", (ee, pp) => { }, null);
					
                    // Regex to incoming command and send the appropriate page back
					if (playerInfoCommand.IsMatch(incomingCommand))
					{
						string[] words = incomingCommand.Split(' ', '=');
						SendPlayerInfoPage(ss, words[2]);
					}

					else if (gameInfoCommand.IsMatch(incomingCommand))
					{
						string[] words = incomingCommand.Split(' ', '=');
						SendGameInfoPage(ss, Convert.ToInt32(words[2]));
					}

					else if (serverStatsCommand.IsMatch(incomingCommand))
					{
						SendServerStatsPage(ss);
					}

					// else an illegal command has been received, send BAD REQUEST message
					else
					{
						ss.BeginSend("<h1>Bad request</h1><h2>Try reloading the page or clicking back on your browser.</h2>\n", 
							WebSendCallback, ss);
					}

				}
			}
        }

        /// <summary>
        /// Callback for sending a message to the web
        /// </summary>
        /// <param name="e"></param>
        /// <param name="payload"></param>
		private void WebSendCallback(Exception e, object payload)
		{
			StringSocket ss = (StringSocket)payload;
			ss.Close();
		}

		/// <summary>
		/// Builds the html string for server statistics page and sends it back to web browser
		/// 
		/// This page needs to get all player names from the database
		/// It also needs to get the number of wins, losses and tied games of each player
		/// This data will be stored in a table
		/// </summary>
		private void SendServerStatsPage(StringSocket ss)
		{
			// List of tuples to hold all necessary info for stats page
			List<Tuple<string, int, int, int>> playerInfo = new List<Tuple<string,int, int, int>>();

			// Issue command to get info from player_info table in database
			using (MySqlConnection connection = new MySqlConnection(connectionString))
			{
				try
				{
					connection.Open();
					MySqlCommand command = connection.CreateCommand();
					command.CommandText = String.Format("SELECT * FROM player_info");

					MySqlDataReader Reader = command.ExecuteReader();
					if (!Reader.HasRows) return;
					while(Reader.Read())
					{
						playerInfo.Add(Tuple.Create((string)Reader["p_name"], (int)Reader["wins"], (int)Reader["losses"], (int)Reader["ties"]));
					}
				}
				catch (Exception e)
				{
					Console.WriteLine("Error getting info from database " + e.ToString());
				}
			}

            // Start html string 
            string htmlString = "<!DOCTYPE html><html><body><font face=\"arial\"><div id=\"header\" style=\"background-color:indigo;color:white;text-align:center;padding=100x\"><h1><font size=\"7\">CS 3500 Boggle Game</font></h1></div><div id=\"header\" style=\"background-color:lightgreen;color:white;text-align:center;padding=100x;font-size=300%\"><font size=\"5\">Jessie Delacenserie & Camille Rasmussen</font></div><div id=\"section\" style=\"float:left;padding:10px;\">";

            htmlString += "<h1>Overall Server Stats</h1><p>Click on any player name to learn more!</p><table bordercolor=\"lightgreen\" border=\"1\" style=\"width:100%;text-align:center\"><tr><th>Player Name</th><th>Wins</th><th>Losses</th><th>Ties</th></tr>";
			
            // Add each player's info to message
			foreach (Tuple<string, int, int, int> player in playerInfo)
			{
				htmlString += "<tr><td><a href=\"./games?player=" + player.Item1 + "\">" + player.Item1 +"</a></td><td>" + player.Item2.ToString() + "</td><td>" + player.Item3.ToString()
					+ "</td><td>" + player.Item4 + "</td></tr>";
			}

            // Finish html string
			htmlString += "</table></font></body></html>";

            // Send html string to web server
			ss.BeginSend(htmlString+" \n", WebSendCallback, ss);
		}

		/// <summary>
		/// Builds the html string for game info page and sends it back to web browser
		/// </summary>
		private void SendGameInfoPage(StringSocket ss, int gameID)
		{
            // Start the string message
            string htmlString = "<!DOCTYPE html><html><body><font face=\"arial\"><div id=\"header\" style=\"background-color:indigo;color:white;text-align:center;padding=100x\"><h1><font size=\"7\">CS 3500 Boggle Game</font></h1></div><div id=\"header\" style=\"background-color:lightgreen;color:white;text-align:center;padding=100x;font-size=300%\"><font size=\"5\">Jessie Delacenserie & Camille Rasmussen</font></div><div id=\"section\" style=\"float:left;padding:10px;\">";

            // Variables to hold necessary page info
			string p1name = "", p2name = "", dateTime = "", boardLetters = "";
			int p1ID = 0, p2ID = 0, p1score = 0, p2Score = 0, timeLimit = 0;

            // Lists of words to be sent to page
			List<Tuple<string, int, int>> words = new List<Tuple<string, int, int>>();
			List<string> common = new List<string>();

			// Issue command to get info from player_info table in database
			using (MySqlConnection connection = new MySqlConnection(connectionString))
			{
				try
				{
					connection.Open();
					MySqlCommand command = connection.CreateCommand();
					command.CommandText = String.Format("SELECT * FROM game_info WHERE game_id = {0};", gameID);

					MySqlDataReader Reader = command.ExecuteReader();
					if (!Reader.HasRows)
					{
						ss.BeginSend(String.Format("{0}<h1>Game not found with ID {1}</h1>\n", htmlString, gameID), WebSendCallback, ss);
						return;
					}
                    // Read all required info from database and store in variables
					while (Reader.Read())
					{
						p1ID = Convert.ToInt32(Reader[1]);
						p2ID = Convert.ToInt32(Reader[2]);
						dateTime = Reader[3].ToString();
						boardLetters = Reader[4].ToString();
						timeLimit = Convert.ToInt32(Reader[5]);
						p1score = Convert.ToInt32(Reader[6]);
						p2Score = Convert.ToInt32(Reader[7]);
					}
					Reader.Close();

                    // Get the names of both players from the database using player ID's
					command.CommandText = String.Format("SELECT p_name FROM player_info WHERE ID = {0};", p1ID);
					p1name = command.ExecuteScalar().ToString();
					command.CommandText = String.Format("SELECT p_name FROM player_info WHERE ID = {0};", p2ID);
					p2name = command.ExecuteScalar().ToString();

                    // Get all the words played during the game
					command.CommandText = String.Format("SELECT * FROM words_played WHERE game_ID = {0}", gameID);
					Reader = command.ExecuteReader();
					while (Reader.Read())
					{
						words.Add(Tuple.Create(Reader[0].ToString(), Convert.ToInt32(Reader[2]), Convert.ToInt32(Reader[3])));	
					}
					Reader.Close();

					// create a lits for the common words and remove from list of words
					for (int i = 0; i < words.Count - 1; i++)
					{
						for (int j = i + 1; j < words.Count; j++)
						{
							if (words[i].Item1 == words[j].Item1)
							{
								common.Add(words[i].Item1);
								words.Remove(words[i]);
								words.Remove(words[j - 1]);
							}
						}
					}
				}
				catch (Exception e)
				{
					Console.WriteLine("Error getting info from database " + e.ToString());
				}
			}

            // Format the html string
			htmlString += String.Format("<h1><center>Game Stats</center></h1><p>Played: {0}</p><table border=\"0\" style=\"width:150%\">", dateTime);
            htmlString += String.Format("<tr><td valign=\"top\"><h2>SCORES</h2><a href=\"./games?player={0}\">{0}</a>: {1}<br /><a href=\"./games?player={2}\">{2}</a>: {3}<br />", p1name, p1score, p2name, p2Score);
            htmlString += String.Format("<br /><b>Time Limit: {0}</td>", timeLimit.ToString());
            htmlString += String.Format("<td valign=\"top\"><h2>GAME BOARD</h2><table bordercolor=\"lightgreen\" border=\"1\" width=\"250\" height=\"150\" style=\"text-align:center;font-size:300%;\">");
			
            // Construct the boggle board
			for (int i = 0; i < boardLetters.Length; i++ )
			{
				htmlString += "<td>" + boardLetters[i] + "</td>";
				if ((i + 1) % 4 == 0)
					htmlString += "</tr><tr>";
			}

            // Create a new html paragraph to write the 5-part game summary
            htmlString += String.Format("</table></td><td valign=\"top\"><p><h2>WORDS PLAYED</h2><u>{0} Legal Words</u><br/ >", p1name);
			
            // List words in appropriate list
            foreach (Tuple<string, int, int> word in words)
				if(word.Item2 == p1ID && word.Item3 == 1)
					htmlString += word.Item1 + " ";
            htmlString += String.Format("<br /><br /><u>{0} Legal Words</u><br />", p2name);

			foreach (Tuple<string, int, int> word in words)
				if (word.Item2 == p2ID && word.Item3 == 1)
					htmlString += word.Item1 + " ";
            htmlString += String.Format("<br /><br /><u>{0} Illegal Words</u><br />", p1name);

			foreach (Tuple<string, int, int> word in words)
				if (word.Item2 == p1ID && word.Item3 == 0)
					htmlString += word.Item1 + " ";
            htmlString += String.Format("<br /><br /><u>{0} Illegal Words</u><br />", p2name);
            
            foreach (Tuple<string, int, int> word in words)
				if (word.Item2 == p2ID && word.Item3 == 0)
					htmlString += word.Item1 + " ";
            htmlString += String.Format("<br /><br /><u>Common Words</u><br />");

			foreach (string word in common)
				htmlString += word + " ";

            // Finish the html string
            htmlString += "</p></td></tr></table><p><a href=\"./players\">Click to return to home screen</a></p></font></body></html>";

            // Send message to web server
			ss.BeginSend(htmlString + " \n", WebSendCallback, ss);
		}

		/// <summary>
		/// Builds the html string for player info page and sends it back to web browser
		/// </summary>
		private void SendPlayerInfoPage(StringSocket ss, string playerName)
		{
            // Start the html string
            string htmlString = "<!DOCTYPE html><html><body><font face=\"arial\"><div id=\"header\" style=\"background-color:indigo;color:white;text-align:center;padding=100x\"><h1><font size=\"7\">CS 3500 Boggle Game</font></h1></div><div id=\"header\" style=\"background-color:lightgreen;color:white;text-align:center;padding=100x;font-size=300%\"><font size=\"5\">Jessie Delacenserie & Camille Rasmussen</font></div><div id=\"section\" style=\"float:left;padding:10px;\">";

            int playerID;

            // List of tuples which hold the game #, date/time, opponent name, score, and opponents score
            List<Tuple<int, string, int, int, int>> games = new List<Tuple<int, string, int, int, int>>();

            // List of opponent names
            List<string> opponents = new List<string>();

			// Issue command to get info from player_info table in database
			using (MySqlConnection connection = new MySqlConnection(connectionString))
			{
				try
				{
					connection.Open();
					MySqlCommand command = connection.CreateCommand();

					command.CommandText = String.Format("SELECT count(*) FROM player_info WHERE p_name = '{0}'", playerName);

					if(Convert.ToInt32(command.ExecuteScalar()) == 0)
					{
						ss.BeginSend(String.Format("{0}<h1>Player: {1} not found</h1>\n", htmlString, playerName), WebSendCallback, ss);
						return;
					}

                    // Issue MySQL command to get player id 
					command.CommandText = String.Format("SELECT ID FROM player_info WHERE p_name = '{0}'", playerName);
					playerID = Convert.ToInt32(command.ExecuteScalar());

					// if he was player 1 in the game
					command.CommandText = String.Format("SELECT * FROM game_info WHERE player1_ID = {0}", playerID);
					MySqlDataReader Reader = command.ExecuteReader();
					while (Reader.Read())
					{
                        games.Add(Tuple.Create((int)Reader["game_ID"], (string)Reader["date_time"], (int)Reader["player2_ID"], (int)Reader["player1_score"], (int)Reader["player2_score"]));
					}
					Reader.Close();

					// if he was player 2 in the game
					command.CommandText = String.Format("SELECT * FROM game_info WHERE player2_ID = {0}", playerID);
					Reader = command.ExecuteReader();
					while (Reader.Read())
					{
                        games.Add(Tuple.Create((int)Reader["game_ID"], (string)Reader["date_time"], (int)Reader["player1_ID"], (int)Reader["player2_score"], (int)Reader["player1_score"]));
					}
					Reader.Close();

                    // get list of opponent players' names
                    foreach(Tuple<int, string, int, int, int> game in games)
                    {
                        // Get the player name from the id in the tuple
                        command.CommandText = String.Format("SELECT p_name FROM player_info WHERE ID = {0}", game.Item3);
                        string name = command.ExecuteScalar().ToString();

                        opponents.Add(name);
                    }

				}
				catch (Exception e)
				{
					Console.WriteLine("Error getting info from database " + e.ToString());
				}

				htmlString += String.Format("<center><h1>Stats for {0}</h1><table bordercolor=\"lightgreen\" border=\"1\" style=\"width:100%;text-align:center\"><tr><th>Game ID</th><th>Date/Time Played</th><th>Opponent Name</th><th>Player Score</th><th>Opponent Score</th></tr>", 
					playerName);

                // Add data to html string for each game the player played
                int oppIndex = 0;
                foreach(Tuple<int, string, int, int, int> currGame in games)
                {
                    htmlString += String.Format("<tr><td><a href=\"./game?id={5}\">{0}</a></td><td>{1}</td><td><a href=\"./games?player={2}\">{2}</a></td><td>{3}</td><td>{4}</td></tr>",
                        currGame.Item1.ToString(), currGame.Item2, opponents[oppIndex], currGame.Item4.ToString(), currGame.Item5.ToString(), currGame.Item1);
                    oppIndex++;
                }

                // Finish the string
                htmlString += "</center></table><p><a href=\"./players\">Click to return to home screen</a></p></font></body></html>";

                // Send message to the web server
                ss.BeginSend(htmlString + " \n", WebSendCallback, ss);
			}
		}

        /// <summary>
        /// PopulateDictionary -- helper method to make hashset of all words in dictionary from text file
        /// </summary>
        /// <param name="filePath"></param>
		private static void PopulateDictionary(string filePath)
		{

            // Create a new HashSet
			dictionary = new List<string>();

            // Read each line of the text
			try
			{
				using (StreamReader reader = new StreamReader(filePath))
				{
                    // One word per line, add each to the HashSet
					string line;
					while ((line = reader.ReadLine()) != null)
					{
                        line = line.Trim();
                        line = line.ToUpper();
						dictionary.Add(line);
					}
				}
			}

            // Send error message if something goes wrong
			catch (Exception e)
			{
				Console.WriteLine("Sorry, something went wrong when reading the list of words:\n" + e.Message);
			}
		}

        /// <summary>
        /// Callback to inform program when player1 has received its START message
        /// 
        /// Game can begin when both boolean are set to true
        /// </summary>
        /// <param name="e"></param>
        /// <param name="payload"></param>
		private void Player1ReadyCallback(Exception e, object payload)
		{
			p1ready = true;
		}

        /// <summary>
        /// Callback to inform program when player2 has received its START message
        /// 
        /// Game can begin when both boolean are set to true
        /// </summary>
        /// <param name="e"></param>
        /// <param name="payload"></param>
		private void Player2ReadyCallback(Exception e, object payload)
		{
			p2ready = true;
		}

        /// <summary>
        /// Helper method to wait until both players' callbacks have been invoked
        /// 
        /// Calls the CountdownTime which starts the timer for the game
        /// </summary>
        /// <param name="currentGame"></param>
		private void WaitForPlayers(Game currentGame)
		{
			while(!p1ready || !p2ready){}
			CountdownTime(currentGame);
		}

        /// <summary>
        /// CountdownTime -- helper method to run the timer for the game
        /// 
        /// Loop and update the time to both players every second
        /// Then call another method to send final messages and end the game
        /// </summary>
        /// <param name="currentGame"></param>
		private void CountdownTime(Game currentGame)
		{
            // Define player1 and player2 for the current game
            StringSocket player1 = currentGame.getP1();
            StringSocket player2 = currentGame.getP2();

			// the current time in seconds
			int t;

            // Loop and send a time update every second while time > 0
			while (currentGame.getTime() >= 0)
			{
				t = currentGame.decrementTime();
                currentGame.getP1().BeginSend("TIME " + t.ToString() + '\n', (ee, pp) => { }, null);
                currentGame.getP2().BeginSend("TIME " + t.ToString() + '\n', (ee, pp) => { }, null);
				Thread.Sleep(1000);
			}

            // When time = 0, stop accepting commands and end the game
			acceptingGameCommands = false;
            EndGame(currentGame, player1, player2);
		}

        /// <summary>
        /// ProcessPlayCommand -- helper method to handle command from client
        /// 
        /// Called when client issues a PLAY command and waits for a second player
        /// to start a new game.
        /// </summary>
        /// <param name="ss"></param>
        /// <param name="incomingCommand"></param>
        private void ProcessPlayCommand(StringSocket ss, string incomingCommand)
        {
            lock (ss)
            {
                // Save the name of the client
                string name = incomingCommand.Substring(5);

                // if there is no single socket, replace with the incoming socket
                if (singleSocket == null)
                {
                    singleSocket = Tuple.Create(ss, name);
                }

                // else, if 2 players are ready, combine the singlesocket with the incoming socket to create a new game
                else
                {
                    // Define the socket and name of both players
                    StringSocket p1ss = singleSocket.Item1;
                    StringSocket p2ss = ss;
                    string p1name = singleSocket.Item2;
                    string p2name = name;

                    // Create a new current game
                    Game currentGame;

                    // If there was no 16 letter string inputted at beginning, create a new game and beginSend to both
                    //      players without it
                    if (providedBoardLetters == null)
                    {
                        currentGame = new Game(p1ss, p2ss, p1name, p2name, gameLength);
                        p1ss.BeginSend("START " + currentGame.getBoardLetters() + ' ' + gameLength.ToString() + ' ' + currentGame.GetPlayerName(currentGame.GetPartner(p1ss)) + '\n', Player1ReadyCallback, null);
                        p2ss.BeginSend("START " + currentGame.getBoardLetters() + ' ' + gameLength.ToString() + ' ' + currentGame.GetPlayerName(currentGame.GetPartner(p2ss)) + '\n', Player2ReadyCallback, null);
                    }
                    // Else send the same message and create the same game, but include the 16 letter string specified in
                    //      original args
                    else
                    {
                        currentGame = new Game(p1ss, p2ss, p1name, p2name, gameLength, providedBoardLetters);
                        p1ss.BeginSend("START " + providedBoardLetters + " " + gameLength.ToString() + ' ' + currentGame.GetPlayerName(currentGame.GetPartner(p1ss)) + '\n', Player1ReadyCallback, null);
                        p2ss.BeginSend("START " + providedBoardLetters + " " + gameLength.ToString() + ' ' + currentGame.GetPlayerName(currentGame.GetPartner(p2ss)) + '\n', Player2ReadyCallback, null);
                    }

                    // Add the game to the list of games
                    games.Add(currentGame);

                    // Set singleSocket back to null to wait for new player
                    singleSocket = null;

                    // Wait for both players to receive START on a new thread to start the game
                    new Thread(() => WaitForPlayers(currentGame)).Start();
                }
            }
        }

        /// <summary>
        /// ProcessWordCommand -- helper method to handle a client input of a new word
        /// 
        /// Finds the current game, then validates the input word and updates the players' scores
        /// Reports the scores to the players and adds the word to the appropriate list of words within the game
        /// </summary>
        /// <param name="ss"></param>
        /// <param name="incomingWord"></param>
        private void ProcessWordCommand(StringSocket ss, string incomingWord)
        {
            // Initiate current game as null incase it does not exist
            Game currentGame = null;
            
            // Looks for current game given a string socket
			currentGame = FindCurrentGame(ss);

            // If the current game does not exist in the list of games, send IGNORING message
            if (currentGame == null)
                ss.BeginSend("IGNORING " + incomingWord + '\n', (ee, pp) => { }, null);
            
            // Else check that the word is valid and process
            else
            {
				// We make sure to lock this section of code to block other threads
				// from accessing at the same time and corrupting data
				lock (lockObj)
				{
					// format the incoming word
					string word = incomingWord.Substring(5).ToUpper().Trim();

					// bool to check if the word exists in the dictionary
					bool wordInDictionary = dictionary.Contains(word);

					// bool to check if the word is valid for the current boggle game
					bool validWord = currentGame.CanBeFormed(ss, word);

					// If word is in the dictionary and can be processed by the boggle game, update scores and add
					//      to game list
					if (word.Length > 2)
					{
                        if (validWord && wordInDictionary)
                        {
                            // Increment scores in the game
                            currentGame.IncrementScore(ss, word);

                            // Add word to list of legal words for appropriate SS
                            currentGame.AddLegalWord(ss, word);
                            SendScoreCommand(currentGame, ss);
                        }

                        // If word is not legal, add it to the appropriate socket's list of illegal words
                        else
                        {
                            currentGame.AddIllegalWord(ss, word);
                            SendScoreCommand(currentGame, ss);
                        }
					}
				}
            }
        }

		/// <summary>
		/// BeginSend the score to both clients whenever it changes. 
		/// </summary>
		/// <param name="currentGame"></param>
		/// <param name="ss"></param>
        private void SendScoreCommand(Game currentGame, StringSocket ss)
        {
            // Define player1 and get partner
            StringSocket p1 = ss;
            StringSocket p2 = currentGame.GetPartner(ss);

            // Get scores of both players
            int s1 = currentGame.GetScore(p1);
            int s2 = currentGame.GetScore(p2);

            // Send scores to each player
            p1.BeginSend("SCORE " + s1.ToString() + " " + s2.ToString() + "\n",
                (ee, pp) => { }, null);

            p2.BeginSend("SCORE " + s2.ToString() + " " + s1.ToString() + "\n",
                (ee, pp) => { }, null);
        }

		/// <summary>
		/// Find the current game we want to deal with. If there is no game associated
		/// with this socket, null is returned.
		/// </summary>
		/// <param name="current"></param>
		/// <returns></returns>
		private Game FindCurrentGame(StringSocket current)
		{
			// Looks for current game given a string socket
			foreach (Game game in games)
			{
				if (game.isCurrentGame(current))
				{
					return game;
				}
			}
			return null;
		}


        /// <summary>
        /// EndGame -- helper method to execute all final components of the game
        /// 
        /// Called when the timer reaches zero. 
        /// Sends the final score to both players.
        /// Send the lists and counts of legal, illegal and common words played to both players
        /// </summary>
        /// <param name="currentGame"></param>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        private void EndGame(Game currentGame, StringSocket player1, StringSocket player2)
        {
            // DateTime when the game ends
            DateTime endGameTime = DateTime.Now;

            // Get and send the final scores of both players
            int p1Score = currentGame.GetScore(player1);
            int p2Score = currentGame.GetScore(player2);

            player1.BeginSend("SCORE " + p1Score.ToString() + " " + p2Score.ToString() + "\n",
                                (ee, pp) => { }, null);

            player2.BeginSend("SCORE " + p2Score.ToString() + " " + p1Score.ToString() + "\n",
                (ee, pp) => { }, null);

            // Ends the current game, method which creates the necessary lists of legal/illegal/common words
            //currentGame.ResetLists();

            // Lists created in the game
            List<string> p1LegalWords = currentGame.getLegalWords(player1);
            List<string> p2LegalWords = currentGame.getLegalWords(player2);
            List<string> p1IllegalWords = currentGame.getIllegalWords(player1);
            List<string> p2IllegalWords = currentGame.getIllegalWords(player2);
            List<string> commonWords = currentGame.getCommonWords();

            // Send data to player_info table in database
            int id1 = InsertPlayerInfo(currentGame.GetPlayerName(player1), p1Score, p2Score);
            int id2 = InsertPlayerInfo(currentGame.GetPlayerName(player2), p2Score, p1Score);

            // Send data to game_info table in database
            int gameID = InsertGameInfo(id1, id2, endGameTime, currentGame.getBoardLetters(), currentGame.GetScore(player1), currentGame.GetScore(player2));
            
            // Creates a string for each list create above to be inserted in the message to be sent to each socket
            string p1Legal = "";
            foreach (string word in p1LegalWords)
            {
                p1Legal += word;
                p1Legal += " ";

                InsertWordInfo(word, gameID, id1, 1);
            }

            string p2Legal = "";
            foreach (string word in p2LegalWords)
            {
                p2Legal += word;
                p2Legal += " ";

                InsertWordInfo(word, gameID, id2, 1);
            }

            string p1Illegal = "";
            foreach (string word in p1IllegalWords)
            {
                p1Illegal += word;
                p1Illegal += " ";

                InsertWordInfo(word, gameID, id1, 0);
            }

            string p2Illegal = "";
            foreach (string word in p2IllegalWords)
            {
                p2Illegal += word;
                p2Illegal += " ";

                InsertWordInfo(word, gameID, id2, 0);
            }

            string common = "";
            foreach (string word in commonWords)
            {
                common += word;
                common += " ";

                InsertWordInfo(word, gameID, id1, 1);
                InsertWordInfo(word, gameID, id2, 1);
            }

            // BeginSend all counts and lists necessary to both players
            player1.BeginSend("STOP " + p1LegalWords.Count.ToString() + " " +
                p1Legal + p2LegalWords.Count.ToString() + " " + p2Legal + commonWords.Count.ToString()
                + " " + common + p1IllegalWords.Count.ToString() + " " + p1Illegal + p2IllegalWords.Count.ToString()
                + " " + p2Illegal + '\n', (ee, pp) => { }, null);

            player2.BeginSend("STOP " + p2LegalWords.Count.ToString() + " " +
                p2Legal + p1LegalWords.Count.ToString() + " " + p1Legal + commonWords.Count.ToString()
                + " " + common + p2IllegalWords.Count.ToString() + " " + p2Illegal + p1IllegalWords.Count.ToString()
                + " " + p1Illegal + '\n', (ee, pp) => { }, null);

            player1.Close();
            player2.Close();

        }

        /// <summary>
        /// Helper method to send data to the words_played table in the database
        /// </summary>
        /// <param name="word"></param>
        /// <param name="gameID"></param>
        /// <param name="playerID"></param>
        /// <param name="valid"></param>
        private void InsertWordInfo(string word, int gameID, int playerID, int valid)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = string.Format("INSERT INTO words_played (word, game_ID, player_ID, legal) VALUES ('{0}', {1}, {2}, {3});",
                        word, gameID, playerID, valid);

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error inserting word info to database: " + e.ToString());
                }
            }
        }

        /// <summary>
        /// Helper method to send data to the game_info table in database
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <param name="endGameTime"></param>
        /// <param name="gameBoard"></param>
        /// <param name="score1"></param>
        /// <param name="score2"></param>
        /// <returns></returns>
        private int InsertGameInfo(int id1, int id2, DateTime endGameTime, string gameBoard, int score1, int score2)
        {
            //TODO: bobby tables

            //command.Parameters.AddWithValue()

			// convert the endGameTime to a string to represent the date and time together
			string dateNtime = String.Format("{0} {1}", endGameTime.ToLongDateString(), endGameTime.ToLongTimeString());

            int gameID = -1;

            using (MySqlConnection connection= new MySqlConnection(connectionString))
            {

                try
                {
                    connection.Open();

                    MySqlCommand command = connection.CreateCommand();

                    // Define the command text to fill row with date
                    command.CommandText = string.Format("INSERT INTO game_info (player1_ID, player2_ID, date_time, board_config, time_limit, player1_score, player2_score) VALUES ({0}, {1}, '{2}', '{3}', {4}, {5}, {6});",
                        id1, id2, dateNtime, gameBoard, gameLength, score1, score2);

                    // Execute the query
                    command.ExecuteNonQuery();

                    // Define command text to retrieve most recently added ID 
                    command.CommandText = string.Format("SELECT last_insert_id();");

                    // Get game ID
                    gameID = Convert.ToInt32(command.ExecuteScalar());
                }

                catch(Exception e)
                {
                    Console.WriteLine("Error inserting game info to database: " + e.ToString());
                }
            }

            return gameID;
        }

        /// <summary>
        /// Helper method to send data to the player_info table in database
        /// </summary>
        /// <param name="name"></param>
		/// <param name="currentPlayerScore"></param>
		/// <param name="opponentScore"></param>
        /// <returns></returns>
        private int InsertPlayerInfo(string name, int currentPlayerScore, int opponentScore)
        {
            int playerID = -1;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
				// 0 = win, 1 = loss, 2 = tie;
				string outcome = "";
				if (currentPlayerScore > opponentScore)
					outcome = "wins";
				else if (currentPlayerScore < opponentScore)
					outcome = "losses";
				else
					outcome = "ties";

                try
                {
                    connection.Open();

                    MySqlCommand command = connection.CreateCommand();

					command.CommandText = String.Format("SELECT count(*) FROM player_info WHERE p_name = '{0}'", name);

					int inTable = Convert.ToInt32(command.ExecuteScalar());

					// if the username is not in the table yet, add them
					if (inTable == 0)
					{
						command.CommandText = string.Format("INSERT INTO player_info (p_name) VALUES ('{0}');", name);

						command.ExecuteNonQuery();
					}

					command.CommandText = String.Format("UPDATE player_info SET {0} = {0} + 1 WHERE p_name = '{1}'", outcome, name);
					command.ExecuteNonQuery();

					// Get the player ID
					command.CommandText = String.Format("SELECT ID FROM player_info WHERE p_name = '{0}'", name);

                    playerID = Convert.ToInt32(command.ExecuteScalar());
                }

                catch (Exception e)
                {
                    Console.WriteLine("Error inserting player info to database: " + e.ToString());
                }
            }

            // Return the player ID
            return playerID;
        }


		/// <summary>
		/// If one client drops out of the game (closes, disconnects, or becomes unresponsive)
		/// then the game is terminated and the command TERMINATED is sent to the surviving
		/// socket of that game.
		/// </summary>
		/// <param name="terminatedSocket"></param>
		public void GameTerminated(StringSocket terminatedSocket)
		{
			Game currentGame = FindCurrentGame(terminatedSocket);
			if (currentGame != null) 
			{
				StringSocket survivingSocket = currentGame.GetPartner(terminatedSocket);
				survivingSocket.BeginSend("TERMINATED\n", (ee, pp) => { }, null);
				//acceptingCommands = false;
				survivingSocket.Close();
				games.Remove(currentGame);
			}
			else
			{
				singleSocket = null;
			}
            Console.WriteLine("Sockets in this game disconnected.");
		}

		/// <summary>
		/// Used mainly for testing to close the Server. When starting this application 
		/// from command line, simply pressing enter will close the server and stop the
		/// app.
		/// </summary>
		public void StopServer()
		{
			gameServer.Stop();
		}
	}
}