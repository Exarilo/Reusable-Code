using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public class GradientBackgroundPanel : Panel
    {
        // Set the start and end colors for the gradient
        private Color startColor = Color.FromArgb(255, 255, 255);
        private Color endColor = Color.FromArgb(192, 192, 192);

        public Color StartColor
        {
            get { return startColor; }
            set
            {
                startColor = value;
                InitializeBrushAndPath();
                Invalidate();
            }
        }

        public Color EndColor
        {
            get { return endColor; }
            set
            {
                endColor = value;
                InitializeBrushAndPath();
                Invalidate();
            }
        }
        // Create a linear brush to draw the gradient background
        private LinearGradientBrush brush;

        // Create a path to draw a rounded background
        private GraphicsPath path;

        public GradientBackgroundPanel()
        {
            // Initialize the brush and path when the control is created
            InitializeBrushAndPath();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Draw the gradient background using the brush and path
            e.Graphics.FillPath(brush, path);

            base.OnPaint(e);
        }

        private void InitializeBrushAndPath()
        {
            // Create the brush with the start and end colors and the direction of the gradient
            brush = new LinearGradientBrush(ClientRectangle, startColor, endColor, 90f);

            // Create a path to draw a rounded background with rounded edges
            path = new GraphicsPath();
            path.AddArc(0, 0, 10, 10, 180, 90);
            path.AddArc(Width - 11, 0, 10, 10, -90, 90);
            path.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
            path.AddArc(0, Height - 11, 10, 10, 90, 90);
            path.CloseAllFigures();
        }

        protected override void OnResize(EventArgs e)
        {
            // Update the brush and path when the panel is resized
            InitializeBrushAndPath();

            base.OnResize(e);
        }
    }
}
