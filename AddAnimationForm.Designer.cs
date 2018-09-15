namespace CaravelEditor
{
    partial class AddAnimationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAnimationForm));
            this.textBox = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox.ForeColor = System.Drawing.SystemColors.Control;
            this.textBox.Location = new System.Drawing.Point(107, 18);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(165, 20);
            this.textBox.TabIndex = 0;
            this.textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_OnTextChanged);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.ForeColor = System.Drawing.SystemColors.Control;
            this.label.Location = new System.Drawing.Point(12, 21);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(84, 13);
            this.label.TabIndex = 1;
            this.label.Text = "Animation Name";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.addButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.addButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.ForeColor = System.Drawing.SystemColors.Control;
            this.addButton.Location = new System.Drawing.Point(32, 48);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(103, 23);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = false;
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.ForeColor = System.Drawing.SystemColors.Control;
            this.cancelButton.Location = new System.Drawing.Point(141, 48);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(113, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            // 
            // AddAnimationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(284, 83);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label);
            this.Controls.Add(this.textBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddAnimationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Animation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button cancelButton;
    }
}