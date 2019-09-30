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
    public partial class UnsavedChangesForm : Form
    {
        public bool Save
        {
            get; set;
        }

        public UnsavedChangesForm()
        {
            Save = false;
            InitializeComponent();
        }

        private void saveAndContinueButton_Click(object sender, EventArgs e)
        {
            Save = true;
        }
    }
}
