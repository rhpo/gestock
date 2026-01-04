using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GEStock
{
    public partial class About : UserControl
    {
        public About()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            LoadLogo();
        }

        private void LoadLogo()
        {
            try
            {
                // Try relative path first (Resources folder in execution directory)
                string relativePath = Path.Combine(Application.StartupPath, "Resources", "ESST.png");
                if (File.Exists(relativePath))
                {
                    picLogo.Image = Image.FromFile(relativePath);
                }
                else
                {
                    // Fallback to gestock.png if ESST.png is missing
                    string fallbackPath = "C:/Users/ramyh/Pictures/ESST.png";
                    if (File.Exists(fallbackPath))
                    {
                        picLogo.Image = Image.FromFile(fallbackPath);
                    }
                }
            }
            catch { /* Ignore if images fail to load */ }
        }

        private void pnlCard_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw a subtle border or glow
            using (Pen pen = new Pen(Color.FromArgb(50, 50, 70), 2))
            {
                Rectangle rect = pnlCard.ClientRectangle;
                rect.Width -= 1;
                rect.Height -= 1;

                // Draw rounded rectangle border
                int radius = 20;
                using (GraphicsPath path = GetRoundedRect(rect, radius))
                {
                    g.DrawPath(pen, path);
                }
            }
        }

        private GraphicsPath GetRoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // top left arc
            path.AddArc(arc, 180, 90);

            // top right arc
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}
