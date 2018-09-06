namespace CaravelEditor
{
    partial class AddMaterialForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMaterialForm));
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.densityTextBox = new System.Windows.Forms.TextBox();
            this.densityLabel = new System.Windows.Forms.Label();
            this.frictionTextBox = new System.Windows.Forms.TextBox();
            this.frictionLabel = new System.Windows.Forms.Label();
            this.restitutionTextBox = new System.Windows.Forms.TextBox();
            this.restitutionLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.nameTextBox.Location = new System.Drawing.Point(148, 25);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(138, 20);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nameTextBox.TextChanged += new System.EventHandler(textBox_OnTextChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(43, 27);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(78, 13);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "Material Name:";
            // 
            // densityTextBox
            // 
            this.densityTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.densityTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.densityTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.densityTextBox.Location = new System.Drawing.Point(148, 60);
            this.densityTextBox.Name = "densityTextBox";
            this.densityTextBox.Size = new System.Drawing.Size(138, 20);
            this.densityTextBox.TabIndex = 4;
            this.densityTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.densityTextBox.TextChanged += new System.EventHandler(textBox_OnTextChanged);
            // 
            // densityLabel
            // 
            this.densityLabel.AutoSize = true;
            this.densityLabel.Location = new System.Drawing.Point(43, 62);
            this.densityLabel.Name = "densityLabel";
            this.densityLabel.Size = new System.Drawing.Size(45, 13);
            this.densityLabel.TabIndex = 5;
            this.densityLabel.Text = "Density:";
            // 
            // frictionTextBox
            // 
            this.frictionTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.frictionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.frictionTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.frictionTextBox.Location = new System.Drawing.Point(148, 97);
            this.frictionTextBox.Name = "frictionTextBox";
            this.frictionTextBox.Size = new System.Drawing.Size(138, 20);
            this.frictionTextBox.TabIndex = 6;
            this.frictionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.frictionTextBox.TextChanged += new System.EventHandler(textBox_OnTextChanged);
            // 
            // frictionLabel
            // 
            this.frictionLabel.AutoSize = true;
            this.frictionLabel.Location = new System.Drawing.Point(43, 99);
            this.frictionLabel.Name = "frictionLabel";
            this.frictionLabel.Size = new System.Drawing.Size(44, 13);
            this.frictionLabel.TabIndex = 7;
            this.frictionLabel.Text = "Friction:";
            // 
            // restitutionTextBox
            // 
            this.restitutionTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.restitutionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.restitutionTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.restitutionTextBox.Location = new System.Drawing.Point(148, 132);
            this.restitutionTextBox.Name = "restitutionTextBox";
            this.restitutionTextBox.Size = new System.Drawing.Size(138, 20);
            this.restitutionTextBox.TabIndex = 8;
            this.restitutionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.restitutionTextBox.TextChanged += new System.EventHandler(textBox_OnTextChanged);
            // 
            // restitutionLabel
            // 
            this.restitutionLabel.AutoSize = true;
            this.restitutionLabel.Location = new System.Drawing.Point(44, 134);
            this.restitutionLabel.Name = "restitutionLabel";
            this.restitutionLabel.Size = new System.Drawing.Size(60, 13);
            this.restitutionLabel.TabIndex = 9;
            this.restitutionLabel.Text = "Restitution:";
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.addButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.addButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.ForeColor = System.Drawing.SystemColors.Control;
            this.addButton.Location = new System.Drawing.Point(47, 179);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(103, 23);
            this.addButton.TabIndex = 10;
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
            this.cancelButton.Location = new System.Drawing.Point(173, 179);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(113, 23);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            // 
            // AddMaterialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(330, 231);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.restitutionLabel);
            this.Controls.Add(this.restitutionTextBox);
            this.Controls.Add(this.frictionLabel);
            this.Controls.Add(this.frictionTextBox);
            this.Controls.Add(this.densityLabel);
            this.Controls.Add(this.densityTextBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddMaterialForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Material";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox densityTextBox;
        private System.Windows.Forms.Label densityLabel;
        private System.Windows.Forms.TextBox frictionTextBox;
        private System.Windows.Forms.Label frictionLabel;
        private System.Windows.Forms.TextBox restitutionTextBox;
        private System.Windows.Forms.Label restitutionLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button cancelButton;
    }
}