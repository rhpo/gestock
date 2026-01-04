using GEStock.Models;
using GEStock.Services;
using GEStock.Utils;

namespace GEStock
{
    public partial class Form1 : Form
    {

        private Dashboard dashboardView = null!;
        private Products productsView = null!;
        private History historyView = null!;
        private Moves movesView = null!;
        private About aboutView = null!;

        public static T Init<T>() where T : Control, new()
        {
            return new T { Dock = DockStyle.Fill };
        }

        public void InitializeViews()
        {
            this.dashboardView = Init<Dashboard>();
            this.productsView = Init<Products>();
            this.historyView = Init<History>();
            this.movesView = Init<Moves>();
            this.aboutView = Init<About>();

            this.mainView.Controls.Add(this.dashboardView);
            this.mainView.Controls.Add(this.productsView);
            this.mainView.Controls.Add(this.historyView);
            this.mainView.Controls.Add(this.movesView);
            this.mainView.Controls.Add(this.aboutView);
        }

        public void SwitchView(Control next)
        {
            this.mainView.SuspendLayout();

            foreach (Control c in this.mainView.Controls)
                c.Visible = false;

            next.Visible = true;
            next.BringToFront();

            // Rafraîchir les données de la vue si nécessaire
            if (next is Dashboard db) db.LoadStats();
            else if (next is Products p) p.LoadProducts();
            else if (next is Moves m) m.LoadMovements();
            else if (next is History h) h.LoadHistory();

            this.mainView.ResumeLayout();
        }

        public void RefreshAllViews()
        {
            dashboardView.LoadStats();
            productsView.LoadProducts();
            movesView.LoadMovements();
            historyView.LoadHistory();
        }

        public Form1()
        {
            InitializeComponent();
            InitializeViews();
            ConfigureUIForRole();
        }

        private void ConfigureUIForRole()
        {
            if (!AuthService.IsAuthenticated || AuthService.CurrentUser == null)
            {
                MessageBox.Show("Vous devez être connecté pour accéder à cette page.",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            var user = AuthService.CurrentUser;

            // Mettre à jour le titre avec le nom de l'utilisateur
            this.Text = $"GEStock - {user.FullName} ({user.GetRoleName()})";

            // Adapter l'interface selon le rôle
            switch (user.Role)
            {
                case UserRole.UtilisateurSimple:
                    // Utilisateur simple: consultation uniquement
                    mouvementsButton.Visible = false;
                    // Repositionner les boutons restants pour éviter les trous
                    historyButton.Top = mouvementsButton.Top;
                    break;

                case UserRole.Magasinier:
                    // Magasinier: peut gérer les mouvements mais pas les produits
                    // On laisse le bouton produits mais il sera en lecture seule dans son propre contrôle
                    break;

                case UserRole.Administrateur:
                    // Administrateur: accès complet
                    break;
            }

            // Ajouter les infos utilisateur dans la sidebar
            UpdateSidebarUserInfo();
        }

        private void UpdateSidebarUserInfo()
        {
            var user = AuthService.CurrentUser;
            if (user == null) return;

            // Supprimer l'ancien panel s'il existe
            var oldPanel = panel1.Controls.Find("userPanel", false).FirstOrDefault();
            if (oldPanel != null) panel1.Controls.Remove(oldPanel);

            // Créer un panel pour les infos utilisateur en bas de la sidebar
            Panel userPanel = new Panel
            {
                Name = "userPanel",
                Dock = DockStyle.Bottom,
                Height = 180,
                BackColor = Color.FromArgb(10, 20, 30),
                Padding = new Padding(15)
            };

            Label lblName = new Label
            {
                Text = user.FullName,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 25
            };

            Label lblRole = new Label
            {
                Text = user.GetRoleName(),
                ForeColor = Color.FromArgb(150, 150, 170),
                Font = new Font("Segoe UI", 9),
                Dock = DockStyle.Top,
                Height = 20
            };

            // Bouton Déconnexion
            Button btnLogout = new Button
            {
                Text = "Déconnexion",
                Dock = DockStyle.Bottom,
                Height = 35,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.FromArgb(234, 67, 53),
                BackColor = Color.FromArgb(40, 20, 20),
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI Semibold", 9)
            };
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Click += (s, e) => {
                AuthService.Logout();
                Application.Restart();
            };

            // Petit graphique d'état du stock dans la sidebar
            Panel chartPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 10, 0, 10)
            };
            chartPanel.Paint += (s, e) => DrawSidebarChart(e.Graphics, chartPanel.ClientRectangle);

            userPanel.Controls.Add(chartPanel);
            userPanel.Controls.Add(btnLogout);
            userPanel.Controls.Add(lblRole);
            userPanel.Controls.Add(lblName);

            panel1.Controls.Add(userPanel);
        }

        private void DrawSidebarChart(Graphics g, Rectangle rect)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int total = StatsService.GetTotalProducts();
            int low = StatsService.GetLowStockCount();

            if (total == 0) return;

            float lowPercent = (float)low / total;
            float okPercent = 1f - lowPercent;

            // Dessiner une barre de progression stylisée
            int barHeight = 10;
            int barWidth = rect.Width - 10;
            Rectangle barRect = new Rectangle(5, rect.Height / 2 - 5, barWidth, barHeight);

            // Fond
            using (var brush = new SolidBrush(Color.FromArgb(40, 40, 50)))
                g.FillRoundedRectangle(brush, barRect, 5);

            // Partie OK (Vert)
            if (okPercent > 0)
            {
                Rectangle okRect = new Rectangle(barRect.X, barRect.Y, (int)(barWidth * okPercent), barHeight);
                using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(okRect, Color.FromArgb(52, 168, 83), Color.FromArgb(34, 139, 34), 0f))
                    g.FillRoundedRectangle(brush, okRect, 5);
            }

            // Texte d'info
            string info = $"{total} Produits | {low} Alertes";
            using (var font = new Font("Segoe UI", 8))
            using (var brush = new SolidBrush(Color.FromArgb(180, 180, 200)))
            {
                g.DrawString(info, font, brush, new PointF(5, barRect.Bottom + 5));
                g.DrawString("État Global du Stock", font, brush, new PointF(5, barRect.Top - 18));
            }
        }

        private void panel2_Paint(object? sender, PaintEventArgs e)
        {
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            SwitchView(this.dashboardView);
        }

        private void mainView_Paint(object? sender, PaintEventArgs e)
        {
        }

        private void dashboardButton_Click(object? sender, EventArgs e)
        {
            SwitchView(this.dashboardView);
        }

        private void productsButton_Click(object? sender, EventArgs e)
        {
            SwitchView(this.productsView);
        }

        private void mouvementsButton_Click(object? sender, EventArgs e)
        {
            if (AuthService.CurrentUser?.Role == UserRole.UtilisateurSimple)
            {
                return;
            }
            SwitchView(this.movesView);
        }

        private void historyButton_Click(object? sender, EventArgs e)
        {
            SwitchView(this.historyView);
        }

        private void aboutButton_Click(object? sender, EventArgs e)
        {
            SwitchView(this.aboutView);
        }

        private void fullScreenButton_Click(object? sender, EventArgs e)
        {
            if (this.FormBorderStyle == FormBorderStyle.None)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
                fullScreenButton.Text = "🖥️ Plein Écran";
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                fullScreenButton.Text = "🗗 Fenêtré";
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            AuthService.Logout();
        }
    }
}
