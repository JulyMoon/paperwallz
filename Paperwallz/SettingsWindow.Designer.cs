namespace Paperwallz
{
    partial class SettingsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            this.redditGroupBox = new System.Windows.Forms.GroupBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.timeGroupBox = new System.Windows.Forms.GroupBox();
            this.hoursLabel = new System.Windows.Forms.Label();
            this.semicolonLabel2 = new System.Windows.Forms.Label();
            this.semicolonLabel1 = new System.Windows.Forms.Label();
            this.secondsNumeric = new System.Windows.Forms.NumericUpDown();
            this.minutesNumeric = new System.Windows.Forms.NumericUpDown();
            this.hoursNumeric = new System.Windows.Forms.NumericUpDown();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.minutesLabel = new System.Windows.Forms.Label();
            this.secondsLabel = new System.Windows.Forms.Label();
            this.warningLabel = new System.Windows.Forms.Label();
            this.redditGroupBox.SuspendLayout();
            this.timeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutesNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoursNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // redditGroupBox
            // 
            this.redditGroupBox.Controls.Add(this.passwordTextBox);
            this.redditGroupBox.Controls.Add(this.usernameTextBox);
            this.redditGroupBox.Location = new System.Drawing.Point(12, 12);
            this.redditGroupBox.Name = "redditGroupBox";
            this.redditGroupBox.Size = new System.Drawing.Size(218, 45);
            this.redditGroupBox.TabIndex = 0;
            this.redditGroupBox.TabStop = false;
            this.redditGroupBox.Text = "Reddit";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.AccessibleName = "Password";
            this.passwordTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.passwordTextBox.Location = new System.Drawing.Point(112, 19);
            this.passwordTextBox.MaxLength = 250;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(100, 20);
            this.passwordTextBox.TabIndex = 2;
            this.passwordTextBox.Text = "Password";
            this.passwordTextBox.UseSystemPasswordChar = true;
            this.passwordTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxSelector);
            this.passwordTextBox.TextChanged += new System.EventHandler(this.passwordTextBox_TextChanged);
            this.passwordTextBox.Enter += new System.EventHandler(this.TextBoxHandler);
            this.passwordTextBox.Leave += new System.EventHandler(this.TextBoxHandler);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.AccessibleName = "Username";
            this.usernameTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.usernameTextBox.Location = new System.Drawing.Point(6, 19);
            this.usernameTextBox.MaxLength = 20;
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(100, 20);
            this.usernameTextBox.TabIndex = 1;
            this.usernameTextBox.Text = "Username";
            this.usernameTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxSelector);
            this.usernameTextBox.TextChanged += new System.EventHandler(this.usernameTextBox_TextChanged);
            this.usernameTextBox.Enter += new System.EventHandler(this.TextBoxHandler);
            this.usernameTextBox.Leave += new System.EventHandler(this.TextBoxHandler);
            // 
            // timeGroupBox
            // 
            this.timeGroupBox.Controls.Add(this.warningLabel);
            this.timeGroupBox.Controls.Add(this.secondsLabel);
            this.timeGroupBox.Controls.Add(this.minutesLabel);
            this.timeGroupBox.Controls.Add(this.hoursLabel);
            this.timeGroupBox.Controls.Add(this.semicolonLabel2);
            this.timeGroupBox.Controls.Add(this.semicolonLabel1);
            this.timeGroupBox.Controls.Add(this.secondsNumeric);
            this.timeGroupBox.Controls.Add(this.minutesNumeric);
            this.timeGroupBox.Controls.Add(this.hoursNumeric);
            this.timeGroupBox.Location = new System.Drawing.Point(12, 63);
            this.timeGroupBox.Name = "timeGroupBox";
            this.timeGroupBox.Size = new System.Drawing.Size(218, 114);
            this.timeGroupBox.TabIndex = 1;
            this.timeGroupBox.TabStop = false;
            this.timeGroupBox.Text = "Time between submissions";
            // 
            // hoursLabel
            // 
            this.hoursLabel.AutoSize = true;
            this.hoursLabel.Location = new System.Drawing.Point(15, 42);
            this.hoursLabel.Name = "hoursLabel";
            this.hoursLabel.Size = new System.Drawing.Size(35, 13);
            this.hoursLabel.TabIndex = 5;
            this.hoursLabel.Text = "Hours";
            // 
            // semicolonLabel2
            // 
            this.semicolonLabel2.AutoSize = true;
            this.semicolonLabel2.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.semicolonLabel2.Location = new System.Drawing.Point(140, 18);
            this.semicolonLabel2.Name = "semicolonLabel2";
            this.semicolonLabel2.Size = new System.Drawing.Size(16, 18);
            this.semicolonLabel2.TabIndex = 4;
            this.semicolonLabel2.Text = ":";
            // 
            // semicolonLabel1
            // 
            this.semicolonLabel1.AutoSize = true;
            this.semicolonLabel1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.semicolonLabel1.Location = new System.Drawing.Point(62, 18);
            this.semicolonLabel1.Name = "semicolonLabel1";
            this.semicolonLabel1.Size = new System.Drawing.Size(16, 18);
            this.semicolonLabel1.TabIndex = 3;
            this.semicolonLabel1.Text = ":";
            // 
            // secondsNumeric
            // 
            this.secondsNumeric.Location = new System.Drawing.Point(162, 19);
            this.secondsNumeric.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.secondsNumeric.Name = "secondsNumeric";
            this.secondsNumeric.Size = new System.Drawing.Size(50, 20);
            this.secondsNumeric.TabIndex = 2;
            this.secondsNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.secondsNumeric.ValueChanged += new System.EventHandler(this.NumericValueChanged);
            // 
            // minutesNumeric
            // 
            this.minutesNumeric.Location = new System.Drawing.Point(84, 19);
            this.minutesNumeric.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.minutesNumeric.Name = "minutesNumeric";
            this.minutesNumeric.Size = new System.Drawing.Size(50, 20);
            this.minutesNumeric.TabIndex = 1;
            this.minutesNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.minutesNumeric.ValueChanged += new System.EventHandler(this.NumericValueChanged);
            // 
            // hoursNumeric
            // 
            this.hoursNumeric.Location = new System.Drawing.Point(6, 19);
            this.hoursNumeric.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.hoursNumeric.Name = "hoursNumeric";
            this.hoursNumeric.Size = new System.Drawing.Size(50, 20);
            this.hoursNumeric.TabIndex = 0;
            this.hoursNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.hoursNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.hoursNumeric.ValueChanged += new System.EventHandler(this.NumericValueChanged);
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(12, 183);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(69, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(87, 183);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(69, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // applyButton
            // 
            this.applyButton.Enabled = false;
            this.applyButton.Location = new System.Drawing.Point(162, 183);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(68, 23);
            this.applyButton.TabIndex = 4;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // minutesLabel
            // 
            this.minutesLabel.AutoSize = true;
            this.minutesLabel.Location = new System.Drawing.Point(88, 42);
            this.minutesLabel.Name = "minutesLabel";
            this.minutesLabel.Size = new System.Drawing.Size(44, 13);
            this.minutesLabel.TabIndex = 6;
            this.minutesLabel.Text = "Minutes";
            // 
            // secondsLabel
            // 
            this.secondsLabel.AutoSize = true;
            this.secondsLabel.Location = new System.Drawing.Point(163, 42);
            this.secondsLabel.Name = "secondsLabel";
            this.secondsLabel.Size = new System.Drawing.Size(49, 13);
            this.secondsLabel.TabIndex = 7;
            this.secondsLabel.Text = "Seconds";
            // 
            // warningLabel
            // 
            this.warningLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.warningLabel.Location = new System.Drawing.Point(6, 61);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(206, 46);
            this.warningLabel.TabIndex = 8;
            this.warningLabel.Text = "Flooding /r/wallpapers might get you banned from the subreddit so I don\'t recomme" +
    "nd values less than 1 hour";
            this.warningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SettingsWindow
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(242, 218);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.timeGroupBox);
            this.Controls.Add(this.redditGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsWindow_FormClosing);
            this.Shown += new System.EventHandler(this.SettingsWindow_Shown);
            this.redditGroupBox.ResumeLayout(false);
            this.redditGroupBox.PerformLayout();
            this.timeGroupBox.ResumeLayout(false);
            this.timeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutesNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoursNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox redditGroupBox;
        private System.Windows.Forms.GroupBox timeGroupBox;
        private System.Windows.Forms.NumericUpDown hoursNumeric;
        private System.Windows.Forms.NumericUpDown minutesNumeric;
        private System.Windows.Forms.NumericUpDown secondsNumeric;
        private System.Windows.Forms.Label hoursLabel;
        private System.Windows.Forms.Label semicolonLabel2;
        private System.Windows.Forms.Label semicolonLabel1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button applyButton;
        public System.Windows.Forms.TextBox usernameTextBox;
        public System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label secondsLabel;
        private System.Windows.Forms.Label minutesLabel;
        private System.Windows.Forms.Label warningLabel;
    }
}