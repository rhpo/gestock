using System;
using System.Windows.Forms;
using GEStock.Models;
using GEStock.Services;
using GEStock.Utils;

namespace GEStock
{
    public partial class Moves : UserControl
    {
        public Moves()
        {
            InitializeComponent();
            this.Load += Moves_Load;
        }

        private void Moves_Load(object? sender, EventArgs e)
        {
            LoadMovements();
            LoadProducts();
            ConfigureUI();
        }

        private void ConfigureUI()
        {
            // Si c'est un utilisateur simple, masquer les contrôles d'ajout
            if (AuthService.CurrentUser?.Role == UserRole.UtilisateurSimple)
            {
                grpNewMovement.Visible = false;
                btnDelete.Visible = false;

                // Agrandir la grille pour occuper l'espace
                dgvMovements.Left = grpNewMovement.Left;
                dgvMovements.Width += grpNewMovement.Width + 20;
            }
        }

        private void LoadProducts()
        {
            try
            {
                var products = ProductService.GetAllProducts();
                cboProduct.DataSource = products;
                cboProduct.DisplayMember = "Name";
                cboProduct.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des produits: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadMovements()
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            try
            {
                var movements = MovementService.GetMovementsWithDetails();
                string searchText = txtSearch.Text.ToLower();
                int filterType = cboFilterType.SelectedIndex; // 0: Tous, 1: Entrée, 2: Sortie

                var filtered = movements.FindAll(m =>
                {
                    bool matchSearch = string.IsNullOrWhiteSpace(searchText) ||
                                     m.ProductName.ToLower().Contains(searchText) ||
                                     m.ProductCode.ToLower().Contains(searchText) ||
                                     m.Reference.ToLower().Contains(searchText);

                    bool matchType = filterType == 0 ||
                                   (filterType == 1 && m.TypeName == "Entrée") ||
                                   (filterType == 2 && m.TypeName == "Sortie");

                    return matchSearch && matchType;
                });

                dgvMovements.DataSource = filtered;
                lblTotal.Text = $"Total: {filtered.Count} mouvements";

                // Mettre à jour le résumé
                int entries = filtered.Count(m => m.TypeName == "Entrée");
                int exits = filtered.Count(m => m.TypeName == "Sortie");
                lblSummaryEntries.Text = $"📈 Entrées: {entries}";
                lblSummaryExits.Text = $"📉 Sorties: {exits}";
                lblSummaryTotal.Text = $"📊 Total: {filtered.Count} mouvements";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du filtrage des mouvements: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            if (AuthService.CurrentUser == null) return;

            var movement = new Movement
            {
                ProductId = (int)(cboProduct.SelectedValue ?? 0),
                Type = rbEntree.Checked ? MovementType.Entree : MovementType.Sortie,
                Quantity = (int)numQuantity.Value,
                Reference = txtReference.Text.Trim(),
                Notes = txtNotes.Text.Trim(),
                UserId = AuthService.CurrentUser.Id
            };

            if (MovementService.AddMovement(movement))
            {
                MessageBox.Show("Mouvement enregistré avec succès!", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();

                // Notifier toutes les vues pour qu'elles se rafraîchissent
                if (this.FindForm() is Form1 mainForm)
                {
                    mainForm.RefreshAllViews();
                }
            }
            else
            {
                MessageBox.Show("Erreur lors de l'enregistrement du mouvement.\nVérifiez que la quantité en stock est suffisante pour une sortie.",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (cboProduct.SelectedValue == null)
            {
                MessageBox.Show("Veuillez sélectionner un produit.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numQuantity.Value == 0)
            {
                MessageBox.Show("La quantité doit être supérieure à 0.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!rbEntree.Checked && !rbSortie.Checked)
            {
                MessageBox.Show("Veuillez sélectionner le type de mouvement.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            numQuantity.Value = 1;
            txtReference.Clear();
            txtNotes.Clear();
            rbEntree.Checked = true;
            if (cboProduct.Items.Count > 0)
                cboProduct.SelectedIndex = 0;
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvMovements.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un mouvement à supprimer.",
                    "Sélection requise", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce mouvement ?",
                "Confirmer la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                dynamic movement = dgvMovements.SelectedRows[0].DataBoundItem;
                if (MovementService.DeleteMovement(movement.Id))
                {
                    MessageBox.Show("Mouvement supprimé avec succès!", "Succès",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMovements();
                }
                else
                {
                    MessageBox.Show("Erreur lors de la suppression du mouvement.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            cboFilterType.SelectedIndex = 0;
            LoadMovements();
            LoadProducts();
        }

        private void txtSearch_TextChanged(object? sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cboFilterType_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnExport_Click(object? sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void ExportToExcel()
        {
            ExcelExporter.ExportDataGridView(dgvMovements, "Mouvements_Stock");
        }
    }
}
