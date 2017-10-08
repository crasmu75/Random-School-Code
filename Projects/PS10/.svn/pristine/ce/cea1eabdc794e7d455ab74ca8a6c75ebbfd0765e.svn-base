// Authors: Camille Rasmussen & Jessie Delacenserie
// Class: CS 3500, fall 2014
// PS9 -- Boggle Client Test

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoggleClient;
using System.Threading;

namespace BoggleClientTest
{
	[TestClass]
	public class TestCannotConnectEvent
	{
        /// <summary>
        /// String to hold the expected string value
        /// </summary>
		string expected = "";

        /// <summary>
        /// String to hold the actual string value
        /// </summary>
		string actual = "";

        /// <summary>
        /// Manual Reset Event used for tests
        /// </summary>
		ManualResetEvent mre1;

        /// <summary>
        /// Method to test if a connection cannot be made
        /// </summary>
		[TestMethod]
		public void TestCannotConnectEvent1()
		{
			expected = "System.Net.Sockets.SocketException";

			mre1 = new ManualResetEvent(false);

			BoggleClientModel model = new BoggleClientModel();

			model.CannotConnectEvent += CannotConnectEvent;

			model.Connect("localhost", 2000, "player1");

			mre1.WaitOne();
			// the true here means we ignore case just like our model and view
			Assert.AreEqual(expected, actual, true);

			model.CloseSocket();
		}

		public void CannotConnectEvent(string line)
		{
			actual = line.Substring(0, 34);
			mre1.Set();
		}
	}

	[TestClass]
	public class TestConnectEvent
	{
        /// <summary>
        /// String containing the board letters
        /// </summary>
		string boggleBoardLetters = "AAPOERDSRAVSKEOK";

        /// <summary>
        /// Manual Reset Event used for tests
        /// </summary>
		ManualResetEvent mre1;

        /// <summary>
        /// Test that a connection can be made
        /// </summary>
		[TestMethod]
		public void TestConnectEvent1()
		{
			mre1 = new ManualResetEvent(false);

			BoggleServer.BoggleServer server = new BoggleServer.BoggleServer(2000, 60, @"..\..\..\Resources\dictionary.txt", boggleBoardLetters);
			BoggleClientModel model = new BoggleClientModel();

			model.ConnectedEvent += ConnectCommand;

			model.Connect("localhost", 2000, "player1");

			// wait for the Event to happen
			mre1.WaitOne();
			// then pass the test
			Assert.IsTrue(true);

			model.CloseSocket();
			server.StopServer();
		}

		public void ConnectCommand()
		{
			mre1.Set();
		}
	}

    [TestClass]
    public class TestStartEvent
    {
        string boggleBoardLetters = "AAPOERDSRAVSKEOK";
		string expected1 = "";
		string expected2 = "";
		string actual1 = "";
		string actual2 = "";

		ManualResetEvent mre1;
		ManualResetEvent mre2;


        /// <summary>
        /// Test the start event
        /// </summary>
        [TestMethod]
        public void TestStartEvent1()
        {
			expected1 = "START " + boggleBoardLetters + " 60 player2";
			expected2 = "START " + boggleBoardLetters + " 60 player1";

			mre1 = new ManualResetEvent(false);
			mre2 = new ManualResetEvent(false);

            BoggleServer.BoggleServer server = new BoggleServer.BoggleServer(2000, 60, @"..\..\..\Resources\dictionary.txt", boggleBoardLetters);
            BoggleClientModel model = new BoggleClientModel();
            BoggleClientModel model2 = new BoggleClientModel();

            model.Connect("localhost", 2000, "player1");
            model2.Connect("localhost", 2000, "player2");

			model.IncomingStartEvent += StartCommand;
			model2.IncomingStartEvent += StartCommand2;

            model.SendMessage("PLAY player1");
            model2.SendMessage("PLAY player2");

			mre1.WaitOne();
			// the true here means we ignore case just like our model and view
			Assert.AreEqual(expected1, actual1, true);
			mre2.WaitOne();
			Assert.AreEqual(expected2, actual2, true);

            model.CloseSocket();
            model2.CloseSocket();

            server.StopServer();
        }

        public void StartCommand(string line)
        {
			actual1 = line;
			mre1.Set();
        }

