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
using System.Xml;

namespace CaravelEditor
{
    public partial class MakeIntoTypeForm : Form
    {
        private string m_sEntityResourceBundle;
        private string m_sProjectDirectory;
        private string[] m_ExistingTypes;

        public MakeIntoTypeForm(string resourceBundle, string projectDirectory, string[] existingTypes)
        {
            m_sEntityResourceBundle = resourceBundle;
            m_ExistingTypes = existingTypes;
            m_sProjectDirectory = projectDirectory;

            InitializeComponent();
            saveButton.Enabled = false;
        }

        public string GetFileName()
        {
            return fileTextBox.Text;
        }

        public string GetTypeName()
        {
            return typeTextBox.Text;
        }

        public void textBox_OnTextChanged(object sender, EventArgs eventArgs)
        {
            if (fileTextBox.Text != "" && typeTextBox.Text != "" && !m_ExistingTypes.Contains(typeTextBox.Text))
            {
                saveButton.Enabled = true;
            }
            else
            {
                saveButton.Enabled = false;
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            string bundleLocation = Path.Combine(m_sProjectDirectory, Path.GetFileNameWithoutExtension(m_sEntityResourceBundle));
            string entityTypesLocation = Path.Combine(bundleLocation, "entity_types");

            saveFile.InitialDirectory = entityTypesLocation;
            saveFile.Filter = "Caravel Entity Type | *.cve";
            saveFile.ShowDialog();
            if (saveFile.FileNames.Length > 0)
            {
                string fileName = saveFile.FileNames[0];
                if (fileName.StartsWith(entityTypesLocation))
                {
                    fileTextBox.Text = fileName.Substring(bundleLocation.Length + 1);
                }
                else
                {
                    MessageBox.Show("Error - The file must be a part of the same resource bundle as the entity (it must be in " + entityTypesLocation + ").");
                }
            }
        }
    }
}
