namespace CaravelEditor
{
    partial class UnsavedChangesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnsavedChangesForm));
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveAndContinueButton = new System.Windows.Forms.Button();
            this.continueButton = new System.Windows.Forms.Button();
            this.warningLabel = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(553, 164);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(6);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(200, 44);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            // 
            // saveAndContinueButton
            // 
            this.saveAndContinueButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.saveAndContinueButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveAndContinueButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.saveAndContinueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveAndContinueButton.Location = new System.Drawing.Point(65, 164);
            this.saveAndContinueButton.Margin = new System.Windows.Forms.Padding(6);
            this.saveAndContinueButton.Name = "saveAndContinueButton";
            this.saveAndContinueButton.Size = new System.Drawing.Size(200, 44);
            this.saveAndContinueButton.TabIndex = 11;
            this.saveAndContinueButton.Text = "Save && Continue";
            this.saveAndContinueButton.UseVisualStyleBackColor = false;
            this.saveAndContinueButton.Click += new System.EventHandler(this.saveAndContinueButton_Click);
            // 
            // continueButton
            // 
            this.continueButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.continueButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.continueButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.continueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.continueButton.Location = new System.Drawing.Point(305, 164);
            this.continueButton.Margin = new System.Windows.Forms.Padding(6);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(200, 44);
            this.continueButton.TabIndex = 13;
            this.continueButton.Text = "Continue";
            this.continueButton.UseVisualStyleBackColor = false;
            // 
            // warningLabel
            // 
            this.warningLabel.Location = new System.Drawing.Point(182, 52);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(571, 55);
            this.warningLabel.TabIndex = 14;
            this.warningLabel.Text = "Warning: You have unsaved changes. If you proceed you will lose your work. Do you" +
    " wish to continue?";
            // 
            // pictureBox
            // 
            this.pictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox.BackgroundImage")));
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox.InitialImage")));
            this.pictureBox.Location = new System.Drawing.Point(65, 36);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(92, 89);
            this.pictureBox.TabIndex = 15;
            this.pictureBox.TabStop = false;
            // 
            // UnsavedChangesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(814, 251);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveAndContinueButton);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UnsavedChangesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Warning: You have unsaved changes.";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveAndContinueButton;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}