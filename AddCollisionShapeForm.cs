using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaravelEditor
{
    public partial class AddCollisionShapeForm : Form
    {
        public AddCollisionShapeForm()
        {
            InitializeComponent();

            comboBox.Items.Add("Box");
            comboBox.Items.Add("Trigger");
            comboBox.Items.Add("Circle");
            comboBox.SelectedIndex = 0;
        }

        public string GetShapeType()
        {
            return (string) comboBox.SelectedItem;
        }
    }
}
