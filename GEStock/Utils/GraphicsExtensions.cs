using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GEStock.Utils
{
    public static class GraphicsExtensions
    {
        public static void FillRoundedRectangle(this Graphics g, Brush brush, Rectangle rect, int radius)
        {
            if (rect.Width <= 0 || rect.Height <= 0) return;
            using (GraphicsPath path = CreateRoundedRectanglePath(rect, radius))
            {
                g.FillPath(brush, path);
            }
        }

        public static void DrawRoundedRectangle(this Graphics g, Pen pen, Rectangle rect, int radius)
        {
            if (rect.Width <= 0 || rect.Height <= 0) return;
            using (GraphicsPath path = CreateRoundedRectanglePath(rect, radius))
            {
                g.DrawPath(pen, path);
            }
        }

        private static GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));

            // Top Left
            path.AddArc(arcRect, 180, 90);

            // Top Right
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);

            // Bottom Right
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);

            // Bottom Left
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}
