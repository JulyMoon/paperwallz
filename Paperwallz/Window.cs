using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Paperwallz
{
    public partial class Window : Form
    {
        private readonly string scriptLocation;
        private const string link = "https://www.reddit.com/r/wallpapers/new/";
        private bool gotUsername, gotPassword, gotFile, gotTitle, notInProcess = true;

        public Window()
        {
            InitializeComponent();
            urlTextBox.Select();

            // ReSharper disable once AssignNullToNotNullAttribute
            scriptLocation = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "py", "paperwallz.py");

            if (!File.Exists(scriptLocation))
            {
                MessageBox.Show("Script not found", "Fatal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        private void UpdateSubmitButton()
        {
            submitButton.Enabled = gotUsername && gotPassword && gotFile && gotTitle && notInProcess;
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
            Text = "Paperwallz [Submitting]";
            notInProcess = false;
            UpdateSubmitButton();

            backgroundWorker.RunWorkerAsync(new ScriptArgs(scriptLocation, titleTextBox.Text,
                (urlRadioButton.Checked ? urlTextBox.Text : openFileDialog.FileName), loginTextBox.Text,
                passwordTextBox.Text, urlRadioButton.Checked));
        }

        private struct ScriptArgs
        {
            public readonly bool fromUrl;
            public readonly string scriptLocation, title, file, username, password;

            public ScriptArgs(string scriptLocation, string title, string file, string username, string password, bool fromUrl)
            {
                this.scriptLocation = scriptLocation;
                this.title = title;
                this.file = file;
                this.username = username;
                this.password = password;
                this.fromUrl = fromUrl;
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                pcRadioButton.Checked = gotFile = true;
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

        private void openButton_Click(object sender, EventArgs e)
        {
            Process.Start(link);
        }

        private void TextBoxSelector(object sender, MouseEventArgs e)
        {
            var textbox = (TextBoxBase)sender;

            if (textbox.SelectionLength == 0)
                textbox.SelectAll();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var args = (ScriptArgs)e.Argument;

            Process pyscript = new Process
            {
                StartInfo =
                {
                    FileName = "python",
                    Arguments = "-W ignore " +
                                "\"" + args.scriptLocation +
                                "\" -t \"" + args.title +
                                "\" -f \"" + args.file +
                                "\" -n \"" + args.username +
                                "\" -p \"" + args.password +
                                (args.fromUrl ? "\" -i" : "\""),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            pyscript.Start();
            string output = pyscript.StandardOutput.ReadToEnd();
            pyscript.WaitForExit();

            if (output.Split('\n').All(line => !line.StartsWith("PEACEOUT")))
                MessageBox.Show(output);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Text = "Paperwallz";
            notInProcess = true;
            UpdateSubmitButton();
        }
    }
}
