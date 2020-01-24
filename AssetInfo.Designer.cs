namespace CaravelEditor
{
    partial class AssetInfo
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
            this.sizeLabel = new System.Windows.Forms.Label();
            this.sizeTextBox = new System.Windows.Forms.TextBox();
            this.dimensionsTextBox = new System.Windows.Forms.TextBox();
            this.dimensionsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.sizeLabel.Location = new System.Drawing.Point(21, 12);
            this.sizeLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(54, 25);
            this.sizeLabel.TabIndex = 4;
            this.sizeLabel.Text = "Size";
            // 
            // sizeTextBox
            // 
            this.sizeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.sizeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sizeTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.sizeTextBox.Location = new System.Drawing.Point(87, 10);
            this.sizeTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.sizeTextBox.Name = "sizeTextBox";
            this.sizeTextBox.ReadOnly = true;
            this.sizeTextBox.Size = new System.Drawing.Size(94, 31);
            this.sizeTextBox.TabIndex = 5;
            this.sizeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dimensionsTextBox
            // 
            this.dimensionsTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.dimensionsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dimensionsTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.dimensionsTextBox.Location = new System.Drawing.Point(351, 10);
            this.dimensionsTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.dimensionsTextBox.Name = "dimensionsTextBox";
            this.dimensionsTextBox.ReadOnly = true;
            this.dimensionsTextBox.Size = new System.Drawing.Size(143, 31);
            this.dimensionsTextBox.TabIndex = 7;
            this.dimensionsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dimensionsLabel
            // 
            this.dimensionsLabel.AutoSize = true;
            this.dimensionsLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.dimensionsLabel.Location = new System.Drawing.Point(215, 12);
            this.dimensionsLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.dimensionsLabel.Name = "dimensionsLabel";
            this.dimensionsLabel.Size = new System.Drawing.Size(124, 25);
            this.dimensionsLabel.TabIndex = 6;
            this.dimensionsLabel.Text = "Dimensions";
            // 
            // AssetInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.dimensionsTextBox);
            this.Controls.Add(this.dimensionsLabel);
            this.Controls.Add(this.sizeTextBox);
            this.Controls.Add(this.sizeLabel);
            this.Name = "AssetInfo";
            this.Size = new System.Drawing.Size(512, 49);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.TextBox sizeTextBox;
        private System.Windows.Forms.TextBox dimensionsTextBox;
        private System.Windows.Forms.Label dimensionsLabel;
    }
}
