using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Paperwallz
{
    public partial class MainWindow : Form
    {
        private readonly AboutWindow aboutWindow = new AboutWindow();
        private readonly string scriptLocation;
        private const string link = "https://www.reddit.com/r/wallpapers/new/";
        private bool gotUsername, gotPassword, gotFile, gotTitle, notInProcess = true;
        private const int maxFilenameLength = 29;

        public MainWindow()
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
            gotUsername = HasText(loginTextBox);
            UpdateSubmitButton();
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            gotPassword = HasText(passwordTextBox);
            UpdateSubmitButton();
        }

        private void urlTextBox_TextChanged(object sender, EventArgs e)
        {
            gotFile = HasText(urlTextBox);
            UpdateSubmitButton();
        }

        private static bool HasText(TextBoxBase textbox)
        {
            return textbox.ForeColor == SystemColors.WindowText && textbox.Text.Length > 0;
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
                (imageControl.SelectedIndex == 0 ? urlTextBox.Text : openFileDialog.FileName), loginTextBox.Text,
                passwordTextBox.Text, imageControl.SelectedIndex == 0));
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
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            gotFile = true;

            string filename = Path.GetFileName(openFileDialog.FileName);

            // ReSharper disable once PossibleNullReferenceException
            filenameLabel.Text = filename.Length > maxFilenameLength ?
                filename.Substring(0, maxFilenameLength - 3) + "..." : filename;
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
            aboutWindow.ShowDialog();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var args = (ScriptArgs)e.Argument;

            Process pyscript = new Process
            {
                StartInfo =
                {
                    FileName = "python",
                    Arguments = //"-W ignore " +
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

            bool signedin = false;
            bool uploaded = false;
            bool submitted = false;
            foreach (var line in output.Split('\n'))
            {
                if (line.Contains("SIGNEDIN"))
                    signedin = true;

                if (line.Contains("UPLOADED"))
                    uploaded = true;

                if (line.Contains("SUBMITTED"))
                    submitted = true;
            }

            if (submitted)
                return;

            string error = "Unable to submit to /r/wallpapers. I don't know why :(";

            if (!uploaded)
            {
                error = "Unable to upload to imgur.com. I don't know why :(";

                if (!signedin)
                    error = "Unable to log into Reddit. Wrong username/password combination, perhaps?";
            }

            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Text = "Paperwallz";
            notInProcess = true;
            UpdateSubmitButton();
        }

        private void pasteButton_Click(object sender, EventArgs e)
        {
            if (!Clipboard.ContainsText())
                return;

            urlTextBox.Text = Clipboard.GetText();
            urlTextBox.ForeColor = SystemColors.WindowText;
            urlTextBox.SelectionStart = urlTextBox.Text.Length;

            urlTextBox_TextChanged(new object(), new EventArgs());
        }

        private void imageControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (imageControl.SelectedIndex == 0)
                gotFile = HasText(urlTextBox);
            else
                gotFile = openFileDialog.FileName != "";

            UpdateSubmitButton();
        }
    }
}
