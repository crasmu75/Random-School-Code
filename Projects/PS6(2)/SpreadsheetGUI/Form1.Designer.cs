﻿namespace SpreadsheetGUI
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
			this.menuChoiceNew = new System.Windows.Forms.ToolStripMenuItem();
			this.menuChoiceSave = new System.Windows.Forms.ToolStripMenuItem();
			this.menuChoiceOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.menuChoiceClose = new System.Windows.Forms.ToolStripMenuItem();
			this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.menuChoiceInstructions = new System.Windows.Forms.ToolStripMenuItem();
			this.menuChoiceAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.labelCellName = new System.Windows.Forms.Label();
			this.textBoxCellName = new System.Windows.Forms.TextBox();
			this.spreadsheetPanel = new SS.SpreadsheetPanel();
			this.labelValue = new System.Windows.Forms.Label();
			this.textBoxValue = new System.Windows.Forms.TextBox();
			this.labelContents = new System.Windows.Forms.Label();
			this.textBoxContents = new System.Windows.Forms.TextBox();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.buttonUpdateContents = new System.Windows.Forms.Button();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.comboBoxColors = new System.Windows.Forms.ComboBox();
			this.labelBorderColor = new System.Windows.Forms.Label();
			this.menuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuHelp});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(1275, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "menuStrip1";
			// 
			// menuFile
			// 
			this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuChoiceNew,
            this.menuChoiceSave,
            this.menuChoiceOpen,
            this.menuChoiceClose});
			this.menuFile.Name = "menuFile";
			this.menuFile.Size = new System.Drawing.Size(37, 20);
			this.menuFile.Text = "File";
			// 
			// menuChoiceNew
			// 
			this.menuChoiceNew.Name = "menuChoiceNew";
			this.menuChoiceNew.Size = new System.Drawing.Size(103, 22);
			this.menuChoiceNew.Text = "New";
			this.menuChoiceNew.Click += new System.EventHandler(this.menuChoiceNew_Click);
			// 
			// menuChoiceSave
			// 
			this.menuChoiceSave.Name = "menuChoiceSave";
			this.menuChoiceSave.Size = new System.Drawing.Size(103, 22);
			this.menuChoiceSave.Text = "Save";
			this.menuChoiceSave.Click += new System.EventHandler(this.menuChoiceSave_Click);
			// 
			// menuChoiceOpen
			// 
			this.menuChoiceOpen.Name = "menuChoiceOpen";
			this.menuChoiceOpen.Size = new System.Drawing.Size(103, 22);
			this.menuChoiceOpen.Text = "Open";
			this.menuChoiceOpen.Click += new System.EventHandler(this.menuChoiceOpen_Click);
			// 
			// menuChoiceClose
			// 
			this.menuChoiceClose.Name = "menuChoiceClose";
			this.menuChoiceClose.Size = new System.Drawing.Size(103, 22);
			this.menuChoiceClose.Text = "Close";
			this.menuChoiceClose.Click += new System.EventHandler(this.menuChoiceClose_Click);
			// 
			// menuHelp
			// 
			this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuChoiceInstructions,
            this.menuChoiceAbout});
			this.menuHelp.Name = "menuHelp";
			this.menuHelp.Size = new System.Drawing.Size(44, 20);
			this.menuHelp.Text = "Help";
			// 
			// menuChoiceInstructions
			// 
			this.menuChoiceInstructions.Name = "menuChoiceInstructions";
			this.menuChoiceInstructions.Size = new System.Drawing.Size(136, 22);
			this.menuChoiceInstructions.Text = "Instructions";
			this.menuChoiceInstructions.Click += new System.EventHandler(this.menuChoiceInstructions_Click);
			// 
			// menuChoiceAbout
			// 
			this.menuChoiceAbout.Name = "menuChoiceAbout";
			this.menuChoiceAbout.Size = new System.Drawing.Size(136, 22);
			this.menuChoiceAbout.Text = "About";
			this.menuChoiceAbout.Click += new System.EventHandler(this.menuChoiceAbout_Click);
			// 
			// labelCellName
			// 
			this.labelCellName.AutoSize = true;
			this.labelCellName.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelCellName.Font = new System.Drawing.Font("Segoe Print", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelCellName.Location = new System.Drawing.Point(0, 24);
			this.labelCellName.Name = "labelCellName";
			this.labelCellName.Size = new System.Drawing.Size(192, 31);
			this.labelCellName.TabIndex = 1;
			this.labelCellName.Text = "Selected Cell Name:";
			// 
			// textBoxCellName
			// 
			this.textBoxCellName.Enabled = false;
			this.textBoxCellName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxCellName.Location = new System.Drawing.Point(189, 29);
			this.textBoxCellName.Name = "textBoxCellName";
			this.textBoxCellName.ReadOnly = true;
			this.textBoxCellName.Size = new System.Drawing.Size(63, 20);
			this.textBoxCellName.TabIndex = 2;
			this.textBoxCellName.Text = "A1";
			this.textBoxCellName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// spreadsheetPanel
			// 
			this.spreadsheetPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.spreadsheetPanel.Location = new System.Drawing.Point(0, 55);
			this.spreadsheetPanel.Name = "spreadsheetPanel";
			this.spreadsheetPanel.Size = new System.Drawing.Size(1275, 599);
			this.spreadsheetPanel.TabIndex = 3;
			// 
			// labelValue
			// 
			this.labelValue.AutoSize = true;
			this.labelValue.Font = new System.Drawing.Font("Segoe Print", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelValue.Location = new System.Drawing.Point(271, 24);
			this.labelValue.Name = "labelValue";
			this.labelValue.Size = new System.Drawing.Size(68, 31);
			this.labelValue.TabIndex = 4;
			this.labelValue.Text = "Value:";
			// 
			// textBoxValue
			// 
			this.textBoxValue.Enabled = false;
			this.textBoxValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxValue.Location = new System.Drawing.Point(336, 29);
			this.textBoxValue.Name = "textBoxValue";
			this.textBoxValue.ReadOnly = true;
			this.textBoxValue.Size = new System.Drawing.Size(217, 20);
			this.textBoxValue.TabIndex = 5;
			this.textBoxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// labelContents
			// 
			this.labelContents.AutoSize = true;
			this.labelContents.Font = new System.Drawing.Font("Segoe Print", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelContents.Location = new System.Drawing.Point(574, 24);
			this.labelContents.Name = "labelContents";
			this.labelContents.Size = new System.Drawing.Size(99, 31);
			this.labelContents.TabIndex = 6;
			this.labelContents.Text = "Contents:";
			// 
			// textBoxContents
			// 
			this.textBoxContents.Location = new System.Drawing.Point(670, 29);
			this.textBoxContents.Name = "textBoxContents";
			this.textBoxContents.Size = new System.Drawing.Size(230, 20);
			this.textBoxContents.TabIndex = 7;
			this.textBoxContents.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// buttonUpdateContents
			// 
			this.buttonUpdateContents.Location = new System.Drawing.Point(906, 27);
			this.buttonUpdateContents.Name = "buttonUpdateContents";
			this.buttonUpdateContents.Size = new System.Drawing.Size(106, 23);
			this.buttonUpdateContents.TabIndex = 8;
			this.buttonUpdateContents.Text = "Update Contents";
			this.buttonUpdateContents.UseVisualStyleBackColor = true;
			this.buttonUpdateContents.Click += new System.EventHandler(this.buttonUpdateContents_Click);
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.FileName = "Untitled1.sprd";
			// 
			// comboBoxColors
			// 
			this.comboBoxColors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxColors.FormattingEnabled = true;
			this.comboBoxColors.Items.AddRange(new object[] {
            "blue",
            "gray",
            "yellow",
            "lime",
            "pink"});
			this.comboBoxColors.Location = new System.Drawing.Point(1174, 29);
			this.comboBoxColors.Name = "comboBoxColors";
			this.comboBoxColors.Size = new System.Drawing.Size(80, 21);
			this.comboBoxColors.TabIndex = 9;
			this.comboBoxColors.SelectedIndexChanged += new System.EventHandler(this.comboBoxColors_SelectedIndexChanged);
			// 
			// labelBorderColor
			// 
			this.labelBorderColor.AutoSize = true;
			this.labelBorderColor.Font = new System.Drawing.Font("Buxton Sketch", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelBorderColor.Location = new System.Drawing.Point(1084, 32);
			this.labelBorderColor.Name = "labelBorderColor";
			this.labelBorderColor.Size = new System.Drawing.Size(84, 17);
			this.labelBorderColor.TabIndex = 10;
			this.labelBorderColor.Text = "Border Color :)";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1275, 654);
			this.Controls.Add(this.comboBoxColors);
			this.Controls.Add(this.labelBorderColor);
			this.Controls.Add(this.buttonUpdateContents);
			this.Controls.Add(this.textBoxContents);
			this.Controls.Add(this.labelContents);
			this.Controls.Add(this.textBoxValue);
			this.Controls.Add(this.labelValue);
			this.Controls.Add(this.spreadsheetPanel);
			this.Controls.Add(this.textBoxCellName);
			this.Controls.Add(this.labelCellName);
			this.Controls.Add(this.menuStrip);
			this.MainMenuStrip = this.menuStrip;
			this.Name = "Form1";
			this.Text = "Spreadsheet Application";
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem menuFile;
		private System.Windows.Forms.ToolStripMenuItem menuChoiceNew;
		private System.Windows.Forms.ToolStripMenuItem menuChoiceSave;
		private System.Windows.Forms.ToolStripMenuItem menuChoiceOpen;
		private System.Windows.Forms.ToolStripMenuItem menuChoiceClose;
		private System.Windows.Forms.ToolStripMenuItem menuHelp;
		private System.Windows.Forms.ToolStripMenuItem menuChoiceInstructions;
		private System.Windows.Forms.Label labelCellName;
		private System.Windows.Forms.TextBox textBoxCellName;
		private SS.SpreadsheetPanel spreadsheetPanel;
		private System.Windows.Forms.Label labelValue;
		private System.Windows.Forms.TextBox textBoxValue;
		private System.Windows.Forms.Label labelContents;
		private System.Windows.Forms.TextBox textBoxContents;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.Button buttonUpdateContents;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.ToolStripMenuItem menuChoiceAbout;
		private System.Windows.Forms.ComboBox comboBoxColors;
		private System.Windows.Forms.Label labelBorderColor;
	}
}

