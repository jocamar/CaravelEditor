using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CaravelEditor.EditorForm;

namespace CaravelEditor
{
    public partial class AddEntityForm : Form
    {
        private string[] m_Names;

        public AddEntityForm(List<EntityTypeItem> types, string[] names)
        {
            InitializeComponent();

            /*this.typeComboBox.DisplayMember = "Type";
            this.typeComboBox.ValueMember = "Resource";
            this.typeComboBox.DataSource = types;*/

            foreach(var type in types)
            {
                this.typeComboBox.Items.Add(type);
            }

            this.m_Names = names;

            this.addButton.Enabled = false;
        }

        public string GetEntityName()
        {
            return textBox.Text;
        }

        public string GetEntityType()
        {
            return ((EntityTypeItem) typeComboBox.SelectedItem).Resource;
        }

        public bool TypeWasSelected()
        {
            return typeComboBox.SelectedIndex != -1;
        }

        public void textBox_OnTextChanged(object sender, EventArgs eventArgs)
        {
            if (textBox.Text != "" && !m_Names.Contains(textBox.Text))
            {
                addButton.Enabled = true;
            }
            else
            {
                addButton.Enabled = false;
            }
        }
    }
}
