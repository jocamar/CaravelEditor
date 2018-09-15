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
