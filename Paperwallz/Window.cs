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
        private readonly string scriptLocation;
        private bool gotUsername, gotPassword, gotFile, gotTitle;

        public Window()
        {
            InitializeComponent();
            urlRadioButton.Select();

            string exeDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            // ReSharper disable once AssignNullToNotNullAttribute
            scriptLocation = Path.Combine(exeDirectory, "py", "paperwallz.py");

            if (!File.Exists(scriptLocation))
            {
                MessageBox.Show("Script not found", "Fatal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        private void UpdateSubmitButton()
        {
            submitButton.Enabled = gotUsername && gotPassword && gotFile && gotTitle;
        }

        private void loginTextBox_TextChanged(object sender, EventArgs e)
        {
            gotUsername = loginTextBox.ForeColor == SystemColors.WindowText && loginTextBox.Text.Length > 0;
            UpdateSubmitButton();
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            gotPassword = passwordTextBox.ForeColor == SystemColors.WindowText && passwordTextBox.Text.Length > 0;
            UpdateSubmitButton();
        }

        private void urlTextBox_TextChanged(object sender, EventArgs e)
        {
            urlRadioButton.Checked = true;
            gotFile = IsUrlValid();
            UpdateSubmitButton();
        }

        private bool IsUrlValid()
        {
            return urlTextBox.Text.Length > 0 && urlTextBox.ForeColor == SystemColors.WindowText;
            /*Uri uriResult;
            return Uri.TryCreate(urlTextBox.Text.StartsWith("http://") || urlTextBox.Text.StartsWith("https://") ?
                urlTextBox.Text : "http://" + urlTextBox.Text,
                UriKind.Absolute, out uriResult) &&
                (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);*/
        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {
            gotTitle = titleTextBox.ForeColor == SystemColors.WindowText && titleTextBox.Text.Length > 0;
            UpdateSubmitButton();
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
                                "\" -u \"" + (urlRadioButton.Checked ? urlTextBox.Text : openFileDialog.FileName) +
                                "\" -n \"" + loginTextBox.Text +
                                "\" -p \"" + passwordTextBox.Text +
                                (urlRadioButton.Checked ? "\" -i" : "\""),
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
            pcRadioButton.Checked = openFileDialog.ShowDialog() == DialogResult.OK;
        }

        private void urlRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (urlRadioButton.Checked)
                gotFile = IsUrlValid();
            else
                gotFile = openFileDialog.FileName != "";

            UpdateSubmitButton();
        }

        private void TextBoxHandler(object sender, EventArgs e)
        {
            var textbox = (TextBoxBase)sender;
            
            if (ActiveControl == textbox)
            {
                if (textbox.ForeColor == SystemColors.GrayText)
                {
                    textbox.ForeColor = SystemColors.WindowText;
                    textbox.Text = "";
                }
                else
                    //SelectAll doesnt work without this
                    BeginInvoke((Action)delegate { textbox.SelectAll(); });
            }
            else if (textbox.Text == "")
            {
                textbox.ForeColor = SystemColors.GrayText;
                textbox.Text = textbox.AccessibleName;
            }
        }
    }
}
