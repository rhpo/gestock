using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEStock.Services;
using GEStock.Models;
using GEStock.Utils;
using System.IO;

namespace GEStock
{
    public partial class Dashboard : UserControl
    {
        private List<int> _dailyMoves = new List<int>();

        public Dashboard()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            this.Load += Dashboard_Load;
            this.Resize += (s, e) => this.Invalidate(true);

            SetupResponsivePanel(panel1GraphArea, (g, r) => DrawMiniGraph(g, r, Color.FromArgb(66, 133, 244)));
            SetupResponsivePanel(panel2GraphArea, (g, r) => DrawMiniGraph(g, r, Color.FromArgb(234, 67, 53)));
            SetupResponsivePanel(panel3GraphArea, (g, r) => DrawMiniGraph(g, r, Color.FromArgb(171, 71, 188), _dailyMoves));
            SetupResponsivePanel(panel4GraphArea, (g, r) => DrawMiniGraph(g, r, Color.FromArgb(251, 140, 0)));
            SetupResponsivePanel(pnlChartContainer, (g, r) => DrawStockDistribution(g, r));

            pnlTipsContainer.Resize += (s, e) => LoadIntelligentAdvices();

            pnlTopProductsList.Resize += (s, e) => UpdateListItemsWidth(pnlTopProductsList);
            pnlActivitiesList.Resize += (s, e) => UpdateListItemsWidth(pnlActivitiesList);

            // Ensure they resize with their parents
            panelTopProducts.Resize += (s, e) => UpdateListItemsWidth(pnlTopProductsList);
            panelRecentActivities.Resize += (s, e) => UpdateListItemsWidth(pnlActivitiesList);
        }

        private void UpdateListItemsWidth(FlowLayoutPanel pnl)
        {
            pnl.SuspendLayout();
            int width = pnl.ClientSize.Width - (pnl.VerticalScroll.Visible ? SystemInformation.VerticalScrollBarWidth : 0) - 5;
            if (width < 100) width = pnl.Width - 25;

            foreach (Control c in pnl.Controls)
            {
                if (c is Panel p)
                {
                    p.Width = width;
                    if (p.Tag?.ToString() == "ProductItem")
                    {
                        var info = p.Controls.OfType<Panel>().FirstOrDefault(x => x.Dock == DockStyle.Bottom);
                        if (info != null)
                        {
                            var lblCount = info.Controls.OfType<Label>().FirstOrDefault(x => x.Anchor.HasFlag(AnchorStyles.Right));
                            if (lblCount != null)
                            {
                                lblCount.Left = info.Width - lblCount.Width - 15;
                            }
                        }
                    }
                }
            }
            pnl.ResumeLayout();
        }

        private void SetupResponsivePanel(Panel pnl, Action<Graphics, Rectangle> paintAction)
        {
            pnl.Paint += (s, e) => paintAction(e.Graphics, pnl.ClientRectangle);
            pnl.Resize += (s, e) => pnl.Invalidate();
        }

