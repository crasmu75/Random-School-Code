﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BoggleServerTestClient
{
	public static class BoggleClientView
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		public static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
