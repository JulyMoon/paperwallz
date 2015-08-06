using System.ComponentModel;
using System.Windows.Forms;

namespace Paperwallz
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "1",
            "asd11",
            "Salt",
            "No"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "2",
            "Lmaokay",
            "http://lmao.jpg",
            "Yes"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.browseButton = new System.Windows.Forms.Button();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.openButton = new System.Windows.Forms.Button();
            this.titleTextBox = new System.Windows.Forms.RichTextBox();
            this.aboutButton = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.pasteButton = new System.Windows.Forms.Button();
            this.imageControl = new System.Windows.Forms.TabControl();
            this.urlTab = new System.Windows.Forms.TabPage();
            this.pcTab = new System.Windows.Forms.TabPage();
            this.filenameLabel = new System.Windows.Forms.Label();
            this.queueList = new System.Windows.Forms.ListView();
            this.numberColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.titleColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.internetColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.switchButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.descriptiveLabel = new System.Windows.Forms.Label();
            this.timeLeftLabel = new System.Windows.Forms.Label();
            this.settingsButton = new System.Windows.Forms.Button();
            this.imageControl.SuspendLayout();
            this.urlTab.SuspendLayout();
            this.pcTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Images|*.png;*.jpg;*.jpeg;*.gif;*.bmp";
            this.openFileDialog.Title = "Submit an image";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(6, 6);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(72, 24);
            this.browseButton.TabIndex = 6;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // urlTextBox
            // 
            this.urlTextBox.AccessibleName = "Image url";
            this.urlTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.urlTextBox.Location = new System.Drawing.Point(84, 9);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(200, 20);
            this.urlTextBox.TabIndex = 5;
            this.urlTextBox.Text = "Image url";
            this.urlTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxSelector);
            this.urlTextBox.TextChanged += new System.EventHandler(this.urlTextBox_TextChanged);
            this.urlTextBox.Enter += new System.EventHandler(this.TextBox_Enter);
            this.urlTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(164, 196);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(51, 27);
            this.openButton.TabIndex = 10;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // titleTextBox
            // 
            this.titleTextBox.AccessibleName = "The title goes here";
            this.titleTextBox.DetectUrls = false;
            this.titleTextBox.Font = new System.Drawing.Font("Verdana", 14F);
            this.titleTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.titleTextBox.Location = new System.Drawing.Point(12, 80);
            this.titleTextBox.MaxLength = 250;
            this.titleTextBox.Multiline = false;
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(298, 31);
            this.titleTextBox.TabIndex = 7;
            this.titleTextBox.Text = "The title goes here";
            this.titleTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxSelector);
            this.titleTextBox.TextChanged += new System.EventHandler(this.titleTextBox_TextChanged);
            this.titleTextBox.Enter += new System.EventHandler(this.TextBox_Enter);
            this.titleTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // aboutButton
            // 
            this.aboutButton.Location = new System.Drawing.Point(107, 196);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(51, 27);
            this.aboutButton.TabIndex = 8;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // pasteButton
            // 
            this.pasteButton.Location = new System.Drawing.Point(6, 6);
            this.pasteButton.Name = "pasteButton";
            this.pasteButton.Size = new System.Drawing.Size(72, 24);
            this.pasteButton.TabIndex = 7;
            this.pasteButton.Text = "Paste";
            this.pasteButton.UseVisualStyleBackColor = true;
            this.pasteButton.Click += new System.EventHandler(this.pasteButton_Click);
            // 
            // imageControl
            // 
            this.imageControl.Controls.Add(this.urlTab);
            this.imageControl.Controls.Add(this.pcTab);
            this.imageControl.Location = new System.Drawing.Point(12, 12);
            this.imageControl.Name = "imageControl";
            this.imageControl.SelectedIndex = 0;
            this.imageControl.Size = new System.Drawing.Size(298, 62);
            this.imageControl.TabIndex = 11;
            this.imageControl.SelectedIndexChanged += new System.EventHandler(this.imageControl_SelectedIndexChanged);
            // 
            // urlTab
            // 
            this.urlTab.BackColor = System.Drawing.Color.White;
            this.urlTab.Controls.Add(this.urlTextBox);
            this.urlTab.Controls.Add(this.pasteButton);
            this.urlTab.Location = new System.Drawing.Point(4, 22);
            this.urlTab.Name = "urlTab";
            this.urlTab.Padding = new System.Windows.Forms.Padding(3);
            this.urlTab.Size = new System.Drawing.Size(290, 36);
            this.urlTab.TabIndex = 0;
            this.urlTab.Text = "Upload from the internet";
            // 
            // pcTab
            // 
            this.pcTab.BackColor = System.Drawing.Color.White;
            this.pcTab.Controls.Add(this.filenameLabel);
            this.pcTab.Controls.Add(this.browseButton);
            this.pcTab.Location = new System.Drawing.Point(4, 22);
            this.pcTab.Name = "pcTab";
            this.pcTab.Padding = new System.Windows.Forms.Padding(3);
            this.pcTab.Size = new System.Drawing.Size(290, 36);
            this.pcTab.TabIndex = 1;
            this.pcTab.Text = "Upload from this PC";
            // 
            // filenameLabel
            // 
            this.filenameLabel.AutoSize = true;
            this.filenameLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filenameLabel.Location = new System.Drawing.Point(79, 12);
            this.filenameLabel.Name = "filenameLabel";
            this.filenameLabel.Size = new System.Drawing.Size(0, 14);
            this.filenameLabel.TabIndex = 7;
            // 
            // queueList
            // 
            this.queueList.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.queueList.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.queueList.AllowColumnReorder = true;
            this.queueList.AutoArrange = false;
            this.queueList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.numberColumn,
            this.titleColumn,
            this.fileColumn,
            this.internetColumn});
            this.queueList.FullRowSelect = true;
            this.queueList.GridLines = true;
            this.queueList.HideSelection = false;
            listViewItem2.StateImageIndex = 0;
            this.queueList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.queueList.LabelEdit = true;
            this.queueList.Location = new System.Drawing.Point(316, 12);
            this.queueList.MultiSelect = false;
            this.queueList.Name = "queueList";
            this.queueList.ShowGroups = false;
            this.queueList.Size = new System.Drawing.Size(298, 211);
            this.queueList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.queueList.TabIndex = 13;
            this.queueList.UseCompatibleStateImageBehavior = false;
            this.queueList.View = System.Windows.Forms.View.Details;
            this.queueList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.queueList_ItemDrag);
            this.queueList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.queueList_ItemSelectionChanged);
            this.queueList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.queueList_MouseUp);
            // 
            // numberColumn
            // 
            this.numberColumn.Text = "#";
            this.numberColumn.Width = 32;
            // 
            // titleColumn
            // 
            this.titleColumn.Text = "Title";
            this.titleColumn.Width = 121;
            // 
            // fileColumn
            // 
            this.fileColumn.Text = "File";
            this.fileColumn.Width = 93;
            // 
            // internetColumn
            // 
            this.internetColumn.Text = "Internet";
            this.internetColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.internetColumn.Width = 48;
            // 
            // addButton
            // 
            this.addButton.Enabled = false;
            this.addButton.Location = new System.Drawing.Point(129, 117);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(181, 27);
            this.addButton.TabIndex = 14;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Enabled = false;
            this.removeButton.Location = new System.Drawing.Point(12, 117);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(111, 27);
            this.removeButton.TabIndex = 15;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // switchButton
            // 
            this.switchButton.Enabled = false;
            this.switchButton.Location = new System.Drawing.Point(221, 196);
            this.switchButton.Name = "switchButton";
            this.switchButton.Size = new System.Drawing.Size(89, 27);
            this.switchButton.TabIndex = 16;
            this.switchButton.Text = "Start";
            this.switchButton.UseVisualStyleBackColor = true;
            this.switchButton.Click += new System.EventHandler(this.switchButton_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 150);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(298, 27);
            this.progressBar.TabIndex = 17;
            // 
            // descriptiveLabel
            // 
            this.descriptiveLabel.AutoSize = true;
            this.descriptiveLabel.Location = new System.Drawing.Point(12, 180);
            this.descriptiveLabel.Name = "descriptiveLabel";
            this.descriptiveLabel.Size = new System.Drawing.Size(149, 13);
            this.descriptiveLabel.TabIndex = 18;
            this.descriptiveLabel.Text = "Time left until next submission:";
            // 
            // timeLeftLabel
            // 
            this.timeLeftLabel.AutoSize = true;
            this.timeLeftLabel.Location = new System.Drawing.Point(261, 180);
            this.timeLeftLabel.Name = "timeLeftLabel";
            this.timeLeftLabel.Size = new System.Drawing.Size(49, 13);
            this.timeLeftLabel.TabIndex = 19;
            this.timeLeftLabel.Text = "00:00:00";
            // 
            // settingsButton
            // 
            this.settingsButton.Location = new System.Drawing.Point(12, 196);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(89, 27);
            this.settingsButton.TabIndex = 20;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 235);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.timeLeftLabel);
            this.Controls.Add(this.descriptiveLabel);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.switchButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.queueList);
            this.Controls.Add(this.imageControl);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.aboutButton);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paperwallz [OFF]";
            this.imageControl.ResumeLayout(false);
            this.urlTab.ResumeLayout(false);
            this.urlTab.PerformLayout();
            this.pcTab.ResumeLayout(false);
            this.pcTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenFileDialog openFileDialog;
        private Button browseButton;
        private RichTextBox titleTextBox;
        private TextBox urlTextBox;
        private Button aboutButton;
        private Button openButton;
        private BackgroundWorker backgroundWorker;
        private Button pasteButton;
        private TabControl imageControl;
        private TabPage urlTab;
        private TabPage pcTab;
        private Label filenameLabel;
        private ListView queueList;
        private ColumnHeader numberColumn;
        private ColumnHeader titleColumn;
        private ColumnHeader fileColumn;
        private ColumnHeader internetColumn;
        private Button addButton;
        private Button removeButton;
        private Button switchButton;
        private Timer timer;
        private ProgressBar progressBar;
        private Label descriptiveLabel;
        private Label timeLeftLabel;
        private Button settingsButton;
    }
}

