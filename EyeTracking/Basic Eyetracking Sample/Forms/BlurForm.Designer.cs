﻿using System.Windows.Forms;

namespace BasicEyetrackingSample
{
    partial class BlurForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlurForm));
            this._BlurImageLabel = new System.Windows.Forms.Label();
            this._ImagePath = new System.Windows.Forms.TextBox();
            this._ImportImageButton = new System.Windows.Forms.Button();
            this._blurButton = new System.Windows.Forms.Button();
            this._blurLevelLabel = new System.Windows.Forms.Label();
            this._LowestBlurLevel = new System.Windows.Forms.PictureBox();
            this._LowestBlurLabel = new System.Windows.Forms.Label();
            this._HighestBlurLabel = new System.Windows.Forms.Label();
            this._GobackButton = new System.Windows.Forms.Button();
            this._HighestBlurLevel = new System.Windows.Forms.PictureBox();
            this._blurLevel = new System.Windows.Forms.ComboBox();
            this._saveButton = new System.Windows.Forms.Button();
            this._numberImages = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._LowestBlurLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._HighestBlurLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // _BlurImageLabel
            // 
            this._BlurImageLabel.AutoSize = true;
            this._BlurImageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._BlurImageLabel.Location = new System.Drawing.Point(44, 88);
            this._BlurImageLabel.Name = "_BlurImageLabel";
            this._BlurImageLabel.Size = new System.Drawing.Size(98, 20);
            this._BlurImageLabel.TabIndex = 0;
            this._BlurImageLabel.Text = "Image Path:";
            // 
            // _ImagePath
            // 
            this._ImagePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ImagePath.ForeColor = System.Drawing.SystemColors.GrayText;
            this._ImagePath.Location = new System.Drawing.Point(148, 85);
            this._ImagePath.Name = "_ImagePath";
            this._ImagePath.Size = new System.Drawing.Size(236, 26);
            this._ImagePath.TabIndex = 1;
            this._ImagePath.Text = "Enter File Path";
            // 
            // _ImportImageButton
            // 
            this._ImportImageButton.Location = new System.Drawing.Point(390, 85);
            this._ImportImageButton.Name = "_ImportImageButton";
            this._ImportImageButton.Size = new System.Drawing.Size(95, 26);
            this._ImportImageButton.TabIndex = 2;
            this._ImportImageButton.Text = "Browse";
            this._ImportImageButton.UseVisualStyleBackColor = true;
            this._ImportImageButton.Click += new System.EventHandler(this._ImportImageButton_Click);
            // 
            // _blurButton
            // 
            this._blurButton.Location = new System.Drawing.Point(295, 159);
            this._blurButton.Name = "_blurButton";
            this._blurButton.Size = new System.Drawing.Size(104, 37);
            this._blurButton.TabIndex = 3;
            this._blurButton.Text = "Blur it";
            this._blurButton.UseVisualStyleBackColor = true;
            this._blurButton.Click += new System.EventHandler(this._blurButton_Click);
            // 
            // _blurLevelLabel
            // 
            this._blurLevelLabel.AutoSize = true;
            this._blurLevelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._blurLevelLabel.Location = new System.Drawing.Point(44, 164);
            this._blurLevelLabel.Name = "_blurLevelLabel";
            this._blurLevelLabel.Size = new System.Drawing.Size(90, 20);
            this._blurLevelLabel.TabIndex = 4;
            this._blurLevelLabel.Text = "Blur Level:";
            // 
            // _LowestBlurLevel
            // 
            this._LowestBlurLevel.BackColor = System.Drawing.SystemColors.Control;
            this._LowestBlurLevel.Image = ((System.Drawing.Image)(resources.GetObject("_LowestBlurLevel.Image")));
            this._LowestBlurLevel.Location = new System.Drawing.Point(26, 287);
            this._LowestBlurLevel.Name = "_LowestBlurLevel";
            this._LowestBlurLevel.Size = new System.Drawing.Size(322, 232);
            this._LowestBlurLevel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._LowestBlurLevel.TabIndex = 6;
            this._LowestBlurLevel.TabStop = false;
            // 
            // _LowestBlurLabel
            // 
            this._LowestBlurLabel.AutoSize = true;
            this._LowestBlurLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._LowestBlurLabel.Location = new System.Drawing.Point(107, 248);
            this._LowestBlurLabel.Name = "_LowestBlurLabel";
            this._LowestBlurLabel.Size = new System.Drawing.Size(144, 20);
            this._LowestBlurLabel.TabIndex = 8;
            this._LowestBlurLabel.Text = "Lowest Blur Level";
            // 
            // _HighestBlurLabel
            // 
            this._HighestBlurLabel.AutoSize = true;
            this._HighestBlurLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._HighestBlurLabel.Location = new System.Drawing.Point(572, 248);
            this._HighestBlurLabel.Name = "_HighestBlurLabel";
            this._HighestBlurLabel.Size = new System.Drawing.Size(148, 20);
            this._HighestBlurLabel.TabIndex = 9;
            this._HighestBlurLabel.Text = "Highest Blur Level";
            // 
            // _GobackButton
            // 
            this._GobackButton.Cursor = System.Windows.Forms.Cursors.Default;
            this._GobackButton.Location = new System.Drawing.Point(26, 29);
            this._GobackButton.Name = "_GobackButton";
            this._GobackButton.Size = new System.Drawing.Size(75, 23);
            this._GobackButton.TabIndex = 11;
            this._GobackButton.Text = "Go back";
            this._GobackButton.UseVisualStyleBackColor = true;
            this._GobackButton.Click += new System.EventHandler(this._GobackButton_Click);
            // 
            // _HighestBlurLevel
            // 
            this._HighestBlurLevel.Image = ((System.Drawing.Image)(resources.GetObject("_HighestBlurLevel.Image")));
            this._HighestBlurLevel.Location = new System.Drawing.Point(576, 287);
            this._HighestBlurLevel.Name = "_HighestBlurLevel";
            this._HighestBlurLevel.Size = new System.Drawing.Size(567, 460);
            this._HighestBlurLevel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._HighestBlurLevel.TabIndex = 13;
            this._HighestBlurLevel.TabStop = false;
            // 
            // _blurLevel
            // 
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
            this._blurLevel.Location = new System.Drawing.Point(148, 161);
            this._blurLevel.Name = "_blurLevel";
            this._blurLevel.Size = new System.Drawing.Size(112, 28);
            this._blurLevel.TabIndex = 14;
            this._blurLevel.Text = "1";
            this._blurLevel.SelectedIndexChanged += new System.EventHandler(this._blurLevel_SelectedIndexChanged);
            // 
            // _saveButton
            // 
            this._saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._saveButton.Location = new System.Drawing.Point(730, 159);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(104, 37);
            this._saveButton.TabIndex = 15;
            this._saveButton.Text = "Save Image";
            this._saveButton.UseVisualStyleBackColor = true;
            this._saveButton.Click += new System.EventHandler(this._saveButton_Click);
            // 
            // _numberImages
            // 
            this._numberImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._numberImages.FormattingEnabled = true;
            this._numberImages.Items.AddRange(new object[] {
            "5",
            "10"});
            this._numberImages.Location = new System.Drawing.Point(586, 163);
            this._numberImages.Name = "_numberImages";
            this._numberImages.Size = new System.Drawing.Size(112, 28);
            this._numberImages.TabIndex = 16;
            this._numberImages.Text = "5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(438, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Image group size:";
            // 
            // BlurForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 781);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._numberImages);
            this.Controls.Add(this._saveButton);
            this.Controls.Add(this._blurLevel);
            this.Controls.Add(this._HighestBlurLevel);
            this.Controls.Add(this._GobackButton);
            this.Controls.Add(this._HighestBlurLabel);
            this.Controls.Add(this._LowestBlurLabel);
            this.Controls.Add(this._LowestBlurLevel);
            this.Controls.Add(this._blurLevelLabel);
            this.Controls.Add(this._blurButton);
            this.Controls.Add(this._ImportImageButton);
            this.Controls.Add(this._ImagePath);
            this.Controls.Add(this._BlurImageLabel);
            this.Name = "BlurForm";
            this.Text = "BlurForm";
            ((System.ComponentModel.ISupportInitialize)(this._LowestBlurLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._HighestBlurLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _BlurImageLabel;
        private System.Windows.Forms.TextBox _ImagePath;
        private System.Windows.Forms.Button _ImportImageButton;
        private System.Windows.Forms.Button _blurButton;
        private System.Windows.Forms.Label _blurLevelLabel;
        private System.Windows.Forms.PictureBox _LowestBlurLevel;
        private Label _LowestBlurLabel;
        private Label _HighestBlurLabel;
        private Button _GobackButton;
        private PictureBox _HighestBlurLevel;
        private ComboBox _blurLevel;
        private Button _saveButton;
        private ComboBox _numberImages;
        private Label label1;
    }
}