        public void StartCommand2(string line)
        {
			actual2 = line;
			mre2.Set();
        }
	}

	[TestClass]
	public class TestTimeEvent
	{
		string boggleBoardLetters = "AAPOERDSRAVSKEOK";

		string actual1 = "";
		string actual2 = "";

		ManualResetEvent mre1;
		ManualResetEvent mre2;

        /// <summary>
        /// Test the time event
        /// </summary>
        [TestMethod]
        public void TestTimeEvent1()
        {
			mre1 = new ManualResetEvent(false);
			mre2 = new ManualResetEvent(false);

            BoggleServer.BoggleServer server = new BoggleServer.BoggleServer(2000, 5, @"..\..\..\Resources\dictionary.txt", boggleBoardLetters);
            BoggleClientModel model = new BoggleClientModel();
            BoggleClientModel model2 = new BoggleClientModel();

            model.Connect("localhost", 2000, "player1");
            model2.Connect("localhost", 2000, "player2");

			model.IncomingStartEvent += Start;
			model2.IncomingStartEvent += Start;
			model.IncomingTimeEvent += TimeCommand;
			model2.IncomingTimeEvent += TimeCommand2;

            model.SendMessage("PLAY player1");
            model2.SendMessage("PLAY player2");

			mre1.WaitOne();
			Assert.AreEqual("TIME 5", actual1);

			mre2.WaitOne();
			mre2.Reset();
			Assert.AreEqual("TIME 5", actual2);

			// make sure time goes down correctly
			mre2.WaitOne();
			Assert.AreEqual("TIME 4", actual2);

            model.CloseSocket();
            model2.CloseSocket();

            server.StopServer();
        }

		public void Start(string line){}

        public void TimeCommand(string line)
        {
			actual1 = line;
			mre1.Set();
        }

        public void TimeCommand2(string line)
        {
			actual2 = line;
			mre2.Set();
        }
	}

	[TestClass]
	public class TestScoreEvent
	{
		string boggleBoardLetters = "AAPOERDSRAVSKEOK";
		string expected1 = "";
		string expected2 = "";
		string actual1 = "";
		string actual2 = "";

		ManualResetEvent mre1;
		ManualResetEvent mre2;

        /// <summary>
        /// Test a score event
        /// </summary>
        [TestMethod]
        public void TestScoreEvent1()
        {
			expected1 = "SCORE 11 0";
			expected2 = "SCORE 0 11";

			mre1 = new ManualResetEvent(false);
			mre2 = new ManualResetEvent(false);

            BoggleServer.BoggleServer server = new BoggleServer.BoggleServer(2000, 5, @"..\..\..\Resources\dictionary.txt", boggleBoardLetters);
            BoggleClientModel model = new BoggleClientModel();
            BoggleClientModel model2 = new BoggleClientModel();

            model.Connect("localhost", 2000, "player1");
            model2.Connect("localhost", 2000, "player2");

			model.IncomingStartEvent += Start;
			model2.IncomingStartEvent += Start;
			model.IncomingTimeEvent += Time;
			model2.IncomingTimeEvent += Time;
			model.IncomingScoreEvent += ScoreCommand;
			model2.IncomingScoreEvent += ScoreCommand2;

            model.SendMessage("PLAY player1");
            model2.SendMessage("PLAY player2");

            model.SendMessage("WORD aardvark");

			mre1.WaitOne();
			Assert.AreEqual(expected1, actual1, true);
			mre2.WaitOne();
			Assert.AreEqual(expected2, actual2, true);

            model.CloseSocket();
            model2.CloseSocket();

            server.StopServer();
        }

		public void Start(string line){}
		public void Time(string line){}

        public void ScoreCommand(string line)
        {
			actual1 = line;
			mre1.Set();
        }

        public void ScoreCommand2(string line)
        {
			actual2 = line;
			mre2.Set();
        }
	}

	[TestClass]
	public class TestIgnoringEvent
	{
		string boggleBoardLetters = "AAPOERDSRAVSKEOK";

		string actual = "";

		ManualResetEvent mre1;

