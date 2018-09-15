using System;
using System.Windows.Forms;

namespace CaravelEditor
{
    public partial class AddAnimationForm : Form
    {
        public AddAnimationForm()
        {
            InitializeComponent();
            addButton.Enabled = false;
        }

        public string GetAnimationId()
        {
            return textBox.Text;
        }

        public void textBox_OnTextChanged(object sender, EventArgs eventArgs)
        {
            if (textBox.Text != "")
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
