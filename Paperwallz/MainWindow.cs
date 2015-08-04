using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Paperwallz
{
    public partial class MainWindow : Form
    {
        private readonly AboutWindow aboutWindow = new AboutWindow();
        private readonly string scriptLocation;
        private const string link = "https://www.reddit.com/r/wallpapers/new/";
        private readonly WebClient webClient = new WebClient();
        private bool gotUsername, gotPassword, gotFile, gotTitle;
        private const int maxFilenameLength = 29;
        private int selectedIndex = -1;
        private bool dragging;
        private TimeSpan timeLeft = TimeSpan.Zero;
        private bool submitting;
        private bool wallhaven;

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

        private void UpdateAddButton()
        {
            addButton.Enabled = gotFile && gotTitle;
        }

        private void loginTextBox_TextChanged(object sender, EventArgs e)
        {
            gotUsername = HasText(loginTextBox);
            UpdateSwitch();
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            gotPassword = HasText(passwordTextBox);
            UpdateSwitch();
        }

        private void UpdateSwitch()
        {
            switchButton.Enabled = gotUsername && gotPassword;
        }

        private void urlTextBox_TextChanged(object sender, EventArgs e)
        {
            gotFile = HasText(urlTextBox);
            UpdateAddButton();
        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {
            gotTitle = HasText(titleTextBox);
            UpdateAddButton();
        }

        private void imageControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (imageControl.SelectedIndex == 0)
                gotFile = HasText(urlTextBox);
            else
                gotFile = openFileDialog.FileName != "";

            UpdateAddButton();
        }

        private static bool HasText(TextBoxBase textbox)
        {
            return textbox.ForeColor == SystemColors.WindowText && textbox.Text.Length > 0;
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

            if (ActiveControl == textbox) //maybe just separate TextBoxHandler into 2 methods?
            {
                if (textbox.ForeColor == SystemColors.GrayText)
                {
                    textbox.ForeColor = SystemColors.WindowText;
                    textbox.Text = "";
                }
                else
                    //SelectAll doesnt work without this //BeginInvoke((Action)textbox.SelectAll); maybe?
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

            e.Result = "Noice";

            if (submitted)
                return;

            string error = "Unable to submit to /r/wallpapers. I don't know why :(";

            if (!uploaded)
            {
                error = "Unable to upload to imgur.com. I don't know why :(";

                if (!signedin)
                    error = "Unable to log into Reddit. Wrong username/password combination, perhaps?";
            }

            e.Result = error;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            submitting = false;
            wallhaven = false;

            string result = (string)e.Result;
            if (result != "Noice")
            {
                SwitchPosting(false);
                MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                UpdateTitle(true);
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

        private void queueList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            removeButton.Enabled = e.IsSelected;
            selectedIndex = e.IsSelected ? e.ItemIndex : -1;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            queueList.Items.RemoveAt(selectedIndex);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            queueList.Items.Add(new ListViewItem(new[]
                {
                    (queueList.Items.Count + 1).ToString(),
                    titleTextBox.Text,
                    imageControl.SelectedIndex == 0 ? urlTextBox.Text : openFileDialog.FileName,
                    imageControl.SelectedIndex == 0 ? "Yes" : "No"
                }));
        }

        private void Swap(int a, int b)
        {
            if (a < 0 || b < 0 || a == b)
                return;

            for (int i = 1; i < queueList.Items[a].SubItems.Count; i++)
            {
                var temp = queueList.Items[a].SubItems[i].Text;
                queueList.Items[a].SubItems[i].Text = queueList.Items[b].SubItems[i].Text;
                queueList.Items[b].SubItems[i].Text = temp;
            }
        }

        private void queueList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            dragging = true;
        }

        private void queueList_MouseUp(object sender, MouseEventArgs e)
        {
            if (!dragging)
                return;

            dragging = false;

            Swap(queueList.Items.IndexOf(queueList.HitTest(e.X, e.Y).Item), selectedIndex);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > TimeSpan.Zero)
            {
                timeLeft -= TimeSpan.FromMilliseconds(timer.Interval);
            }
            else
            {
                timeLeft = TimeSpan.FromMinutes(1);

                submitting = true;
                UpdateTitle(false);

                string url = urlTextBox.Text;

                if (imageControl.SelectedIndex == 0 && Regex.IsMatch(url, @"http://alpha.wallhaven.cc/wallpaper/\d+"))
                {
                    string contents = webClient.DownloadString(url);
                    int index = contents.IndexOf(@"content=""//", StringComparison.Ordinal);
                    if (index != -1)
                    {
                        index += 9;
                        url = "http:" + contents.Substring(index, contents.IndexOf(@"""", index, StringComparison.Ordinal) - index);
                        wallhaven = true;
                        UpdateTitle(false);
                    }
                }

                backgroundWorker.RunWorkerAsync(new ScriptArgs(scriptLocation, titleTextBox.Text,
                    (imageControl.SelectedIndex == 0 ? url : openFileDialog.FileName), loginTextBox.Text,
                    passwordTextBox.Text, imageControl.SelectedIndex == 0));
            }

            UpdateTime();
        }

        private void UpdateTime()
        {
            timeLeftLabel.Text = timeLeft.ToString();
            progressBar.Value = (int)((1 - ((double)timeLeft.Ticks / TimeSpan.FromMinutes(1).Ticks)) * 100);
        }

        private void switchButton_Click(object sender, EventArgs e)
        {
            SwitchPosting(!timer.Enabled);
        }

        private void UpdateTitle(bool updateSwitch)
        {
            if (updateSwitch)
                switchButton.Text = timer.Enabled ? "Stop" : "Start";

            Text = Application.ProductName +
                   (timer.Enabled ? " [ON]" : " [OFF]") +
                   (submitting ? " [Submitting]" : "") +
                   (wallhaven ? " [W]" : "");
        }

        private void SwitchPosting(bool start)
        {
            if (start)
            {
                loginTextBox.ReadOnly = true;
                passwordTextBox.ReadOnly = true;
                timer.Start();
            }
            else
            {
                timer.Stop();
                loginTextBox.ReadOnly = false;
                passwordTextBox.ReadOnly = false;
            }

            UpdateTitle(true);
        }
    }
}
