using System;
using System.Drawing;
using System.Windows.Forms;

namespace Paperwallz
{
    public partial class SettingsWindow : Form
    {
        public bool gotUsername, gotPassword;
        private decimal oldHours, oldMinutes, oldSeconds;
        private string oldUsername, oldPassword;
        public TimeSpan timespan;
        //private readonly MainWindow mw;

        public SettingsWindow()
        {
            InitializeComponent();
            //mw = (MainWindow)Parent;

            timespan = new TimeSpan((int)hoursNumeric.Value, (int)minutesNumeric.Value, (int)secondsNumeric.Value);
        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            gotUsername = MainWindow.HasText(usernameTextBox);
            UpdateApply();
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            gotPassword = MainWindow.HasText(passwordTextBox);
            UpdateApply();
        }

        private void TextBoxHandler(object sender, EventArgs e)
        { // WARNING: THIS METHOD WAS COPY-PASTED
            var textbox = (TextBoxBase)sender;

            if (ActiveControl == textbox) //maybe just separate TextBoxHandler into 2 methods?
            {
                if (textbox.ForeColor == SystemColors.GrayText)
                {
                    textbox.ForeColor = SystemColors.WindowText;
                    textbox.Text = "";
                }
                else
                    //BeginInvoke((Action)textbox.SelectAll); maybe?
                    BeginInvoke((Action)delegate { textbox.SelectAll(); });
            }
            else if (textbox.Text == "")
            {
                textbox.ForeColor = SystemColors.GrayText;
                textbox.Text = textbox.AccessibleName;
            }
        }

        private void TextBoxSelector(object sender, MouseEventArgs e)
        { // WARNING: THIS METHOD WAS COPY-PASTED
            var textbox = (TextBoxBase)sender;

            if (textbox.SelectionLength == 0)
                textbox.SelectAll();
        }

        private static string GetText(TextBoxBase textbox)
        {
            return MainWindow.HasText(textbox) ? textbox.Text : "";
        }

        private static void SetText(TextBoxBase textbox, string text)
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

        private void SettingsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.Cancel)
                return;

            hoursNumeric.Value = oldHours;
            minutesNumeric.Value = oldMinutes;
            secondsNumeric.Value = oldSeconds;
            SetText(usernameTextBox, oldUsername);
            SetText(passwordTextBox, oldPassword);
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            Apply();
        }
    }
}
