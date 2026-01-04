using System;
using System.Drawing;
using System.Windows.Forms;
using GEStock.Models;
using GEStock.Services;
using GEStock.Utils;

namespace GEStock
{
    public partial class Products : UserControl
    {
        public Products()
        {
            InitializeComponent();
            this.Load += Products_Load;
        }

        private void Products_Load(object? sender, EventArgs e)
        {
            LoadProducts();
            ConfigureGridView();
            ConfigureUI();
            dgvProducts.CellFormatting += dgvProducts_CellFormatting;
        }

        private void ConfigureUI()
        {
            if (AuthService.CurrentUser?.Role != UserRole.Administrateur)
            {
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
            }
        }

        private void ConfigureGridView()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;
        }

        public void LoadProducts()
        {
            try
            {
                var products = ProductService.GetAllProducts();
                string searchText = txtSearch.Text.ToLower();

                var filtered = products.FindAll(p =>
                    string.IsNullOrWhiteSpace(searchText) ||
                    p.Code.ToLower().Contains(searchText) ||
                    p.Name.ToLower().Contains(searchText) ||
                    p.Description.ToLower().Contains(searchText));

                dgvProducts.DataSource = filtered;
                lblTotal.Text = $"Total: {filtered.Count} produits";

                // Mettre à jour le résumé
                int lowStockCount = filtered.Count(p => p.Quantity <= p.MinQuantity);
                decimal totalValue = filtered.Sum(p => (decimal)p.Price * p.Quantity);

                lblSummaryTotal.Text = $"📦 Total Produits: {filtered.Count}";
                lblSummaryLowStock.Text = $"⚠️ Stock Faible: {lowStockCount}";
                lblSummaryValue.Text = $"💰 Valeur Totale: {totalValue:N2} DA";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des produits: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (AuthService.CurrentUser?.Role != UserRole.Administrateur)
            {
                MessageBox.Show("Seul l'administrateur peut ajouter des produits.",
                    "Accès refusé", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var form = new ProductFormDialog();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (ProductService.AddProduct(form.Product))
                {
                    MessageBox.Show("Produit ajouté avec succès!", "Succès",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (this.FindForm() is Form1 mainForm)
                    {
                        mainForm.RefreshAllViews();
                    }
                }
                else
                {
                    MessageBox.Show("Erreur lors de l'ajout du produit.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_Click(object? sender, EventArgs e)
        {
            if (AuthService.CurrentUser?.Role != UserRole.Administrateur)
            {
                MessageBox.Show("Seul l'administrateur peut modifier des produits.",
                    "Accès refusé", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un produit à modifier.",
                    "Sélection requise", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var product = (Product)dgvProducts.SelectedRows[0].DataBoundItem;
            var form = new ProductFormDialog(product);

            if (form.ShowDialog() == DialogResult.OK)
            {
                if (ProductService.UpdateProduct(form.Product))
                {
                    MessageBox.Show("Produit modifié avec succès!", "Succès",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (this.FindForm() is Form1 mainForm)
                    {
                        mainForm.RefreshAllViews();
                    }
                }
                else
                {
                    MessageBox.Show("Erreur lors de la modification du produit.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (AuthService.CurrentUser?.Role != UserRole.Administrateur)
            {
                MessageBox.Show("Seul l'administrateur peut supprimer des produits.",
                    "Accès refusé", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un produit à supprimer.",
                    "Sélection requise", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var product = (Product)dgvProducts.SelectedRows[0].DataBoundItem;
            var result = MessageBox.Show($"Êtes-vous sûr de vouloir supprimer le produit '{product.Name}' ?",
                "Confirmer la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (ProductService.DeleteProduct(product.Code))
                {
                    MessageBox.Show("Produit supprimé avec succès!", "Succès",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (this.FindForm() is Form1 mainForm)
                    {
                        mainForm.RefreshAllViews();
                    }
                }
                else
                {
                    MessageBox.Show("Erreur lors de la suppression du produit.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            LoadProducts();
        }

        private void txtSearch_TextChanged(object? sender, EventArgs e)
        {
            LoadProducts();
        }

        private void dgvProducts_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvProducts.Columns[e.ColumnIndex].Name == "colImage")
            {
                var product = (Product)dgvProducts.Rows[e.RowIndex].DataBoundItem;
                if (product != null)
                {
                    if (!string.IsNullOrEmpty(product.ImagePath) && System.IO.File.Exists(product.ImagePath))
                    {
                        try
                        {
                            // On utilise une copie en mémoire pour ne pas verrouiller le fichier
                            using (var img = Image.FromFile(product.ImagePath))
                            {
                                e.Value = new Bitmap(img);
                            }
                        }
                        catch
                        {
                            e.Value = GetQuestionMarkBitmap();
                        }
                    }
                    else
                    {
                        e.Value = GetQuestionMarkBitmap();
                    }
                }
            }
            else if (dgvProducts.Columns[e.ColumnIndex].Name == "colCategory")
            {
                if (e.Value != null && e.Value is int categoryId)
                {
                    var category = CategoryService.GetCategoryById(categoryId);
                    if (category != null)
                    {
                        e.Value = category.Name;
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void btnExport_Click(object? sender, EventArgs e)
        {
            ExcelExporter.ExportDataGridView(dgvProducts, "Liste_Produits");
        }
        private Bitmap GetQuestionMarkBitmap()
        {
            Bitmap bmp = new Bitmap(50, 50);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(45, 45, 55));
                using (Font f = new Font("Segoe UI", 24, FontStyle.Bold))
                {
                    var size = g.MeasureString("?", f);
                    g.DrawString("?", f, Brushes.Gray, (50 - size.Width) / 2, (50 - size.Height) / 2);
                }
            }
            return bmp;
        }
    }
}
