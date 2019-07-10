namespace CaravelEditor
{
    partial class TransformToolOptions
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
            this.stepXLabel = new System.Windows.Forms.Label();
            this.stepXTextBox = new System.Windows.Forms.TextBox();
            this.stepYLabel = new System.Windows.Forms.Label();
            this.stepYTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // stepXLabel
            // 
            this.stepXLabel.AutoSize = true;
            this.stepXLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.stepXLabel.Location = new System.Drawing.Point(20, 10);
            this.stepXLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.stepXLabel.Name = "stepXLabel";
            this.stepXLabel.Size = new System.Drawing.Size(76, 25);
            this.stepXLabel.TabIndex = 4;
            this.stepXLabel.Text = "Step X";
            // 
            // stepXTextBox
            // 
            this.stepXTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.stepXTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stepXTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.stepXTextBox.Location = new System.Drawing.Point(110, 6);
            this.stepXTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.stepXTextBox.Name = "stepXTextBox";
            this.stepXTextBox.Size = new System.Drawing.Size(94, 31);
            this.stepXTextBox.TabIndex = 5;
            this.stepXTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.stepXTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxOnKeyDown);
            this.stepXTextBox.Leave += new System.EventHandler(this.TextBoxChanged);
            // 
            // stepYLabel
            // 
            this.stepYLabel.AutoSize = true;
            this.stepYLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.stepYLabel.Location = new System.Drawing.Point(260, 10);
            this.stepYLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.stepYLabel.Name = "stepYLabel";
            this.stepYLabel.Size = new System.Drawing.Size(77, 25);
            this.stepYLabel.TabIndex = 6;
            this.stepYLabel.Text = "Step Y";
            // 
            // stepYTextBox
            // 
            this.stepYTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.stepYTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stepYTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.stepYTextBox.Location = new System.Drawing.Point(350, 6);
            this.stepYTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.stepYTextBox.Name = "stepYTextBox";
            this.stepYTextBox.Size = new System.Drawing.Size(94, 31);
            this.stepYTextBox.TabIndex = 7;
            this.stepYTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.stepYTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxOnKeyDown);
            this.stepYTextBox.Leave += new System.EventHandler(this.TextBoxChanged);
            // 
            // TransformToolOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.stepYTextBox);
            this.Controls.Add(this.stepYLabel);
            this.Controls.Add(this.stepXTextBox);
            this.Controls.Add(this.stepXLabel);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "TransformToolOptions";
            this.Size = new System.Drawing.Size(486, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label stepXLabel;
        private System.Windows.Forms.TextBox stepXTextBox;
        private System.Windows.Forms.Label stepYLabel;
        private System.Windows.Forms.TextBox stepYTextBox;
    }
}
