﻿namespace CaravelEditor
{
    partial class CameraToolOptions
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.zoomLabel = new System.Windows.Forms.Label();
            this.zoomTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // zoomLabel
            // 
            this.zoomLabel.AutoSize = true;
            this.zoomLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.zoomLabel.Location = new System.Drawing.Point(20, 10);
            this.zoomLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.zoomLabel.Name = "zoomLabel";
            this.zoomLabel.Size = new System.Drawing.Size(66, 25);
            this.zoomLabel.TabIndex = 3;
            this.zoomLabel.Text = "Zoom";
            // 
            // zoomTextBox
            // 
            this.zoomTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.zoomTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zoomTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.zoomTextBox.Location = new System.Drawing.Point(100, 6);
            this.zoomTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.zoomTextBox.Name = "zoomTextBox";
            this.zoomTextBox.ReadOnly = true;
            this.zoomTextBox.Size = new System.Drawing.Size(94, 31);
            this.zoomTextBox.TabIndex = 4;
            this.zoomTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CameraToolOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.zoomTextBox);
            this.Controls.Add(this.zoomLabel);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "CameraToolOptions";
            this.Size = new System.Drawing.Size(234, 48);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label zoomLabel;
        private System.Windows.Forms.TextBox zoomTextBox;
    }
}
