namespace CaravelEditor
{
    partial class AddSubSceneForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSubSceneForm));
            this.nameLabel = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.browseResourceButton = new System.Windows.Forms.Button();
            this.sceneResourceTextBox = new System.Windows.Forms.TextBox();
            this.sceneResourceLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(47, 47);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(135, 25);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "Scene Name";
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox.Location = new System.Drawing.Point(194, 41);
            this.textBox.Margin = new System.Windows.Forms.Padding(6);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(529, 31);
            this.textBox.TabIndex = 2;
            this.textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_OnTextChanged);
            // 
            // browseResourceButton
            // 
            this.browseResourceButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.browseResourceButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.browseResourceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseResourceButton.Location = new System.Drawing.Point(573, 95);
            this.browseResourceButton.Margin = new System.Windows.Forms.Padding(6);
            this.browseResourceButton.Name = "browseResourceButton";
            this.browseResourceButton.Size = new System.Drawing.Size(150, 44);
            this.browseResourceButton.TabIndex = 16;
            this.browseResourceButton.Text = "Choose File";
            this.browseResourceButton.UseVisualStyleBackColor = false;
            this.browseResourceButton.Click += new System.EventHandler(this.browseResourceButton_Click);
            // 
            // sceneResourceTextBox
            // 
            this.sceneResourceTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.sceneResourceTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sceneResourceTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.sceneResourceTextBox.Location = new System.Drawing.Point(230, 103);
            this.sceneResourceTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.sceneResourceTextBox.Name = "sceneResourceTextBox";
            this.sceneResourceTextBox.Size = new System.Drawing.Size(315, 31);
            this.sceneResourceTextBox.TabIndex = 15;
            // 
            // sceneResourceLabel
            // 
            this.sceneResourceLabel.AutoSize = true;
            this.sceneResourceLabel.Location = new System.Drawing.Point(44, 105);
            this.sceneResourceLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.sceneResourceLabel.Name = "sceneResourceLabel";
            this.sceneResourceLabel.Size = new System.Drawing.Size(177, 25);
            this.sceneResourceLabel.TabIndex = 14;
            this.sceneResourceLabel.Text = "Scene Resource:";
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.ForeColor = System.Drawing.SystemColors.Control;
            this.cancelButton.Location = new System.Drawing.Point(397, 178);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(6);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(226, 44);
            this.cancelButton.TabIndex = 18;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.addButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.addButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.ForeColor = System.Drawing.SystemColors.Control;
            this.addButton.Location = new System.Drawing.Point(161, 178);
            this.addButton.Margin = new System.Windows.Forms.Padding(6);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(206, 44);
            this.addButton.TabIndex = 17;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = false;
            // 
            // AddSubSceneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(786, 262);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.browseResourceButton);
            this.Controls.Add(this.sceneResourceTextBox);
            this.Controls.Add(this.sceneResourceLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.textBox);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddSubSceneForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Sub Scene";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button browseResourceButton;
        private System.Windows.Forms.TextBox sceneResourceTextBox;
        private System.Windows.Forms.Label sceneResourceLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button addButton;
    }
}