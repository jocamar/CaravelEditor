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
            this.browseUnLoadButton = new System.Windows.Forms.Button();
            this.unLoadScriptTextBox = new System.Windows.Forms.TextBox();
            this.unLoadLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(62, 58);
            this.widthLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(162, 25);
            this.widthLabel.TabIndex = 6;
            this.widthLabel.Text = "Viewport Width:";
            // 
            // heigthLabel
            // 
            this.heigthLabel.AutoSize = true;
            this.heigthLabel.Location = new System.Drawing.Point(62, 131);
            this.heigthLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.heigthLabel.Name = "heigthLabel";
            this.heigthLabel.Size = new System.Drawing.Size(169, 25);
            this.heigthLabel.TabIndex = 8;
            this.heigthLabel.Text = "Viewport Height:";
            // 
            // widthTextBox
            // 
            this.widthTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.widthTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.widthTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.widthTextBox.Location = new System.Drawing.Point(238, 54);
            this.widthTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(124, 31);
            this.widthTextBox.TabIndex = 9;
            this.widthTextBox.TextChanged += new System.EventHandler(this.NumChanged);
            // 
            // heightTextBox
            // 
            this.heightTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.heightTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.heightTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.heightTextBox.Location = new System.Drawing.Point(238, 127);
            this.heightTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(124, 31);
            this.heightTextBox.TabIndex = 10;
            this.heightTextBox.TextChanged += new System.EventHandler(this.NumChanged);
            // 
            // preLoadLabel
            // 
            this.preLoadLabel.AutoSize = true;
            this.preLoadLabel.Location = new System.Drawing.Point(62, 217);
            this.preLoadLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.preLoadLabel.Name = "preLoadLabel";
            this.preLoadLabel.Size = new System.Drawing.Size(160, 25);
            this.preLoadLabel.TabIndex = 12;
            this.preLoadLabel.Text = "PreLoad Script:";
            // 
            // postLoadLabel
            // 
            this.postLoadLabel.AutoSize = true;
            this.postLoadLabel.Location = new System.Drawing.Point(62, 288);
            this.postLoadLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.postLoadLabel.Name = "postLoadLabel";
            this.postLoadLabel.Size = new System.Drawing.Size(170, 25);
            this.postLoadLabel.TabIndex = 13;
            this.postLoadLabel.Text = "PostLoad Script:";
            // 
            // preLoadScriptTextBox
            // 
            this.preLoadScriptTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.preLoadScriptTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.preLoadScriptTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.preLoadScriptTextBox.Location = new System.Drawing.Point(238, 213);
            this.preLoadScriptTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.preLoadScriptTextBox.Name = "preLoadScriptTextBox";
            this.preLoadScriptTextBox.Size = new System.Drawing.Size(488, 31);
            this.preLoadScriptTextBox.TabIndex = 14;
            // 
            // postLoadScriptTextBox
            // 
            this.postLoadScriptTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.postLoadScriptTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.postLoadScriptTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.postLoadScriptTextBox.Location = new System.Drawing.Point(238, 285);
            this.postLoadScriptTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.postLoadScriptTextBox.Name = "postLoadScriptTextBox";
            this.postLoadScriptTextBox.Size = new System.Drawing.Size(488, 31);
            this.postLoadScriptTextBox.TabIndex = 16;
            // 
            // browsePreLoadButton
            // 
            this.browsePreLoadButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.browsePreLoadButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.browsePreLoadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browsePreLoadButton.Location = new System.Drawing.Point(772, 208);
            this.browsePreLoadButton.Margin = new System.Windows.Forms.Padding(6);
            this.browsePreLoadButton.Name = "browsePreLoadButton";
            this.browsePreLoadButton.Size = new System.Drawing.Size(150, 44);
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
            this.browsePostLoadButton.Location = new System.Drawing.Point(772, 279);
            this.browsePostLoadButton.Margin = new System.Windows.Forms.Padding(6);
            this.browsePostLoadButton.Name = "browsePostLoadButton";
            this.browsePostLoadButton.Size = new System.Drawing.Size(150, 44);
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
            this.saveButton.Location = new System.Drawing.Point(106, 438);
            this.saveButton.Margin = new System.Windows.Forms.Padding(6);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(346, 44);
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
            this.cancelButton.Location = new System.Drawing.Point(526, 438);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(6);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(346, 44);
            this.cancelButton.TabIndex = 20;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            // 
            // browseUnLoadButton
            // 
            this.browseUnLoadButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.browseUnLoadButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.browseUnLoadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseUnLoadButton.Location = new System.Drawing.Point(772, 350);
            this.browseUnLoadButton.Margin = new System.Windows.Forms.Padding(6);
            this.browseUnLoadButton.Name = "browseUnLoadButton";
            this.browseUnLoadButton.Size = new System.Drawing.Size(150, 44);
            this.browseUnLoadButton.TabIndex = 23;
            this.browseUnLoadButton.Text = "Choose File";
            this.browseUnLoadButton.UseVisualStyleBackColor = false;
            this.browseUnLoadButton.Click += new System.EventHandler(this.browseUnLoadButton_Click);
            // 
            // unLoadScriptTextBox
            // 
            this.unLoadScriptTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.unLoadScriptTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.unLoadScriptTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.unLoadScriptTextBox.Location = new System.Drawing.Point(238, 356);
            this.unLoadScriptTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.unLoadScriptTextBox.Name = "unLoadScriptTextBox";
            this.unLoadScriptTextBox.Size = new System.Drawing.Size(488, 31);
            this.unLoadScriptTextBox.TabIndex = 22;
            // 
            // unLoadLabel
            // 
            this.unLoadLabel.AutoSize = true;
            this.unLoadLabel.Location = new System.Drawing.Point(62, 360);
            this.unLoadLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.unLoadLabel.Name = "unLoadLabel";
            this.unLoadLabel.Size = new System.Drawing.Size(154, 25);
            this.unLoadLabel.TabIndex = 21;
            this.unLoadLabel.Text = "UnLoad Script:";
            // 
            // EditSceneSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(982, 533);
            this.Controls.Add(this.browseUnLoadButton);
            this.Controls.Add(this.unLoadScriptTextBox);
            this.Controls.Add(this.unLoadLabel);
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
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "EditSceneSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
        private System.Windows.Forms.Button browseUnLoadButton;
        private System.Windows.Forms.TextBox unLoadScriptTextBox;
        private System.Windows.Forms.Label unLoadLabel;
    }
}