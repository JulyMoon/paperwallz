using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using RedditSharp;
using RedditSharp.Things;

namespace Paperwallz
{
    public partial class SettingsWindow : Form
    {
        private decimal oldHours, oldMinutes, oldSeconds;
        private TimeSpan timespan;
        private static readonly TimeSpan minimum = TimeSpan.FromSeconds(20);
        private bool gotUsername, gotPassword;
        private Reddit reddit;
        public bool Signedin { get; private set; }
        private string username;
        private string password;

        public string Username { get { return username; } set { SetText(usernameTextBox, value); } }
        public string Password { get { return password; } set { SetText(passwordTextBox, value); } }

        public TimeSpan Timespan
        {
            get { return timespan; }
            set
            {
                timespan = value;
                hoursNumeric.Value = oldHours = timespan.Hours;
                minutesNumeric.Value = oldMinutes = timespan.Minutes;
                secondsNumeric.Value = oldSeconds = timespan.Seconds;
            }
        }

        public SettingsWindow()
        {
            InitializeComponent();
        }

        public Subreddit GetWallpapers()
        {
            return reddit.GetSubreddit("wallpapers");
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

            SetText(textbox, textbox.Text);
        }

        private void TextBoxSelector(object sender, MouseEventArgs e)
        {
            var textbox = (TextBoxBase)sender;

            if (textbox.SelectionLength == 0)
                textbox.SelectAll();
        }

        private static string GetText(TextBoxBase textbox)
        {
            return MainWindow.HasText(textbox) ? textbox.Text : "";
        }

        public static void SetText(TextBoxBase textbox, string text)
        {
            if (text == "")
            {
                textbox.ForeColor = SystemColors.GrayText;
                textbox.Text = textbox.AccessibleName;
            }
            else
            {
                textbox.ForeColor = SystemColors.WindowText;
                textbox.Text = text;
            }
        }

        private void UpdateApply()
        {
            applyButton.Enabled = oldHours != hoursNumeric.Value ||
                                  oldMinutes != minutesNumeric.Value ||
                                  oldSeconds != secondsNumeric.Value;
        }

        private void SettingsWindow_Shown(object sender, EventArgs e)
        {
            Apply();

            var textbox = ActiveControl as TextBoxBase;
            if (textbox == null || MainWindow.HasText(textbox))
                return;
            
            TextBox_Enter(textbox, new EventArgs());
        }

        private void Apply()
        {
            oldHours = hoursNumeric.Value;
            oldMinutes = minutesNumeric.Value;
            oldSeconds = secondsNumeric.Value;
            applyButton.Enabled = false;
        }

        private void NumericValueChanged(object sender, EventArgs e)
        {
            UpdateApply();
        }

        public void SetReadOnly(bool enabled)
        {
            if (enabled)
            {
                usernameTextBox.ReadOnly = true;
                passwordTextBox.ReadOnly = true;

                hoursNumeric.ReadOnly = true;
                minutesNumeric.ReadOnly = true;
                secondsNumeric.ReadOnly = true;

                hoursNumeric.Increment = 0;
                minutesNumeric.Increment = 0;
                secondsNumeric.Increment = 0;
            }
            else
            {
                usernameTextBox.ReadOnly = false;
                passwordTextBox.ReadOnly = false;

                hoursNumeric.ReadOnly = false;
                minutesNumeric.ReadOnly = false;
                secondsNumeric.ReadOnly = false;

                hoursNumeric.Increment = 1;
                minutesNumeric.Increment = 1;
                secondsNumeric.Increment = 1;
            }
        }

        private void SettingsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
            {
                hoursNumeric.Value = oldHours;
                minutesNumeric.Value = oldMinutes;
                secondsNumeric.Value = oldSeconds;
            }

            timespan = new TimeSpan((int)hoursNumeric.Value, (int)minutesNumeric.Value, (int)secondsNumeric.Value);
            if (timespan < minimum)
            {
                timespan = minimum;

                hoursNumeric.Value = oldHours = timespan.Hours;
                minutesNumeric.Value = oldMinutes = timespan.Minutes;
                secondsNumeric.Value = oldSeconds = timespan.Seconds;
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            Apply();
        }

        private void UpdateSigninButton()
        {
            signinButton.Enabled = gotUsername && gotPassword;
        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            gotUsername = MainWindow.HasText(usernameTextBox);
            UpdateSigninButton();
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            gotPassword = MainWindow.HasText(passwordTextBox);
            UpdateSigninButton();
        }

        private void signinButton_Click(object sender, EventArgs e)
        {
            if (!Signedin)
            {
                signinButton.Enabled = false;
                signinLabel.Text = "Signing in...";
                backgroundWorker.RunWorkerAsync(new Credentials(GetText(usernameTextBox), GetText(passwordTextBox)));
            }
        }

        private struct Credentials
        {
            public readonly string Username, Password;

            public Credentials(string username, string password)
            {
                Username = username;
                Password = password;
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var args = (Credentials)e.Argument;

            Reddit reddit_;

            try
            {
                reddit_ = new Reddit(args.Username, args.Password);
                username = args.Username;
                password = args.Password;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Message: " + ex.Message + "\nSource: " + ex.Source + "\nStacktrace: " + ex.StackTrace);
                reddit_ = null;
            }

            e.Result = reddit_;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                signinLabel.Text = "Signed in";
                signinButton.Enabled = true;
                reddit = (Reddit)e.Result;
                Signedin = true;
            }
            else
            {
                Signedin = false;
            }
        }
    }
}
