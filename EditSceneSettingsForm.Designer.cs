namespace CaravelEditor
{
    partial class EditSceneSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditSceneSettingsForm));
            this.widthLabel = new System.Windows.Forms.Label();
            this.heigthLabel = new System.Windows.Forms.Label();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.preLoadLabel = new System.Windows.Forms.Label();
            this.postLoadLabel = new System.Windows.Forms.Label();
            this.preLoadScriptTextBox = new System.Windows.Forms.TextBox();
            this.postLoadScriptTextBox = new System.Windows.Forms.TextBox();
            this.browsePreLoadButton = new System.Windows.Forms.Button();
            this.browsePostLoadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(31, 30);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(82, 13);
            this.widthLabel.TabIndex = 6;
            this.widthLabel.Text = "Viewport Width:";
            // 
            // heigthLabel
            // 
            this.heigthLabel.AutoSize = true;
            this.heigthLabel.Location = new System.Drawing.Point(31, 68);
            this.heigthLabel.Name = "heigthLabel";
            this.heigthLabel.Size = new System.Drawing.Size(85, 13);
            this.heigthLabel.TabIndex = 8;
            this.heigthLabel.Text = "Viewport Height:";
            // 
            // widthTextBox
            // 
            this.widthTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.widthTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.widthTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.widthTextBox.Location = new System.Drawing.Point(119, 28);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(63, 20);
            this.widthTextBox.TabIndex = 9;
            this.widthTextBox.TextChanged += new System.EventHandler(this.NumChanged);
            // 
            // heightTextBox
            // 
            this.heightTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.heightTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.heightTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.heightTextBox.Location = new System.Drawing.Point(119, 66);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(63, 20);
            this.heightTextBox.TabIndex = 10;
            this.heightTextBox.TextChanged += new System.EventHandler(this.NumChanged);
            // 
            // preLoadLabel
            // 
            this.preLoadLabel.AutoSize = true;
            this.preLoadLabel.Location = new System.Drawing.Point(31, 113);
            this.preLoadLabel.Name = "preLoadLabel";
            this.preLoadLabel.Size = new System.Drawing.Size(80, 13);
            this.preLoadLabel.TabIndex = 12;
            this.preLoadLabel.Text = "PreLoad Script:";
            // 
            // postLoadLabel
            // 
            this.postLoadLabel.AutoSize = true;
            this.postLoadLabel.Location = new System.Drawing.Point(31, 150);
            this.postLoadLabel.Name = "postLoadLabel";
            this.postLoadLabel.Size = new System.Drawing.Size(85, 13);
            this.postLoadLabel.TabIndex = 13;
            this.postLoadLabel.Text = "PostLoad Script:";
            // 
            // preLoadScriptTextBox
            // 
            this.preLoadScriptTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.preLoadScriptTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.preLoadScriptTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.preLoadScriptTextBox.Location = new System.Drawing.Point(119, 111);
            this.preLoadScriptTextBox.Name = "preLoadScriptTextBox";
            this.preLoadScriptTextBox.Size = new System.Drawing.Size(245, 20);
            this.preLoadScriptTextBox.TabIndex = 14;
            // 
            // postLoadScriptTextBox
            // 
            this.postLoadScriptTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.postLoadScriptTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.postLoadScriptTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.postLoadScriptTextBox.Location = new System.Drawing.Point(119, 148);
            this.postLoadScriptTextBox.Name = "postLoadScriptTextBox";
            this.postLoadScriptTextBox.Size = new System.Drawing.Size(245, 20);
            this.postLoadScriptTextBox.TabIndex = 16;
            // 
            // browsePreLoadButton
            // 
            this.browsePreLoadButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.browsePreLoadButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.browsePreLoadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browsePreLoadButton.Location = new System.Drawing.Point(386, 108);
            this.browsePreLoadButton.Name = "browsePreLoadButton";
            this.browsePreLoadButton.Size = new System.Drawing.Size(75, 23);
            this.browsePreLoadButton.TabIndex = 17;
            this.browsePreLoadButton.Text = "Choose File";
            this.browsePreLoadButton.UseVisualStyleBackColor = false;
            this.browsePreLoadButton.Click += new System.EventHandler(this.browsePreLoadButton_Click);
            // 
            // browsePostLoadButton
            // 
            this.browsePostLoadButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.browsePostLoadButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.browsePostLoadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browsePostLoadButton.Location = new System.Drawing.Point(386, 145);
            this.browsePostLoadButton.Name = "browsePostLoadButton";
            this.browsePostLoadButton.Size = new System.Drawing.Size(75, 23);
            this.browsePostLoadButton.TabIndex = 18;
            this.browsePostLoadButton.Text = "Choose File";
            this.browsePostLoadButton.UseVisualStyleBackColor = false;
            this.browsePostLoadButton.Click += new System.EventHandler(this.browsePostLoadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(55, 191);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(173, 23);
            this.saveButton.TabIndex = 19;
            this.saveButton.Text = "Apply Changes";
            this.saveButton.UseVisualStyleBackColor = false;
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(265, 191);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(173, 23);
            this.cancelButton.TabIndex = 20;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            // 
            // EditSceneSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(491, 239);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.browsePostLoadButton);
            this.Controls.Add(this.browsePreLoadButton);
            this.Controls.Add(this.postLoadScriptTextBox);
            this.Controls.Add(this.preLoadScriptTextBox);
            this.Controls.Add(this.postLoadLabel);
            this.Controls.Add(this.preLoadLabel);
            this.Controls.Add(this.heightTextBox);
            this.Controls.Add(this.widthTextBox);
            this.Controls.Add(this.heigthLabel);
            this.Controls.Add(this.widthLabel);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditSceneSettingsForm";
            this.Text = "Edit Scene Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label heigthLabel;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.Label preLoadLabel;
        private System.Windows.Forms.Label postLoadLabel;
        private System.Windows.Forms.TextBox preLoadScriptTextBox;
        private System.Windows.Forms.TextBox postLoadScriptTextBox;
        private System.Windows.Forms.Button browsePreLoadButton;
        private System.Windows.Forms.Button browsePostLoadButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}