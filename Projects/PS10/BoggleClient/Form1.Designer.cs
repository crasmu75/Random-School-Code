namespace BoggleClient
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
            this.Label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IPAddressBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.StatusButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Player1 = new System.Windows.Forms.Label();
            this.Player2 = new System.Windows.Forms.Label();
            this.Player1Score = new System.Windows.Forms.TextBox();
            this.Player2Score = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.WordEnteredBox = new System.Windows.Forms.TextBox();
            this.PlayWordButton = new System.Windows.Forms.Button();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.seconds = new System.Windows.Forms.Label();
            this.Letter1 = new System.Windows.Forms.Button();
            this.Letter2 = new System.Windows.Forms.Button();
            this.Letter3 = new System.Windows.Forms.Button();
            this.Letter4 = new System.Windows.Forms.Button();
            this.Letter5 = new System.Windows.Forms.Button();
            this.Letter6 = new System.Windows.Forms.Button();
            this.Letter7 = new System.Windows.Forms.Button();
            this.Letter8 = new System.Windows.Forms.Button();
            this.Letter9 = new System.Windows.Forms.Button();
            this.Letter10 = new System.Windows.Forms.Button();
            this.Letter11 = new System.Windows.Forms.Button();
            this.Letter12 = new System.Windows.Forms.Button();
            this.Letter13 = new System.Windows.Forms.Button();
            this.Letter14 = new System.Windows.Forms.Button();
            this.Letter15 = new System.Windows.Forms.Button();
            this.Letter16 = new System.Windows.Forms.Button();
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
            // StatusButton
            // 
            this.StatusButton.BackColor = System.Drawing.Color.Lime;
            this.StatusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.StatusButton.Location = new System.Drawing.Point(419, 10);
            this.StatusButton.Name = "StatusButton";
            this.StatusButton.Size = new System.Drawing.Size(173, 53);
            this.StatusButton.TabIndex = 4;
            this.StatusButton.Text = "CONNECT";
            this.StatusButton.UseVisualStyleBackColor = false;
            this.StatusButton.Click += new System.EventHandler(this.StatusButton_Click);
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
            // Player1
            // 
            this.Player1.AutoSize = true;
            this.Player1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1.Location = new System.Drawing.Point(364, 120);
            this.Player1.Name = "Player1";
            this.Player1.Size = new System.Drawing.Size(97, 17);
            this.Player1.TabIndex = 22;
            this.Player1.Text = "Player1 Name";
            this.Player1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Player2
            // 
            this.Player2.AutoSize = true;
            this.Player2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2.Location = new System.Drawing.Point(364, 166);
            this.Player2.Name = "Player2";
            this.Player2.Size = new System.Drawing.Size(97, 17);
            this.Player2.TabIndex = 23;
            this.Player2.Text = "Player2 Name";
            this.Player2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.WordEnteredBox.Enabled = false;
            this.WordEnteredBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WordEnteredBox.Location = new System.Drawing.Point(332, 287);
            this.WordEnteredBox.Name = "WordEnteredBox";
            this.WordEnteredBox.Size = new System.Drawing.Size(173, 23);
            this.WordEnteredBox.TabIndex = 29;
            // 
            // PlayWordButton
            // 
            this.PlayWordButton.Enabled = false;
            this.PlayWordButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayWordButton.Location = new System.Drawing.Point(525, 280);
            this.PlayWordButton.Name = "PlayWordButton";
            this.PlayWordButton.Size = new System.Drawing.Size(67, 36);
            this.PlayWordButton.TabIndex = 30;
            this.PlayWordButton.Text = "PLAY";
            this.PlayWordButton.UseVisualStyleBackColor = true;
            this.PlayWordButton.Click += new System.EventHandler(this.PlayWordButton_Click);
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLabel.Location = new System.Drawing.Point(472, 207);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(0, 26);
            this.TimeLabel.TabIndex = 31;
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
            // Letter1
            // 
            this.Letter1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter1.Enabled = false;
            this.Letter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter1.Location = new System.Drawing.Point(19, 79);
            this.Letter1.Name = "Letter1";
            this.Letter1.Size = new System.Drawing.Size(67, 67);
            this.Letter1.TabIndex = 33;
            this.Letter1.UseVisualStyleBackColor = false;
            // 
            // Letter2
            // 
            this.Letter2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter2.Enabled = false;
            this.Letter2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter2.Location = new System.Drawing.Point(92, 79);
            this.Letter2.Name = "Letter2";
            this.Letter2.Size = new System.Drawing.Size(67, 67);
            this.Letter2.TabIndex = 34;
            this.Letter2.UseVisualStyleBackColor = false;
            // 
            // Letter3
            // 
            this.Letter3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter3.Enabled = false;
            this.Letter3.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter3.Location = new System.Drawing.Point(165, 80);
            this.Letter3.Name = "Letter3";
            this.Letter3.Size = new System.Drawing.Size(67, 67);
            this.Letter3.TabIndex = 35;
            this.Letter3.UseVisualStyleBackColor = false;
            // 
            // Letter4
            // 
            this.Letter4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter4.Enabled = false;
            this.Letter4.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter4.Location = new System.Drawing.Point(238, 80);
            this.Letter4.Name = "Letter4";
            this.Letter4.Size = new System.Drawing.Size(67, 67);
            this.Letter4.TabIndex = 36;
            this.Letter4.UseVisualStyleBackColor = false;
            // 
            // Letter5
            // 
            this.Letter5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter5.Enabled = false;
            this.Letter5.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter5.Location = new System.Drawing.Point(19, 152);
            this.Letter5.Name = "Letter5";
            this.Letter5.Size = new System.Drawing.Size(67, 67);
            this.Letter5.TabIndex = 37;
            this.Letter5.UseVisualStyleBackColor = false;
            // 
            // Letter6
            // 
            this.Letter6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter6.Enabled = false;
            this.Letter6.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter6.Location = new System.Drawing.Point(92, 152);
            this.Letter6.Name = "Letter6";
            this.Letter6.Size = new System.Drawing.Size(67, 67);
            this.Letter6.TabIndex = 38;
            this.Letter6.UseVisualStyleBackColor = false;
            // 
            // Letter7
            // 
            this.Letter7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter7.Enabled = false;
            this.Letter7.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter7.Location = new System.Drawing.Point(165, 152);
            this.Letter7.Name = "Letter7";
            this.Letter7.Size = new System.Drawing.Size(67, 67);
            this.Letter7.TabIndex = 39;
            this.Letter7.UseVisualStyleBackColor = false;
            // 
            // Letter8
            // 
            this.Letter8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter8.Enabled = false;
            this.Letter8.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter8.Location = new System.Drawing.Point(238, 152);
            this.Letter8.Name = "Letter8";
            this.Letter8.Size = new System.Drawing.Size(67, 67);
            this.Letter8.TabIndex = 40;
            this.Letter8.UseVisualStyleBackColor = false;
            // 
            // Letter9
            // 
            this.Letter9.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter9.Enabled = false;
            this.Letter9.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter9.Location = new System.Drawing.Point(19, 225);
            this.Letter9.Name = "Letter9";
            this.Letter9.Size = new System.Drawing.Size(67, 67);
            this.Letter9.TabIndex = 41;
            this.Letter9.UseVisualStyleBackColor = false;
            // 
            // Letter10
            // 
            this.Letter10.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter10.Enabled = false;
            this.Letter10.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter10.Location = new System.Drawing.Point(92, 225);
            this.Letter10.Name = "Letter10";
            this.Letter10.Size = new System.Drawing.Size(67, 67);
            this.Letter10.TabIndex = 42;
            this.Letter10.UseVisualStyleBackColor = false;
            // 
            // Letter11
            // 
            this.Letter11.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter11.Enabled = false;
            this.Letter11.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter11.Location = new System.Drawing.Point(165, 225);
            this.Letter11.Name = "Letter11";
            this.Letter11.Size = new System.Drawing.Size(67, 67);
            this.Letter11.TabIndex = 43;
            this.Letter11.UseVisualStyleBackColor = false;
            // 
            // Letter12
            // 
            this.Letter12.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter12.Enabled = false;
            this.Letter12.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter12.Location = new System.Drawing.Point(238, 225);
            this.Letter12.Name = "Letter12";
            this.Letter12.Size = new System.Drawing.Size(67, 67);
            this.Letter12.TabIndex = 44;
            this.Letter12.UseVisualStyleBackColor = false;
            // 
            // Letter13
            // 
            this.Letter13.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter13.Enabled = false;
            this.Letter13.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter13.Location = new System.Drawing.Point(20, 298);
            this.Letter13.Name = "Letter13";
            this.Letter13.Size = new System.Drawing.Size(67, 67);
            this.Letter13.TabIndex = 45;
            this.Letter13.UseVisualStyleBackColor = false;
            // 
            // Letter14
            // 
            this.Letter14.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter14.Enabled = false;
            this.Letter14.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter14.Location = new System.Drawing.Point(93, 298);
            this.Letter14.Name = "Letter14";
            this.Letter14.Size = new System.Drawing.Size(67, 67);
            this.Letter14.TabIndex = 46;
            this.Letter14.UseVisualStyleBackColor = false;
            // 
            // Letter15
            // 
            this.Letter15.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter15.Enabled = false;
            this.Letter15.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter15.Location = new System.Drawing.Point(166, 298);
            this.Letter15.Name = "Letter15";
            this.Letter15.Size = new System.Drawing.Size(67, 67);
            this.Letter15.TabIndex = 47;
            this.Letter15.UseVisualStyleBackColor = false;
            // 
            // Letter16
            // 
            this.Letter16.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Letter16.Enabled = false;
            this.Letter16.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Letter16.Location = new System.Drawing.Point(239, 298);
            this.Letter16.Name = "Letter16";
            this.Letter16.Size = new System.Drawing.Size(67, 67);
            this.Letter16.TabIndex = 48;
            this.Letter16.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 383);
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
            this.Controls.Add(this.seconds);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.PlayWordButton);
            this.Controls.Add(this.WordEnteredBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Player2Score);
            this.Controls.Add(this.Player1Score);
            this.Controls.Add(this.Player2);
            this.Controls.Add(this.Player1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.StatusButton);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.IPAddressBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Boggle Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IPAddressBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Button StatusButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Player1;
        private System.Windows.Forms.Label Player2;
        private System.Windows.Forms.TextBox Player1Score;
        private System.Windows.Forms.TextBox Player2Score;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox WordEnteredBox;
        private System.Windows.Forms.Button PlayWordButton;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Label seconds;
        private System.Windows.Forms.Button Letter1;
        private System.Windows.Forms.Button Letter2;
        private System.Windows.Forms.Button Letter3;
        private System.Windows.Forms.Button Letter4;
        private System.Windows.Forms.Button Letter5;
        private System.Windows.Forms.Button Letter6;
        private System.Windows.Forms.Button Letter7;
        private System.Windows.Forms.Button Letter8;
        private System.Windows.Forms.Button Letter9;
        private System.Windows.Forms.Button Letter10;
        private System.Windows.Forms.Button Letter11;
        private System.Windows.Forms.Button Letter12;
        private System.Windows.Forms.Button Letter13;
        private System.Windows.Forms.Button Letter14;
        private System.Windows.Forms.Button Letter15;
        private System.Windows.Forms.Button Letter16;
    }
}

