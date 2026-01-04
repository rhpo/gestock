namespace GEStock
{
    partial class Products
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dgvProducts = new DataGridView();
            colImage = new DataGridViewImageColumn();
            colCode = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colCategory = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colMinQty = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            panelTop = new Panel();
            tlpTop = new TableLayoutPanel();
            lblTitle = new Label();
            txtSearch = new TextBox();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            pnlSummary = new Panel();
            lblSummaryTotal = new Label();
            lblSummaryLowStock = new Label();
            lblSummaryValue = new Label();
            btnExport = new Button();
            panelBottom = new Panel();
            lblTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            panelTop.SuspendLayout();
            tlpTop.SuspendLayout();
            pnlSummary.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // dgvProducts
            // 
            dgvProducts.BackgroundColor = Color.FromArgb(30, 30, 40);
            dgvProducts.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(50, 50, 60);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvProducts.ColumnHeadersHeight = 35;
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { colImage, colCode, colName, colCategory, colDescription, colPrice, colQuantity, colMinQty, colStatus });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(40, 40, 50);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(66, 133, 244);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvProducts.DefaultCellStyle = dataGridViewCellStyle3;
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.GridColor = Color.FromArgb(60, 60, 70);
            dgvProducts.Location = new Point(0, 140);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowTemplate.Height = 60;
            dgvProducts.Size = new Size(900, 420);
            dgvProducts.TabIndex = 0;
            // 
            // colImage
            // 
            colImage.HeaderText = "";
            colImage.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colImage.Name = "colImage";
            colImage.ReadOnly = true;
            colImage.Width = 60;
            // 
            // colCode
            // 
            colCode.DataPropertyName = "Code";
            colCode.HeaderText = "Code";
            colCode.Name = "colCode";
            colCode.ReadOnly = true;
            // 
            // colName
            // 
            colName.DataPropertyName = "Name";
            colName.HeaderText = "Nom";
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 200;
            // 
            // colCategory
            // 
            colCategory.DataPropertyName = "CategoryId";
            colCategory.HeaderText = "Catégorie";
            colCategory.Name = "colCategory";
            colCategory.ReadOnly = true;
            colCategory.Width = 120;
            // 
            // colDescription
            // 
            colDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDescription.DataPropertyName = "Description";
            colDescription.HeaderText = "Description";
            colDescription.MinimumWidth = 200;
            colDescription.Name = "colDescription";
            colDescription.ReadOnly = true;
            // 
            // colPrice
            // 
            colPrice.DataPropertyName = "Price";
            dataGridViewCellStyle2.Format = "N2";
            colPrice.DefaultCellStyle = dataGridViewCellStyle2;
            colPrice.HeaderText = "Prix (DA)";
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            // 
            // colQuantity
            // 
            colQuantity.DataPropertyName = "Quantity";
            colQuantity.HeaderText = "Quantité";
            colQuantity.Name = "colQuantity";
            colQuantity.ReadOnly = true;
            colQuantity.Width = 80;
            // 
            // colMinQty
            // 
            colMinQty.DataPropertyName = "MinQuantity";
            colMinQty.HeaderText = "Min";
            colMinQty.Name = "colMinQty";
            colMinQty.ReadOnly = true;
            colMinQty.Width = 60;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Statut";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(20, 20, 30);
            panelTop.Controls.Add(tlpTop);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(15);
            panelTop.Size = new Size(900, 140);
            panelTop.TabIndex = 1;
            // 
            // tlpTop
            // 
            tlpTop.ColumnCount = 6;
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpTop.Controls.Add(lblTitle, 0, 0);
            tlpTop.Controls.Add(txtSearch, 1, 0);
            tlpTop.Controls.Add(btnAdd, 2, 0);
            tlpTop.Controls.Add(btnEdit, 3, 0);
            tlpTop.Controls.Add(btnDelete, 4, 0);
            tlpTop.Controls.Add(btnRefresh, 5, 0);
            tlpTop.Controls.Add(pnlSummary, 0, 1);
            tlpTop.Controls.Add(btnExport, 5, 1);
            tlpTop.Dock = DockStyle.Fill;
            tlpTop.Location = new Point(15, 15);
            tlpTop.Name = "tlpTop";
            tlpTop.RowCount = 2;
            tlpTop.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tlpTop.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tlpTop.Size = new Size(870, 110);
            tlpTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(3, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(211, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Gestion Produits";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(40, 40, 50);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.ForeColor = Color.White;
            txtSearch.Location = new Point(220, 12);
            txtSearch.Margin = new Padding(3, 12, 3, 3);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Rechercher...";
            txtSearch.Size = new Size(211, 25);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(66, 133, 244);
            btnAdd.Dock = DockStyle.Fill;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(437, 8);
            btnAdd.Margin = new Padding(3, 8, 3, 8);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(102, 34);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "➕ Ajouter";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(52, 168, 83);
            btnEdit.Dock = DockStyle.Fill;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(545, 8);
            btnEdit.Margin = new Padding(3, 8, 3, 8);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(102, 34);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "✏️ Modifier";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(234, 67, 53);
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(653, 8);
            btnDelete.Margin = new Padding(3, 8, 3, 8);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(102, 34);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "🗑️ Supprimer";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(171, 71, 188);
            btnRefresh.Dock = DockStyle.Fill;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(761, 8);
            btnRefresh.Margin = new Padding(3, 8, 3, 8);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(106, 34);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "🔄 Actualiser";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // pnlSummary
            // 
            pnlSummary.BackColor = Color.FromArgb(30, 30, 40);
            tlpTop.SetColumnSpan(pnlSummary, 5);
            pnlSummary.Controls.Add(lblSummaryTotal);
            pnlSummary.Controls.Add(lblSummaryLowStock);
            pnlSummary.Controls.Add(lblSummaryValue);
            pnlSummary.Dock = DockStyle.Fill;
            pnlSummary.Location = new Point(3, 53);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new Size(752, 54);
            pnlSummary.TabIndex = 7;
            // 
            // lblSummaryTotal
            // 
            lblSummaryTotal.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblSummaryTotal.ForeColor = Color.White;
            lblSummaryTotal.Location = new Point(15, 17);
            lblSummaryTotal.Name = "lblSummaryTotal";
            lblSummaryTotal.Size = new Size(200, 20);
            lblSummaryTotal.TabIndex = 0;
            lblSummaryTotal.Text = "📦 Total Produits: 0";
            // 
            // lblSummaryLowStock
            // 
            lblSummaryLowStock.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblSummaryLowStock.ForeColor = Color.FromArgb(234, 67, 53);
            lblSummaryLowStock.Location = new Point(250, 17);
            lblSummaryLowStock.Name = "lblSummaryLowStock";
            lblSummaryLowStock.Size = new Size(200, 20);
            lblSummaryLowStock.TabIndex = 1;
            lblSummaryLowStock.Text = "⚠️ Stock Faible: 0";
            // 
            // lblSummaryValue
            // 
            lblSummaryValue.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblSummaryValue.ForeColor = Color.FromArgb(251, 140, 0);
            lblSummaryValue.Location = new Point(500, 17);
            lblSummaryValue.Name = "lblSummaryValue";
            lblSummaryValue.Size = new Size(250, 20);
            lblSummaryValue.TabIndex = 2;
            lblSummaryValue.Text = "💰 Valeur Totale: 0 DA";
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(52, 168, 83);
            btnExport.Dock = DockStyle.Fill;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(761, 58);
            btnExport.Margin = new Padding(3, 8, 3, 8);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(106, 44);
            btnExport.TabIndex = 6;
            btnExport.Text = "📊 Excel";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.FromArgb(20, 20, 30);
            panelBottom.Controls.Add(lblTotal);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 560);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(900, 40);
            panelBottom.TabIndex = 2;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 10F);
            lblTotal.ForeColor = Color.FromArgb(160, 160, 180);
            lblTotal.Location = new Point(15, 10);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(108, 19);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "Total: 0 produits";
            // 
            // Products
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(2, 6, 13);
            Controls.Add(dgvProducts);
            Controls.Add(panelBottom);
            Controls.Add(panelTop);
            Name = "Products";
            Size = new Size(900, 600);
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            panelTop.ResumeLayout(false);
            tlpTop.ResumeLayout(false);
            tlpTop.PerformLayout();
            pnlSummary.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvProducts;
        private DataGridViewImageColumn colImage;
        private DataGridViewTextBoxColumn colCode;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colQuantity;
        private DataGridViewTextBoxColumn colMinQty;
        private DataGridViewTextBoxColumn colCategory;
        private DataGridViewTextBoxColumn colStatus;
        private Panel panelTop;
        private TableLayoutPanel tlpTop;
        private Label lblTitle;
        private TextBox txtSearch;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnRefresh;
        private Button btnExport;
        private Panel pnlSummary;
        private Label lblSummaryTotal;
        private Label lblSummaryLowStock;
        private Label lblSummaryValue;
        private Panel panelBottom;
        private Label lblTotal;
    }
}
