using System;
using System.IO;
using System.Windows.Forms;

namespace CaravelEditor
{
    public partial class AddSceneForm : Form
    {
        private string m_sCurrentProject;
        private string[] m_ResourceBundles;
        private int m_iViewPortX = -1;
        private int m_iViewPortY = -1;
        private string m_sSceneResourceBundle;

        public AddSceneForm(string currProject, string[] resourceBundles)
        {
            InitializeComponent();
            saveButton.Enabled = false;

            m_sCurrentProject = currProject;
            m_ResourceBundles = resourceBundles;
        }

        public string GetWidth()
        {
            return m_iViewPortX.ToString();
        }

        public string GetHeight()
        {
            return m_iViewPortY.ToString();
        }

        public string GetFile()
        {
            return fileTextBox.Text;
        }

        public string GetPreLoadScript()
        {
            return preLoadScriptTextBox.Text;
        }

        public string GetPostLoadScript()
        {
            return postLoadScriptTextBox.Text;
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

            if (CanCreateScene())
            {
                saveButton.Enabled = true;
            }
            else
            {
                saveButton.Enabled = false;
            }
        }

        private bool CanCreateScene()
        {
            if (m_iViewPortX > 0 && m_iViewPortY > 0 && FileIsPartOfBundle(fileTextBox.Text))
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

            foreach (var bundle in m_ResourceBundles)
            {
                string resourceBundleFullPath = Path.Combine(m_sCurrentProject, Path.GetFileNameWithoutExtension(bundle));
               
                if (filePath.StartsWith(resourceBundleFullPath))
                {
                    m_sSceneResourceBundle = bundle;
                    return true;
                }
            }

            return false;
        }

        private void sceneFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.InitialDirectory = m_sCurrentProject;
            saveFile.Filter = "Caravel Scene | *.cvs";
            saveFile.ShowDialog();
            if (saveFile.FileNames.Length > 0)
            {
                string fileName = saveFile.FileNames[0];
                if (FileIsPartOfBundle(fileName))
                {
                    fileTextBox.Text = fileName;

                    if (CanCreateScene())
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
                    MessageBox.Show("Error - The file must be inside one of the existing resource bundles for this project.", "Error");
                }
            }
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

                if (m_sSceneResourceBundle != null && m_sSceneResourceBundle != "")
                {
                    string resourceBundleFullPath = Path.Combine(m_sCurrentProject, Path.GetFileNameWithoutExtension(m_sSceneResourceBundle));

                    if (fileName.StartsWith(resourceBundleFullPath))
                    {
                        preLoadScriptTextBox.Text = fileName.Replace(resourceBundleFullPath + Path.DirectorySeparatorChar, "").Replace("\\","/");

                        if (CanCreateScene())
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
                else
                {
                    MessageBox.Show("Error - You must first choose the location of the scene file.", "Error");
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

                if (m_sSceneResourceBundle != null && m_sSceneResourceBundle != "")
                {
                    string resourceBundleFullPath = Path.Combine(m_sCurrentProject, Path.GetFileNameWithoutExtension(m_sSceneResourceBundle));

                    if (fileName.StartsWith(resourceBundleFullPath))
                    {
                        postLoadScriptTextBox.Text = fileName.Replace(resourceBundleFullPath + Path.DirectorySeparatorChar, "").Replace("\\", "/");

                        if (CanCreateScene())
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
                else
                {
                    MessageBox.Show("Error - You must first choose the location of the scene file.", "Error");
                }
            }
        }
    }
}
