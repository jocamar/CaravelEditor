namespace CaravelEditor
{
    partial class RenameEntityForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RenameEntityForm));
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.renameButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.nameTextBox.Location = new System.Drawing.Point(75, 27);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(222, 20);
            this.nameTextBox.TabIndex = 4;
            this.nameTextBox.TextChanged += new System.EventHandler(this.NameChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(31, 29);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 5;
            this.nameLabel.Text = "Name:";
            // 
            // renameButton
            // 
            this.renameButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.renameButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.renameButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.renameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.renameButton.Location = new System.Drawing.Point(34, 71);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(125, 23);
            this.renameButton.TabIndex = 6;
            this.renameButton.Text = "Rename";
            this.renameButton.UseVisualStyleBackColor = false;
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(172, 71);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(125, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            // 
            // RenameEntityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(326, 119);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.renameButton);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RenameEntityForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rename Entity";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.Button cancelButton;
    }
}