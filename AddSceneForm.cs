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

        private void browseButton_Click(object sender, EventArgs e)
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
    }
}
