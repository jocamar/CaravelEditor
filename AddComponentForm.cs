﻿using System;
using System.Linq;
using System.Windows.Forms;

namespace CaravelEditor
{
    public partial class AddComponentForm : Form
    {
        public AddComponentForm(string[] components, string[] entityComponents)
        {
            InitializeComponent();

            addButton.Enabled = false;

            foreach (var comp in components)
            {
                if (!entityComponents.Contains(comp))
                {
                    comboBox.Items.Add(comp);
                }
            }
        }

        public string GetSelectedComponent()
        {
            return (string) comboBox.SelectedItem;
        }

        public void comboBox_OnSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            if (comboBox.SelectedIndex != -1)
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
