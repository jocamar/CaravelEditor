using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using static Caravel.Core.Physics.Cv_GamePhysics;

namespace CaravelEditor
{
    public partial class MaterialEditorControl : UserControl
    {
        public Dictionary<string, Cv_PhysicsMaterial> PhysicsMaterials;
        public EditorApp EditorApp;

        private string m_sCurrentMaterial;

        public MaterialEditorControl()
        {
            InitializeComponent();
        }

        public void SetMaterial(string materialId)
        {
            m_sCurrentMaterial = materialId;

            if (materialId == null || materialId == "" || !PhysicsMaterials.ContainsKey(materialId))
            {
                m_sCurrentMaterial = "";
                restitutionTextBox.Text = "";
                frictionTextBox.Text = "";
                densityTextBox.Text = "";
            }
            else
            {
                var material = PhysicsMaterials[materialId];

                restitutionTextBox.Text = material.Restitution.ToString(CultureInfo.InvariantCulture);
                frictionTextBox.Text = material.Friction.ToString(CultureInfo.InvariantCulture);
                densityTextBox.Text = material.Density.ToString(CultureInfo.InvariantCulture);
            }
        }

        public void SaveMaterials()
        {
            XmlDocument doc = new XmlDocument();
            var root = doc.CreateElement("Physics");
            var materials = doc.CreateElement("Materials");

            doc.AppendChild(root);
            root.AppendChild(materials);

            foreach (var material in PhysicsMaterials)
            {
                var materialNode = doc.CreateElement(material.Key);

                materialNode.SetAttribute("density", material.Value.Density.ToString(CultureInfo.InvariantCulture));
                materialNode.SetAttribute("friction", material.Value.Friction.ToString(CultureInfo.InvariantCulture));
                materialNode.SetAttribute("restitution", material.Value.Restitution.ToString(CultureInfo.InvariantCulture));

                materials.AppendChild(materialNode);
            }

            XmlWriterSettings oSettings = new XmlWriterSettings();
            oSettings.Indent = true;
            oSettings.OmitXmlDeclaration = true;
            oSettings.Encoding = Encoding.UTF8;
            oSettings.ConformanceLevel = ConformanceLevel.Auto;

            using (XmlWriter writer = XmlWriter.Create(Path.Combine(EditorApp.EForm.CurrentProjectDirectory, EditorApp.MaterialsLocation), oSettings))
            {
                root.WriteTo(writer);
            }

            EditorApp.EditorReadMaterials(EditorApp.EForm.CurrentProjectDirectory);
        }

        private void TextBoxChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox) sender;

            var material = PhysicsMaterials[m_sCurrentMaterial];

            if (textBox == restitutionTextBox)
            {
                material.Restitution = float.Parse(textBox.Text, CultureInfo.InvariantCulture);
            }
            else if (textBox == frictionTextBox)
            {
                material.Friction = float.Parse(textBox.Text, CultureInfo.InvariantCulture);
            }
            else if (textBox == densityTextBox)
            {
                material.Density = float.Parse(textBox.Text, CultureInfo.InvariantCulture);
            }

            PhysicsMaterials[m_sCurrentMaterial] = material;

            SaveMaterials();
        }

        private void TextBoxOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBoxChanged(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