        private void DrawMiniGraph(Graphics g, Rectangle rect, Color color, List<int>? data = null)
        {
            if (rect.Width <= 10 || rect.Height <= 10) return;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (var pen = new Pen(color, 2f))
            {
                var points = new PointF[10];
                float stepX = rect.Width / 9f;

                if (data != null && data.Count >= 10)
                {
                    int max = data.Max();
                    if (max == 0) max = 1;
                    for (int i = 0; i < 10; i++)
                    {
                        float val = data[i];
                        float y = rect.Height - (val / max * (rect.Height - 15)) - 5;
                        points[i] = new PointF(i * stepX, y);
                    }
                }
                else
                {
                    var rand = new Random(rect.GetHashCode());
                    for (int i = 0; i < 10; i++)
                    {
                        float y = rect.Height - (rand.Next(10, (int)rect.Height - 5));
                        points[i] = new PointF(i * stepX, y);
                    }
                }

                g.DrawLines(pen, points);

                using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                    rect, Color.FromArgb(40, color), Color.Transparent, 90f))
                {
                    var path = new System.Drawing.Drawing2D.GraphicsPath();
                    path.AddLines(points);
                    path.AddLine(points[9].X, rect.Height, 0, rect.Height);
                    path.CloseFigure();
                    g.FillPath(brush, path);
                }
            }
        }

        private void DrawStockDistribution(Graphics g, Rectangle rect)
        {
            if (rect.Width <= 50 || rect.Height <= 50) return;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            using (var fontTitle = new Font("Segoe UI Semibold", 12F, FontStyle.Bold))
            {
                g.DrawString("État des Stocks", fontTitle, Brushes.White, 10, 10);
            }

            int total = StatsService.GetTotalProducts();
            int low = StatsService.GetLowStockCount();
            int ok = total - low;

            if (total == 0)
            {
                using (var fontEmpty = new Font("Segoe UI", 10))
                {
                    string msg = "Aucune donnée";
                    var sizeMsg = g.MeasureString(msg, fontEmpty);
                    g.DrawString(msg, fontEmpty, Brushes.Gray, (rect.Width - sizeMsg.Width) / 2, (rect.Height - sizeMsg.Height) / 2);
                }
                return;
            }

            float okPercent = (float)ok / total;
            float okAngle = okPercent * 360f;
            float lowAngle = 360f - okAngle;

            int titleHeight = 40;
            int legendHeight = 50;
            int availableHeight = rect.Height - titleHeight - legendHeight;

            int maxSize = 250;
            int size = Math.Min(Math.Min(rect.Width - 60, availableHeight - 20), maxSize);
            if (size < 60) size = 60;

            Rectangle chartRect = new Rectangle(
                (rect.Width - size) / 2,
                titleHeight + (availableHeight - size) / 2,
                size, size);

            int thickness = size / 6;
            Rectangle drawRect = chartRect;
            drawRect.Inflate(-thickness / 2, -thickness / 2);

            using (var penBg = new Pen(Color.FromArgb(45, 45, 55), thickness))
            {
                g.DrawEllipse(penBg, drawRect);
            }

            using (var penOk = new Pen(Color.FromArgb(52, 168, 83), thickness))
            using (var penLow = new Pen(Color.FromArgb(234, 67, 53), thickness))
            {
                penOk.StartCap = penOk.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                penLow.StartCap = penLow.EndCap = System.Drawing.Drawing2D.LineCap.Round;

                if (okAngle > 0)
                    g.DrawArc(penOk, drawRect, -90, okAngle);

                if (lowAngle > 0)
                    g.DrawArc(penLow, drawRect, -90 + okAngle, lowAngle);
            }

            using (var fontPct = new Font("Segoe UI", size / 6, FontStyle.Bold))
            using (var fontLabel = new Font("Segoe UI", size / 12))
            {
                string pctText = $"{(int)(okPercent * 100)}%";
                var sizePct = g.MeasureString(pctText, fontPct);
                g.DrawString(pctText, fontPct, Brushes.White,
                    chartRect.X + (chartRect.Width - sizePct.Width) / 2,
                    chartRect.Y + (chartRect.Height - sizePct.Height) / 2 - 5);

                string labelText = "Sain";
                var sizeLabel = g.MeasureString(labelText, fontLabel);
                g.DrawString(labelText, fontLabel, Brushes.Gray,
                    chartRect.X + (chartRect.Width - sizeLabel.Width) / 2,
                    chartRect.Y + (chartRect.Height - sizeLabel.Height) / 2 + sizePct.Height / 2);
            }

            using (Font fontLeg = new Font("Segoe UI Semibold", 9))
            {
                string txtOk = $"Sain ({ok})";
                string txtLow = $"Alerte ({low})";

                var szOk = g.MeasureString(txtOk, fontLeg);
                var szLow = g.MeasureString(txtLow, fontLeg);

                float spacing = 30;
                float totalLegWidth = szOk.Width + szLow.Width + 50 + spacing;
                float legX = (rect.Width - totalLegWidth) / 2;
                float legY = rect.Height - 35;

                g.FillEllipse(new SolidBrush(Color.FromArgb(52, 168, 83)), legX, legY + 3, 10, 10);
                g.DrawString(txtOk, fontLeg, Brushes.White, legX + 18, legY);

                float legX2 = legX + szOk.Width + 18 + spacing;
                g.FillEllipse(new SolidBrush(Color.FromArgb(234, 67, 53)), legX2, legY + 3, 10, 10);
                g.DrawString(txtLow, fontLeg, Brushes.White, legX2 + 18, legY);
            }
        }

        private void Dashboard_Load(object? sender, EventArgs e)
        {
            LoadStats();
        }

        public void LoadStats()
        {
            try
            {
                int totalProducts = StatsService.GetTotalProducts();
                int lowStock = StatsService.GetLowStockCount();
                int recentMoves = StatsService.GetRecentMovementsCount(7);
                decimal totalValue = StatsService.GetTotalStockValue();
                _dailyMoves = StatsService.GetDailyMovementCounts(10);

                UpdateStats(totalProducts, lowStock, recentMoves, totalValue);
                LoadRecentActivities();
                LoadTopProducts();
                LoadIntelligentAdvices();

                this.Invalidate(true);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading stats: {ex.Message}");
            }
        }

        private void LoadIntelligentAdvices()
        {
            if (pnlTipsContainer == null) return;
            pnlTipsContainer.SuspendLayout();
            pnlTipsContainer.Controls.Clear();
            var advices = new List<string>();

            var criticals = StatsService.GetCriticalStockNames();
            if (criticals.Any())
                advices.Add($"⚠️ ALERTE CRITIQUE : {string.Join(", ", criticals.Take(2))} sont presque épuisés.");

            var highValue = StatsService.GetHighValueLowSalesNames();
            if (highValue.Any())
                advices.Add($"💰 OPTIMISATION : {string.Join(", ", highValue.Take(2))} ont une valeur élevée mais peu de ventes.");

            var stagnant = StatsService.GetStagnantProducts(30);
            if (stagnant.Any())
                advices.Add($"📉 STOCK DORMANT : {string.Join(", ", stagnant.Take(2))} n'ont eu aucun mouvement depuis 30 jours.");

            int missingImages = StatsService.GetProductsWithoutImagesCount();
            if (missingImages > 0)
                advices.Add($"🖼️ CATALOGUE : {missingImages} produits n'ont pas de photo.");

            advices.Add("💡 CONSEIL : Utilisez la méthode FIFO pour optimiser la rotation de vos stocks.");
            advices.Add("💡 CONSEIL : Réalisez un inventaire tournant chaque semaine.");

            // DEBUG ALERT (Optional, can be uncommented if still not showing)
            // MessageBox.Show($"Chargement de {advices.Count} conseils.");

            foreach (var advice in advices)
            {
                Label lbl = new Label
                {
                    Text = advice,
                    ForeColor = Color.FromArgb(220, 220, 240),
                    Font = new Font("Segoe UI", 10, FontStyle.Italic),
                    AutoSize = true,
                    Margin = new Padding(0, 0, 0, 10),
                    MaximumSize = new Size(Math.Max(200, pnlTipsContainer.Width - 50), 0),
                    BackColor = Color.Transparent
                };

                pnlTipsContainer.Controls.Add(lbl);
            }

            pnlTipsContainer.BringToFront();
            pnlTipsContainer.ResumeLayout(true);
            pnlTipsContainer.PerformLayout();
        }

        private void LoadTopProducts()
        {
            pnlTopProductsList.SuspendLayout();
            pnlTopProductsList.Controls.Clear();

            var topProducts = StatsService.GetTopProducts(10);

            // Add in reverse order because Dock.Top stacks upwards
            for (int i = topProducts.Count - 1; i >= 0; i--)
            {
                var tp = topProducts[i];
                bool hasImage = !string.IsNullOrEmpty(tp.ImagePath) && File.Exists(tp.ImagePath);

                Panel item = new Panel
                {
                    Width = pnlTopProductsList.DisplayRectangle.Width - 10,
                    Height = hasImage ? 210 : 60,
                    BackColor = Color.FromArgb(35, 35, 45),
                    Padding = new Padding(0),
                    Tag = "ProductItem",
                    Margin = new Padding(0, 0, 0, 10)
                };

                if (hasImage)
                {
                    PictureBox pic = new PictureBox
                    {
                        Dock = DockStyle.Top,
                        Height = 150,
                        Image = Image.FromFile(tp.ImagePath),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        BackColor = Color.FromArgb(25, 25, 35)
                    };
                    item.Controls.Add(pic);
                }

                Panel info = new Panel
                {
                    Dock = DockStyle.Bottom,
                    Height = 50,
                    Padding = new Padding(10, 5, 10, 5)
                };

                Label lblName = new Label
                {
                    Text = tp.Name,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI Semibold", 10),
                    AutoSize = true,
                    Location = new Point(10, 12),
                    Anchor = AnchorStyles.Left | AnchorStyles.Top
                };

                Label lblCount = new Label
                {
                    Text = $"{tp.Count} mvts",
                    ForeColor = Color.FromArgb(66, 133, 244),
                    Font = new Font("Segoe UI Bold", 9),
                    AutoSize = true,
                    Anchor = AnchorStyles.Right | AnchorStyles.Top
                };

                info.Controls.Add(lblName);
                info.Controls.Add(lblCount);
                item.Controls.Add(info);

                // Force count to the right
                lblCount.Left = info.Width - lblCount.Width - 15;
                lblCount.Top = 12;

                pnlTopProductsList.Controls.Add(item);
            }

            pnlTopProductsList.ResumeLayout(true);
            pnlTopProductsList.PerformLayout();
            UpdateListItemsWidth(pnlTopProductsList);
        }

        private void LoadRecentActivities()
        {
            pnlActivitiesList.Controls.Clear();
            var movements = MovementService.GetMovementsWithDetails().Take(10).ToList();

            foreach (var m in movements)
            {
                Panel item = new Panel
                {
                    Width = pnlActivitiesList.DisplayRectangle.Width - 10,
                    Height = 60,
                    Padding = new Padding(10),
                    BackColor = Color.FromArgb(35, 35, 45),
                    Margin = new Padding(0, 0, 0, 5)
                };

                PictureBox picProduct = new PictureBox
                {
                    Size = new Size(40, 40),
                    Location = new Point(10, 10),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BackColor = Color.FromArgb(45, 45, 55)
                };

                if (!string.IsNullOrEmpty(m.ProductImage) && File.Exists(m.ProductImage))
                {
                    try { picProduct.Image = Image.FromFile(m.ProductImage); } catch { SetQuestionMark(picProduct); }
                }
                else
                {
                    SetQuestionMark(picProduct);
                }

                Label lblInfo = new Label
                {
                    Text = $"{m.TypeName} : {m.ProductName} ({m.Quantity})",
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI Semibold", 10),
                    AutoSize = true,
                    Location = new Point(60, 10)
                };

                Label lblSub = new Label
                {
                    Text = $"{m.Date:dd/MM HH:mm} - Par {m.UserName}",
                    ForeColor = Color.FromArgb(150, 150, 170),
                    Font = new Font("Segoe UI", 8),
                    AutoSize = true,
                    Location = new Point(60, 32)
                };

                item.Controls.Add(lblInfo);
                item.Controls.Add(lblSub);
                item.Controls.Add(picProduct);

                pnlActivitiesList.Controls.Add(item);
            }
            UpdateListItemsWidth(pnlActivitiesList);
        }

        private void SetQuestionMark(PictureBox pic)
        {
            Bitmap bmp = new Bitmap(40, 40);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(45, 45, 55));
                using (Font f = new Font("Segoe UI", 20, FontStyle.Bold))
                {
                    var size = g.MeasureString("?", f);
                    g.DrawString("?", f, Brushes.Gray, (40 - size.Width) / 2, (40 - size.Height) / 2);
                }
            }
            pic.Image = bmp;
        }

        public void UpdateStats(int totalProducts, int lowStock, int recentMoves, decimal totalValue)
        {
            lblCard1Number.Text = totalProducts.ToString();
            lblCard2Number.Text = lowStock.ToString();
            lblCard3Number.Text = recentMoves.ToString();
            lblCard4Number.Text = $"{totalValue:N0} DA";
        }

        public void UpdateCard1(int value, string? title = null, string? description = null)
        {
            lblCard1Number.Text = value.ToString();
            if (!string.IsNullOrEmpty(title)) lblCard1Title.Text = title;
            if (!string.IsNullOrEmpty(description)) lblCard1Description.Text = description;
        }

        public void UpdateCard2(int value, string? title = null, string? description = null)
        {
            lblCard2Number.Text = value.ToString();
            if (!string.IsNullOrEmpty(title)) lblCard2Title.Text = title;
            if (!string.IsNullOrEmpty(description)) lblCard2Description.Text = description;
        }

        public void UpdateCard3(int value, string? title = null, string? description = null)
        {
            lblCard3Number.Text = value.ToString();
            if (!string.IsNullOrEmpty(title)) lblCard3Title.Text = title;
            if (!string.IsNullOrEmpty(description)) lblCard3Description.Text = description;
        }

        public void UpdateCard4(decimal value, string? title = null, string? description = null)
        {
            lblCard4Number.Text = $"{value:N0} DA";
            if (!string.IsNullOrEmpty(title)) lblCard4Title.Text = title;
            if (!string.IsNullOrEmpty(description)) lblCard4Description.Text = description;
        }

        public Panel? GetGraphArea(int cardNumber)
        {
            return cardNumber switch
            {
                1 => panel1GraphArea,
                2 => panel2GraphArea,
                3 => panel3GraphArea,
                4 => panel4GraphArea,
                _ => null
            };
        }
    }
}
