namespace Paperwallz
{
    partial class AboutWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutWindow));
            this.okButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.authorLabel2 = new System.Windows.Forms.Label();
            this.emailLabel2 = new System.Windows.Forms.Label();
            this.authorLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(71, 148);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 24);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(20, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.nameLabel.Location = new System.Drawing.Point(90, 30);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(80, 18);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Paperwallz";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.versionLabel.Location = new System.Drawing.Point(90, 48);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(24, 15);
            this.versionLabel.TabIndex = 3;
            this.versionLabel.Text = "1.0";
            // 
            // authorLabel2
            // 
            this.authorLabel2.AutoSize = true;
            this.authorLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.authorLabel2.Location = new System.Drawing.Point(17, 89);
            this.authorLabel2.Name = "authorLabel2";
            this.authorLabel2.Size = new System.Drawing.Size(54, 17);
            this.authorLabel2.TabIndex = 4;
            this.authorLabel2.Text = "Author:";
            // 
            // emailLabel2
            // 
            this.emailLabel2.AutoSize = true;
            this.emailLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.emailLabel2.Location = new System.Drawing.Point(17, 114);
            this.emailLabel2.Name = "emailLabel2";
            this.emailLabel2.Size = new System.Drawing.Size(51, 17);
            this.emailLabel2.TabIndex = 5;
            this.emailLabel2.Text = "E-Mail:";
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.authorLabel.Location = new System.Drawing.Point(77, 89);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(58, 17);
            this.authorLabel.TabIndex = 6;
            this.authorLabel.Text = "foxneZz";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.emailLabel.Location = new System.Drawing.Point(77, 114);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(133, 17);
            this.emailLabel.TabIndex = 7;
            this.emailLabel.TabStop = true;
            this.emailLabel.Text = "foxnezz@gmail.com";
            this.emailLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.emailLabel_LinkClicked);
            // 
            // AboutWindow
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 188);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.authorLabel);
            this.Controls.Add(this.emailLabel2);
            this.Controls.Add(this.authorLabel2);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AboutWindow";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label authorLabel2;
        private System.Windows.Forms.Label emailLabel2;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.LinkLabel emailLabel;
    }
}