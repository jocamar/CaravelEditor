using System;
using System.Windows.Forms;
using Caravel.Core.Entity;
using Caravel.Editor;

namespace CaravelEditor
{
    public partial class TransformToolOptions : UserControl
    {
        private EditorApp m_EditorApp;
        private Cv_Entity m_EditorCamera;

        public TransformToolOptions()
        {
            InitializeComponent();
        }

        public void Initialize(EditorApp app)
        {
            if (m_EditorApp != null)
            {
                return;
            }

            m_EditorApp = app;
            stepXTextBox.Text = "1";
            stepYTextBox.Text = "1";
            m_EditorApp.EditorLogic.EntityDragStepX = 1;
            m_EditorApp.EditorLogic.EntityDragStepY = 1;
        }

        private void TextBoxChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            int step;
            if (int.TryParse(textBox.Text, out step))
            {
                if (step < 0)
                {
                    step = -step;
                    textBox.Text = step.ToString();
                }
                else if (step == 0)
                {
                    step = 1;
                    textBox.Text = step.ToString();
                }
            }
            else
            {
                step = 1;
                textBox.Text = step.ToString();
            }

            if (textBox == stepXTextBox)
            {
                m_EditorApp.EditorLogic.EntityDragStepX = step;
            }
            else if (textBox == stepYTextBox)
            {
                m_EditorApp.EditorLogic.EntityDragStepY = step;
            }
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
