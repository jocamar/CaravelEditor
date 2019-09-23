using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaravelEditor
{
    public partial class AddSubSceneForm : Form
    {
        public AddSubSceneForm()
        {
            InitializeComponent();
        }

        private string m_sCurrentProject;
        private string[] m_Paths;
        private string m_sParentPath;
        private string m_sFileName;
        private string m_sParentResourceBundle;
        private static int lastIdUsed = 0;
        private static string lastSceneUsed = "";

        public AddSubSceneForm(string currProject, string[] paths, string parentPath, string parentResourceBundle)
        {
            InitializeComponent();

            m_sCurrentProject = currProject;
            m_sParentResourceBundle = parentResourceBundle;

            m_sParentPath = parentPath;

            this.m_Paths = paths;
            this.addButton.Enabled = false;

            string placeHolderName;
            do
            {
                placeHolderName = "Scene_" + lastIdUsed;
                lastIdUsed++;
            }
            while (m_Paths.Contains(parentPath + "/" + placeHolderName));

            string resourceBundleFullPath = Path.Combine(m_sCurrentProject, Path.GetFileNameWithoutExtension(m_sParentResourceBundle));

            textBox.Text = placeHolderName;
            sceneResourceTextBox.Text = lastSceneUsed.Replace(resourceBundleFullPath + Path.DirectorySeparatorChar, "").Replace("\\", "/"); ;
            m_sFileName = lastSceneUsed;

            if (CanAddScene())
            {
                addButton.Enabled = true;
            }
            else
            {
                addButton.Enabled = false;
            }
        }

        public string GetSceneName()
        {
            return textBox.Text;
        }

        public string GetSceneResource()
        {
            return sceneResourceTextBox.Text;
        }
        public void textBox_OnTextChanged(object sender, EventArgs eventArgs)
        {
            if (CanAddScene())
            {
                addButton.Enabled = true;
            }
            else
            {
                addButton.Enabled = false;
            }
        }

        private void browseResourceButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.InitialDirectory = m_sCurrentProject;
            openFile.Filter = "Caravel Scene | *.cvs";
            openFile.ShowDialog();
            if (openFile.FileNames.Length > 0)
            {
                string resourceBundleFullPath = Path.Combine(m_sCurrentProject, Path.GetFileNameWithoutExtension(m_sParentResourceBundle));

                string fileName = openFile.FileNames[0];

                if (fileName.StartsWith(resourceBundleFullPath))
                {
                    m_sFileName = fileName;
                    sceneResourceTextBox.Text = fileName.Replace(resourceBundleFullPath + Path.DirectorySeparatorChar, "").Replace("\\", "/");
                    lastSceneUsed = fileName;

                    if (CanAddScene())
                    {
                        addButton.Enabled = true;
                    }
                    else
                    {
                        addButton.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Error - The scene file must be inside the same resource bundle as its parent scene.", "Error");
                }
            }
        }

        private bool FileIsPartOfBundle(string filePath)
        {
            if (filePath == null || filePath == "")
            {
                return false;
            }

            string resourceBundleFullPath = Path.Combine(m_sCurrentProject, Path.GetFileNameWithoutExtension(m_sParentResourceBundle));

            if (filePath.StartsWith(resourceBundleFullPath))
            {
                return true;
            }

            return false;
        }

        private bool CanAddScene()
        {
            if (textBox.Text != "" && !m_Paths.Contains(m_sParentPath + "/" + textBox.Text)
                && FileIsPartOfBundle(m_sFileName) && textBox.Text != "Root")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