        /// <summary>
        /// Test an ignoring event
        /// </summary>
        [TestMethod]
        public void TestIgnoringEvent1()
        {
			mre1 = new ManualResetEvent(false);

            BoggleServer.BoggleServer server = new BoggleServer.BoggleServer(2000, 5, @"..\..\..\Resources\dictionary.txt", boggleBoardLetters);
            BoggleClientModel model = new BoggleClientModel();

            model.Connect("localhost", 2000, "player1");

			model.IncomingIgnoringEvent += IgnoringCommand;

            model.SendMessage("hello");

			mre1.WaitOne();
			Assert.AreEqual("IGNORING hello", actual, true);

            model.CloseSocket();

            server.StopServer();
        }

        public void IgnoringCommand(string line)
        {
			actual = line;
			mre1.Set();
        }
	}

	[TestClass]
	public class TestTerminatedEvent
	{
		string boggleBoardLetters = "AAPOERDSRAVSKEOK";

		ManualResetEvent mre1;

        /// <summary>
        /// Test an ignoring command
        /// </summary>
        [TestMethod]
        public void TestTerminatedEvent1()
        {
			mre1 = new ManualResetEvent(false);

            BoggleServer.BoggleServer server = new BoggleServer.BoggleServer(2000, 5, @"..\..\..\Resources\dictionary.txt", boggleBoardLetters);
            BoggleClientModel model = new BoggleClientModel();
            BoggleClientModel model2 = new BoggleClientModel();

            model.Connect("localhost", 2000, "player1");
            model2.Connect("localhost", 2000, "player2");

			model.IncomingStartEvent += Start;
			model2.IncomingStartEvent += Start;
			model.IncomingTimeEvent += Time;
			model2.IncomingTimeEvent += Time;
			model.IncomingTerminatedEvent += TerminatedCommand;

            model.SendMessage("PLAY player1");
            model2.SendMessage("PLAY player2");
            
            model2.CloseSocket();
			mre1.WaitOne();
			Assert.IsTrue(true);

            server.StopServer();
        }

		public void Start(string line) { }
		public void Time(string line) { }

        /// <summary>
        /// Assert that the action occurs
        /// </summary>
        public void TerminatedCommand()
        {
			mre1.Set();
        }
	}

	[TestClass]
	public class TestStopEvent
	{
		string boggleBoardLetters = "AAPOERDSRAVSKEOK";

		string expected1 = "STOP 1 spare 2 read reads 1 soaker 1 hello 0";
		string expected2 = "STOP 2 read reads 1 spare 1 soaker 0 1 hello";
		string actual1 = "";
		string actual2 = "";

		ManualResetEvent mre1;
		ManualResetEvent mre2;

        /// <summary>
        /// Test a stop event
        /// </summary>
        [TestMethod]
        public void TestStopEvent1()
        {
			mre1 = new ManualResetEvent(false);
			mre2 = new ManualResetEvent(false);

            BoggleServer.BoggleServer server = new BoggleServer.BoggleServer(2000, 5, @"..\..\..\Resources\dictionary.txt", boggleBoardLetters);
            BoggleClientModel model = new BoggleClientModel();
            BoggleClientModel model2 = new BoggleClientModel();

            model.Connect("localhost", 2000, "player1");
            model2.Connect("localhost", 2000, "player2");

			model.IncomingStartEvent += Start;
			model2.IncomingStartEvent += Start;
			model.IncomingTimeEvent += Time;
			model2.IncomingTimeEvent += Time;
			model.IncomingScoreEvent += Score;
			model2.IncomingScoreEvent += Score;
			model.IncomingStopEvent += StopCommand;
            model2.IncomingStopEvent += StopCommand2;

            model.SendMessage("PLAY player1");
            model2.SendMessage("PLAY player2");

            model.SendMessage("WORD spare");
            model2.SendMessage("WORD read");
            model.SendMessage("WORD hello");
            model2.SendMessage("WORD soaker");
            model.SendMessage("WORD soaker");
            model2.SendMessage("WORD reads");

			mre1.WaitOne();
			Assert.AreEqual(expected1, actual1, true);
			mre2.WaitOne();
			Assert.AreEqual(expected2, actual2, true);

            model.CloseSocket();
            model2.CloseSocket();

            server.StopServer();
        }

		public void Start(string line) { }
		public void Time(string line) { }
		public void Score(string line) { }

        public void StopCommand(string line)
        {
			actual1 = line;
			mre1.Set();
        }

        public void StopCommand2(string line)
        {
			actual2 = line;
			mre2.Set();
        }
    }
}
