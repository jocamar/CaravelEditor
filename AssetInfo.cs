using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaravelEditor
{
    public partial class AssetInfo : UserControl
    {
        public AssetInfo()
        {
            InitializeComponent();
        }

        public void SetSize(int size)
        {
            float sizeInKb = size / (1024f);
            float sizeInMb = sizeInKb / (1024f);

            if (sizeInKb > 500)
            {
                sizeTextBox.Text = sizeInMb.ToString("n2") + "MB";
            }
            else
            {
                sizeTextBox.Text = sizeInKb.ToString("n2") + "KB";
            }
        }

        public void SetDimensions(string dimensions)
        {
            dimensionsTextBox.Text = dimensions;
        }
    }
}
