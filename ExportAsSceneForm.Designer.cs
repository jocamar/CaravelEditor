﻿namespace CaravelEditor
{
    partial class ExportAsSceneForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportAsSceneForm));
            this.browseUnLoadButton = new System.Windows.Forms.Button();
            this.unLoadScriptTextBox = new System.Windows.Forms.TextBox();
            this.unLoadLabel = new System.Windows.Forms.Label();
            this.browsePostLoadButton = new System.Windows.Forms.Button();
            this.postLoadScriptTextBox = new System.Windows.Forms.TextBox();
            this.postLoadLabel = new System.Windows.Forms.Label();
            this.browsePreLoadButton = new System.Windows.Forms.Button();
            this.preLoadScriptTextBox = new System.Windows.Forms.TextBox();
            this.preLoadLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.heigthLabel = new System.Windows.Forms.Label();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.widthLabel = new System.Windows.Forms.Label();
            this.browseFileButton = new System.Windows.Forms.Button();
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.fileLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // browseUnLoadButton
            // 
            this.browseUnLoadButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.browseUnLoadButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.browseUnLoadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseUnLoadButton.Location = new System.Drawing.Point(779, 447);
            this.browseUnLoadButton.Margin = new System.Windows.Forms.Padding(6);
            this.browseUnLoadButton.Name = "browseUnLoadButton";
            this.browseUnLoadButton.Size = new System.Drawing.Size(150, 44);
            this.browseUnLoadButton.TabIndex = 37;
            this.browseUnLoadButton.Text = "Choose File";
            this.browseUnLoadButton.UseVisualStyleBackColor = false;
            this.browseUnLoadButton.Click += new System.EventHandler(this.browseUnLoadButton_Click);
            // 
            // unLoadScriptTextBox
            // 
            this.unLoadScriptTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.unLoadScriptTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.unLoadScriptTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.unLoadScriptTextBox.Location = new System.Drawing.Point(245, 453);
            this.unLoadScriptTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.unLoadScriptTextBox.Name = "unLoadScriptTextBox";
            this.unLoadScriptTextBox.Size = new System.Drawing.Size(488, 31);
            this.unLoadScriptTextBox.TabIndex = 36;
            // 
            // unLoadLabel
            // 
            this.unLoadLabel.AutoSize = true;
            this.unLoadLabel.Location = new System.Drawing.Point(69, 456);
            this.unLoadLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.unLoadLabel.Name = "unLoadLabel";
            this.unLoadLabel.Size = new System.Drawing.Size(154, 25);
            this.unLoadLabel.TabIndex = 35;
            this.unLoadLabel.Text = "UnLoad Script:";
            // 
            // browsePostLoadButton
            // 
            this.browsePostLoadButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.browsePostLoadButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.browsePostLoadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browsePostLoadButton.Location = new System.Drawing.Point(779, 374);
            this.browsePostLoadButton.Margin = new System.Windows.Forms.Padding(6);
            this.browsePostLoadButton.Name = "browsePostLoadButton";
            this.browsePostLoadButton.Size = new System.Drawing.Size(150, 44);
            this.browsePostLoadButton.TabIndex = 34;
            this.browsePostLoadButton.Text = "Choose File";
            this.browsePostLoadButton.UseVisualStyleBackColor = false;
            this.browsePostLoadButton.Click += new System.EventHandler(this.browsePostLoadButton_Click);
            // 
            // postLoadScriptTextBox
            // 
            this.postLoadScriptTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.postLoadScriptTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.postLoadScriptTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.postLoadScriptTextBox.Location = new System.Drawing.Point(245, 380);
            this.postLoadScriptTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.postLoadScriptTextBox.Name = "postLoadScriptTextBox";
            this.postLoadScriptTextBox.Size = new System.Drawing.Size(488, 31);
            this.postLoadScriptTextBox.TabIndex = 33;
            // 
            // postLoadLabel
            // 
            this.postLoadLabel.AutoSize = true;
            this.postLoadLabel.Location = new System.Drawing.Point(69, 383);
            this.postLoadLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.postLoadLabel.Name = "postLoadLabel";
            this.postLoadLabel.Size = new System.Drawing.Size(170, 25);
            this.postLoadLabel.TabIndex = 32;
            this.postLoadLabel.Text = "PostLoad Script:";
            // 
            // browsePreLoadButton
            // 
            this.browsePreLoadButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.browsePreLoadButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.browsePreLoadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browsePreLoadButton.Location = new System.Drawing.Point(779, 303);
            this.browsePreLoadButton.Margin = new System.Windows.Forms.Padding(6);
            this.browsePreLoadButton.Name = "browsePreLoadButton";
            this.browsePreLoadButton.Size = new System.Drawing.Size(150, 44);
            this.browsePreLoadButton.TabIndex = 31;
            this.browsePreLoadButton.Text = "Choose File";
            this.browsePreLoadButton.UseVisualStyleBackColor = false;
            this.browsePreLoadButton.Click += new System.EventHandler(this.browsePreLoadButton_Click);
            // 
            // preLoadScriptTextBox
            // 
            this.preLoadScriptTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.preLoadScriptTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.preLoadScriptTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.preLoadScriptTextBox.Location = new System.Drawing.Point(245, 308);
            this.preLoadScriptTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.preLoadScriptTextBox.Name = "preLoadScriptTextBox";
            this.preLoadScriptTextBox.Size = new System.Drawing.Size(488, 31);
            this.preLoadScriptTextBox.TabIndex = 30;
            // 
            // preLoadLabel
            // 
            this.preLoadLabel.AutoSize = true;
            this.preLoadLabel.Location = new System.Drawing.Point(69, 312);
            this.preLoadLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.preLoadLabel.Name = "preLoadLabel";
            this.preLoadLabel.Size = new System.Drawing.Size(160, 25);
            this.preLoadLabel.TabIndex = 29;
            this.preLoadLabel.Text = "PreLoad Script:";
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(553, 562);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(6);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(346, 44);
            this.cancelButton.TabIndex = 28;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(111, 562);
            this.saveButton.Margin = new System.Windows.Forms.Padding(6);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(346, 44);
            this.saveButton.TabIndex = 27;
            this.saveButton.Text = "Create Scene";
            this.saveButton.UseVisualStyleBackColor = false;
            // 
            // heightTextBox
            // 
            this.heightTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.heightTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.heightTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.heightTextBox.Location = new System.Drawing.Point(245, 222);
            this.heightTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(124, 31);
            this.heightTextBox.TabIndex = 26;
            this.heightTextBox.TextChanged += new System.EventHandler(this.NumChanged);
            // 
            // heigthLabel
            // 
            this.heigthLabel.AutoSize = true;
            this.heigthLabel.Location = new System.Drawing.Point(69, 226);
            this.heigthLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.heigthLabel.Name = "heigthLabel";
            this.heigthLabel.Size = new System.Drawing.Size(169, 25);
            this.heigthLabel.TabIndex = 25;
            this.heigthLabel.Text = "Viewport Height:";
            // 
            // widthTextBox
            // 
            this.widthTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.widthTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.widthTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.widthTextBox.Location = new System.Drawing.Point(245, 149);
            this.widthTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(124, 31);
            this.widthTextBox.TabIndex = 24;
            this.widthTextBox.TextChanged += new System.EventHandler(this.NumChanged);
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(69, 153);
            this.widthLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(162, 25);
            this.widthLabel.TabIndex = 23;
            this.widthLabel.Text = "Viewport Width:";
            // 
            // browseFileButton
            // 
            this.browseFileButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.browseFileButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.browseFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseFileButton.Location = new System.Drawing.Point(779, 62);
            this.browseFileButton.Margin = new System.Windows.Forms.Padding(6);
            this.browseFileButton.Name = "browseFileButton";
            this.browseFileButton.Size = new System.Drawing.Size(150, 44);
            this.browseFileButton.TabIndex = 22;
            this.browseFileButton.Text = "Choose File";
            this.browseFileButton.UseVisualStyleBackColor = false;
            this.browseFileButton.Click += new System.EventHandler(this.sceneFileButton_Click);
            // 
            // fileTextBox
            // 
            this.fileTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.fileTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fileTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.fileTextBox.Location = new System.Drawing.Point(245, 68);
            this.fileTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.ReadOnly = true;
            this.fileTextBox.Size = new System.Drawing.Size(488, 31);
            this.fileTextBox.TabIndex = 21;
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Location = new System.Drawing.Point(69, 72);
            this.fileLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(115, 25);
            this.fileLabel.TabIndex = 20;
            this.fileLabel.Text = "File Name:";
            // 
            // ExportAsSceneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1006, 668);
            this.Controls.Add(this.browseUnLoadButton);
            this.Controls.Add(this.unLoadScriptTextBox);
            this.Controls.Add(this.unLoadLabel);
            this.Controls.Add(this.browsePostLoadButton);
            this.Controls.Add(this.postLoadScriptTextBox);
            this.Controls.Add(this.postLoadLabel);
            this.Controls.Add(this.browsePreLoadButton);
            this.Controls.Add(this.preLoadScriptTextBox);
            this.Controls.Add(this.preLoadLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.heightTextBox);
            this.Controls.Add(this.heigthLabel);
            this.Controls.Add(this.widthTextBox);
            this.Controls.Add(this.widthLabel);
            this.Controls.Add(this.browseFileButton);
            this.Controls.Add(this.fileTextBox);
            this.Controls.Add(this.fileLabel);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExportAsSceneForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export As Scene";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button browseUnLoadButton;
        private System.Windows.Forms.TextBox unLoadScriptTextBox;
        private System.Windows.Forms.Label unLoadLabel;
        private System.Windows.Forms.Button browsePostLoadButton;
        private System.Windows.Forms.TextBox postLoadScriptTextBox;
        private System.Windows.Forms.Label postLoadLabel;
        private System.Windows.Forms.Button browsePreLoadButton;
        private System.Windows.Forms.TextBox preLoadScriptTextBox;
        private System.Windows.Forms.Label preLoadLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.Label heigthLabel;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Button browseFileButton;
        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.Label fileLabel;
    }
}