using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoggleClient
{
    public partial class Form1 : Form
    {
		private BoggleClientModel model;

        
		// object for locking
		private object locker;

		/// <summary>
		/// Constructor to initialize the component and set up Action events for the model.
		/// </summary>
		public Form1()
		{
			InitializeComponent();
			model = new BoggleClientModel();
            model.IncomingScoreEvent += ScoreCommand;
            model.IncomingIgnoringEvent += IgnoringCommand;
            model.IncomingStartEvent += StartCommand;
            model.IncomingTimeEvent += TimeCommand;
            model.IncomingStopEvent += StopCommand;
            model.IncomingTerminatedEvent += RestartClient;
			model.ConnectedEvent += ConnectedSuccessfully;
            model.CannotConnectEvent += ConnectionUnsuccessful;
			locker = new Object();
		}

        /// <summary>
        /// Show message to user if client cannot be connected to server
        /// </summary>
        /// <param name="obj"></param>
        private void ConnectionUnsuccessful(string obj)
        {
            MessageBox.Show("Connection failed due to error " + obj, "Connection Failure");
            RestartClient();
        }

        /// <summary>
        /// Executes when a STOP command is received marking a completed game
        /// Outputs game recap to users, closes the socket and restarts the client
        /// </summary>
        /// <param name="line"></param>
        private void StopCommand(string line)
        {
            string[] messages = line.Split(' ');
            string LegalWords1, LegalWords2, CommonWords, IllegalWords1, IllegalWords2;
            int numLegalWords1, numLegalWords2, numCommonWords, numIllegalWords1, numIllegalWords2, currentIndex;

            currentIndex = 1;

            numLegalWords1 = Convert.ToInt32(messages[currentIndex]);
            currentIndex++;

            LegalWords1 = GetListOfWords(currentIndex, numLegalWords1, messages);
            currentIndex += numLegalWords1;

            numLegalWords2 = Convert.ToInt32(messages[currentIndex]);
            currentIndex++;

            LegalWords2 = GetListOfWords(currentIndex, numLegalWords2, messages);
            currentIndex += numLegalWords2;

            numCommonWords = Convert.ToInt32(messages[currentIndex]);
            currentIndex++;

            CommonWords = GetListOfWords(currentIndex, numCommonWords, messages);
            currentIndex += numCommonWords;

            numIllegalWords1 = Convert.ToInt32(messages[currentIndex]);
            currentIndex++;

            IllegalWords1 = GetListOfWords(currentIndex, numIllegalWords1, messages);
            currentIndex += numIllegalWords1;

            numIllegalWords2 = Convert.ToInt32(messages[currentIndex]);
            currentIndex++;

            IllegalWords2 = GetListOfWords(currentIndex, numIllegalWords2, messages);
            currentIndex += numIllegalWords2;

            MessageBox.Show("You played " + numLegalWords1.ToString() + " legal words:\n" + LegalWords1 + "\n\nYour opponent played " + numLegalWords2.ToString() +
                    " legal words:\n" + LegalWords2 + "\n\nYou played " + numCommonWords.ToString() + " of the same words:\n" + CommonWords +
                    "\n\nYou played " + numIllegalWords1.ToString() + " illegal words:\n" + IllegalWords1 + "\n\nYour opponent played " + numIllegalWords2 + " illegal words:\n"
                    + IllegalWords2, "GAME OVER!");

            model.CloseSocket();
            RestartClient();
        }

        /// <summary>
        /// Executed when a TIME command is received
        /// Updates timer on boggle board
        /// Time becomes red when less than 10 seconds remain for convenience
        /// </summary>
        /// <param name="line"></param>
        private void TimeCommand(string line)
        {
            int timeLeft = Convert.ToInt32(line.Substring(5));
            TimeLabel.Invoke(new Action(() =>
            {
                TimeLabel.Text = timeLeft.ToString();
                if (timeLeft == 10)
                    TimeLabel.ForeColor = Color.Red;
            }));
        }

        /// <summary>
        /// Executed when a START command is received
        /// </summary>
        /// <param name="line"></param>
        private void StartCommand(string line)
        {
            string[] startParams = line.Split(' ');
            SetBoggleLetters(startParams[1]);
            TimeLabel.Invoke(new Action(() =>
                {
                    TimeLabel.Text = startParams[2];
                    Player2.Text = startParams[3];
					PlayWordButton.Enabled = true;
                    StatusButton.Text = "EXIT GAME";
                    WordEnteredBox.Enabled = true;
                    Player1Score.Text = "0";
                    Player2Score.Text = "0";
                }));
        }

        /// <summary>
        /// Shows a message box to the user when the client has sent an illegal message to the server
        /// </summary>
        /// <param name="line"></param>
        private void IgnoringCommand(string line)
        {
            MessageBox.Show("Client sent illegal command to server: " + line.Substring(9));
        }

        /// <summary>
        /// Executed when a SCORE command is received to update the score of both players
        /// </summary>
        /// <param name="line"></param>
        private void ScoreCommand(string line)
        {
            string[] scores = line.Split(' ');
            Player1Score.Invoke(new Action(() =>
            {
                Player1Score.Text = scores[1];
                Player2Score.Text = scores[2];
            }));
        }

		/// <summary>
		/// Called using the Actions from model when we are successfully connected 
		/// to the server. 
		/// </summary>
		private void ConnectedSuccessfully()
        {
            StatusButton.Invoke(new Action(() =>
            {
                StatusButton.Text = "CANCEL";
                StatusButton.BackColor = Color.Red;
            }));
        }

        /// <summary>
        /// Create the boggle playing board on the GUI by putting all 16 letters in their respective boxes
        /// </summary>
        /// <param name="s"></param>
        private void SetBoggleLetters(string s)
        {
            char[] chars = s.ToCharArray();
            string[] strings = new string[16];
            int pos = 0;

            foreach(char c in chars)
            {
                if (c.Equals('Q'))
                    strings[pos] = c.ToString() + "u";
                else
                    strings[pos] = c.ToString();

                pos++;
            }

            Letter1.Invoke(new Action(() =>
                {
                    Letter1.Text = strings[0];
                    Letter2.Text = strings[1];
                    Letter3.Text = strings[2];
                    Letter4.Text = strings[3];
                    Letter5.Text = strings[4];
                    Letter6.Text = strings[5];
                    Letter7.Text = strings[6];
                    Letter8.Text = strings[7];
                    Letter9.Text = strings[8];
                    Letter10.Text = strings[9];
                    Letter11.Text = strings[10];
                    Letter12.Text = strings[11];
                    Letter13.Text = strings[12];
                    Letter14.Text = strings[13];
                    Letter15.Text = strings[14];
                    Letter16.Text = strings[15];
                }));
        }

		/// <summary>
		/// This method is called when the user clicks on the status button. Depending
		/// on what text is inside the button, different events are handled.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void StatusButton_Click(object sender, EventArgs e)
        {
			// user hasn't connected to server yet, do so
            if (StatusButton.Text == "CONNECT")
            {
                if (IPAddressBox.Text == "" || NameTextBox.Text == "")
                    MessageBox.Show("IP Address and Name fields cannot be empty to connect. Try Again!");
                else
                {
                    model.Connect(IPAddressBox.Text, 2000, NameTextBox.Text);
                    Player1.Text = NameTextBox.Text;
					IPAddressBox.Enabled = false;
					NameTextBox.Enabled = false;
                }
            }

			// user has connected to the server, wants to cancel on waiting for game
                // or user has started game with opponent and wants to exit before game ends
            else if (StatusButton.Text == "CANCEL" || StatusButton.Text == "EXIT GAME")
            {
                model.CloseSocket();
                RestartClient();
            }
        }

        /// <summary>
        /// Helper method to split up incoming words sent with the STOP command
        /// Returns a list 'n' words starting at the specified index of the incoming array of words
        /// </summary>
        /// <param name="index"></param>
        /// <param name="n"></param>
        /// <param name="messages"></param>
        /// <returns></returns>
        private string GetListOfWords(int index, int n, string[] messages)
        {
            string toReturn = "";
            for (int i = index; i < index+n; i++)
            {
                toReturn += messages[i];
                toReturn += " ";
            }

            return toReturn;
        }

        /// <summary>
        /// Click event for the "Play word button"
        /// Sends the word typed in the play box to the socket to be scored
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void PlayWordButton_Click(object sender, EventArgs e)
		{
			if (WordEnteredBox.Text != "")
			{
				model.SendMessage("WORD " + WordEnteredBox.Text);
				WordEnteredBox.Text = "";
			}
		}

        /// <summary>
        /// Called when client needs to be restarted 
        /// </summary>
        private void RestartClient()
        {
            IPAddressBox.Invoke(new Action(() =>
                {
                    IPAddressBox.Text = "";
                    NameTextBox.Text = "";
                    IPAddressBox.Enabled = true;
                    NameTextBox.Enabled = true;
                    StatusButton.Text = "CONNECT";
                    StatusButton.BackColor = Color.Lime;
                    PlayWordButton.Enabled = false;
                    WordEnteredBox.Text = "";
                    WordEnteredBox.Enabled = false;
                    Player1.Text = "Player 1";
                    Player2.Text = "Player 2";
                    Player1Score.Text = "";
                    Player2Score.Text = "";
                    TimeLabel.ForeColor = Color.Black;
                    TimeLabel.Text = "";
                }));
            SetBoggleLetters("                ");
        }
    }
}
