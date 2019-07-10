using System;
using System.Linq;
using System.Windows.Forms;

namespace CaravelEditor
{
    public partial class RenameEntityForm : Form
    {
        public string m_ParentPath;
        public string[] m_EntityPaths;

        public RenameEntityForm(string entityName, string parentPath, string[] entityPaths)
        {
            InitializeComponent();

            m_EntityPaths = entityPaths;
            nameTextBox.Text = entityName;

            m_ParentPath = parentPath;

            renameButton.Enabled = false;
        }

        public string GetNewName()
        {
            return nameTextBox.Text;
        }

        private void NameChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (!m_EntityPaths.Contains(m_ParentPath + "/" + textBox.Text) && textBox.Text != "")
            {
                renameButton.Enabled = true;
            }
            else
            {
                renameButton.Enabled = false;
            }
        }
    }
}
