namespace GEStock
{
    partial class Dashboard : UserControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tlpMain = new TableLayoutPanel();
            tlpCards = new TableLayoutPanel();
            panel1 = new Panel();
            panel1IconPanel = new Panel();
            lblCard1Title = new Label();
            lblCard1Number = new Label();
            lblCard1Description = new Label();
            panel1GraphArea = new Panel();
            panel2 = new Panel();
            panel2IconPanel = new Panel();
            lblCard2Title = new Label();
            lblCard2Number = new Label();
            lblCard2Description = new Label();
            panel2GraphArea = new Panel();
            panel3 = new Panel();
            panel3IconPanel = new Panel();
            lblCard3Title = new Label();
            lblCard3Number = new Label();
            lblCard3Description = new Label();
            panel3GraphArea = new Panel();
            panel4 = new Panel();
            panel4IconPanel = new Panel();
            lblCard4Title = new Label();
            lblCard4Number = new Label();
            lblCard4Description = new Label();
            panel4GraphArea = new Panel();
            tlpMiddle = new TableLayoutPanel();
            panelRecentActivities = new Panel();
            lblRecentTitle = new Label();
            pnlActivitiesList = new FlowLayoutPanel();
            panelStockDistribution = new Panel();
            pnlChartContainer = new Panel();
            lblCardIcon1 = new Label();
            lblCardIcon2 = new Label();
            lblCardIcon3 = new Label();
            lblCardIcon4 = new Label();
            panelTopProducts = new Panel();
            lblTopTitle = new Label();
            pnlTopProductsList = new FlowLayoutPanel();
            panelTips = new Panel();
            lblTipsTitle = new Label();
            lblTipIcon = new Label();
            pnlTipsContainer = new FlowLayoutPanel();

            tlpMain.SuspendLayout();
            tlpCards.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            tlpMiddle.SuspendLayout();
            panelRecentActivities.SuspendLayout();
            panelStockDistribution.SuspendLayout();
            panelTopProducts.SuspendLayout();
            panelTips.SuspendLayout();
            SuspendLayout();

