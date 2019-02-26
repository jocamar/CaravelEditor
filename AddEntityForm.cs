using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static CaravelEditor.EditorForm;

namespace CaravelEditor
{
    public partial class AddEntityForm : Form
    {
        private string[] m_Names;
        private static int lastIdUsed = 0;
        private static string lastEntityTypeResourceUsed = "";

        public AddEntityForm(List<EntityTypeItem> types, string[] names)
        {
            InitializeComponent();
            
            int lastUsedIdx = -1;

            var noType = new EntityTypeItem();
            noType.Type = "None";
            noType.Resource = "";

            this.typeComboBox.Items.Add(noType);
            for(var i = 0; i < types.Count; i++)
            {
                var type = types[i];
                if (type.Resource == lastEntityTypeResourceUsed)
                {
                    lastUsedIdx = i;
                }

                this.typeComboBox.Items.Add(type);
            }

            if (lastUsedIdx >= 0)
            {
                typeComboBox.SelectedIndex = lastUsedIdx+1;
            }

            this.m_Names = names;
            this.addButton.Enabled = false;

            var placeHolderName = "";
            do
            {
                placeHolderName = "Entity_" + lastIdUsed;
                lastIdUsed++;
            }
            while (m_Names.Contains(placeHolderName));
            textBox.Text = placeHolderName;
        }

        public string GetEntityName()
        {
            return textBox.Text;
        }

        public string GetEntityType()
        {
            lastEntityTypeResourceUsed = ((EntityTypeItem)typeComboBox.SelectedItem).Resource;
            return ((EntityTypeItem) typeComboBox.SelectedItem).Resource;
        }

        public bool TypeWasSelected()
        {
            return typeComboBox.SelectedIndex != -1 && typeComboBox.SelectedIndex != 0;
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
