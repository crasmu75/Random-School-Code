﻿namespace BoggleClient
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
<<<<<<< .mine
			this.Label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.IPAddressBox = new System.Windows.Forms.TextBox();
			this.NameTextBox = new System.Windows.Forms.TextBox();
			this.ReadyButton = new System.Windows.Forms.Button();
			this.Letter1 = new System.Windows.Forms.TextBox();
			this.Letter2 = new System.Windows.Forms.TextBox();
			this.Letter3 = new System.Windows.Forms.TextBox();
			this.Letter4 = new System.Windows.Forms.TextBox();
			this.Letter5 = new System.Windows.Forms.TextBox();
			this.Letter6 = new System.Windows.Forms.TextBox();
			this.Letter7 = new System.Windows.Forms.TextBox();
			this.Letter8 = new System.Windows.Forms.TextBox();
			this.Letter9 = new System.Windows.Forms.TextBox();
			this.Letter10 = new System.Windows.Forms.TextBox();
			this.Letter11 = new System.Windows.Forms.TextBox();
			this.Letter12 = new System.Windows.Forms.TextBox();
			this.Letter13 = new System.Windows.Forms.TextBox();
			this.Letter14 = new System.Windows.Forms.TextBox();
			this.Letter15 = new System.Windows.Forms.TextBox();
			this.Letter16 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.Player1Score = new System.Windows.Forms.TextBox();
			this.Player2Score = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.WordEnteredBox = new System.Windows.Forms.TextBox();
			this.PlayWordButton = new System.Windows.Forms.Button();
			this.TimeLabel = new System.Windows.Forms.Label();
			this.seconds = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.Location = new System.Drawing.Point(17, 26);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(80, 17);
			this.Label1.TabIndex = 0;
			this.Label1.Text = "IP Address:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(218, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "Name:";
			// 
			// IPAddressBox
			// 
			this.IPAddressBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IPAddressBox.Location = new System.Drawing.Point(100, 23);
			this.IPAddressBox.Name = "IPAddressBox";
			this.IPAddressBox.Size = new System.Drawing.Size(112, 23);
			this.IPAddressBox.TabIndex = 2;
			// 
			// NameTextBox
			// 
			this.NameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NameTextBox.Location = new System.Drawing.Point(273, 23);
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.Size = new System.Drawing.Size(112, 23);
			this.NameTextBox.TabIndex = 3;
			// 
			// ReadyButton
			// 
			this.ReadyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.ReadyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ReadyButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.ReadyButton.Location = new System.Drawing.Point(428, 10);
			this.ReadyButton.Name = "ReadyButton";
			this.ReadyButton.Size = new System.Drawing.Size(143, 53);
			this.ReadyButton.TabIndex = 4;
			this.ReadyButton.Text = "CONNECT";
			this.ReadyButton.UseVisualStyleBackColor = false;
			// 
			// Letter1
			// 
			this.Letter1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Letter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Letter1.Location = new System.Drawing.Point(20, 79);
			this.Letter1.Multiline = true;
			this.Letter1.Name = "Letter1";
			this.Letter1.ReadOnly = true;
			this.Letter1.Size = new System.Drawing.Size(66, 62);
			this.Letter1.TabIndex = 5;
			this.Letter1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Letter2
			// 
			this.Letter2.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Letter2.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Letter2.Location = new System.Drawing.Point(92, 79);
			this.Letter2.Multiline = true;
			this.Letter2.Name = "Letter2";
			this.Letter2.ReadOnly = true;
			this.Letter2.Size = new System.Drawing.Size(66, 62);
			this.Letter2.TabIndex = 6;
			this.Letter2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Letter3
			// 
			this.Letter3.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Letter3.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Letter3.Location = new System.Drawing.Point(164, 79);
			this.Letter3.Multiline = true;
			this.Letter3.Name = "Letter3";
			this.Letter3.ReadOnly = true;
			this.Letter3.Size = new System.Drawing.Size(66, 62);
			this.Letter3.TabIndex = 7;
			this.Letter3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Letter4
			// 
			this.Letter4.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Letter4.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Letter4.Location = new System.Drawing.Point(236, 79);
			this.Letter4.Multiline = true;
			this.Letter4.Name = "Letter4";
			this.Letter4.ReadOnly = true;
			this.Letter4.Size = new System.Drawing.Size(66, 62);
			this.Letter4.TabIndex = 8;
			this.Letter4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Letter5
			// 
			this.Letter5.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Letter5.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Letter5.Location = new System.Drawing.Point(20, 147);
			this.Letter5.Multiline = true;
			this.Letter5.Name = "Letter5";
			this.Letter5.ReadOnly = true;
			this.Letter5.Size = new System.Drawing.Size(66, 62);
			this.Letter5.TabIndex = 9;
			this.Letter5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Letter6
			// 
			this.Letter6.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Letter6.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Letter6.Location = new System.Drawing.Point(92, 147);
			this.Letter6.Multiline = true;
			this.Letter6.Name = "Letter6";
			this.Letter6.ReadOnly = true;
			this.Letter6.Size = new System.Drawing.Size(66, 62);
			this.Letter6.TabIndex = 10;
			this.Letter6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Letter7
			// 
			this.Letter7.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Letter7.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Letter7.Location = new System.Drawing.Point(164, 147);
			this.Letter7.Multiline = true;
			this.Letter7.Name = "Letter7";
			this.Letter7.ReadOnly = true;
			this.Letter7.Size = new System.Drawing.Size(66, 62);
			this.Letter7.TabIndex = 11;
			this.Letter7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Letter8
			// 
			this.Letter8.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Letter8.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Letter8.Location = new System.Drawing.Point(236, 147);
			this.Letter8.Multiline = true;
			this.Letter8.Name = "Letter8";
			this.Letter8.ReadOnly = true;
			this.Letter8.Size = new System.Drawing.Size(66, 62);
			this.Letter8.TabIndex = 12;
			this.Letter8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Letter9
			// 
			this.Letter9.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Letter9.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Letter9.Location = new System.Drawing.Point(20, 215);
			this.Letter9.Multiline = true;
			this.Letter9.Name = "Letter9";
			this.Letter9.ReadOnly = true;
			this.Letter9.Size = new System.Drawing.Size(66, 62);
			this.Letter9.TabIndex = 13;
			this.Letter9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Letter10
			// 
			this.Letter10.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Letter10.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Letter10.Location = new System.Drawing.Point(92, 215);
			this.Letter10.Multiline = true;
			this.Letter10.Name = "Letter10";
			this.Letter10.ReadOnly = true;
			this.Letter10.Size = new System.Drawing.Size(66, 62);
			this.Letter10.TabIndex = 14;
			this.Letter10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Letter11
			// 
			this.Letter11.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Letter11.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Letter11.Location = new System.Drawing.Point(164, 215);
			this.Letter11.Multiline = true;
			this.Letter11.Name = "Letter11";
			this.Letter11.ReadOnly = true;
			this.Letter11.Size = new System.Drawing.Size(66, 62);
			this.Letter11.TabIndex = 15;
			this.Letter11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Letter12
			// 
			this.Letter12.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Letter12.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Letter12.Location = new System.Drawing.Point(236, 215);
			this.Letter12.Multiline = true;
			this.Letter12.Name = "Letter12";
			this.Letter12.ReadOnly = true;
			this.Letter12.Size = new System.Drawing.Size(66, 62);
			this.Letter12.TabIndex = 16;
			this.Letter12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Letter13
			// 
			this.Letter13.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Letter13.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Letter13.Location = new System.Drawing.Point(20, 283);
			this.Letter13.Multiline = true;
			this.Letter13.Name = "Letter13";
			this.Letter13.ReadOnly = true;
			this.Letter13.Size = new System.Drawing.Size(66, 62);
			this.Letter13.TabIndex = 17;
			this.Letter13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Letter14
			// 
			this.Letter14.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Letter14.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Letter14.Location = new System.Drawing.Point(92, 283);
			this.Letter14.Multiline = true;
			this.Letter14.Name = "Letter14";
			this.Letter14.ReadOnly = true;
			this.Letter14.Size = new System.Drawing.Size(66, 62);
			this.Letter14.TabIndex = 18;
			this.Letter14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Letter15
			// 
			this.Letter15.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Letter15.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Letter15.Location = new System.Drawing.Point(164, 283);
			this.Letter15.Multiline = true;
			this.Letter15.Name = "Letter15";
			this.Letter15.ReadOnly = true;
			this.Letter15.Size = new System.Drawing.Size(66, 62);
			this.Letter15.TabIndex = 19;
			this.Letter15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Letter16
			// 
			this.Letter16.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Letter16.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Letter16.Location = new System.Drawing.Point(236, 283);
			this.Letter16.Multiline = true;
			this.Letter16.Name = "Letter16";
			this.Letter16.ReadOnly = true;
			this.Letter16.Size = new System.Drawing.Size(66, 62);
			this.Letter16.TabIndex = 20;
			this.Letter16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(425, 79);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(61, 17);
			this.label3.TabIndex = 21;
			this.label3.Text = "SCORE";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(395, 120);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 17);
			this.label4.TabIndex = 22;
			this.label4.Text = "Player1";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(395, 166);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 17);
			this.label5.TabIndex = 23;
			this.label5.Text = "Player2";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Player1Score
			// 
			this.Player1Score.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Player1Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Player1Score.Location = new System.Drawing.Point(467, 110);
			this.Player1Score.Multiline = true;
			this.Player1Score.Name = "Player1Score";
			this.Player1Score.ReadOnly = true;
			this.Player1Score.Size = new System.Drawing.Size(52, 31);
			this.Player1Score.TabIndex = 24;
			this.Player1Score.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Player2Score
			// 
			this.Player2Score.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Player2Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Player2Score.Location = new System.Drawing.Point(467, 156);
			this.Player2Score.Multiline = true;
			this.Player2Score.Name = "Player2Score";
			this.Player2Score.ReadOnly = true;
			this.Player2Score.Size = new System.Drawing.Size(52, 31);
			this.Player2Score.TabIndex = 25;
			this.Player2Score.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(388, 209);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(63, 24);
			this.label6.TabIndex = 26;
			this.label6.Text = "Time:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(401, 260);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(118, 17);
			this.label7.TabIndex = 28;
			this.label7.Text = "Enter Your Word:";
			// 
			// WordEnteredBox
			// 
			this.WordEnteredBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.WordEnteredBox.Location = new System.Drawing.Point(332, 287);
			this.WordEnteredBox.Name = "WordEnteredBox";
			this.WordEnteredBox.Size = new System.Drawing.Size(173, 23);
			this.WordEnteredBox.TabIndex = 29;
			// 
			// PlayWordButton
			// 
			this.PlayWordButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PlayWordButton.Location = new System.Drawing.Point(525, 280);
			this.PlayWordButton.Name = "PlayWordButton";
			this.PlayWordButton.Size = new System.Drawing.Size(67, 36);
			this.PlayWordButton.TabIndex = 30;
			this.PlayWordButton.Text = "PLAY";
			this.PlayWordButton.UseVisualStyleBackColor = true;
			// 
			// TimeLabel
			// 
			this.TimeLabel.AutoSize = true;
			this.TimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TimeLabel.Location = new System.Drawing.Point(472, 207);
			this.TimeLabel.Name = "TimeLabel";
			this.TimeLabel.Size = new System.Drawing.Size(24, 26);
			this.TimeLabel.TabIndex = 31;
			this.TimeLabel.Text = "0";
			this.TimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// seconds
			// 
			this.seconds.AutoSize = true;
			this.seconds.Location = new System.Drawing.Point(522, 216);
			this.seconds.Name = "seconds";
			this.seconds.Size = new System.Drawing.Size(47, 13);
			this.seconds.TabIndex = 32;
			this.seconds.Text = "seconds";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(613, 363);
			this.Controls.Add(this.seconds);
			this.Controls.Add(this.TimeLabel);
			this.Controls.Add(this.PlayWordButton);
			this.Controls.Add(this.WordEnteredBox);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.Player2Score);
			this.Controls.Add(this.Player1Score);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.Letter16);
			this.Controls.Add(this.Letter15);
			this.Controls.Add(this.Letter14);
			this.Controls.Add(this.Letter13);
			this.Controls.Add(this.Letter12);
			this.Controls.Add(this.Letter11);
			this.Controls.Add(this.Letter10);
			this.Controls.Add(this.Letter9);
			this.Controls.Add(this.Letter8);
			this.Controls.Add(this.Letter7);
			this.Controls.Add(this.Letter6);
			this.Controls.Add(this.Letter5);
			this.Controls.Add(this.Letter4);
			this.Controls.Add(this.Letter3);
			this.Controls.Add(this.Letter2);
			this.Controls.Add(this.Letter1);
			this.Controls.Add(this.ReadyButton);
			this.Controls.Add(this.NameTextBox);
			this.Controls.Add(this.IPAddressBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.Label1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "Form1";
			this.Text = "Boggle Client";
			this.ResumeLayout(false);
			this.PerformLayout();
=======
            this.Label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IPAddressBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.ReadyButton = new System.Windows.Forms.Button();
            this.Letter1 = new System.Windows.Forms.TextBox();
            this.Letter2 = new System.Windows.Forms.TextBox();
            this.Letter3 = new System.Windows.Forms.TextBox();
            this.Letter4 = new System.Windows.Forms.TextBox();
            this.Letter5 = new System.Windows.Forms.TextBox();
            this.Letter6 = new System.Windows.Forms.TextBox();
            this.Letter7 = new System.Windows.Forms.TextBox();
            this.Letter8 = new System.Windows.Forms.TextBox();
            this.Letter9 = new System.Windows.Forms.TextBox();
            this.Letter10 = new System.Windows.Forms.TextBox();
            this.Letter11 = new System.Windows.Forms.TextBox();
            this.Letter12 = new System.Windows.Forms.TextBox();
            this.Letter13 = new System.Windows.Forms.TextBox();
            this.Letter14 = new System.Windows.Forms.TextBox();
            this.Letter15 = new System.Windows.Forms.TextBox();
            this.Letter16 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Player1Score = new System.Windows.Forms.TextBox();
            this.Player2Score = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.WordEnteredBox = new System.Windows.Forms.TextBox();
            this.PlayWordButton = new System.Windows.Forms.Button();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.seconds = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(17, 26);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(80, 17);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "IP Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(233, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name:";
            // 
            // IPAddressBox
            // 
            this.IPAddressBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPAddressBox.Location = new System.Drawing.Point(100, 23);
            this.IPAddressBox.Name = "IPAddressBox";
            this.IPAddressBox.Size = new System.Drawing.Size(112, 23);
            this.IPAddressBox.TabIndex = 2;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTextBox.Location = new System.Drawing.Point(288, 23);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(112, 23);
            this.NameTextBox.TabIndex = 3;
            // 
            // ReadyButton
            // 
            this.ReadyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ReadyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReadyButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ReadyButton.Location = new System.Drawing.Point(428, 10);
            this.ReadyButton.Name = "ReadyButton";
            this.ReadyButton.Size = new System.Drawing.Size(143, 53);
            this.ReadyButton.TabIndex = 4;
            this.ReadyButton.Text = "READY!";
            this.ReadyButton.UseVisualStyleBackColor = false;
            // 
            // Letter1
            // 
            this.Letter1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter1.Location = new System.Drawing.Point(20, 79);
            this.Letter1.Multiline = true;
            this.Letter1.Name = "Letter1";
            this.Letter1.ReadOnly = true;
            this.Letter1.Size = new System.Drawing.Size(66, 62);
            this.Letter1.TabIndex = 5;
            this.Letter1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Letter2
            // 
            this.Letter2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter2.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter2.Location = new System.Drawing.Point(92, 79);
            this.Letter2.Multiline = true;
            this.Letter2.Name = "Letter2";
            this.Letter2.ReadOnly = true;
            this.Letter2.Size = new System.Drawing.Size(66, 62);
            this.Letter2.TabIndex = 6;
            this.Letter2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Letter3
            // 
            this.Letter3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter3.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter3.Location = new System.Drawing.Point(164, 79);
            this.Letter3.Multiline = true;
            this.Letter3.Name = "Letter3";
            this.Letter3.ReadOnly = true;
            this.Letter3.Size = new System.Drawing.Size(66, 62);
            this.Letter3.TabIndex = 7;
            this.Letter3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Letter4
            // 
            this.Letter4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter4.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter4.Location = new System.Drawing.Point(236, 79);
            this.Letter4.Multiline = true;
            this.Letter4.Name = "Letter4";
            this.Letter4.ReadOnly = true;
            this.Letter4.Size = new System.Drawing.Size(66, 62);
            this.Letter4.TabIndex = 8;
            this.Letter4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Letter5
            // 
            this.Letter5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter5.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter5.Location = new System.Drawing.Point(20, 147);
            this.Letter5.Multiline = true;
            this.Letter5.Name = "Letter5";
            this.Letter5.ReadOnly = true;
            this.Letter5.Size = new System.Drawing.Size(66, 62);
            this.Letter5.TabIndex = 9;
            this.Letter5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Letter6
            // 
            this.Letter6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter6.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter6.Location = new System.Drawing.Point(92, 147);
            this.Letter6.Multiline = true;
            this.Letter6.Name = "Letter6";
            this.Letter6.ReadOnly = true;
            this.Letter6.Size = new System.Drawing.Size(66, 62);
            this.Letter6.TabIndex = 10;
            this.Letter6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Letter7
            // 
            this.Letter7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter7.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter7.Location = new System.Drawing.Point(164, 147);
            this.Letter7.Multiline = true;
            this.Letter7.Name = "Letter7";
            this.Letter7.ReadOnly = true;
            this.Letter7.Size = new System.Drawing.Size(66, 62);
            this.Letter7.TabIndex = 11;
            this.Letter7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Letter8
            // 
            this.Letter8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter8.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter8.Location = new System.Drawing.Point(236, 147);
            this.Letter8.Multiline = true;
            this.Letter8.Name = "Letter8";
            this.Letter8.ReadOnly = true;
            this.Letter8.Size = new System.Drawing.Size(66, 62);
            this.Letter8.TabIndex = 12;
            this.Letter8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Letter9
            // 
            this.Letter9.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter9.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter9.Location = new System.Drawing.Point(20, 215);
            this.Letter9.Multiline = true;
            this.Letter9.Name = "Letter9";
            this.Letter9.ReadOnly = true;
            this.Letter9.Size = new System.Drawing.Size(66, 62);
            this.Letter9.TabIndex = 13;
            this.Letter9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Letter10
            // 
            this.Letter10.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter10.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter10.Location = new System.Drawing.Point(92, 215);
            this.Letter10.Multiline = true;
            this.Letter10.Name = "Letter10";
            this.Letter10.ReadOnly = true;
            this.Letter10.Size = new System.Drawing.Size(66, 62);
            this.Letter10.TabIndex = 14;
            this.Letter10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Letter11
            // 
            this.Letter11.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter11.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter11.Location = new System.Drawing.Point(164, 215);
            this.Letter11.Multiline = true;
            this.Letter11.Name = "Letter11";
            this.Letter11.ReadOnly = true;
            this.Letter11.Size = new System.Drawing.Size(66, 62);
            this.Letter11.TabIndex = 15;
            this.Letter11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Letter12
            // 
            this.Letter12.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter12.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter12.Location = new System.Drawing.Point(236, 215);
            this.Letter12.Multiline = true;
            this.Letter12.Name = "Letter12";
            this.Letter12.ReadOnly = true;
            this.Letter12.Size = new System.Drawing.Size(66, 62);
            this.Letter12.TabIndex = 16;
            this.Letter12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Letter13
            // 
            this.Letter13.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter13.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter13.Location = new System.Drawing.Point(20, 283);
            this.Letter13.Multiline = true;
            this.Letter13.Name = "Letter13";
            this.Letter13.ReadOnly = true;
            this.Letter13.Size = new System.Drawing.Size(66, 62);
            this.Letter13.TabIndex = 17;
            this.Letter13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Letter14
            // 
            this.Letter14.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter14.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter14.Location = new System.Drawing.Point(92, 283);
            this.Letter14.Multiline = true;
            this.Letter14.Name = "Letter14";
            this.Letter14.ReadOnly = true;
            this.Letter14.Size = new System.Drawing.Size(66, 62);
            this.Letter14.TabIndex = 18;
            this.Letter14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Letter15
            // 
            this.Letter15.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter15.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter15.Location = new System.Drawing.Point(164, 283);
            this.Letter15.Multiline = true;
            this.Letter15.Name = "Letter15";
            this.Letter15.ReadOnly = true;
            this.Letter15.Size = new System.Drawing.Size(66, 62);
            this.Letter15.TabIndex = 19;
            this.Letter15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Letter16
            // 
            this.Letter16.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter16.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter16.Location = new System.Drawing.Point(236, 283);
            this.Letter16.Multiline = true;
            this.Letter16.Name = "Letter16";
            this.Letter16.ReadOnly = true;
            this.Letter16.Size = new System.Drawing.Size(66, 62);
            this.Letter16.TabIndex = 20;
            this.Letter16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(425, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "SCORE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(395, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Player1";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(395, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 23;
            this.label5.Text = "Player2";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Player1Score
            // 
            this.Player1Score.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Player1Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1Score.Location = new System.Drawing.Point(467, 110);
            this.Player1Score.Multiline = true;
            this.Player1Score.Name = "Player1Score";
            this.Player1Score.ReadOnly = true;
            this.Player1Score.Size = new System.Drawing.Size(52, 31);
            this.Player1Score.TabIndex = 24;
            this.Player1Score.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Player2Score
            // 
            this.Player2Score.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Player2Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2Score.Location = new System.Drawing.Point(467, 156);
            this.Player2Score.Multiline = true;
            this.Player2Score.Name = "Player2Score";
            this.Player2Score.ReadOnly = true;
            this.Player2Score.Size = new System.Drawing.Size(52, 31);
            this.Player2Score.TabIndex = 25;
            this.Player2Score.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(388, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 24);
            this.label6.TabIndex = 26;
            this.label6.Text = "Time:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(401, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 17);
            this.label7.TabIndex = 28;
            this.label7.Text = "Enter Your Word:";
            // 
            // WordEnteredBox
            // 
            this.WordEnteredBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WordEnteredBox.Location = new System.Drawing.Point(332, 287);
            this.WordEnteredBox.Name = "WordEnteredBox";
            this.WordEnteredBox.Size = new System.Drawing.Size(173, 23);
            this.WordEnteredBox.TabIndex = 29;
            // 
            // PlayWordButton
            // 
            this.PlayWordButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayWordButton.Location = new System.Drawing.Point(525, 280);
            this.PlayWordButton.Name = "PlayWordButton";
            this.PlayWordButton.Size = new System.Drawing.Size(67, 36);
            this.PlayWordButton.TabIndex = 30;
            this.PlayWordButton.Text = "PLAY";
            this.PlayWordButton.UseVisualStyleBackColor = true;
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLabel.Location = new System.Drawing.Point(472, 207);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(24, 26);
            this.TimeLabel.TabIndex = 31;
            this.TimeLabel.Text = "0";
            this.TimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // seconds
            // 
            this.seconds.AutoSize = true;
            this.seconds.Location = new System.Drawing.Point(522, 216);
            this.seconds.Name = "seconds";
            this.seconds.Size = new System.Drawing.Size(47, 13);
            this.seconds.TabIndex = 32;
            this.seconds.Text = "seconds";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 363);
            this.Controls.Add(this.seconds);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.PlayWordButton);
            this.Controls.Add(this.WordEnteredBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Player2Score);
            this.Controls.Add(this.Player1Score);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Letter16);
            this.Controls.Add(this.Letter15);
            this.Controls.Add(this.Letter14);
            this.Controls.Add(this.Letter13);
            this.Controls.Add(this.Letter12);
            this.Controls.Add(this.Letter11);
            this.Controls.Add(this.Letter10);
            this.Controls.Add(this.Letter9);
            this.Controls.Add(this.Letter8);
            this.Controls.Add(this.Letter7);
            this.Controls.Add(this.Letter6);
            this.Controls.Add(this.Letter5);
            this.Controls.Add(this.Letter4);
            this.Controls.Add(this.Letter3);
            this.Controls.Add(this.Letter2);
            this.Controls.Add(this.Letter1);
            this.Controls.Add(this.ReadyButton);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.IPAddressBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Boggle Client";
            this.ResumeLayout(false);
            this.PerformLayout();
>>>>>>> .r394

        }

        #endregion

        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IPAddressBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Button ReadyButton;
        private System.Windows.Forms.TextBox Letter1;
        private System.Windows.Forms.TextBox Letter2;
        private System.Windows.Forms.TextBox Letter3;
        private System.Windows.Forms.TextBox Letter4;
        private System.Windows.Forms.TextBox Letter5;
        private System.Windows.Forms.TextBox Letter6;
        private System.Windows.Forms.TextBox Letter7;
        private System.Windows.Forms.TextBox Letter8;
        private System.Windows.Forms.TextBox Letter9;
        private System.Windows.Forms.TextBox Letter10;
        private System.Windows.Forms.TextBox Letter11;
        private System.Windows.Forms.TextBox Letter12;
        private System.Windows.Forms.TextBox Letter13;
        private System.Windows.Forms.TextBox Letter14;
        private System.Windows.Forms.TextBox Letter15;
        private System.Windows.Forms.TextBox Letter16;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Player1Score;
        private System.Windows.Forms.TextBox Player2Score;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox WordEnteredBox;
        private System.Windows.Forms.Button PlayWordButton;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Label seconds;
    }
}

