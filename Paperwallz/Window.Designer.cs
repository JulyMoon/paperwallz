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
            this.submitButton = new System.Windows.Forms.Button();
            this.urlRadioButton = new System.Windows.Forms.RadioButton();
            this.pcRadioButton = new System.Windows.Forms.RadioButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.browseButton = new System.Windows.Forms.Button();
            this.chooseGroupBox = new System.Windows.Forms.GroupBox();
            this.redditGroupBox = new System.Windows.Forms.GroupBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.submitGroupBox = new System.Windows.Forms.GroupBox();
            this.titleTextBox = new System.Windows.Forms.RichTextBox();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.chooseGroupBox.SuspendLayout();
            this.redditGroupBox.SuspendLayout();
            this.submitGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.Enabled = false;
            this.submitButton.Location = new System.Drawing.Point(246, 19);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(122, 69);
            this.submitButton.TabIndex = 0;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
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
            // 
            // pcRadioButton
            // 
            this.pcRadioButton.AutoSize = true;
            this.pcRadioButton.Location = new System.Drawing.Point(190, 19);
            this.pcRadioButton.Name = "pcRadioButton";
            this.pcRadioButton.Size = new System.Drawing.Size(118, 17);
            this.pcRadioButton.TabIndex = 6;
            this.pcRadioButton.Text = "Upload from this PC";
            this.pcRadioButton.UseVisualStyleBackColor = true;
            this.pcRadioButton.CheckedChanged += new System.EventHandler(this.pcRadioButton_CheckedChanged);
            // 
            // browseButton
            // 
            this.browseButton.Enabled = false;
            this.browseButton.Location = new System.Drawing.Point(190, 42);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(178, 26);
            this.browseButton.TabIndex = 7;
            this.browseButton.Text = "Browse...";
            this.browseButton.UseVisualStyleBackColor = true;
            // 
            // chooseGroupBox
            // 
            this.chooseGroupBox.Controls.Add(this.urlTextBox);
            this.chooseGroupBox.Controls.Add(this.urlRadioButton);
            this.chooseGroupBox.Controls.Add(this.browseButton);
            this.chooseGroupBox.Controls.Add(this.pcRadioButton);
            this.chooseGroupBox.Location = new System.Drawing.Point(12, 12);
            this.chooseGroupBox.Name = "chooseGroupBox";
            this.chooseGroupBox.Size = new System.Drawing.Size(374, 74);
            this.chooseGroupBox.TabIndex = 9;
            this.chooseGroupBox.TabStop = false;
            this.chooseGroupBox.Text = "Choose source of the image";
            // 
            // redditGroupBox
            // 
            this.redditGroupBox.Controls.Add(this.passwordTextBox);
            this.redditGroupBox.Controls.Add(this.loginTextBox);
            this.redditGroupBox.Location = new System.Drawing.Point(12, 92);
            this.redditGroupBox.Name = "redditGroupBox";
            this.redditGroupBox.Size = new System.Drawing.Size(374, 45);
            this.redditGroupBox.TabIndex = 10;
            this.redditGroupBox.TabStop = false;
            this.redditGroupBox.Text = "Reddit";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.passwordTextBox.Location = new System.Drawing.Point(190, 19);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(178, 20);
            this.passwordTextBox.TabIndex = 1;
            this.passwordTextBox.Text = "Password";
            this.passwordTextBox.UseSystemPasswordChar = true;
            this.passwordTextBox.TextChanged += new System.EventHandler(this.passwordTextBox_TextChanged);
            this.passwordTextBox.Enter += new System.EventHandler(this.passwordTextBox_Enter);
            this.passwordTextBox.Leave += new System.EventHandler(this.passwordTextBox_Leave);
            // 
            // loginTextBox
            // 
            this.loginTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.loginTextBox.Location = new System.Drawing.Point(6, 19);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(178, 20);
            this.loginTextBox.TabIndex = 0;
            this.loginTextBox.Text = "Username";
            this.loginTextBox.TextChanged += new System.EventHandler(this.loginTextBox_TextChanged);
            this.loginTextBox.Enter += new System.EventHandler(this.loginTextBox_Enter);
            this.loginTextBox.Leave += new System.EventHandler(this.loginTextBox_Leave);
            // 
            // submitGroupBox
            // 
            this.submitGroupBox.Controls.Add(this.titleTextBox);
            this.submitGroupBox.Controls.Add(this.submitButton);
            this.submitGroupBox.Location = new System.Drawing.Point(12, 143);
            this.submitGroupBox.Name = "submitGroupBox";
            this.submitGroupBox.Size = new System.Drawing.Size(374, 94);
            this.submitGroupBox.TabIndex = 11;
            this.submitGroupBox.TabStop = false;
            this.submitGroupBox.Text = "Come up with a title and submit";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.titleTextBox.Location = new System.Drawing.Point(6, 19);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(234, 69);
            this.titleTextBox.TabIndex = 1;
            this.titleTextBox.Text = "Title";
            this.titleTextBox.TextChanged += new System.EventHandler(this.titleTextBox_TextChanged);
            this.titleTextBox.Enter += new System.EventHandler(this.titleTextBox_Enter);
            this.titleTextBox.Leave += new System.EventHandler(this.titleTextBox_Leave);
            // 
            // urlTextBox
            // 
            this.urlTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.urlTextBox.Location = new System.Drawing.Point(6, 42);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(178, 20);
            this.urlTextBox.TabIndex = 8;
            this.urlTextBox.Text = "Url";
            this.urlTextBox.TextChanged += new System.EventHandler(this.urlTextBox_TextChanged);
            this.urlTextBox.Enter += new System.EventHandler(this.urlTextBox_Enter);
            this.urlTextBox.Leave += new System.EventHandler(this.urlTextBox_Leave);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 249);
            this.Controls.Add(this.submitGroupBox);
            this.Controls.Add(this.redditGroupBox);
            this.Controls.Add(this.chooseGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paperwallz";
            this.chooseGroupBox.ResumeLayout(false);
            this.chooseGroupBox.PerformLayout();
            this.redditGroupBox.ResumeLayout(false);
            this.redditGroupBox.PerformLayout();
            this.submitGroupBox.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox submitGroupBox;
        private System.Windows.Forms.RichTextBox titleTextBox;
        private System.Windows.Forms.TextBox urlTextBox;
    }
}

