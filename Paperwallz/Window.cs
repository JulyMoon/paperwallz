using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Paperwallz
{
    public partial class Window : Form
    {
        private const string loginDefault = "Username";
        private const string urlDefault = "Url";
        private const string passwordDefault = "Password";
        private const string titleDefault = "The title goes here";
        private readonly string scriptLocation;

        public Window()
        {
            InitializeComponent();
            urlTextBox.Select();

            string exeDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            // ReSharper disable once AssignNullToNotNullAttribute
            scriptLocation = Path.Combine(exeDirectory, "py", "paperwallz.py");

            if (!File.Exists(scriptLocation))
            {
                MessageBox.Show("Script not found", "Fatal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
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
            urlRadioButton.Checked = true;
            IsSubmitEnabled();
        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {
            IsSubmitEnabled();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            Enabled = false;
            UseWaitCursor = true;

            Process pyscript = new Process
            {
                StartInfo =
                {
                    FileName = "python",
                    Arguments = "-W ignore " +
                                "\"" + scriptLocation +
                                "\" -t \"" + titleTextBox.Text +
                                "\" -u \"" + urlTextBox.Text +
                                "\" -n \"" + loginTextBox.Text +
                                "\" -p \"" + passwordTextBox.Text +
                                "\" -i",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            pyscript.Start();
            string output = pyscript.StandardOutput.ReadToEnd();
            pyscript.WaitForExit();
            MessageBox.Show(output);

            Enabled = true;
            UseWaitCursor = false;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            pcRadioButton.Checked = true;
        }
    }
}
