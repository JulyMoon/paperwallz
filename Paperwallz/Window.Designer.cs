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
            this.urlRadioButton = new System.Windows.Forms.RadioButton();
            this.pcRadioButton = new System.Windows.Forms.RadioButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.browseButton = new System.Windows.Forms.Button();
            this.chooseGroupBox = new System.Windows.Forms.GroupBox();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.redditGroupBox = new System.Windows.Forms.GroupBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.RichTextBox();
            this.aboutButton = new System.Windows.Forms.Button();
            this.chooseGroupBox.SuspendLayout();
            this.redditGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.Enabled = false;
            this.submitButton.Location = new System.Drawing.Point(117, 175);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(193, 31);
            this.submitButton.TabIndex = 5;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // urlRadioButton
            // 
            this.urlRadioButton.AutoSize = true;
            this.urlRadioButton.Checked = true;
            this.urlRadioButton.Location = new System.Drawing.Point(6, 19);
            this.urlRadioButton.Name = "urlRadioButton";
            this.urlRadioButton.Size = new System.Drawing.Size(96, 17);
            this.urlRadioButton.TabIndex = 5;
            this.urlRadioButton.TabStop = true;
            this.urlRadioButton.Text = "Upload from url";
            this.urlRadioButton.UseVisualStyleBackColor = true;
            this.urlRadioButton.CheckedChanged += new System.EventHandler(this.urlRadioButton_CheckedChanged);
            // 
            // pcRadioButton
            // 
            this.pcRadioButton.AutoSize = true;
            this.pcRadioButton.Location = new System.Drawing.Point(152, 19);
            this.pcRadioButton.Name = "pcRadioButton";
            this.pcRadioButton.Size = new System.Drawing.Size(118, 17);
            this.pcRadioButton.TabIndex = 6;
            this.pcRadioButton.Text = "Upload from this PC";
            this.pcRadioButton.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Images|*.png;*.jpg;*.jpeg;*.gif;*.bmp";
            this.openFileDialog.Title = "Submit an image";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(152, 40);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(140, 23);
            this.browseButton.TabIndex = 7;
            this.browseButton.Text = "Browse...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // chooseGroupBox
            // 
            this.chooseGroupBox.Controls.Add(this.urlTextBox);
            this.chooseGroupBox.Controls.Add(this.urlRadioButton);
            this.chooseGroupBox.Controls.Add(this.browseButton);
            this.chooseGroupBox.Controls.Add(this.pcRadioButton);
            this.chooseGroupBox.Location = new System.Drawing.Point(12, 63);
            this.chooseGroupBox.Name = "chooseGroupBox";
            this.chooseGroupBox.Size = new System.Drawing.Size(298, 69);
            this.chooseGroupBox.TabIndex = 9;
            this.chooseGroupBox.TabStop = false;
            this.chooseGroupBox.Text = "Choose source of the image";
            // 
            // urlTextBox
            // 
            this.urlTextBox.AccessibleName = "Url";
            this.urlTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.urlTextBox.Location = new System.Drawing.Point(6, 42);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(140, 20);
            this.urlTextBox.TabIndex = 3;
            this.urlTextBox.Text = "Url";
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
            this.titleTextBox.Location = new System.Drawing.Point(12, 138);
            this.titleTextBox.MaxLength = 250;
            this.titleTextBox.Multiline = false;
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(298, 31);
            this.titleTextBox.TabIndex = 4;
            this.titleTextBox.Text = "The title goes here";
            this.titleTextBox.TextChanged += new System.EventHandler(this.titleTextBox_TextChanged);
            this.titleTextBox.Enter += new System.EventHandler(this.TextBoxHandler);
            this.titleTextBox.Leave += new System.EventHandler(this.TextBoxHandler);
            // 
            // aboutButton
            // 
            this.aboutButton.Location = new System.Drawing.Point(12, 175);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(99, 31);
            this.aboutButton.TabIndex = 12;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = true;
            // 
            // Window
            // 
            this.AcceptButton = this.submitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 218);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.chooseGroupBox);
            this.Controls.Add(this.redditGroupBox);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paperwallz";
            this.chooseGroupBox.ResumeLayout(false);
            this.chooseGroupBox.PerformLayout();
            this.redditGroupBox.ResumeLayout(false);
            this.redditGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.RadioButton urlRadioButton;
        private System.Windows.Forms.RadioButton pcRadioButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.GroupBox chooseGroupBox;
        private System.Windows.Forms.GroupBox redditGroupBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.RichTextBox titleTextBox;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Button aboutButton;
    }
}

