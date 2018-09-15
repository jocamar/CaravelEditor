﻿using System;
using System.Linq;
using System.Windows.Forms;

namespace CaravelEditor
{
    public partial class RenameEntityForm : Form
    {
        public string[] m_EntityNames;

        public RenameEntityForm(string entityName, string[] entityNames)
        {
            InitializeComponent();

            m_EntityNames = entityNames;
            nameTextBox.Text = entityName;

            renameButton.Enabled = false;
        }

        public string GetNewName()
        {
            return nameTextBox.Text;
        }

        private void NameChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (!m_EntityNames.Contains(textBox.Text) && textBox.Text != "")
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
