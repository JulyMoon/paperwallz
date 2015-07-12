using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paperwallz
{
    public partial class Window : Form
    {
        private const string loginDefault = "Username";
        private const string urlDefault = "Url";
        private const string passwordDefault = "Password";
        private const string titleDefault = "Title";
        //private bool goodUrl = false;

        public Window()
        {
            InitializeComponent();
        }

        private void IsSubmitEnabled()
        {
            submitButton.Enabled = urlTextBox.Text != urlDefault && urlTextBox.Text.Length > 0 &&
                                   loginTextBox.Text != loginDefault && loginTextBox.Text.Length > 0 &&
                                   passwordTextBox.Text != passwordDefault && passwordTextBox.Text.Length > 0 &&
                                   titleTextBox.Text != titleDefault && titleTextBox.Text.Length > 0;
        }

        private static void Change(Control textbox, bool enable, string text)
        {
            if (enable && textbox.Text == text && textbox.ForeColor == SystemColors.GrayText)
            {
                textbox.ForeColor = SystemColors.WindowText;
                textbox.Text = "";
            }
            else if (textbox.Text == "")
            {
                textbox.ForeColor = SystemColors.GrayText;
                textbox.Text = text;
            }
        }

        private void loginTextBox_Enter(object sender, EventArgs e)
        {
            Change((Control)sender, true, loginDefault);
        }

        private void loginTextBox_Leave(object sender, EventArgs e)
        {
            Change((Control)sender, false, loginDefault);
        }

        private void urlTextBox_Enter(object sender, EventArgs e)
        {
            Change((Control)sender, true, urlDefault);
        }

        private void urlTextBox_Leave(object sender, EventArgs e)
        {
            Change((Control)sender, false, urlDefault);
        }

        private void passwordTextBox_Enter(object sender, EventArgs e)
        {
            Change((Control)sender, true, passwordDefault);
        }

        private void passwordTextBox_Leave(object sender, EventArgs e)
        {
            Change((Control)sender, false, passwordDefault);
        }

        private void titleTextBox_Enter(object sender, EventArgs e)
        {
            Change((Control)sender, true, titleDefault);
        }

        private void titleTextBox_Leave(object sender, EventArgs e)
        {
            Change((Control)sender, false, titleDefault);
        }

        private void pcRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            urlTextBox.Enabled = !urlTextBox.Enabled;
            browseButton.Enabled = !browseButton.Enabled;
        }

        private void loginTextBox_TextChanged(object sender, EventArgs e)
        {
            IsSubmitEnabled();
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            IsSubmitEnabled();
        }

        private void urlTextBox_TextChanged(object sender, EventArgs e)
        {
            IsSubmitEnabled();
        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {
            IsSubmitEnabled();
        }
    }
}
