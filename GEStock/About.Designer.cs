namespace GEStock
{
    partial class About
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
            pnlCard = new Panel();
            lblGL = new Label();
            lblTechDetails = new Label();
            lblAuthors = new Label();
            lblTitle = new Label();
            picLogo = new PictureBox();
            tlpMain.SuspendLayout();
            pnlCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            //
            // tlpMain
            //
            tlpMain.ColumnCount = 3;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tlpMain.Controls.Add(pnlCard, 1, 1);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 0);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 3;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tlpMain.Size = new Size(1000, 700);
            tlpMain.TabIndex = 0;
            //
            // pnlCard
            //
            pnlCard.BackColor = Color.FromArgb(30, 30, 40);
            pnlCard.Controls.Add(lblGL);
            pnlCard.Controls.Add(lblTechDetails);
            pnlCard.Controls.Add(lblAuthors);
            pnlCard.Controls.Add(lblTitle);
            pnlCard.Controls.Add(picLogo);
            pnlCard.Dock = DockStyle.Fill;
            pnlCard.Location = new Point(103, 38);
            pnlCard.Name = "pnlCard";
            pnlCard.Padding = new Padding(30);
            pnlCard.Size = new Size(794, 624);
            pnlCard.TabIndex = 0;
            pnlCard.Paint += pnlCard_Paint;
            //
            // lblGL
            //
            lblGL.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblGL.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold | FontStyle.Italic);
            lblGL.ForeColor = Color.FromArgb(251, 140, 0);
            lblGL.Location = new Point(30, 330);
            lblGL.Name = "lblGL";
            lblGL.Size = new Size(734, 30);
            lblGL.TabIndex = 4;
            lblGL.Text = "Projet de Génie Logiciel (GL)";
            lblGL.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblTechDetails
            //
            lblTechDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblTechDetails.Font = new Font("Segoe UI", 10F);
            lblTechDetails.ForeColor = Color.FromArgb(170, 170, 190);
            lblTechDetails.Location = new Point(30, 480);
            lblTechDetails.Name = "lblTechDetails";
            lblTechDetails.Size = new Size(734, 114);
            lblTechDetails.TabIndex = 3;
            lblTechDetails.Text = "Améliorations & Extensions Fonctionnelles:\r\n• Smart Insights & Analyse Prédictive (Système de Conseils)\r\n• Dashboard Analytique & KPI en temps réel\r\n• Reporting & Exportation de Données (Microsoft Excel)\r\n• Gestion Multimédia Intégrée (Indexation Visuelle)\r\n• Expérience Utilisateur Immersive (Mode Plein Écran)";
            lblTechDetails.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblAuthors
            //
            lblAuthors.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblAuthors.Font = new Font("Segoe UI", 13F);
            lblAuthors.ForeColor = Color.FromArgb(220, 220, 240);
            lblAuthors.Location = new Point(30, 370);
            lblAuthors.Name = "lblAuthors";
            lblAuthors.Size = new Size(734, 100);
            lblAuthors.TabIndex = 2;
            lblAuthors.Text = "Auteur: HADID Rami\r\nCo-Auteur: MIMOUNI Meriem";
            lblAuthors.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblTitle
            //
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(30, 260);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(734, 60);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "GEStock - Ease your Stock Management";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            //
            // picLogo
            //
            picLogo.Anchor = AnchorStyles.Top;
            picLogo.Location = new Point(297, 30);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(200, 200);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            //
            // About
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 24);
            Controls.Add(tlpMain);
            Name = "About";
            Size = new Size(1000, 700);
            tlpMain.ResumeLayout(false);
            pnlCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
        }

        private TableLayoutPanel tlpMain;
        private Panel pnlCard;
        private PictureBox picLogo;
        private Label lblTitle;
        private Label lblAuthors;
        private Label lblTechDetails;
        private Label lblGL;
    }
}
