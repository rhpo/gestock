namespace GEStock
{
    partial class ProductFormDialog
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
            panelMain = new Panel();
            lblCode = new Label();
            txtCode = new TextBox();
            lblName = new Label();
            txtName = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            lblPrice = new Label();
            numPrice = new NumericUpDown();
            lblQuantity = new Label();
            numQuantity = new NumericUpDown();
            lblMinQty = new Label();
            numMinQty = new NumericUpDown();
            lblCategory = new Label();
            cboCategory = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            picProduct = new PictureBox();
            btnSelectImage = new Button();
            lblImage = new Label();

            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMinQty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picProduct).BeginInit();
            SuspendLayout();

            //
            // panelMain
            //
            panelMain.BackColor = Color.FromArgb(30, 30, 40);
            panelMain.Controls.Add(lblCode);
            panelMain.Controls.Add(txtCode);
            panelMain.Controls.Add(lblName);
            panelMain.Controls.Add(txtName);
            panelMain.Controls.Add(lblDescription);
            panelMain.Controls.Add(txtDescription);
            panelMain.Controls.Add(lblPrice);
            panelMain.Controls.Add(numPrice);
            panelMain.Controls.Add(lblQuantity);
            panelMain.Controls.Add(numQuantity);
            panelMain.Controls.Add(lblMinQty);
            panelMain.Controls.Add(numMinQty);
            panelMain.Controls.Add(lblCategory);
            panelMain.Controls.Add(cboCategory);
            panelMain.Controls.Add(lblImage);
            panelMain.Controls.Add(picProduct);
            panelMain.Controls.Add(btnSelectImage);
            panelMain.Controls.Add(btnSave);
            panelMain.Controls.Add(btnCancel);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Padding = new Padding(20);
            panelMain.Size = new Size(480, 650);

            //
            // lblCode
            //
            lblCode.ForeColor = Color.FromArgb(200, 200, 220);
            lblCode.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblCode.Location = new Point(20, 20);
            lblCode.Size = new Size(120, 20);
            lblCode.Text = "Code produit *";

            //
            // txtCode
            //
            txtCode.BackColor = Color.FromArgb(40, 40, 50);
            txtCode.ForeColor = Color.White;
            txtCode.Font = new Font("Segoe UI", 11F);
            txtCode.Location = new Point(20, 45);
            txtCode.Size = new Size(440, 27);

            //
            // lblName
            //
            lblName.ForeColor = Color.FromArgb(200, 200, 220);
            lblName.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblName.Location = new Point(20, 85);
            lblName.Size = new Size(120, 20);
            lblName.Text = "Nom *";

            //
            // txtName
            //
            txtName.BackColor = Color.FromArgb(40, 40, 50);
            txtName.ForeColor = Color.White;
            txtName.Font = new Font("Segoe UI", 11F);
            txtName.Location = new Point(20, 110);
            txtName.Size = new Size(440, 27);

            //
            // lblDescription
            //
            lblDescription.ForeColor = Color.FromArgb(200, 200, 220);
            lblDescription.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblDescription.Location = new Point(20, 150);
            lblDescription.Size = new Size(120, 20);
            lblDescription.Text = "Description";

            //
            // txtDescription
            //
            txtDescription.BackColor = Color.FromArgb(40, 40, 50);
            txtDescription.ForeColor = Color.White;
            txtDescription.Font = new Font("Segoe UI", 11F);
            txtDescription.Location = new Point(20, 175);
            txtDescription.Multiline = true;
            txtDescription.Size = new Size(440, 60);

            //
            // lblPrice
            //
            lblPrice.ForeColor = Color.FromArgb(200, 200, 220);
            lblPrice.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblPrice.Location = new Point(20, 250);
            lblPrice.Size = new Size(120, 20);
            lblPrice.Text = "Prix (DA)";

            //
            // numPrice
            //
            numPrice.BackColor = Color.FromArgb(40, 40, 50);
            numPrice.ForeColor = Color.White;
            numPrice.Font = new Font("Segoe UI", 11F);
            numPrice.Location = new Point(20, 275);
            numPrice.Maximum = 999999999;
            numPrice.Size = new Size(200, 27);
            numPrice.DecimalPlaces = 2;

            //
            // lblQuantity
            //
            lblQuantity.ForeColor = Color.FromArgb(200, 200, 220);
            lblQuantity.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblQuantity.Location = new Point(240, 250);
            lblQuantity.Size = new Size(120, 20);
            lblQuantity.Text = "Quantité";

            //
            // numQuantity
            //
            numQuantity.BackColor = Color.FromArgb(40, 40, 50);
            numQuantity.ForeColor = Color.White;
            numQuantity.Font = new Font("Segoe UI", 11F);
            numQuantity.Location = new Point(240, 275);
            numQuantity.Maximum = 999999;
            numQuantity.Size = new Size(220, 27);

            //
            // lblMinQty
            //
            lblMinQty.ForeColor = Color.FromArgb(200, 200, 220);
            lblMinQty.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblMinQty.Location = new Point(20, 315);
            lblMinQty.Size = new Size(150, 20);
            lblMinQty.Text = "Quantité minimale";

            //
            // numMinQty
            //
            numMinQty.BackColor = Color.FromArgb(40, 40, 50);
            numMinQty.ForeColor = Color.White;
            numMinQty.Font = new Font("Segoe UI", 11F);
            numMinQty.Location = new Point(20, 340);
            numMinQty.Maximum = 999999;
            numMinQty.Value = 10;
            numMinQty.Size = new Size(200, 27);

            //
            // lblCategory
            //
            lblCategory.ForeColor = Color.FromArgb(200, 200, 220);
            lblCategory.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblCategory.Location = new Point(240, 315);
            lblCategory.Size = new Size(120, 20);
            lblCategory.Text = "Catégorie *";

            //
            // cboCategory
            //
            cboCategory.BackColor = Color.FromArgb(40, 40, 50);
            cboCategory.ForeColor = Color.White;
            cboCategory.Font = new Font("Segoe UI", 11F);
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.FlatStyle = FlatStyle.Flat;
            cboCategory.Location = new Point(240, 340);
            cboCategory.Size = new Size(220, 27);

            //
            // lblImage
            //
            lblImage.ForeColor = Color.FromArgb(200, 200, 220);
            lblImage.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblImage.Location = new Point(20, 380);
            lblImage.Size = new Size(120, 20);
            lblImage.Text = "Image";

            //
            // picProduct
            //
            picProduct.BackColor = Color.FromArgb(40, 40, 50);
            picProduct.BorderStyle = BorderStyle.FixedSingle;
            picProduct.Location = new Point(20, 405);
            picProduct.Size = new Size(120, 120);
            picProduct.SizeMode = PictureBoxSizeMode.Zoom;

            //
            // btnSelectImage
            //
            btnSelectImage.BackColor = Color.FromArgb(60, 60, 70);
            btnSelectImage.FlatAppearance.BorderSize = 0;
            btnSelectImage.FlatStyle = FlatStyle.Flat;
            btnSelectImage.Font = new Font("Segoe UI", 9F);
            btnSelectImage.ForeColor = Color.White;
            btnSelectImage.Location = new Point(150, 405);
            btnSelectImage.Size = new Size(100, 30);
            btnSelectImage.Text = "Choisir...";
            btnSelectImage.Click += btnSelectImage_Click;

            //
            // btnSave
            //
            btnSave.BackColor = Color.FromArgb(66, 133, 244);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(20, 550);
            btnSave.Size = new Size(200, 40);
            btnSave.Text = "💾 Enregistrer";
            btnSave.Click += btnSave_Click;

            //
            // btnCancel
            //
            btnCancel.BackColor = Color.FromArgb(60, 60, 70);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(200, 200, 220);
            btnCancel.Location = new Point(260, 550);
            btnCancel.Size = new Size(200, 40);
            btnCancel.Text = "❌ Annuler";
            btnCancel.Click += btnCancel_Click;

            //
            // ProductFormDialog
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(2, 6, 13);
            ClientSize = new Size(480, 620);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProductFormDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Produit";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMinQty).EndInit();
            ((System.ComponentModel.ISupportInitialize)picProduct).EndInit();
            ResumeLayout(false);
        }

        private Panel panelMain;
        private Label lblCode;
        private TextBox txtCode;
        private Label lblName;
        private TextBox txtName;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblPrice;
        private NumericUpDown numPrice;
        private Label lblQuantity;
        private NumericUpDown numQuantity;
        private Label lblMinQty;
        private NumericUpDown numMinQty;
        private Label lblCategory;
        private ComboBox cboCategory;
        private Button btnSave;
        private Button btnCancel;
        private PictureBox picProduct;
        private Button btnSelectImage;
        private Label lblImage;
    }
}
