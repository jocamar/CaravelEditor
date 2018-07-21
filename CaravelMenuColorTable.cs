using System.Drawing;
using System.Windows.Forms;

namespace CaravelEditor
{
    public class CaravelMenuColorTable : ProfessionalColorTable
    {
        public override Color ToolStripDropDownBackground
        {
            get
            {
                return Color.FromArgb(64, 64, 64);
            }
        }

        public override Color ImageMarginGradientBegin
        {
            get
            {
                return Color.FromArgb(80, 80, 80);
            }
        }

        public override Color ImageMarginGradientMiddle
        {
            get
            {
                return Color.FromArgb(80, 80, 80);
            }
        }

        public override Color ImageMarginGradientEnd
        {
            get
            {
                return Color.FromArgb(80, 80, 80);
            }
        }

        public override Color MenuBorder
        {
            get
            {
                return Color.FromArgb(80, 80, 80);
            }
        }

        public override Color MenuItemBorder
        {
            get
            {
                return Color.FromArgb(80, 80, 80);
            }
        }

        public override Color MenuItemSelected
        {
            get
            {
                return Color.FromArgb(80, 80, 80);
            }
        }

        public override Color MenuStripGradientBegin
        {
            get
            {
                return Color.Pink;
            }
        }

        public override Color MenuStripGradientEnd
        {
            get
            {
                return Color.Brown;
            }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get
            {
                return Color.FromArgb(80, 80, 80);
            }
        }

        public override Color MenuItemSelectedGradientEnd
        {
            get
            {
                return Color.FromArgb(80, 80, 80);
            }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get
            {
                return Color.FromArgb(80,80,80);
            }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get
            {
                return Color.FromArgb(80, 80, 80);
            }
        }
    }
}
