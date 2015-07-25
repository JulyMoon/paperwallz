using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Paperwallz
{
    public partial class AboutWindow : Form
    {
        public AboutWindow()
        {
            InitializeComponent();
            nameLabel.Text = Application.ProductName;
            versionLabel.Text = Application.ProductVersion;
            authorLabel.Text = Application.CompanyName;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void emailLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto://foxnezz@gmail.com");
        }
    }
}
