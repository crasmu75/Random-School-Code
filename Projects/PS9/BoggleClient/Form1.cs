﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoggleClient
{
    public partial class Form1 : Form
    {
		private BoggleClientModel model;

		public Form1()
		{
			InitializeComponent();
			model = new BoggleClientModel();
			model.IncomingLineEvent += MessageReceived;
			model.ConnectEvent += ChangeStatusButton;
		}

		// add click methods here

		private void MessageReceived(String line)
		{
			// what to do when we receive a message from server
		}

		private void ChangeStatusButton()
		{
			ReadyButton.Text = "WAITING...";
		}
    }
}