            // tlpMain
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.Controls.Add(tlpCards, 0, 0);
            tlpMain.Controls.Add(tlpMiddle, 0, 1);
            tlpMain.Controls.Add(panelTips, 0, 2);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 0);
            tlpMain.Name = "tlpMain";
            tlpMain.Padding = new Padding(15);
            tlpMain.RowCount = 3;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 220F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 160F));
            tlpMain.Size = new Size(1100, 800);

            // tlpCards
            tlpCards.ColumnCount = 4;
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpCards.Controls.Add(panel1, 0, 0);
            tlpCards.Controls.Add(panel2, 1, 0);
            tlpCards.Controls.Add(panel3, 2, 0);
            tlpCards.Controls.Add(panel4, 3, 0);
            tlpCards.Dock = DockStyle.Fill;
            tlpCards.Location = new Point(18, 18);
            tlpCards.Name = "tlpCards";
            tlpCards.RowCount = 1;
            tlpCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpCards.Size = new Size(1064, 214);

            // panel1
            panel1.BackColor = Color.FromArgb(30, 30, 40);
            panel1.Controls.Add(panel1IconPanel);
            panel1.Controls.Add(lblCard1Title);
            panel1.Controls.Add(lblCard1Number);
            panel1.Controls.Add(lblCard1Description);
            panel1.Controls.Add(panel1GraphArea);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(5, 5);
            panel1.Margin = new Padding(5);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(15);

            // panel1IconPanel
            panel1IconPanel.BackColor = Color.FromArgb(66, 133, 244);
            panel1IconPanel.Controls.Add(lblCardIcon1);
            panel1IconPanel.Location = new Point(15, 15);
            panel1IconPanel.Size = new Size(40, 40);

            // lblCardIcon1
            lblCardIcon1.Dock = DockStyle.Fill;
            lblCardIcon1.Font = new Font("Segoe UI", 18F);
            lblCardIcon1.ForeColor = Color.White;
            lblCardIcon1.Text = "📦";
            lblCardIcon1.TextAlign = ContentAlignment.MiddleCenter;

            // lblCard1Title
            lblCard1Title.AutoSize = true;
            lblCard1Title.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblCard1Title.ForeColor = Color.FromArgb(160, 160, 180);
            lblCard1Title.Location = new Point(65, 15);
            lblCard1Title.Text = "Total Produits";

            // lblCard1Number
            lblCard1Number.AutoSize = true;
            lblCard1Number.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblCard1Number.ForeColor = Color.White;
            lblCard1Number.Location = new Point(15, 60);
            lblCard1Number.Text = "0";

            // lblCard1Description
            lblCard1Description.AutoSize = true;
            lblCard1Description.Font = new Font("Segoe UI", 8F);
            lblCard1Description.ForeColor = Color.FromArgb(120, 120, 140);
            lblCard1Description.Location = new Point(15, 105);
            lblCard1Description.Text = "Articles en inventaire";

            // panel1GraphArea
            panel1GraphArea.BackColor = Color.FromArgb(40, 40, 50);
            panel1GraphArea.Dock = DockStyle.Bottom;
            panel1GraphArea.Location = new Point(15, 139);
            panel1GraphArea.Size = new Size(226, 50);

            // panel2
            panel2.BackColor = Color.FromArgb(30, 30, 40);
            panel2.Controls.Add(panel2IconPanel);
            panel2.Controls.Add(lblCard2Title);
            panel2.Controls.Add(lblCard2Number);
            panel2.Controls.Add(lblCard2Description);
            panel2.Controls.Add(panel2GraphArea);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(271, 5);
            panel2.Margin = new Padding(5);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(15);

            // panel2IconPanel
            panel2IconPanel.BackColor = Color.FromArgb(234, 67, 53);
            panel2IconPanel.Controls.Add(lblCardIcon2);
            panel2IconPanel.Location = new Point(15, 15);
            panel2IconPanel.Size = new Size(40, 40);

            // lblCardIcon2
            lblCardIcon2.Dock = DockStyle.Fill;
            lblCardIcon2.Font = new Font("Segoe UI", 18F);
            lblCardIcon2.ForeColor = Color.White;
            lblCardIcon2.Text = "⚠️";
            lblCardIcon2.TextAlign = ContentAlignment.MiddleCenter;

            // lblCard2Title
            lblCard2Title.AutoSize = true;
            lblCard2Title.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblCard2Title.ForeColor = Color.FromArgb(160, 160, 180);
            lblCard2Title.Location = new Point(65, 15);
            lblCard2Title.Text = "Stock Faible";

            // lblCard2Number
            lblCard2Number.AutoSize = true;
            lblCard2Number.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblCard2Number.ForeColor = Color.White;
            lblCard2Number.Location = new Point(15, 60);
            lblCard2Number.Text = "0";

            // lblCard2Description
            lblCard2Description.AutoSize = true;
            lblCard2Description.Font = new Font("Segoe UI", 8F);
            lblCard2Description.ForeColor = Color.FromArgb(120, 120, 140);
            lblCard2Description.Location = new Point(15, 105);
            lblCard2Description.Text = "Alertes de réapprovisionnement";

            // panel2GraphArea
            panel2GraphArea.BackColor = Color.FromArgb(40, 40, 50);
            panel2GraphArea.Dock = DockStyle.Bottom;
            panel2GraphArea.Location = new Point(15, 139);
            panel2GraphArea.Size = new Size(226, 50);

            // panel3
            panel3.BackColor = Color.FromArgb(30, 30, 40);
            panel3.Controls.Add(panel3IconPanel);
            panel3.Controls.Add(lblCard3Title);
            panel3.Controls.Add(lblCard3Number);
            panel3.Controls.Add(lblCard3Description);
            panel3.Controls.Add(panel3GraphArea);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(537, 5);
            panel3.Margin = new Padding(5);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(15);

            // panel3IconPanel
            panel3IconPanel.BackColor = Color.FromArgb(171, 71, 188);
            panel3IconPanel.Controls.Add(lblCardIcon3);
            panel3IconPanel.Location = new Point(15, 15);
            panel3IconPanel.Size = new Size(40, 40);

            // lblCardIcon3
            lblCardIcon3.Dock = DockStyle.Fill;
            lblCardIcon3.Font = new Font("Segoe UI", 18F);
            lblCardIcon3.ForeColor = Color.White;
            lblCardIcon3.Text = "🔄";
            lblCardIcon3.TextAlign = ContentAlignment.MiddleCenter;

            // lblCard3Title
            lblCard3Title.AutoSize = true;
            lblCard3Title.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblCard3Title.ForeColor = Color.FromArgb(160, 160, 180);
            lblCard3Title.Location = new Point(65, 15);
            lblCard3Title.Text = "Mouvements";

            // lblCard3Number
            lblCard3Number.AutoSize = true;
            lblCard3Number.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblCard3Number.ForeColor = Color.White;
            lblCard3Number.Location = new Point(15, 60);
            lblCard3Number.Text = "0";

            // lblCard3Description
            lblCard3Description.AutoSize = true;
            lblCard3Description.Font = new Font("Segoe UI", 8F);
            lblCard3Description.ForeColor = Color.FromArgb(120, 120, 140);
            lblCard3Description.Location = new Point(15, 105);
            lblCard3Description.Text = "Transactions (7 jours)";

            // panel3GraphArea
            panel3GraphArea.BackColor = Color.FromArgb(40, 40, 50);
            panel3GraphArea.Dock = DockStyle.Bottom;
            panel3GraphArea.Location = new Point(15, 139);
            panel3GraphArea.Size = new Size(226, 50);

            // panel4
            panel4.BackColor = Color.FromArgb(30, 30, 40);
            panel4.Controls.Add(panel4IconPanel);
            panel4.Controls.Add(lblCard4Title);
            panel4.Controls.Add(lblCard4Number);
            panel4.Controls.Add(lblCard4Description);
            panel4.Controls.Add(panel4GraphArea);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(803, 5);
            panel4.Margin = new Padding(5);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(15);

            // panel4IconPanel
            panel4IconPanel.BackColor = Color.FromArgb(251, 140, 0);
            panel4IconPanel.Controls.Add(lblCardIcon4);
            panel4IconPanel.Location = new Point(15, 15);
            panel4IconPanel.Size = new Size(40, 40);

            // lblCardIcon4
            lblCardIcon4.Dock = DockStyle.Fill;
            lblCardIcon4.Font = new Font("Segoe UI", 18F);
            lblCardIcon4.ForeColor = Color.White;
            lblCardIcon4.Text = "💰";
            lblCardIcon4.TextAlign = ContentAlignment.MiddleCenter;

            // lblCard4Title
            lblCard4Title.AutoSize = true;
            lblCard4Title.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblCard4Title.ForeColor = Color.FromArgb(160, 160, 180);
            lblCard4Title.Location = new Point(65, 15);
            lblCard4Title.Text = "Valeur Totale";

            // lblCard4Number
            lblCard4Number.AutoSize = true;
            lblCard4Number.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblCard4Number.ForeColor = Color.White;
            lblCard4Number.Location = new Point(15, 60);
            lblCard4Number.Text = "0 DA";

            // lblCard4Description
            lblCard4Description.AutoSize = true;
            lblCard4Description.Font = new Font("Segoe UI", 8F);
            lblCard4Description.ForeColor = Color.FromArgb(120, 120, 140);
            lblCard4Description.Location = new Point(15, 105);
            lblCard4Description.Text = "Valeur actuelle du stock";

            // panel4GraphArea
            panel4GraphArea.BackColor = Color.FromArgb(40, 40, 50);
            panel4GraphArea.Dock = DockStyle.Bottom;
            panel4GraphArea.Location = new Point(15, 139);
            panel4GraphArea.Size = new Size(226, 50);

            // tlpMiddle
            tlpMiddle.ColumnCount = 3;
            tlpMiddle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpMiddle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tlpMiddle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tlpMiddle.Controls.Add(panelRecentActivities, 0, 0);
            tlpMiddle.Controls.Add(panelStockDistribution, 1, 0);
            tlpMiddle.Controls.Add(panelTopProducts, 2, 0);
            tlpMiddle.Dock = DockStyle.Fill;
            tlpMiddle.Location = new Point(18, 238);
            tlpMiddle.Name = "tlpMiddle";
            tlpMiddle.RowCount = 1;
            tlpMiddle.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMiddle.Size = new Size(1064, 424);

            // panelRecentActivities
            panelRecentActivities.BackColor = Color.FromArgb(30, 30, 40);
            panelRecentActivities.Controls.Add(pnlActivitiesList);
            panelRecentActivities.Controls.Add(lblRecentTitle);
            panelRecentActivities.Dock = DockStyle.Fill;
            panelRecentActivities.Location = new Point(5, 5);
            panelRecentActivities.Margin = new Padding(5);
            panelRecentActivities.Name = "panelRecentActivities";
            panelRecentActivities.Padding = new Padding(20);

            // lblRecentTitle
            lblRecentTitle.AutoSize = true;
            lblRecentTitle.Dock = DockStyle.Top;
            lblRecentTitle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblRecentTitle.ForeColor = Color.White;
            lblRecentTitle.Location = new Point(20, 20);
            lblRecentTitle.Name = "lblRecentTitle";
            lblRecentTitle.Padding = new Padding(0, 0, 0, 25);
            lblRecentTitle.Size = new Size(141, 46);
            lblRecentTitle.TabIndex = 0;
            lblRecentTitle.Text = "Activités Récentes";

            // pnlActivitiesList
            pnlActivitiesList.AutoScroll = true;
            pnlActivitiesList.FlowDirection = FlowDirection.TopDown;
            pnlActivitiesList.WrapContents = false;
            pnlActivitiesList.Dock = DockStyle.Fill;
            pnlActivitiesList.Location = new Point(20, 60);
            pnlActivitiesList.Name = "pnlActivitiesList";
            pnlActivitiesList.Padding = new Padding(0);
            pnlActivitiesList.TabIndex = 1;
            pnlActivitiesList.MouseEnter += (s, e) => pnlActivitiesList.Focus();

            // panelStockDistribution
            panelStockDistribution.BackColor = Color.FromArgb(30, 30, 40);
            panelStockDistribution.Controls.Add(pnlChartContainer);
            panelStockDistribution.Dock = DockStyle.Fill;
            panelStockDistribution.Location = new Point(430, 5);
            panelStockDistribution.Margin = new Padding(5);
            panelStockDistribution.Name = "panelStockDistribution";
            panelStockDistribution.Padding = new Padding(15);

            // pnlChartContainer
            pnlChartContainer.Dock = DockStyle.Fill;
            pnlChartContainer.Location = new Point(15, 15);
            pnlChartContainer.Name = "pnlChartContainer";
            pnlChartContainer.Size = new Size(289, 394);
            pnlChartContainer.TabIndex = 0;

            // panelTopProducts
            panelTopProducts.BackColor = Color.FromArgb(30, 30, 40);
            panelTopProducts.Controls.Add(pnlTopProductsList);
            panelTopProducts.Controls.Add(lblTopTitle);
            panelTopProducts.Dock = DockStyle.Fill;
            panelTopProducts.Location = new Point(749, 5);
            panelTopProducts.Margin = new Padding(5);
            panelTopProducts.Name = "panelTopProducts";
            panelTopProducts.Padding = new Padding(20);

            // lblTopTitle
            lblTopTitle.AutoSize = true;
            lblTopTitle.Dock = DockStyle.Top;
            lblTopTitle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTopTitle.ForeColor = Color.White;
            lblTopTitle.Location = new Point(20, 20);
            lblTopTitle.Name = "lblTopTitle";
            lblTopTitle.Padding = new Padding(0, 0, 0, 25);
            lblTopTitle.Size = new Size(103, 46);
            lblTopTitle.TabIndex = 0;
            lblTopTitle.Text = "Top Produits";

            // pnlTopProductsList
            pnlTopProductsList.AutoScroll = true;
            pnlTopProductsList.FlowDirection = FlowDirection.TopDown;
            pnlTopProductsList.WrapContents = false;
            pnlTopProductsList.Dock = DockStyle.Fill;
            pnlTopProductsList.Location = new Point(20, 60);
            pnlTopProductsList.Name = "pnlTopProductsList";
            pnlTopProductsList.Padding = new Padding(0);
            pnlTopProductsList.TabIndex = 1;
            pnlTopProductsList.MouseEnter += (s, e) => pnlTopProductsList.Focus();

            // panelTips
            panelTips.BackColor = Color.FromArgb(40, 40, 50);
            panelTips.Controls.Add(pnlTipsContainer);
            panelTips.Controls.Add(lblTipsTitle);
            panelTips.Controls.Add(lblTipIcon);
            panelTips.Dock = DockStyle.Fill;
            panelTips.Location = new Point(18, 668);
            panelTips.Margin = new Padding(3, 3, 3, 0);
            panelTips.Name = "panelTips";
            panelTips.Padding = new Padding(20);
            panelTips.Size = new Size(1064, 157);

            // lblTipsTitle
            lblTipsTitle.AutoSize = true;
            lblTipsTitle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTipsTitle.ForeColor = Color.FromArgb(251, 140, 0);
            lblTipsTitle.Location = new Point(70, 20);
            lblTipsTitle.Text = "Conseil de Gestion";

            // pnlTipsContainer
            pnlTipsContainer.AutoScroll = true;
            pnlTipsContainer.FlowDirection = FlowDirection.TopDown;
            pnlTipsContainer.WrapContents = false;
            pnlTipsContainer.Location = new Point(70, 50);
            pnlTipsContainer.Size = new Size(974, 100);
            pnlTipsContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlTipsContainer.Name = "pnlTipsContainer";

            // lblTipIcon
            lblTipIcon.AutoSize = true;
            lblTipIcon.Font = new Font("Segoe UI", 24F);
            lblTipIcon.ForeColor = Color.FromArgb(251, 140, 0);
            lblTipIcon.Location = new Point(20, 25);
            lblTipIcon.Text = "💡";

            // Dashboard
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(2, 6, 13);
            Controls.Add(tlpMain);
            Name = "Dashboard";
            Size = new Size(1100, 800);

            tlpMain.ResumeLayout(false);
            tlpCards.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            tlpMiddle.ResumeLayout(false);
            panelRecentActivities.ResumeLayout(false);
            panelRecentActivities.PerformLayout();
            panelStockDistribution.ResumeLayout(false);
            panelStockDistribution.PerformLayout();
            panelTopProducts.ResumeLayout(false);
            panelTopProducts.PerformLayout();
            panelTips.ResumeLayout(false);
            panelTips.PerformLayout();
            ResumeLayout(false);
        }

        private TableLayoutPanel tlpMain;
        private TableLayoutPanel tlpCards;
        private TableLayoutPanel tlpMiddle;
        private Panel panel1;
        private Panel panel1IconPanel;
        private Label lblCard1Title;
        private Label lblCard1Number;
        private Label lblCard1Description;
        private Panel panel1GraphArea;
        private Panel panel2;
        private Panel panel2IconPanel;
        private Label lblCard2Title;
        private Label lblCard2Number;
        private Label lblCard2Description;
        private Panel panel2GraphArea;
        private Panel panel3;
        private Panel panel3IconPanel;
        private Label lblCard3Title;
        private Label lblCard3Number;
        private Label lblCard3Description;
        private Panel panel3GraphArea;
        private Panel panel4;
        private Panel panel4IconPanel;
        private Label lblCard4Title;
        private Label lblCard4Number;
        private Label lblCard4Description;
        private Panel panel4GraphArea;
        private Label lblCardIcon1;
        private Label lblCardIcon2;
        private Label lblCardIcon3;
        private Label lblCardIcon4;
        private Panel panelRecentActivities;
        private Label lblRecentTitle;
        private FlowLayoutPanel pnlActivitiesList;
        private Panel panelStockDistribution;
        private Panel pnlChartContainer;
        private Panel panelTopProducts;
        private Label lblTopTitle;
        private FlowLayoutPanel pnlTopProductsList;
        private Panel panelTips;
        private Label lblTipsTitle;
        private FlowLayoutPanel pnlTipsContainer;
        private Label lblTipIcon;
    }
}
