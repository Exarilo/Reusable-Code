

using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public class OpacityPanel : Panel
    {
        private float _opacity = 1.0f;

        public float Opacity
        {
            get => _opacity;
            set
            {
                _opacity = value;
                Invalidate();
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;
                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (var brush = new SolidBrush(Color.FromArgb((int)(_opacity * 255), BackColor)))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }

            base.OnPaint(e);
        }
    }
}
