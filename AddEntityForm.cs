﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static CaravelEditor.EditorForm;

namespace CaravelEditor
{
    public partial class AddEntityForm : Form
    {
        private string[] m_Paths;
        private string m_ParentPath;
        private static int lastIdUsed = 0;
        public static string LastEntityTypeResourceUsed = "";

        public AddEntityForm(List<EntityTypeItem> types, string[] paths, string parentPath)
        {
            InitializeComponent();
            
            int lastUsedIdx = -1;
            m_ParentPath = parentPath;

            var noType = new EntityTypeItem();
            noType.Type = "None";
            noType.Resource = "";

            LastEntityTypeResourceUsed = LastEntityTypeResourceUsed.Replace("\\", "/");

            this.typeComboBox.Items.Add(noType);
            for(var i = 0; i < types.Count; i++)
            {
                var type = types[i];
                if (type.Resource == LastEntityTypeResourceUsed)
                {
                    lastUsedIdx = i;
                }

                this.typeComboBox.Items.Add(type);
            }

            if (lastUsedIdx >= 0)
            {
                typeComboBox.SelectedIndex = lastUsedIdx+1;
            }

            this.m_Paths = paths;
            this.addButton.Enabled = false;

            var placeHolderName = "";

            lastUsedIdx = 0;
            do
            {
                string prefix = "Entity";
                if (typeComboBox.SelectedIndex > 0)
                {
                    prefix = types[lastUsedIdx].Type;
                }

                placeHolderName = prefix + "_" + lastIdUsed;
                lastIdUsed++;
            }
            while (m_Paths.Contains(parentPath + "/" + placeHolderName));
            textBox.Text = placeHolderName;
        }

        public string GetEntityName()
        {
            return textBox.Text;
        }

        public string GetEntityType()
        {
            LastEntityTypeResourceUsed = ((EntityTypeItem)typeComboBox.SelectedItem).Resource;
            return ((EntityTypeItem) typeComboBox.SelectedItem).Resource;
        }

        public bool TypeWasSelected()
        {
            return typeComboBox.SelectedIndex != -1 && typeComboBox.SelectedIndex != 0;
        }

        public void textBox_OnTextChanged(object sender, EventArgs eventArgs)
        {
            if (textBox.Text != "" && !m_Paths.Contains(m_ParentPath + "/" + textBox.Text))
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
