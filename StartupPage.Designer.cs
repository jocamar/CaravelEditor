using System.Drawing;

namespace CaravelEditor
{
    partial class StartupPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartupPage));
            this.TitleLabel = new System.Windows.Forms.Label();
            this.Separator = new System.Windows.Forms.Label();
            this.RecentProjects = new System.Windows.Forms.FlowLayoutPanel();
            this.openProjectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(46, 396);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(183, 55);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Recent";
            // 
            // Separator
            // 
            this.Separator.BackColor = System.Drawing.SystemColors.Control;
            this.Separator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Separator.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Separator.Location = new System.Drawing.Point(56, 451);
            this.Separator.Name = "Separator";
            this.Separator.Size = new System.Drawing.Size(599, 5);
            this.Separator.TabIndex = 1;
            // 
            // RecentProjects
            // 
            this.RecentProjects.AutoSize = false;
            this.RecentProjects.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RecentProjects.MinimumSize = new Size(720, 720);
            this.RecentProjects.Location = new System.Drawing.Point(56, 484);
            this.RecentProjects.Name = "RecentProjects";
            this.RecentProjects.TabIndex = 2;
            // 
            // openProjectButton
            // 
            this.openProjectButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.openProjectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.openProjectButton.FlatAppearance.BorderSize = 0;
            this.openProjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openProjectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openProjectButton.ForeColor = System.Drawing.SystemColors.Control;
            this.openProjectButton.Image = ((System.Drawing.Image)(resources.GetObject("openProjectButton.Image")));
            this.openProjectButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.openProjectButton.Location = new System.Drawing.Point(56, 101);
            this.openProjectButton.MinimumSize = new System.Drawing.Size(534, 0);
            this.openProjectButton.Name = "openProjectButton";
            this.openProjectButton.Padding = new System.Windows.Forms.Padding(64, 0, 64, 0);
            this.openProjectButton.Size = new System.Drawing.Size(534, 184);
            this.openProjectButton.TabIndex = 3;
            this.openProjectButton.Text = "Open Project";
            this.openProjectButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.openProjectButton.UseVisualStyleBackColor = false;
            this.openProjectButton.Click += new System.EventHandler(this.openProjectButton_Click);
            // 
            // StartupPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.openProjectButton);
            this.Controls.Add(this.RecentProjects);
            this.Controls.Add(this.Separator);
            this.Controls.Add(this.TitleLabel);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.MinimumSize = new System.Drawing.Size(640, 640);
            this.Name = "StartupPage";
            this.Size = new System.Drawing.Size(1591, 1241);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label Separator;
        private System.Windows.Forms.FlowLayoutPanel RecentProjects;
        private System.Windows.Forms.Button openProjectButton;
    }
}
