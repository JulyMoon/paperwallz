namespace Paperwallz
{
    partial class Window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            this.submitButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.browseButton = new System.Windows.Forms.Button();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.redditGroupBox = new System.Windows.Forms.GroupBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.RichTextBox();
            this.aboutButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.pasteButton = new System.Windows.Forms.Button();
            this.imageControl = new System.Windows.Forms.TabControl();
            this.urlTab = new System.Windows.Forms.TabPage();
            this.pcTab = new System.Windows.Forms.TabPage();
            this.redditGroupBox.SuspendLayout();
            this.imageControl.SuspendLayout();
            this.urlTab.SuspendLayout();
            this.pcTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.Enabled = false;
            this.submitButton.Location = new System.Drawing.Point(90, 168);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(142, 31);
            this.submitButton.TabIndex = 9;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Images|*.png;*.jpg;*.jpeg;*.gif;*.bmp";
            this.openFileDialog.Title = "Submit an image";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(6, 6);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(72, 24);
            this.browseButton.TabIndex = 6;
            this.browseButton.Text = "Browse...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // urlTextBox
            // 
            this.urlTextBox.AccessibleName = "Image url";
            this.urlTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.urlTextBox.Location = new System.Drawing.Point(84, 9);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(200, 20);
            this.urlTextBox.TabIndex = 5;
            this.urlTextBox.Text = "Image url";
            this.urlTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxSelector);
            this.urlTextBox.TextChanged += new System.EventHandler(this.urlTextBox_TextChanged);
            this.urlTextBox.Enter += new System.EventHandler(this.TextBoxHandler);
            this.urlTextBox.Leave += new System.EventHandler(this.TextBoxHandler);
            // 
            // redditGroupBox
            // 
            this.redditGroupBox.Controls.Add(this.passwordTextBox);
            this.redditGroupBox.Controls.Add(this.loginTextBox);
            this.redditGroupBox.Location = new System.Drawing.Point(12, 12);
            this.redditGroupBox.Name = "redditGroupBox";
            this.redditGroupBox.Size = new System.Drawing.Size(298, 45);
            this.redditGroupBox.TabIndex = 10;
            this.redditGroupBox.TabStop = false;
            this.redditGroupBox.Text = "Reddit";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.AccessibleName = "Password";
            this.passwordTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.passwordTextBox.Location = new System.Drawing.Point(152, 19);
            this.passwordTextBox.MaxLength = 250;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(140, 20);
            this.passwordTextBox.TabIndex = 2;
            this.passwordTextBox.Text = "Password";
            this.passwordTextBox.UseSystemPasswordChar = true;
            this.passwordTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxSelector);
            this.passwordTextBox.TextChanged += new System.EventHandler(this.passwordTextBox_TextChanged);
            this.passwordTextBox.Enter += new System.EventHandler(this.TextBoxHandler);
            this.passwordTextBox.Leave += new System.EventHandler(this.TextBoxHandler);
            // 
            // loginTextBox
            // 
            this.loginTextBox.AccessibleName = "Username";
            this.loginTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.loginTextBox.Location = new System.Drawing.Point(6, 19);
            this.loginTextBox.MaxLength = 20;
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(140, 20);
            this.loginTextBox.TabIndex = 1;
            this.loginTextBox.Text = "Username";
            this.loginTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxSelector);
            this.loginTextBox.TextChanged += new System.EventHandler(this.loginTextBox_TextChanged);
            this.loginTextBox.Enter += new System.EventHandler(this.TextBoxHandler);
            this.loginTextBox.Leave += new System.EventHandler(this.TextBoxHandler);
            // 
            // titleTextBox
            // 
            this.titleTextBox.AccessibleName = "The title goes here";
            this.titleTextBox.DetectUrls = false;
            this.titleTextBox.Font = new System.Drawing.Font("Verdana", 14F);
            this.titleTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.titleTextBox.Location = new System.Drawing.Point(12, 131);
            this.titleTextBox.MaxLength = 250;
            this.titleTextBox.Multiline = false;
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(298, 31);
            this.titleTextBox.TabIndex = 7;
            this.titleTextBox.Text = "The title goes here";
            this.titleTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxSelector);
            this.titleTextBox.TextChanged += new System.EventHandler(this.titleTextBox_TextChanged);
            this.titleTextBox.Enter += new System.EventHandler(this.TextBoxHandler);
            this.titleTextBox.Leave += new System.EventHandler(this.TextBoxHandler);
            // 
            // aboutButton
            // 
            this.aboutButton.Location = new System.Drawing.Point(12, 168);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(72, 31);
            this.aboutButton.TabIndex = 8;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(238, 168);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(72, 31);
            this.openButton.TabIndex = 10;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // pasteButton
            // 
            this.pasteButton.Location = new System.Drawing.Point(6, 6);
            this.pasteButton.Name = "pasteButton";
            this.pasteButton.Size = new System.Drawing.Size(72, 24);
            this.pasteButton.TabIndex = 7;
            this.pasteButton.Text = "Paste";
            this.pasteButton.UseVisualStyleBackColor = true;
            this.pasteButton.Click += new System.EventHandler(this.pasteButton_Click);
            // 
            // imageControl
            // 
            this.imageControl.Controls.Add(this.urlTab);
            this.imageControl.Controls.Add(this.pcTab);
            this.imageControl.Location = new System.Drawing.Point(12, 63);
            this.imageControl.Name = "imageControl";
            this.imageControl.SelectedIndex = 0;
            this.imageControl.Size = new System.Drawing.Size(298, 62);
            this.imageControl.TabIndex = 11;
            this.imageControl.SelectedIndexChanged += new System.EventHandler(this.imageControl_SelectedIndexChanged);
            // 
            // urlTab
            // 
            this.urlTab.BackColor = System.Drawing.Color.White;
            this.urlTab.Controls.Add(this.urlTextBox);
            this.urlTab.Controls.Add(this.pasteButton);
            this.urlTab.Location = new System.Drawing.Point(4, 22);
            this.urlTab.Name = "urlTab";
            this.urlTab.Padding = new System.Windows.Forms.Padding(3);
            this.urlTab.Size = new System.Drawing.Size(290, 36);
            this.urlTab.TabIndex = 0;
            this.urlTab.Text = "Upload from the internet";
            // 
            // pcTab
            // 
            this.pcTab.BackColor = System.Drawing.Color.White;
            this.pcTab.Controls.Add(this.browseButton);
            this.pcTab.Location = new System.Drawing.Point(4, 22);
            this.pcTab.Name = "pcTab";
            this.pcTab.Padding = new System.Windows.Forms.Padding(3);
            this.pcTab.Size = new System.Drawing.Size(290, 36);
            this.pcTab.TabIndex = 1;
            this.pcTab.Text = "Upload from this PC";
            // 
            // Window
            // 
            this.AcceptButton = this.submitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 211);
            this.Controls.Add(this.imageControl);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.redditGroupBox);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paperwallz";
            this.redditGroupBox.ResumeLayout(false);
            this.redditGroupBox.PerformLayout();
            this.imageControl.ResumeLayout(false);
            this.urlTab.ResumeLayout(false);
            this.urlTab.PerformLayout();
            this.pcTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.GroupBox redditGroupBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.RichTextBox titleTextBox;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Button openButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Button pasteButton;
        private System.Windows.Forms.TabControl imageControl;
        private System.Windows.Forms.TabPage urlTab;
        private System.Windows.Forms.TabPage pcTab;
    }
}

