using System.Windows.Forms;

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
            this._blurLevel = new System.Windows.Forms.NumericUpDown();
            this._LowestBlurLevel = new System.Windows.Forms.PictureBox();
            this._HighestBlurLevel = new System.Windows.Forms.PictureBox();
            this._LowestBlurLabel = new System.Windows.Forms.Label();
            this._HighestBlurLabel = new System.Windows.Forms.Label();
            this._DescriptionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._blurLevel)).BeginInit();
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
            this._ImportImageButton.Location = new System.Drawing.Point(390, 88);
            this._ImportImageButton.Name = "_ImportImageButton";
            this._ImportImageButton.Size = new System.Drawing.Size(75, 23);
            this._ImportImageButton.TabIndex = 2;
            this._ImportImageButton.Text = "Browse";
            this._ImportImageButton.UseVisualStyleBackColor = true;
            this._ImportImageButton.Click += new System.EventHandler(this._ImportImageButton_Click);
            // 
            // _blurButton
            // 
            this._blurButton.Location = new System.Drawing.Point(319, 157);
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
            // _blurLevel
            // 
            this._blurLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._blurLevel.Location = new System.Drawing.Point(148, 164);
            this._blurLevel.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this._blurLevel.Name = "_blurLevel";
            this._blurLevel.Size = new System.Drawing.Size(120, 26);
            this._blurLevel.TabIndex = 5;
            // 
            // _LowestBlurLevel
            // 
            this._LowestBlurLevel.BackColor = System.Drawing.SystemColors.Control;
            this._LowestBlurLevel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_LowestBlurLevel.BackgroundImage")));
            this._LowestBlurLevel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._LowestBlurLevel.Location = new System.Drawing.Point(26, 260);
            this._LowestBlurLevel.Name = "_LowestBlurLevel";
            this._LowestBlurLevel.Size = new System.Drawing.Size(185, 119);
            this._LowestBlurLevel.TabIndex = 6;
            this._LowestBlurLevel.TabStop = false;
            // 
            // _HighestBlurLevel
            // 
            this._HighestBlurLevel.BackColor = System.Drawing.SystemColors.Control;
            this._HighestBlurLevel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_HighestBlurLevel.BackgroundImage")));
            this._HighestBlurLevel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._HighestBlurLevel.Location = new System.Drawing.Point(362, 260);
            this._HighestBlurLevel.Name = "_HighestBlurLevel";
            this._HighestBlurLevel.Size = new System.Drawing.Size(185, 119);
            this._HighestBlurLevel.TabIndex = 7;
            this._HighestBlurLevel.TabStop = false;
            // 
            // _LowestBlurLabel
            // 
            this._LowestBlurLabel.AutoSize = true;
            this._LowestBlurLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._LowestBlurLabel.Location = new System.Drawing.Point(44, 227);
            this._LowestBlurLabel.Name = "_LowestBlurLabel";
            this._LowestBlurLabel.Size = new System.Drawing.Size(144, 20);
            this._LowestBlurLabel.TabIndex = 8;
            this._LowestBlurLabel.Text = "Lowest Blur Level";
            // 
            // _HighestBlurLabel
            // 
            this._HighestBlurLabel.AutoSize = true;
            this._HighestBlurLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._HighestBlurLabel.Location = new System.Drawing.Point(386, 227);
            this._HighestBlurLabel.Name = "_HighestBlurLabel";
            this._HighestBlurLabel.Size = new System.Drawing.Size(148, 20);
            this._HighestBlurLabel.TabIndex = 9;
            this._HighestBlurLabel.Text = "Highest Blur Level";
            // 
            // _DescriptionLabel
            // 
            this._DescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._DescriptionLabel.Location = new System.Drawing.Point(236, 287);
            this._DescriptionLabel.Name = "_DescriptionLabel";
            this._DescriptionLabel.Size = new System.Drawing.Size(100, 73);
            this._DescriptionLabel.TabIndex = 10;
            this._DescriptionLabel.Text = "There is 10 picture in between\r\n";
            this._DescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BlurForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 456);
            this.Controls.Add(this._DescriptionLabel);
            this.Controls.Add(this._HighestBlurLabel);
            this.Controls.Add(this._LowestBlurLabel);
            this.Controls.Add(this._HighestBlurLevel);
            this.Controls.Add(this._LowestBlurLevel);
            this.Controls.Add(this._blurLevel);
            this.Controls.Add(this._blurLevelLabel);
            this.Controls.Add(this._blurButton);
            this.Controls.Add(this._ImportImageButton);
            this.Controls.Add(this._ImagePath);
            this.Controls.Add(this._BlurImageLabel);
            this.Name = "BlurForm";
            this.Text = "BlurForm";
            ((System.ComponentModel.ISupportInitialize)(this._blurLevel)).EndInit();
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
        private System.Windows.Forms.NumericUpDown _blurLevel;
        private System.Windows.Forms.PictureBox _LowestBlurLevel;
        private PictureBox _HighestBlurLevel;
        private Label _LowestBlurLabel;
        private Label _HighestBlurLabel;
        private Label _DescriptionLabel;
    }
}