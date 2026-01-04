using System;
using System.Windows.Forms;
using GEStock.Models;
using GEStock.Services;
using System.Collections.Generic;
using System.Linq;

namespace GEStock
{
    public partial class ProductFormDialog : Form
    {
        public Product Product { get; private set; }
        private bool _isEditMode;
        private string? _selectedImagePath;

        public ProductFormDialog(Product? product = null)
        {
            InitializeComponent();
            LoadCategories();
            _isEditMode = product != null;

            if (_isEditMode && product != null)
            {
                this.Text = "Modifier un produit";
                Product = product;
                LoadProductData();
                txtCode.ReadOnly = true; // Le code ne peut pas être modifié
            }
            else
            {
                this.Text = "Ajouter un produit";
                Product = new Product();
            }
        }

        private void LoadCategories()
        {
            var categories = CategoryService.GetAllCategories();
            cboCategory.DataSource = categories;
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";
            cboCategory.SelectedIndex = -1;
        }

        private void LoadProductData()
        {
            txtCode.Text = Product.Code;
            txtName.Text = Product.Name;
            txtDescription.Text = Product.Description;
            numPrice.Value = Product.Price;
            numQuantity.Value = Product.Quantity;
            numMinQty.Value = Product.MinQuantity;
            cboCategory.SelectedValue = Product.CategoryId;
            _selectedImagePath = Product.ImagePath;

            if (!string.IsNullOrEmpty(_selectedImagePath) && System.IO.File.Exists(_selectedImagePath))
            {
                try
                {
                    using (var img = System.Drawing.Image.FromFile(_selectedImagePath))
                    {
                        picProduct.Image = new System.Drawing.Bitmap(img);
                    }
                }
                catch
                {
                    picProduct.Image = null;
                }
            }
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            Product.Code = txtCode.Text.Trim();
            Product.Name = txtName.Text.Trim();
            Product.Description = txtDescription.Text.Trim();
            Product.Price = numPrice.Value;
            Product.Quantity = (int)numQuantity.Value;
            Product.MinQuantity = (int)numMinQty.Value;
            if (cboCategory.SelectedValue != null)
            {
                Product.CategoryId = (int)cboCategory.SelectedValue;
            }
            Product.ImagePath = _selectedImagePath;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Le code produit est requis.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Le nom du produit est requis.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (cboCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez sélectionner une catégorie.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCategory.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSelectImage_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Images (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Sélectionner une image de produit";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Créer le dossier Images s'il n'existe pas
                        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        string imagesFolder = System.IO.Path.Combine(documentsPath, "GEStock", "Images");
                        if (!System.IO.Directory.Exists(imagesFolder))
                        {
                            System.IO.Directory.CreateDirectory(imagesFolder);
                        }

                        // Générer un nom de fichier unique
                        string extension = System.IO.Path.GetExtension(ofd.FileName);
                        string fileName = Guid.NewGuid().ToString() + extension;
                        string destPath = System.IO.Path.Combine(imagesFolder, fileName);

                        // Copier le fichier
                        System.IO.File.Copy(ofd.FileName, destPath, true);

                        // Charger l'image pour prévisualisation (copie en mémoire)
                        using (var img = System.Drawing.Image.FromFile(destPath))
                        {
                            picProduct.Image = new System.Drawing.Bitmap(img);
                        }
                        _selectedImagePath = destPath;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur lors du traitement de l'image : {ex.Message}", "Erreur",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
