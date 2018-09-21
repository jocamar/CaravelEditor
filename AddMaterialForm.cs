using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using static Caravel.Core.Physics.Cv_GamePhysics;

namespace CaravelEditor
{
    public partial class AddMaterialForm : Form
    {
        private string[] m_Materials;
        private float m_fDensity;
        private float m_fFriction;
        private float m_fRestitution;

        public AddMaterialForm(string[] materials)
        {
            InitializeComponent();

            addButton.Enabled = false;

            m_Materials = materials;
        }

        public string GetMaterialName()
        {
            return nameTextBox.Text;
        }

        public Cv_PhysicsMaterial GetMaterial()
        {
            return new Cv_PhysicsMaterial(m_fFriction, m_fRestitution, m_fDensity);
        }

        private bool CheckIfMaterialIsValid()
        {
            if (nameTextBox.Text == null || nameTextBox.Text == "" || m_Materials.Contains(nameTextBox.Text))
            {
                return false;
            }

            if (densityTextBox.Text == "" || !float.TryParse(densityTextBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out m_fDensity) || m_fDensity <= 0)
            {
                return false;
            }

            if (frictionTextBox.Text == "" || !float.TryParse(frictionTextBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out m_fFriction) || m_fFriction < 0)
            {
                return false;
            }

            if (restitutionTextBox.Text == "" || !float.TryParse(restitutionTextBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out m_fRestitution) || m_fRestitution < 0)
            {
                 return false;
            }

            return true;
        }

        private void textBox_OnTextChanged(object sender, EventArgs eventArgs)
        {
            var textBox = (TextBox) sender;
            
            if (CheckIfMaterialIsValid())
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
