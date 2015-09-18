using System;
using System.Windows.Forms;

namespace BasicEyetrackingSample
{
    partial class TrackerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this._changeButton = new System.Windows.Forms.Button();
            this._box1 = new System.Windows.Forms.GroupBox();
            this._connectButton = new System.Windows.Forms.Button();
            this._trackerInfoLabel = new System.Windows.Forms.Label();
            this._trackerList = new System.Windows.Forms.ListView();
            this._statusStrip = new System.Windows.Forms.StatusStrip();
            this._connectionStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._box2 = new System.Windows.Forms.GroupBox();
            this._calibrateButton = new System.Windows.Forms.Button();
            this._trackButton = new System.Windows.Forms.Button();
            this._goBackButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._framerateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._saveCalibrationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._viewCalibrationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._loadCalibrationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this._blurLevel = new System.Windows.Forms.ComboBox();
            this._blurLevelLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._numberOfImages = new System.Windows.Forms.ComboBox();
            this.radiusBox = new System.Windows.Forms.ComboBox();
            this.radiusLabel = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this._box1.SuspendLayout();
            this._statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _changeButton
            // 
            this._changeButton.Location = new System.Drawing.Point(69, 763);
            this._changeButton.Name = "_changeButton";
            this._changeButton.Size = new System.Drawing.Size(111, 27);
            this._changeButton.TabIndex = 22;
            this._changeButton.Text = "Apply Changes";
            this._changeButton.UseVisualStyleBackColor = true;
            this._changeButton.Click += new System.EventHandler(this._changeButton_Click);
            // 
            // _box1
            // 
            this._box1.Controls.Add(this._connectButton);
            this._box1.Controls.Add(this._trackerInfoLabel);
            this._box1.Controls.Add(this._trackerList);
            this._box1.Location = new System.Drawing.Point(13, 38);
            this._box1.Name = "_box1";
            this._box1.Size = new System.Drawing.Size(237, 373);
            this._box1.TabIndex = 1;
            this._box1.TabStop = false;
            this._box1.Text = "Eyetrackers Found on the  Network";
            // 
            // _connectButton
            // 
            this._connectButton.Enabled = false;
            this._connectButton.Location = new System.Drawing.Point(45, 334);
            this._connectButton.Name = "_connectButton";
            this._connectButton.Size = new System.Drawing.Size(142, 27);
            this._connectButton.TabIndex = 2;
            this._connectButton.Text = "Connect to Eyetracker";
            this._connectButton.UseVisualStyleBackColor = true;
            this._connectButton.Click += new System.EventHandler(this._connectButton_Click);
            // 
            // _trackerInfoLabel
            // 
            this._trackerInfoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._trackerInfoLabel.Location = new System.Drawing.Point(19, 225);
            this._trackerInfoLabel.Name = "_trackerInfoLabel";
            this._trackerInfoLabel.Size = new System.Drawing.Size(196, 95);
            this._trackerInfoLabel.TabIndex = 1;
            // 
            // _trackerList
            // 
            this._trackerList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._trackerList.Location = new System.Drawing.Point(19, 33);
            this._trackerList.MultiSelect = false;
            this._trackerList.Name = "_trackerList";
            this._trackerList.ShowItemToolTips = true;
            this._trackerList.Size = new System.Drawing.Size(196, 179);
            this._trackerList.TabIndex = 0;
            this._trackerList.UseCompatibleStateImageBehavior = false;
            this._trackerList.View = System.Windows.Forms.View.SmallIcon;
            this._trackerList.SelectedIndexChanged += new System.EventHandler(this._trackerList_SelectedIndexChanged);
            // 
            // _statusStrip
            // 
            this._statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._connectionStatusLabel});
            this._statusStrip.Location = new System.Drawing.Point(0, 1165);
            this._statusStrip.Name = "_statusStrip";
            this._statusStrip.Size = new System.Drawing.Size(1920, 22);
            this._statusStrip.TabIndex = 2;
            this._statusStrip.Text = "statusStrip1";
            // 
            // _connectionStatusLabel
            // 
            this._connectionStatusLabel.Name = "_connectionStatusLabel";
            this._connectionStatusLabel.Size = new System.Drawing.Size(71, 17);
            this._connectionStatusLabel.Text = "Disconnected";
            // 
            // _box2
            // 
            this._box2.Location = new System.Drawing.Point(256, 38);
            this._box2.Name = "_box2";
            this._box2.Size = new System.Drawing.Size(1620, 1100);
            this._box2.TabIndex = 3;
            this._box2.TabStop = false;
            this._box2.Text = "Eyetracker Status";
            // 
            // _calibrateButton
            // 
            this._calibrateButton.Location = new System.Drawing.Point(69, 501);
            this._calibrateButton.Name = "_calibrateButton";
            this._calibrateButton.Size = new System.Drawing.Size(111, 27);
            this._calibrateButton.TabIndex = 2;
            this._calibrateButton.Text = "Run Calibration";
            this._calibrateButton.UseVisualStyleBackColor = true;
            this._calibrateButton.Click += new System.EventHandler(this._calibrateButton_Click);
            // 
            // _trackButton
            // 
            this._trackButton.Location = new System.Drawing.Point(69, 451);
            this._trackButton.Name = "_trackButton";
            this._trackButton.Size = new System.Drawing.Size(111, 27);
            this._trackButton.TabIndex = 0;
            this._trackButton.Text = "Start Tracking";
            this._trackButton.UseVisualStyleBackColor = true;
            this._trackButton.Click += new System.EventHandler(this._trackButton_Click);
            // 
            // _goBackButton
            // 
            this._goBackButton.Location = new System.Drawing.Point(58, 1081);
            this._goBackButton.Name = "_goBackButton";
            this._goBackButton.Size = new System.Drawing.Size(142, 57);
            this._goBackButton.TabIndex = 0;
            this._goBackButton.Text = "Go Back To Main Screen";
            this._goBackButton.UseVisualStyleBackColor = true;
            this._goBackButton.Click += new System.EventHandler(this._goBackButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageToolStripMenuItem,
            this.propertiesToolStripMenuItem,
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1920, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "_menuStrip";
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importImageToolStripMenuItem,
            this.createImageToolStripMenuItem});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.imageToolStripMenuItem.Text = "File";
            // 
            // importImageToolStripMenuItem
            // 
            this.importImageToolStripMenuItem.Name = "importImageToolStripMenuItem";
            this.importImageToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.importImageToolStripMenuItem.Text = "Open Image";
            this.importImageToolStripMenuItem.Click += new System.EventHandler(this.importImageToolStripMenuItem_Click);
            // 
            // createImageToolStripMenuItem
            // 
            this.createImageToolStripMenuItem.Name = "createImageToolStripMenuItem";
            this.createImageToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.createImageToolStripMenuItem.Text = "Create Image";
            this.createImageToolStripMenuItem.Click += new System.EventHandler(this.createImageToolStripMenuItem_Click);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._framerateMenuItem});
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.propertiesToolStripMenuItem.Text = "Properties";
            // 
            // _framerateMenuItem
            // 
            this._framerateMenuItem.Name = "_framerateMenuItem";
            this._framerateMenuItem.Size = new System.Drawing.Size(139, 22);
            this._framerateMenuItem.Text = "FrameRate...";
            this._framerateMenuItem.Click += new System.EventHandler(this._framerateMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._saveCalibrationMenuItem,
            this._viewCalibrationMenuItem,
            this._loadCalibrationMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.fileToolStripMenuItem.Text = "Caliberation";
            // 
            // _saveCalibrationMenuItem
            // 
            this._saveCalibrationMenuItem.Name = "_saveCalibrationMenuItem";
            this._saveCalibrationMenuItem.Size = new System.Drawing.Size(152, 22);
            this._saveCalibrationMenuItem.Text = "Save Calibration";
            this._saveCalibrationMenuItem.Click += new System.EventHandler(this._saveCalibrationMenuItem_Click);
            // 
            // _viewCalibrationMenuItem
            // 
            this._viewCalibrationMenuItem.Name = "_viewCalibrationMenuItem";
            this._viewCalibrationMenuItem.Size = new System.Drawing.Size(152, 22);
            this._viewCalibrationMenuItem.Text = "View Calibration";
            this._viewCalibrationMenuItem.Click += new System.EventHandler(this._viewCalibrationMenuItem_Click);
            // 
            // _loadCalibrationMenuItem
            // 
            this._loadCalibrationMenuItem.Name = "_loadCalibrationMenuItem";
            this._loadCalibrationMenuItem.Size = new System.Drawing.Size(152, 22);
            this._loadCalibrationMenuItem.Text = "Load Calibration";
            this._loadCalibrationMenuItem.Click += new System.EventHandler(this._loadCalibrationMenuItem_Click);
            // 
            // _openFileDialog
            // 
            this._openFileDialog.DefaultExt = "calib";
            this._openFileDialog.FileName = "file";
            this._openFileDialog.Filter = "Calibration Files |*.calib";
            this._openFileDialog.Title = "Load Calibration File";
            // 
            // _saveFileDialog
            // 
            this._saveFileDialog.DefaultExt = "calib";
            this._saveFileDialog.FileName = "file";
            this._saveFileDialog.Filter = "Calibration Files|*.calib";
            this._saveFileDialog.Title = "Save Calibration File";
            // 
            // _blurLevel
            // 
            this._blurLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._blurLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._blurLevel.FormattingEnabled = true;
            this._blurLevel.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this._blurLevel.Location = new System.Drawing.Point(126, 598);
            this._blurLevel.Name = "_blurLevel";
            this._blurLevel.Size = new System.Drawing.Size(112, 28);
            this._blurLevel.TabIndex = 16;
            this.toolTip.SetToolTip(this._blurLevel, "THIS MIGHT TAKE LONG TIME");
            // 
            // _blurLevelLabel
            // 
            this._blurLevelLabel.AutoSize = true;
            this._blurLevelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._blurLevelLabel.Location = new System.Drawing.Point(22, 601);
            this._blurLevelLabel.Name = "_blurLevelLabel";
            this._blurLevelLabel.Size = new System.Drawing.Size(98, 20);
            this._blurLevelLabel.TabIndex = 15;
            this._blurLevelLabel.Text = "Blur Factor:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 651);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Number of Circles:";
            // 
            // _numberOfImages
            // 
            this._numberOfImages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._numberOfImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._numberOfImages.FormattingEnabled = true;
            this._numberOfImages.Items.AddRange(new object[] {
            "5",
            "10"});
            this._numberOfImages.Location = new System.Drawing.Point(165, 648);
            this._numberOfImages.Name = "_numberOfImages";
            this._numberOfImages.Size = new System.Drawing.Size(73, 28);
            this._numberOfImages.TabIndex = 18;
            // 
            // radiusBox
            // 
            this.radiusBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.radiusBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radiusBox.FormattingEnabled = true;
            this.radiusBox.Items.AddRange(new object[] {
            "400",
            "500",
            "600",
            "700"});
            this.radiusBox.Location = new System.Drawing.Point(117, 698);
            this.radiusBox.Name = "radiusBox";
            this.radiusBox.Size = new System.Drawing.Size(121, 28);
            this.radiusBox.TabIndex = 21;
            // 
            // radiusLabel
            // 
            this.radiusLabel.AutoSize = true;
            this.radiusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radiusLabel.Location = new System.Drawing.Point(31, 701);
            this.radiusLabel.Name = "radiusLabel";
            this.radiusLabel.Size = new System.Drawing.Size(66, 20);
            this.radiusLabel.TabIndex = 20;
            this.radiusLabel.Text = "Radius:";
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
            this.toolTip.ShowAlways = true;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // TrackerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1187);
            this.Controls.Add(this._changeButton);
            this.Controls.Add(this.radiusBox);
            this.Controls.Add(this.radiusLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._numberOfImages);
            this.Controls.Add(this._blurLevel);
            this.Controls.Add(this._blurLevelLabel);
            this.Controls.Add(this._calibrateButton);
            this.Controls.Add(this._box2);
            this.Controls.Add(this._statusStrip);
            this.Controls.Add(this._trackButton);
            this.Controls.Add(this._goBackButton);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this._box1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TrackerForm";
            this.Text = "SDK - Basic Eyetracking Sample";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this._box1.ResumeLayout(false);
            this._statusStrip.ResumeLayout(false);
            this._statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox _box1;
        private System.Windows.Forms.ListView _trackerList;
        private System.Windows.Forms.Label _trackerInfoLabel;
        private System.Windows.Forms.Button _connectButton;
        private System.Windows.Forms.StatusStrip _statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel _connectionStatusLabel;
        private System.Windows.Forms.GroupBox _box2;
        private System.Windows.Forms.Button _trackButton;
        private System.Windows.Forms.Button _goBackButton;
        private TrackStatusControl _trackStatus;
        private System.Windows.Forms.Button _calibrateButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _saveCalibrationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _viewCalibrationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _loadCalibrationMenuItem;
        private System.Windows.Forms.OpenFileDialog _openFileDialog;
        private System.Windows.Forms.SaveFileDialog _saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _framerateMenuItem;
        private ToolStripMenuItem imageToolStripMenuItem;
        private ToolStripMenuItem importImageToolStripMenuItem;
        private ComboBox _blurLevel;
        private Label _blurLevelLabel;
        private Label label1;
        private ComboBox _numberOfImages;
        private ComboBox radiusBox;
        private Label radiusLabel;
        private Button _changeButton;
        private ToolTip toolTip;
        private ToolStripMenuItem createImageToolStripMenuItem;
    }
}

