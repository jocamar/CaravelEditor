using System.Drawing;
using System.Windows.Forms;

namespace CaravelEditor
{
    public class ComplexButton : Button
    {
        public ComplexButton()
        {
            UseVisualStyleBackColor = false;
            TextImageRelation = TextImageRelation.ImageAboveText;
            SubtitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
        public override string Text
        {
            get { return ""; }
            set { base.Text = value; }
        }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public Font SubtitleFont { get; set; }

        public Color SubtitleColor { get; set; }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            Rectangle rect = ClientRectangle;

            Rectangle titleRectangle = new Rectangle(2*Padding.Left + Image.Width, Padding.Top, rect.Width - Padding.Right, (rect.Height - Padding.Bottom)/2);
            Rectangle subtitleRectangle = new Rectangle(2*Padding.Left + Image.Width, Padding.Top + titleRectangle.Height, rect.Width - Padding.Right, (rect.Height - Padding.Bottom) / 2);

            titleRectangle.Inflate(-5, -5);
            subtitleRectangle.Inflate(-5, -5);
            using (StringFormat sf = new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Far })
            {
                using (Brush brush = new SolidBrush(ForeColor))
                {
                    pevent.Graphics.DrawString(Title, Font, brush, titleRectangle, sf);
                }

                using(Brush brush = new SolidBrush(SubtitleColor))
                {
                    sf.LineAlignment = StringAlignment.Near;
                    pevent.Graphics.DrawString(Subtitle, SubtitleFont, brush, subtitleRectangle, sf);
                }
            }
        }
    }
}
