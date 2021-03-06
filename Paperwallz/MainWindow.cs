﻿using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security.Authentication;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Paperwallz.Properties;
using RedditSharp;
using RedditSharp.Things;

// TODO: exception handling

namespace Paperwallz
{
    public partial class MainWindow : Form
    {
        private readonly AboutWindow aboutWindow = new AboutWindow();
        private readonly SettingsWindow settingsWindow = new SettingsWindow();
        private bool gotFile, gotTitle;
        private int selectedIndex = -1;
        private bool dragging;
        private TimeSpan timeLeft = TimeSpan.Zero;
        private TimeSpan maxTime;
        private bool submitting;
        private ListViewItem beingSubmitted;
        private readonly string[] essentialDlls = { "HtmlAgilityPack.dll", "Newtonsoft.Json.dll", "RedditSharp.dll", "ChreneLib.dll" };
        private const string clientId = "8ee17b899ab80c3";
        private readonly Imgur imgur = new Imgur(clientId);
        private Subreddit wallpapers;
        private bool signedin;
        private bool manuallyChangedTime;

        public MainWindow()
        {
            InitializeComponent();
            urlTextBox.Select();

            foreach (var dll in essentialDlls)
                // ReSharper disable once AssignNullToNotNullAttribute
                if (!File.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), dll)))
                {
                    MessageBox.Show(dll + " was not found. The application will now exit.", "Fatal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(1);
                }

            ReadConfig();
            UpdateTitle();
            UpdateTime();
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            if (Settings.Default.FirstTime)
            {
                ShowSettingsWindow();
                Settings.Default.FirstTime = false;
            }
        }

        private string GetItemTitle(int index)
        {
            return queueList.Items[index].SubItems[1].Text;
        }

        private string GetItemFile(int index)
        {
            return queueList.Items[index].SubItems[2].Text;
        }

        private static bool IsValidUrl(string s)
        {
            return s.Substring(1, 2) != ":\\";
        }

        private static string[] Separate(string pair)
        {
            var result = new string[2];
            int n = pair.IndexOf('=');
            result[0] = pair.Substring(0, n);
            result[1] = pair.Substring(n + 1, pair.Length - n - 1);
            return result;
        }

        private void UpdateSwitch()
        {
            switchButton.Enabled = timer.Enabled || (settingsWindow.GotCredentials() && queueList.Items.Count > 0);
        }

        private void ReadConfig()
        {
            maxTime = settingsWindow.Timespan = Settings.Default.MaxTime;

            var tl = Settings.Default.TimeLeft - (DateTime.Now - Settings.Default.SaveTime);
            if (tl < TimeSpan.Zero)
                tl = TimeSpan.Zero;

            timeLeft = tl;
            manuallyChangedTime = true;

            settingsWindow.Username = Settings.Default.Username;
            settingsWindow.Password = PseudoDecrypt(Settings.Default.Password);

            if (Settings.Default.Submissions[0] != "empty")
            {
                var submissions = new string[Settings.Default.Submissions.Count / 2][];
                for (int i = 0; i < submissions.Length; i++)
                    submissions[i] = new string[2];

                foreach (var pair in Settings.Default.Submissions)
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
                    }

                    submissions[n][m] = value;
                }

                for (int i = 0; i < submissions.Length; i++)
                    queueList.Items.Add(new ListViewItem(new[] { (i + 1).ToString(), submissions[i][0], submissions[i][1] }));
            }

            UpdateSwitch();

            if (Settings.Default.Height >= MinimumSize.Height && Settings.Default.Height <= MaximumSize.Height)
                Height = Settings.Default.Height;
        }

        private void UpdateAddButton()
        {
            addButton.Enabled = gotFile && gotTitle;
        }

        private void urlTextBox_TextChanged(object sender, EventArgs e)
        {
            gotFile = urlTextBox.Text != "";
            UpdateAddButton();
        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {
            gotTitle = titleTextBox.Text != "";
            UpdateAddButton();
        }

        private void imageControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (imageControl.SelectedIndex == 0)
                gotFile = urlTextBox.Text != "";
            else
                gotFile = openFileDialog.FileName != "";

            UpdateAddButton();
        }

        private struct ScriptArgs // maybe we can access these variables directly in DoWork?
        {
            public bool IsUrl;
            public string Title, File, Username, Password;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            string filename = Path.GetFileName(openFileDialog.FileName);

            const int maxFilenameLength = 29; // this is outdated. TODO: find the new value

            // ReSharper disable once PossibleNullReferenceException
            filenameLabel.Text = filename.Length > maxFilenameLength ?
                filename.Substring(0, maxFilenameLength - 3) + "..." : filename;

            gotFile = true;
            UpdateAddButton();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.reddit.com/r/wallpapers/new/");
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            aboutWindow.ShowDialog();
        }

        private static string Wallhaven(string url)
        {
            if (Regex.IsMatch(url, @"http://alpha.wallhaven.cc/wallpaper/\d+"))
            {
                string contents = new WebClient().DownloadString(url);
                int index = contents.IndexOf(@"content=""//", StringComparison.Ordinal);
                if (index != -1)
                {
                    index += 9;
                    return "http:" + contents.Substring(index,
                               contents.IndexOf(@"""", index, StringComparison.Ordinal) - index);
                }
                
                throw new Exception("Perhaps wallhaven changed their html pages?");
            }

            return url;
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var args = (ScriptArgs)e.Argument;

            try
            {
                if (!signedin)
                {
                    try
                    {
                        wallpapers = new Reddit(args.Username, args.Password).GetSubreddit("wallpapers");
                        signedin = true;
                    }
                    catch (AuthenticationException)
                    {
                        e.Result = "Bad username/password combination.";
                        return;
                    }
                }

                string description = "This image was uploaded using Paperwallz by /u/foxneZz. OP: /u/" + args.Username;

                Imgur.Image image;

                if (args.IsUrl)
                {
                    args.File = Wallhaven(args.File);

                    image = imgur.Upload(args.File, args.Title, description);
                }
                else
                {
                    try
                    {
                        image = imgur.Upload(new Bitmap(args.File), args.Title, description);
                    }
                    catch (WebException)
                    {
                        e.Result = "The image is too big or has bad format.";
                        return;
                    }
                }

                int i = 0;
                while (true)
                {
                    if (i == 5)
                    {
                        e.Result = "I can't post your wallpaper. I don't know why :(";
                        return;
                    }

                    try
                    {
                        wallpapers.SubmitPost(args.Title + " [" + image.Width + "×" + image.Height + "]", image.Link.ToString());
                        break;
                    }
                    catch (WebException)
                    {
                        i++;
                    }
                }

                e.Result = "Noice";
            }
            catch (Exception ex)
            {
                e.Result = "Exception: " + ex + "\nMessage: " + ex.Message + "\nSource: " + ex.Source;
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            submitting = false;

            string result = (string)e.Result;
            if (result != "Noice")
            {
                SwitchPosting(false);

                timeLeft = TimeSpan.Zero;
                UpdateTime();

                queueList.Items.Insert(0, beingSubmitted);
                UpdateListNumbers();
                UpdateSwitch();

                MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateTitle();
        }

        private void pasteButton_Click(object sender, EventArgs e)
        {
            if (!Clipboard.ContainsText() || Clipboard.GetText() == "")
                return;

            urlTextBox.Text = Clipboard.GetText();
        }

        private void queueList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            removeButton.Enabled = e.IsSelected;
            selectedIndex = e.IsSelected ? e.ItemIndex : -1;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            int selected = selectedIndex;
            queueList.Items.RemoveAt(selectedIndex);

            if (queueList.Items.Count == 0)
            {
                switchButton.Enabled = false;

                if (timer.Enabled)
                    SwitchPosting(false);
            }

            UpdateListNumbers();

            if (queueList.Items.Count == 0)
                return;

            if (queueList.Items.Count - 1 < selected)
                queueList.Items[queueList.Items.Count - 1].Selected = true;
            else
                queueList.Items[selected].Selected = true;
        }

        private void SaveSettings()
        {
            Settings.Default.Username = settingsWindow.Username;
            Settings.Default.Password = PseudoEncrypt(settingsWindow.Password);
            Settings.Default.MaxTime = maxTime;

            var submissions = new StringCollection();
            for (int i = 0; i < queueList.Items.Count; i++)
            {
                submissions.Add((i + 1) + " t=" + GetItemTitle(i));
                submissions.Add((i + 1) + " f=" + GetItemFile(i));
            }

            if (submissions.Count == 0)
                submissions.Add("empty");

            Settings.Default.Submissions = submissions;
            Settings.Default.Height = Height;
            Settings.Default.TimeLeft = timeLeft;
            Settings.Default.SaveTime = DateTime.Now;

            Settings.Default.Save();
        }

        private void addButton_Click(object sender, EventArgs e) // TODO: validate
        {
            string file;

            if (imageControl.SelectedIndex == 0)
            {
                file = urlTextBox.Text.Trim();
                if (!Uri.IsWellFormedUriString(file, UriKind.Absolute))
                {
                    MessageBox.Show("Something's wrong with your url. Perhaps you're missing the \"http\" part.",
                        "Invalid url", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
                file = openFileDialog.FileName;

            foreach (ListViewItem item in queueList.Items)
                if (file == item.SubItems[2].Text)
                {
                    MessageBox.Show("You've already added this wallpaper.", "This wallpaper is already in queue",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            string number = (queueList.Items.Count + 1).ToString();
            string title = titleTextBox.Text;

            queueList.Items.Add(new ListViewItem(new[] {number, title, file}));
            UpdateSwitch();

            if (imageControl.SelectedIndex == 0)
                urlTextBox.Text = "";
            else
                openFileDialog.FileName = filenameLabel.Text = "";

            titleTextBox.Text = "";
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

                dragging = false;
                submitting = true;
                UpdateTitle();

                beingSubmitted = queueList.Items[0];
                queueList.Items.RemoveAt(0);
                UpdateListNumbers();

                if (queueList.Items.Count == 0)
                {
                    SwitchPosting(false);
                    switchButton.Enabled = false;
                }

                backgroundWorker.RunWorkerAsync(new ScriptArgs
                {
                    Title = beingSubmitted.SubItems[1].Text,
                    File = beingSubmitted.SubItems[2].Text,
                    IsUrl = IsValidUrl(beingSubmitted.SubItems[2].Text),
                    Username = settingsWindow.Username,
                    Password = settingsWindow.Password
                });
            }

            UpdateTitle();
            UpdateTime();
        }

        private void UpdateListNumbers()
        {
            for (int i = 0; i < queueList.Items.Count; i++)
                queueList.Items[i].SubItems[0].Text = (i + 1).ToString();
        }

        private void UpdateTime()
        {
            UpdateTimeLabel();
            trackBar.Value = (int)((1 - ((double)timeLeft.Ticks / maxTime.Ticks)) * trackBar.Maximum);
        }

        private void UpdateTimeLabel()
        {
            timeLeftLabel.Text = ReadableTime(timeLeft);
        }

        private static string ReadableTime(TimeSpan time)
        {
            return time.Hours + ":" + TwoDigits(time.Minutes) + ":" + TwoDigits(time.Seconds);
        }

        private static string TwoDigits(int number)
        {
            return number < 10 ? "0" + number : number.ToString();
        }

        private void switchButton_Click(object sender, EventArgs e)
        {
            SwitchPosting(!timer.Enabled);
        }

        private void UpdateTitle()
        {
            notifyIcon.Text = Text = Application.ProductName +
                                     (timer.Enabled ? " - ON - " + ReadableTime(timeLeft) : " - OFF") +
                                     (submitting ? " - S" : "");
        }

        private void SwitchPosting(bool start)
        {
            if (start)
            {
                settingsWindow.SetReadOnly(true);
                timer.Start();
                switchButton.Text = "Stop";
                trackBar.Enabled = false;
            }
            else
            {
                timer.Stop();
                settingsWindow.SetReadOnly(false);
                switchButton.Text = "Start";
                trackBar.Enabled = true;
            }

            UpdateTitle();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            ShowSettingsWindow();
        }

        private void ShowSettingsWindow()
        {
            var oldPassword = settingsWindow.Password;
            var oldUsername = settingsWindow.Username;

            settingsWindow.ShowDialog();
            
            maxTime = settingsWindow.Timespan;
            if (maxTime < timeLeft)
                timeLeft = maxTime;
            manuallyChangedTime = true;

            if (oldUsername != settingsWindow.Username || oldPassword != settingsWindow.Password)
                signedin = false;

            UpdateTime();
            UpdateSwitch();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            SaveSettings();
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Show();
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Minimized;
                Hide();
            }
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                Hide();
        }

        private void queueList_ItemActivate(object sender, EventArgs e)
        {
            string file = queueList.Items[selectedIndex].SubItems[2].Text;

            if (IsValidUrl(file))
                Process.Start(file); // TODO: validate input so this doesnt throw an exception
            else
            {
                if (!File.Exists(file))
                {
                    MessageBox.Show("Wallpaper not found. The queue will stop if this file will start submitting. You better delete it now.",
                        "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Process.Start("explorer.exe", "/select, " + "\"" + file + "\"");
            }
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            if (!trackBar.Enabled)
                return;

            if (manuallyChangedTime)
            {
                manuallyChangedTime = false;
                return;
            }

            timeLeft = new TimeSpan((long)Math.Round((1 - (double)trackBar.Value / trackBar.Maximum) * maxTime.Ticks));

            UpdateTimeLabel();
        }

        private static string PseudoEncrypt(string s)
        {
            return Convert.ToBase64String(Magic(Encoding.Unicode.GetBytes(s)));
        }

        private static byte[] Magic(byte[] bytes)
        {
            for (int i = 0; i < bytes.Length; i++)
                bytes[i] ^= 98;

            return bytes;
        }

        private static string PseudoDecrypt(string s)
        {
            return Encoding.Unicode.GetString(Magic(Convert.FromBase64String(s)));
        }
    }
}