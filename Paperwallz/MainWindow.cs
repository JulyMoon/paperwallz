using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Paperwallz.Properties;

namespace Paperwallz
{
    public partial class MainWindow : Form
    {
        private readonly AboutWindow aboutWindow = new AboutWindow();
        private readonly SettingsWindow settingsWindow = new SettingsWindow();
        private readonly string scriptLocation;
        private const string link = "https://www.reddit.com/r/wallpapers/new/";
        private readonly WebClient webClient = new WebClient();
        private bool gotFile, gotTitle;
        private const int maxFilenameLength = 29;
        private int selectedIndex = -1;
        private bool dragging;
        private TimeSpan timeLeft = TimeSpan.Zero;
        private TimeSpan maxTime;
        private bool submitting;
        private bool wallhaven;
        private const char separator = '=';

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

            ReadConfig();
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            if (Settings.Default.firsttime)
            {
                ShowSettingsWindow();
                Settings.Default.firsttime = false;
            }
        }

        private static string[] Separate(string pair)
        {
            var result = new string[2];
            int n = pair.IndexOf(separator);
            result[0] = pair.Substring(0, n);
            result[1] = pair.Substring(n + 1, pair.Length - n - 1);
            return result;
        }

        private void ReadConfig()
        {
            settingsWindow.Username = Settings.Default.username;
            settingsWindow.Password = Settings.Default.password;
            switchButton.Enabled = settingsWindow.GotCredentials();

            maxTime = settingsWindow.Timespan = Settings.Default.maxtime;

            if (Settings.Default.submissions[0] == "empty")
                return;

            var submissions = new string[Settings.Default.submissions.Count / 3][];
            for (int i = 0; i < submissions.Length; i++)
                submissions[i] = new string[3];

            foreach (var pair in Settings.Default.submissions)
            {
                var separate = Separate(pair);
                var key = separate[0];
                var value = separate[1];

                var split = key.Split(' ');
                int n = Int32.Parse(split[0]) - 1;

                int m = -1;
                switch (split[1])
                {
                    case "t": m = 0; break;
                    case "f": m = 1; break;
                    case "i": m = 2; break;
                }

                submissions[n][m] = value;
            }

            for (int i = 0; i < submissions.Length; i++)
                queueList.Items.Add(new ListViewItem(new[] {(i + 1).ToString(), submissions[i][0], submissions[i][1], submissions[i][2]}));
        }

        private void UpdateAddButton()
        {
            addButton.Enabled = gotFile && gotTitle;
        }

        public void UpdateSwitch(bool enabled)
        {
            switchButton.Enabled = enabled;
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

        public static bool HasText(TextBoxBase textbox)
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

        private void TextBox_Enter(object sender, EventArgs e)
        {
            var textbox = (TextBoxBase)sender;

            if (textbox.ForeColor == SystemColors.GrayText)
            {
                textbox.ForeColor = SystemColors.WindowText;
                textbox.Text = "";
            }
            else
                BeginInvoke((Action)textbox.SelectAll);
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            var textbox = (TextBoxBase)sender;

            SettingsWindow.SetText(textbox, textbox.Text);
        }

        private void TextBoxSelector(object sender, MouseEventArgs e)
        {
            var textbox = (TextBoxBase)sender;

            if (textbox.SelectionLength == 0)
                textbox.SelectAll();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            Process.Start(link);
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

            e.Result = error + "\n" + output; //TODO: remove output
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

        private void SaveSettings()
        {
            Settings.Default.username = settingsWindow.Username;
            Settings.Default.password = settingsWindow.Password;
            Settings.Default.maxtime = maxTime;

            var submissions = new StringCollection();
            for (int i = 0; i < queueList.Items.Count; i++)
            {
                submissions.Add((i + 1) + " t=" + queueList.Items[i].SubItems[1].Text);
                submissions.Add((i + 1) + " f=" + queueList.Items[i].SubItems[2].Text);
                submissions.Add((i + 1) + " i=" + queueList.Items[i].SubItems[3].Text);
            }

            if (submissions.Count == 0)
                submissions.Add("empty");

            Settings.Default.submissions = submissions;

            Settings.Default.Save();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string number = (queueList.Items.Count + 1).ToString();
            string title = titleTextBox.Text;
            string file;
            string internet;

            if (imageControl.SelectedIndex == 0)
            {
                file = urlTextBox.Text;
                internet = "Yes";
            }
            else
            {
                file = openFileDialog.FileName;
                internet = "No";
            }

            queueList.Items.Add(new ListViewItem(new[] {number, title, file, internet}));
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
                timeLeft -= TimeSpan.FromMilliseconds(timer.Interval);
            else
            {
                timeLeft = maxTime;

                submitting = true;
                UpdateTitle(false);

                string file = queueList.Items[0].SubItems[2].Text;
                bool internet = queueList.Items[0].SubItems[3].Text == "Yes";

                if (internet && Regex.IsMatch(file, @"http://alpha.wallhaven.cc/wallpaper/\d+"))
                {
                    string contents = webClient.DownloadString(file);
                    int index = contents.IndexOf(@"content=""//", StringComparison.Ordinal);
                    if (index != -1)
                    {
                        index += 9;
                        file = "http:" +
                               contents.Substring(index,
                                   contents.IndexOf(@"""", index, StringComparison.Ordinal) - index);
                        wallhaven = true;
                        UpdateTitle(false);
                    }
                }

                backgroundWorker.RunWorkerAsync(new ScriptArgs(scriptLocation, queueList.Items[0].SubItems[1].Text,
                    file, settingsWindow.Username, settingsWindow.Password, internet));

                queueList.Items.RemoveAt(0);
            }

            UpdateTime();
        }

        private void UpdateTime()
        {
            timeLeftLabel.Text = timeLeft.ToString();
            progressBar.Value = //100 - (int)(((double)timeLeft.Ticks / maxTime.Ticks) * 100);
                                (int)((1 - ((double)timeLeft.Ticks / maxTime.Ticks)) * 100);
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
                settingsWindow.SetReadOnly(true);
                timer.Start();
            }
            else
            {
                timer.Stop();
                settingsWindow.SetReadOnly(false);
            }

            UpdateTitle(true);
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            ShowSettingsWindow();
        }

        private void ShowSettingsWindow()
        {
            settingsWindow.ShowDialog();
            switchButton.Enabled = settingsWindow.GotCredentials();
            maxTime = settingsWindow.Timespan;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            SaveSettings();
        }
    }
}
