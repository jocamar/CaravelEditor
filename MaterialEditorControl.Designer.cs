namespace CaravelEditor
{
    partial class MaterialEditorControl
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
            this.frictionTextBox = new System.Windows.Forms.TextBox();
            this.materialFrictionLabel = new System.Windows.Forms.Label();
            this.restitutionLabel = new System.Windows.Forms.Label();
            this.densityLabel = new System.Windows.Forms.Label();
            this.densityTextBox = new System.Windows.Forms.TextBox();
            this.restitutionTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // frictionTextBox
            // 
            this.frictionTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.frictionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.frictionTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.frictionTextBox.Location = new System.Drawing.Point(143, 11);
            this.frictionTextBox.Name = "frictionTextBox";
            this.frictionTextBox.Size = new System.Drawing.Size(187, 20);
            this.frictionTextBox.TabIndex = 1;
            this.frictionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.frictionTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxOnKeyDown);
            this.frictionTextBox.Leave += new System.EventHandler(this.TextBoxChanged);
            // 
            // materialFrictionLabel
            // 
            this.materialFrictionLabel.AutoSize = true;
            this.materialFrictionLabel.Location = new System.Drawing.Point(35, 13);
            this.materialFrictionLabel.Name = "materialFrictionLabel";
            this.materialFrictionLabel.Size = new System.Drawing.Size(44, 13);
            this.materialFrictionLabel.TabIndex = 2;
            this.materialFrictionLabel.Text = "Friction:";
            // 
            // restitutionLabel
            // 
            this.restitutionLabel.AutoSize = true;
            this.restitutionLabel.Location = new System.Drawing.Point(35, 42);
            this.restitutionLabel.Name = "restitutionLabel";
            this.restitutionLabel.Size = new System.Drawing.Size(60, 13);
            this.restitutionLabel.TabIndex = 3;
            this.restitutionLabel.Text = "Restitution:";
            // 
            // densityLabel
            // 
            this.densityLabel.AutoSize = true;
            this.densityLabel.Location = new System.Drawing.Point(34, 71);
            this.densityLabel.Name = "densityLabel";
            this.densityLabel.Size = new System.Drawing.Size(45, 13);
            this.densityLabel.TabIndex = 4;
            this.densityLabel.Text = "Density:";
            // 
            // densityTextBox
            // 
            this.densityTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.densityTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.densityTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.densityTextBox.Location = new System.Drawing.Point(143, 69);
            this.densityTextBox.Name = "densityTextBox";
            this.densityTextBox.Size = new System.Drawing.Size(187, 20);
            this.densityTextBox.TabIndex = 5;
            this.densityTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.densityTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxOnKeyDown);
            this.densityTextBox.Leave += new System.EventHandler(this.TextBoxChanged);
            // 
            // restitutionTextBox
            // 
            this.restitutionTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.restitutionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.restitutionTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.restitutionTextBox.Location = new System.Drawing.Point(143, 40);
            this.restitutionTextBox.Name = "restitutionTextBox";
            this.restitutionTextBox.Size = new System.Drawing.Size(187, 20);
            this.restitutionTextBox.TabIndex = 6;
            this.restitutionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.restitutionTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxOnKeyDown);
            this.restitutionTextBox.Leave += new System.EventHandler(this.TextBoxChanged);
            // 
            // MaterialEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.restitutionTextBox);
            this.Controls.Add(this.densityTextBox);
            this.Controls.Add(this.densityLabel);
            this.Controls.Add(this.restitutionLabel);
            this.Controls.Add(this.materialFrictionLabel);
            this.Controls.Add(this.frictionTextBox);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "MaterialEditorControl";
            this.Size = new System.Drawing.Size(388, 100);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox frictionTextBox;
        private System.Windows.Forms.Label materialFrictionLabel;
        private System.Windows.Forms.Label restitutionLabel;
        private System.Windows.Forms.Label densityLabel;
        private System.Windows.Forms.TextBox densityTextBox;
        private System.Windows.Forms.TextBox restitutionTextBox;
    }
}
