using System;
using System.IO;
using System.Windows.Forms;

namespace CaravelEditor
{
    public partial class EditSceneSettingsForm : Form
    {
        private string m_sCurrentProject;
        private int m_iViewPortX = -1;
        private int m_iViewPortY = -1;
        private string m_sSceneResourceBundle;

        public EditSceneSettingsForm(string currProject, string currSceneBundle, int currVWidth, int currVHeight, string currPreLoadScript, string currPostLoadScript, string currUnloadScript)
        {
            InitializeComponent();
            saveButton.Enabled = false;

            m_sCurrentProject = currProject;
            m_sSceneResourceBundle = currSceneBundle;

            m_iViewPortX = currVWidth;
            m_iViewPortY = currVHeight;
            widthTextBox.Text = currVWidth.ToString();
            heightTextBox.Text = currVHeight.ToString();
            preLoadScriptTextBox.Text = currPreLoadScript;
            postLoadScriptTextBox.Text = currPostLoadScript;
        }

        public int GetWidth()
        {
            return m_iViewPortX;
        }

        public int GetHeight()
        {
            return m_iViewPortY;
        }

        public string GetPreLoadScript()
        {
            return preLoadScriptTextBox.Text;
        }

        public string GetPostLoadScript()
        {
            return postLoadScriptTextBox.Text;
        }

        public string GetUnLoadScript()
        {
            return unLoadScriptTextBox.Text;
        }

        public string GetSceneResourceBundle()
        {
            return m_sSceneResourceBundle;
        }

        private void NumChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Name == "widthTextBox")
            {
                if (!int.TryParse(textBox.Text, out m_iViewPortX))
                {
                    m_iViewPortX = -1;
                }
            }
            else if (textBox.Name == "heightTextBox")
            {
                if (!int.TryParse(textBox.Text, out m_iViewPortY))
                {
                    m_iViewPortY = -1;
                }
            }

            if (CanSaveScene())
            {
                saveButton.Enabled = true;
            }
            else
            {
                saveButton.Enabled = false;
            }
        }

        private bool CanSaveScene()
        {
            if (m_iViewPortX > 0 && m_iViewPortY > 0)
            {
                return true;
            }

            return false;
        }

        private bool FileIsPartOfBundle(string filePath)
        {
            if (filePath == null || filePath == "")
            {
                return false;
            }
            
            string resourceBundleFullPath = Path.Combine(m_sCurrentProject, Path.GetFileNameWithoutExtension(m_sSceneResourceBundle));

            if (filePath.StartsWith(resourceBundleFullPath))
            {
                return true;
            }

            return false;
        }

        private void browsePreLoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.InitialDirectory = m_sCurrentProject;
            openFile.Filter = "Lua Script | *.lua";
            openFile.ShowDialog();
            if (openFile.FileNames.Length > 0)
            {
                string fileName = openFile.FileNames[0];
                
                string resourceBundleFullPath = Path.Combine(m_sCurrentProject, Path.GetFileNameWithoutExtension(m_sSceneResourceBundle));

                if (fileName.StartsWith(resourceBundleFullPath))
                {
                    preLoadScriptTextBox.Text = fileName.Replace(resourceBundleFullPath + Path.DirectorySeparatorChar, "").Replace("\\", "/");

                    if (CanSaveScene())
                    {
                        saveButton.Enabled = true;
                    }
                    else
                    {
                        saveButton.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Error - The script file must be inside the same resource bundle as the scene file.", "Error");
                }
            }
        }

        private void browsePostLoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.InitialDirectory = m_sCurrentProject;
            openFile.Filter = "Lua Script | *.lua";
            openFile.ShowDialog();
            if (openFile.FileNames.Length > 0)
            {
                string fileName = openFile.FileNames[0];

                string resourceBundleFullPath = Path.Combine(m_sCurrentProject, Path.GetFileNameWithoutExtension(m_sSceneResourceBundle));

                if (fileName.StartsWith(resourceBundleFullPath))
                {
                    postLoadScriptTextBox.Text = fileName.Replace(resourceBundleFullPath + Path.DirectorySeparatorChar, "").Replace("\\", "/");

                    if (CanSaveScene())
                    {
                        saveButton.Enabled = true;
                    }
                    else
                    {
                        saveButton.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Error - The script file must be inside the same resource bundle as the scene file.", "Error");
                }
            }
        }

        private void browseUnLoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.InitialDirectory = m_sCurrentProject;
            openFile.Filter = "Lua Script | *.lua";
            openFile.ShowDialog();
            if (openFile.FileNames.Length > 0)
            {
                string fileName = openFile.FileNames[0];

                string resourceBundleFullPath = Path.Combine(m_sCurrentProject, Path.GetFileNameWithoutExtension(m_sSceneResourceBundle));

                if (fileName.StartsWith(resourceBundleFullPath))
                {
                    unLoadScriptTextBox.Text = fileName.Replace(resourceBundleFullPath + Path.DirectorySeparatorChar, "").Replace("\\", "/");

                    if (CanSaveScene())
                    {
                        saveButton.Enabled = true;
                    }
                    else
                    {
                        saveButton.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Error - The script file must be inside the same resource bundle as the scene file.", "Error");
                }
            }
        }
    }
}
