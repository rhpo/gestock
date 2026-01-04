using System;
using System.Linq;
using System.Windows.Forms;
using GEStock.Services;
using GEStock.Utils;

namespace GEStock
{
    public partial class History : UserControl
    {
        public History()
        {
            InitializeComponent();
            this.Load += History_Load;
        }

        private void History_Load(object? sender, EventArgs e)
        {
            LoadHistory();
            dtpStart.Value = DateTime.Now.AddMonths(-1);
            dtpEnd.Value = DateTime.Now;
        }

        public void LoadHistory()
        {
            try
            {
                var movements = MovementService.GetMovementsWithDetails();
                dgvHistory.DataSource = movements;
                UpdateStats(movements);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement de l'historique: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStats(System.Collections.Generic.List<dynamic> movements)
        {
            int totalMovements = movements.Count;
            int entrees = movements.Count(m => (string)m.TypeName == "Entrée");
            int sorties = movements.Count(m => (string)m.TypeName == "Sortie");

            lblTotal.Text = $"Total: {totalMovements} mouvements";
            lblEntrees.Text = $"Entrées: {entrees}";
            lblSorties.Text = $"Sorties: {sorties}";
        }

        private void btnFilter_Click(object? sender, EventArgs e)
        {
            try
            {
                var allMovements = MovementService.GetMovementsWithDetails();
                DateTime startDate = dtpStart.Value.Date;
                DateTime endDate = dtpEnd.Value.Date.AddDays(1).AddSeconds(-1);

                var filtered = allMovements.Where(m =>
                    m.Date >= startDate && m.Date <= endDate).ToList();

                dgvHistory.DataSource = filtered;
                UpdateStats(filtered);
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du filtrage: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object? sender, EventArgs e)
        {
            dtpStart.Value = DateTime.Now.AddMonths(-1);
            dtpEnd.Value = DateTime.Now;
            txtSearchProduct.Clear();
            LoadHistory();
        }

        private void txtSearchProduct_TextChanged(object? sender, EventArgs e)
        {
            string searchText = txtSearchProduct.Text.ToLower();
            var allMovements = MovementService.GetMovementsWithDetails();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                dgvHistory.DataSource = allMovements;
            }
            else
            {
                var filtered = allMovements.Where(m =>
                    m.ProductCode.ToLower().Contains(searchText) ||
                    m.ProductName.ToLower().Contains(searchText)).ToList();

                dgvHistory.DataSource = filtered;
            }

            if (dgvHistory.DataSource is System.Collections.Generic.List<dynamic> list)
            {
                UpdateStats(list);
            }
        }

        private void btnExport_Click(object? sender, EventArgs e)
        {
            ExcelExporter.ExportDataGridView(dgvHistory, "Historique_Mouvements");
        }
    }
}
