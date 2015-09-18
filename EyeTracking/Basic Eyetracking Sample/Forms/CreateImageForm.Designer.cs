using System.Windows.Forms;

namespace BasicEyetrackingSample
{

    /// <summary>
    /// CURRENTLY NOT USED
    /// </summary>
    partial class CreateSettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateSettingForm));
            this._BlurImageLabel = new System.Windows.Forms.Label();
            this._ImagePath = new System.Windows.Forms.TextBox();
            this._ImportImageButton = new System.Windows.Forms.Button();
            this._LowestBlurLevel = new System.Windows.Forms.PictureBox();
            this._LowestBlurLabel = new System.Windows.Forms.Label();
            this._GobackButton = new System.Windows.Forms.Button();
            this._saveButton = new System.Windows.Forms.Button();
            this._HighestBlurLabel = new System.Windows.Forms.Label();
            this._HighestBlurLevel = new System.Windows.Forms.PictureBox();
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
            // 
            // _LowestBlurLevel
            // 
            this._LowestBlurLevel.BackColor = System.Drawing.SystemColors.Control;
            this._LowestBlurLevel.Image = ((System.Drawing.Image)(resources.GetObject("_LowestBlurLevel.Image")));
            this._LowestBlurLevel.Location = new System.Drawing.Point(26, 208);
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
            this._LowestBlurLabel.Location = new System.Drawing.Point(107, 169);
            this._LowestBlurLabel.Name = "_LowestBlurLabel";
            this._LowestBlurLabel.Size = new System.Drawing.Size(129, 20);
            this._LowestBlurLabel.TabIndex = 8;
            this._LowestBlurLabel.Text = "Imported Image:";
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
            // 
            // _saveButton
            // 
            this._saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._saveButton.Location = new System.Drawing.Point(1019, 403);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(104, 37);
            this._saveButton.TabIndex = 15;
            this._saveButton.Text = "Save Image";
            this._saveButton.UseVisualStyleBackColor = true;
            // 
            // _HighestBlurLabel
            // 
            this._HighestBlurLabel.AutoSize = true;
            this._HighestBlurLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._HighestBlurLabel.Location = new System.Drawing.Point(420, 169);
            this._HighestBlurLabel.Name = "_HighestBlurLabel";
            this._HighestBlurLabel.Size = new System.Drawing.Size(123, 20);
            this._HighestBlurLabel.TabIndex = 9;
            this._HighestBlurLabel.Text = "Preview Image:";
            // 
            // _HighestBlurLevel
            // 
            this._HighestBlurLevel.Image = ((System.Drawing.Image)(resources.GetObject("_HighestBlurLevel.Image")));
            this._HighestBlurLevel.Location = new System.Drawing.Point(424, 208);
            this._HighestBlurLevel.Name = "_HighestBlurLevel";
            this._HighestBlurLevel.Size = new System.Drawing.Size(567, 460);
            this._HighestBlurLevel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._HighestBlurLevel.TabIndex = 13;
            this._HighestBlurLevel.TabStop = false;
            // 
            // CreateSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 784);
            this.Controls.Add(this._saveButton);
            this.Controls.Add(this._HighestBlurLevel);
            this.Controls.Add(this._GobackButton);
            this.Controls.Add(this._HighestBlurLabel);
            this.Controls.Add(this._LowestBlurLabel);
            this.Controls.Add(this._LowestBlurLevel);
            this.Controls.Add(this._ImportImageButton);
            this.Controls.Add(this._ImagePath);
            this.Controls.Add(this._BlurImageLabel);
            this.Name = "CreateSettingForm";
            this.Text = "CreateSettingForm";
            ((System.ComponentModel.ISupportInitialize)(this._LowestBlurLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._HighestBlurLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _BlurImageLabel;
        private System.Windows.Forms.TextBox _ImagePath;
        private System.Windows.Forms.Button _ImportImageButton;
        private System.Windows.Forms.PictureBox _LowestBlurLevel;
        private Label _LowestBlurLabel;
        private Button _GobackButton;
        private Button _saveButton;
        private Label _HighestBlurLabel;
        private PictureBox _HighestBlurLevel;
    }
}