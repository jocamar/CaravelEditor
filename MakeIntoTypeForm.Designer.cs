namespace CaravelEditor
{
    partial class MakeIntoTypeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MakeIntoTypeForm));
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.fileLabel = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.typeLabel = new System.Windows.Forms.Label();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fileTextBox
            // 
            this.fileTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.fileTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fileTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.fileTextBox.Location = new System.Drawing.Point(102, 29);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.ReadOnly = true;
            this.fileTextBox.Size = new System.Drawing.Size(258, 20);
            this.fileTextBox.TabIndex = 0;
            this.fileTextBox.TextChanged += new System.EventHandler(this.textBox_OnTextChanged);
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Location = new System.Drawing.Point(31, 31);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(57, 13);
            this.fileLabel.TabIndex = 1;
            this.fileLabel.Text = "File Name:";
            // 
            // browseButton
            // 
            this.browseButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.browseButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.browseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseButton.Location = new System.Drawing.Point(385, 26);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Choose File";
            this.browseButton.UseVisualStyleBackColor = false;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(31, 66);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(62, 13);
            this.typeLabel.TabIndex = 3;
            this.typeLabel.Text = "Type Name";
            // 
            // typeTextBox
            // 
            this.typeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.typeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.typeTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.typeTextBox.Location = new System.Drawing.Point(102, 64);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.Size = new System.Drawing.Size(258, 20);
            this.typeTextBox.TabIndex = 4;
            this.typeTextBox.TextChanged += new System.EventHandler(this.textBox_OnTextChanged);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(68, 107);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(173, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save Type";
            this.saveButton.UseVisualStyleBackColor = false;
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(261, 107);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(173, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            // 
            // MakeIntoTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(498, 155);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.typeTextBox);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.fileLabel);
            this.Controls.Add(this.fileTextBox);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MakeIntoTypeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Make Into Type";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.TextBox typeTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}