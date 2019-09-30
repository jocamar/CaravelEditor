using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using static CaravelEditor.EditorForm;

namespace CaravelEditor
{
    public partial class StartupPage : UserControl
    {
        public EditorForm Eform
        {
            get; set;
        }
        
        private Dictionary<string, ComplexButton> m_ProjectButtons = new Dictionary<string,ComplexButton>();

        public StartupPage()
        {
            InitializeComponent();
            
            RecentProjects.WrapContents = true;
            RecentProjects.FlowDirection = FlowDirection.LeftToRight;
            this.Resize += new EventHandler((object sender, EventArgs e) =>
            {
                RecentProjects.Size = new Size(this.Size.Width-(50+RecentProjects.Location.X), this.Size.Height - (100+RecentProjects.Location.Y));
                RecentProjects.PerformLayout();
            });

            
        }

        public void PopulateProjects()
        {
            BringToFront();
            LoadLastProjects();

            foreach (var proj in Eform.LastLoadedProjects)
            {
                var complexButton = new ComplexButton();
                complexButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                complexButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                complexButton.FlatAppearance.BorderSize = 0;
                complexButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                complexButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                complexButton.Image = new Bitmap(global::CaravelEditor.Properties.Resources.open, new Size(32, 32));
                complexButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                complexButton.Location = new System.Drawing.Point(3, 3);
                complexButton.Name = "complexButton" + proj.ProjectName;
                complexButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
                complexButton.Size = new System.Drawing.Size(300, 80);
                complexButton.Subtitle = proj.ProjectScene;
                complexButton.SubtitleColor = System.Drawing.SystemColors.AppWorkspace;
                complexButton.SubtitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                complexButton.TabIndex = 4;
                complexButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                complexButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
                complexButton.Title = proj.ProjectName;
                complexButton.UseVisualStyleBackColor = false;
                complexButton.Click += new EventHandler(loadRecentProjectButton_Click);

                m_ProjectButtons.Add(proj.ProjectName, complexButton);
                this.RecentProjects.Controls.Add(complexButton);
            }
        }

        private void openProjectButton_Click(object sender, EventArgs e)
        {
            Eform.openProjectToolStripMenuItem_Click(sender, e);
        }

        private void loadRecentProjectButton_Click(object sender, EventArgs e)
        {
            var button = sender as ComplexButton;
            var projInfo = Eform.LastLoadedProjects.Find(p => p.ProjectName == button.Title);

            Eform.OpenProject(projInfo.FullProjectPath);
            
            if (projInfo.ProjectScene != "")
            {
                Eform.LoadNewScene(projInfo.FullScenePath);
            }
        }

        private void LoadLastProjects()
        {
            if (!File.Exists("settings.xml"))
            {
                return;
            }

            var doc = new XmlDocument();
            doc.Load("settings.xml");

            var rootNode = doc.FirstChild;

            var recentProjs = rootNode.SelectNodes("LastProjects/*");

            int numProjs = 0;

            foreach (XmlNode proj in recentProjs)
            {
                if (numProjs >= 6)
                {
                    break;
                }

                var projName = proj.Attributes["name"].Value;
                var scene = proj.Attributes["scene"].Value;
                var projPath = proj.Attributes["projPath"].Value;
                var scenePath = proj.Attributes["scenePath"].Value;
                Eform.LastLoadedProjects.Add(new ProjectInfo(projName, scene, projPath, scenePath));
                numProjs++;
            }
        }
    }
}
