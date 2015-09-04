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
            versionLabel.Text = Format(Application.ProductVersion);
            authorLabel.Text = Application.CompanyName;
        }

        private static string Format(string version)
        {
            var digits = version.Split('.');

            version = digits[0] + "." + digits[1];

            if (digits[3] != "0")
                version += "." + digits[2] + "." + digits[3];
            else if (digits[2] != "0")
                version += "." + digits[2];

            return version;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void emailLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto://foxnezz@gmail.com");
            Hide();
        }
    }
}
