using System;
using System.Drawing;
using System.Windows.Forms;

namespace Paperwallz
{
    public partial class SettingsWindow : Form
    {
        private decimal oldHours, oldMinutes, oldSeconds;
        private string oldUsername, oldPassword;
        private TimeSpan timespan;
        private static readonly TimeSpan minimum = TimeSpan.FromSeconds(20);

        public string Username
        {
            get { return GetText(usernameTextBox); }
            set { SetText(usernameTextBox, value); }
        }

        public string Password
        {
            get { return GetText(passwordTextBox); }
            set { SetText(passwordTextBox, value); }
        }

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

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateApply();
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
                                  oldSeconds != secondsNumeric.Value ||
                                  oldUsername != GetText(usernameTextBox) ||
                                  oldPassword != GetText(passwordTextBox);
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
            oldUsername = GetText(usernameTextBox);
            oldPassword = GetText(passwordTextBox);
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
                SetText(usernameTextBox, oldUsername);
                SetText(passwordTextBox, oldPassword);
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
            return MainWindow.HasText(usernameTextBox) && MainWindow.HasText(passwordTextBox);
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            Apply();
        }
    }
}
