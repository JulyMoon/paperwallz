using System;
using System.Windows.Forms;

namespace Paperwallz
{
    public partial class SettingsWindow : Form
    {
        private decimal oldHours, oldMinutes, oldSeconds;
        private string oldUsername, oldPassword;
        private TimeSpan timespan;
        private static readonly TimeSpan minimum = TimeSpan.FromSeconds(30);

        public string Username
        {
            get { return usernameTextBox.Text; }
            set { usernameTextBox.Text = value; }
        }

        public string Password
        {
            get { return passwordTextBox.Text; }
            set { passwordTextBox.Text = value; }
        }

        public TimeSpan Timespan
        {
            get { return timespan; }
            set
            {
                timespan = value < minimum ? minimum : value;
                hoursNumeric.Value = oldHours = timespan.Hours;
                minutesNumeric.Value = oldMinutes = timespan.Minutes;
                secondsNumeric.Value = oldSeconds = timespan.Seconds;
            }
        }

        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateApply();
        }

        private void UpdateApply()
        {
            applyButton.Enabled = oldHours != hoursNumeric.Value ||
                                  oldMinutes != minutesNumeric.Value ||
                                  oldSeconds != secondsNumeric.Value ||
                                  oldUsername != Username ||
                                  oldPassword != Password;
        }

        private void SettingsWindow_Shown(object sender, EventArgs e)
        {
            Apply();
        }

        private void Apply()
        {
            oldHours = hoursNumeric.Value;
            oldMinutes = minutesNumeric.Value;
            oldSeconds = secondsNumeric.Value;
            oldUsername = Username;
            oldPassword = Password;
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
                Username = oldUsername;
                Password = oldPassword;
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

        public bool GotCredentials()
        {
            return Username != "" && Password != "";
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            Apply();
        }
    }
}
