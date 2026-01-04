namespace GEStock
{
    partial class Moves
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
            panelTop = new Panel();
            tlpTop = new TableLayoutPanel();
            lblTitle = new Label();
            txtSearch = new TextBox();
            cboFilterType = new ComboBox();
            btnDelete = new Button();
            btnRefresh = new Button();
            btnExport = new Button();
            pnlSummary = new Panel();
            lblSummaryEntries = new Label();
            lblSummaryExits = new Label();
            lblSummaryTotal = new Label();

            grpNewMovement = new GroupBox();
            lblProduct = new Label();
            cboProduct = new ComboBox();
            lblType = new Label();
            rbEntree = new RadioButton();
            rbSortie = new RadioButton();
            lblQuantity = new Label();
            numQuantity = new NumericUpDown();
            lblReference = new Label();
            txtReference = new TextBox();
            lblNotes = new Label();
            txtNotes = new TextBox();
            btnAdd = new Button();

            dgvMovements = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colType = new DataGridViewTextBoxColumn();
            colProductCode = new DataGridViewTextBoxColumn();
            colProductName = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colReference = new DataGridViewTextBoxColumn();
            colUser = new DataGridViewTextBoxColumn();
            colNotes = new DataGridViewTextBoxColumn();

            panelBottom = new Panel();
            lblTotal = new Label();

            panelTop.SuspendLayout();
            tlpTop.SuspendLayout();
            pnlSummary.SuspendLayout();
            grpNewMovement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMovements).BeginInit();
            panelBottom.SuspendLayout();
            SuspendLayout();

            // panelTop
            panelTop.BackColor = Color.FromArgb(20, 20, 30);
            panelTop.Controls.Add(tlpTop);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Padding = new Padding(15);
            panelTop.Size = new Size(900, 140);
            panelTop.TabIndex = 0;

            // tlpTop
            tlpTop.ColumnCount = 6;
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F)); // Title
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F)); // Search
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F)); // Filter
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F)); // Delete
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F)); // Refresh
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11F)); // Export
            tlpTop.Controls.Add(lblTitle, 0, 0);
            tlpTop.Controls.Add(txtSearch, 1, 0);
            tlpTop.Controls.Add(cboFilterType, 2, 0);
            tlpTop.Controls.Add(btnDelete, 3, 0);
            tlpTop.Controls.Add(btnRefresh, 4, 0);
            tlpTop.Controls.Add(btnExport, 5, 0);
            tlpTop.Controls.Add(pnlSummary, 0, 1);
            tlpTop.SetColumnSpan(pnlSummary, 6);
            tlpTop.Dock = DockStyle.Fill;
            tlpTop.Location = new Point(15, 15);
            tlpTop.Name = "tlpTop";
            tlpTop.RowCount = 2;
            tlpTop.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tlpTop.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tlpTop.Size = new Size(870, 110);
            tlpTop.TabIndex = 0;

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(3, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(255, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Mouvements";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;

            // txtSearch
            txtSearch.BackColor = Color.FromArgb(40, 40, 50);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.ForeColor = Color.White;
            txtSearch.Location = new Point(264, 12);
            txtSearch.Margin = new Padding(3, 12, 3, 3);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Rechercher...";
            txtSearch.Size = new Size(168, 25);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;

            // cboFilterType
            cboFilterType.BackColor = Color.FromArgb(40, 40, 50);
            cboFilterType.Dock = DockStyle.Fill;
            cboFilterType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilterType.FlatStyle = FlatStyle.Flat;
            cboFilterType.Font = new Font("Segoe UI", 9F);
            cboFilterType.ForeColor = Color.White;
            cboFilterType.Items.AddRange(new object[] { "Tous les types", "Entrée", "Sortie" });
            cboFilterType.Location = new Point(438, 12);
            cboFilterType.Margin = new Padding(3, 12, 3, 3);
            cboFilterType.Name = "cboFilterType";
            cboFilterType.Size = new Size(124, 23);
            cboFilterType.SelectedIndex = 0;
            cboFilterType.SelectedIndexChanged += cboFilterType_SelectedIndexChanged;

            // btnDelete
            btnDelete.BackColor = Color.FromArgb(234, 67, 53);
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(568, 8);
            btnDelete.Margin = new Padding(3, 8, 3, 8);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(98, 34);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "🗑️ Supprimer";
            btnDelete.Click += btnDelete_Click;

            // btnRefresh
            btnRefresh.BackColor = Color.FromArgb(171, 71, 188);
            btnRefresh.Dock = DockStyle.Fill;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(672, 8);
            btnRefresh.Margin = new Padding(3, 8, 3, 8);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(98, 34);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "🔄 Actualiser";
            btnRefresh.Click += btnRefresh_Click;

            // btnExport
            btnExport.BackColor = Color.FromArgb(52, 168, 83);
            btnExport.Dock = DockStyle.Fill;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(776, 8);
            btnExport.Margin = new Padding(3, 8, 3, 8);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(91, 34);
            btnExport.TabIndex = 5;
            btnExport.Text = "📊 Excel";
            btnExport.Click += btnExport_Click;

            // pnlSummary
            pnlSummary.BackColor = Color.FromArgb(30, 30, 40);
            pnlSummary.Controls.Add(lblSummaryEntries);
            pnlSummary.Controls.Add(lblSummaryExits);
            pnlSummary.Controls.Add(lblSummaryTotal);
            pnlSummary.Dock = DockStyle.Fill;
            pnlSummary.Location = new Point(3, 53);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new Size(864, 54);
            pnlSummary.TabIndex = 6;

            // lblSummaryEntries
            lblSummaryEntries.ForeColor = Color.FromArgb(52, 168, 83);
            lblSummaryEntries.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblSummaryEntries.Location = new Point(15, 17);
            lblSummaryEntries.Name = "lblSummaryEntries";
            lblSummaryEntries.Size = new Size(150, 20);
            lblSummaryEntries.Text = "📈 Entrées: 0";

            // lblSummaryExits
            lblSummaryExits.ForeColor = Color.FromArgb(234, 67, 53);
            lblSummaryExits.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblSummaryExits.Location = new Point(180, 17);
            lblSummaryExits.Name = "lblSummaryExits";
            lblSummaryExits.Size = new Size(150, 20);
            lblSummaryExits.Text = "📉 Sorties: 0";

            // lblSummaryTotal
            lblSummaryTotal.ForeColor = Color.White;
            lblSummaryTotal.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblSummaryTotal.Location = new Point(350, 17);
            lblSummaryTotal.Name = "lblSummaryTotal";
            lblSummaryTotal.Size = new Size(250, 20);
            lblSummaryTotal.Text = "📊 Total: 0 mouvements";

            // grpNewMovement
            grpNewMovement.BackColor = Color.FromArgb(25, 25, 35);
            grpNewMovement.Controls.Add(lblProduct);
            grpNewMovement.Controls.Add(cboProduct);
            grpNewMovement.Controls.Add(lblType);
            grpNewMovement.Controls.Add(rbEntree);
            grpNewMovement.Controls.Add(rbSortie);
            grpNewMovement.Controls.Add(lblQuantity);
            grpNewMovement.Controls.Add(numQuantity);
            grpNewMovement.Controls.Add(lblReference);
            grpNewMovement.Controls.Add(txtReference);
            grpNewMovement.Controls.Add(lblNotes);
            grpNewMovement.Controls.Add(txtNotes);
            grpNewMovement.Controls.Add(btnAdd);
            grpNewMovement.Dock = DockStyle.Left;
            grpNewMovement.ForeColor = Color.White;
            grpNewMovement.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            grpNewMovement.Location = new Point(0, 140);
            grpNewMovement.Padding = new Padding(15);
            grpNewMovement.Size = new Size(300, 410);
            grpNewMovement.Text = "Nouveau Mouvement";

            // lblProduct
            lblProduct.ForeColor = Color.FromArgb(200, 200, 220);
            lblProduct.Font = new Font("Segoe UI", 9F);
            lblProduct.Location = new Point(15, 30);
            lblProduct.Size = new Size(100, 20);
            lblProduct.Text = "Produit";

            // cboProduct
            cboProduct.BackColor = Color.FromArgb(40, 40, 50);
            cboProduct.ForeColor = Color.White;
            cboProduct.Font = new Font("Segoe UI", 10F);
            cboProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProduct.Location = new Point(15, 50);
            cboProduct.Size = new Size(270, 27);

            // lblType
            lblType.ForeColor = Color.FromArgb(200, 200, 220);
            lblType.Font = new Font("Segoe UI", 9F);
            lblType.Location = new Point(15, 90);
            lblType.Size = new Size(100, 20);
            lblType.Text = "Type";

            // rbEntree
            rbEntree.ForeColor = Color.FromArgb(52, 168, 83);
            rbEntree.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            rbEntree.Location = new Point(15, 110);
            rbEntree.Size = new Size(120, 25);
            rbEntree.Text = "➕ Entrée";
            rbEntree.Checked = true;

            // rbSortie
            rbSortie.ForeColor = Color.FromArgb(234, 67, 53);
            rbSortie.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            rbSortie.Location = new Point(150, 110);
            rbSortie.Size = new Size(120, 25);
            rbSortie.Text = "➖ Sortie";

            // lblQuantity
            lblQuantity.ForeColor = Color.FromArgb(200, 200, 220);
            lblQuantity.Font = new Font("Segoe UI", 9F);
            lblQuantity.Location = new Point(15, 145);
            lblQuantity.Size = new Size(100, 20);
            lblQuantity.Text = "Quantité";

            // numQuantity
            numQuantity.BackColor = Color.FromArgb(40, 40, 50);
            numQuantity.ForeColor = Color.White;
            numQuantity.Font = new Font("Segoe UI", 10F);
            numQuantity.Location = new Point(15, 165);
            numQuantity.Maximum = 999999;
            numQuantity.Minimum = 1;
            numQuantity.Value = 1;
            numQuantity.Size = new Size(270, 27);

            // lblReference
            lblReference.ForeColor = Color.FromArgb(200, 200, 220);
            lblReference.Font = new Font("Segoe UI", 9F);
            lblReference.Location = new Point(15, 205);
            lblReference.Size = new Size(100, 20);
            lblReference.Text = "Référence";

            // txtReference
            txtReference.BackColor = Color.FromArgb(40, 40, 50);
            txtReference.ForeColor = Color.White;
            txtReference.Font = new Font("Segoe UI", 10F);
            txtReference.Location = new Point(15, 225);
            txtReference.Size = new Size(270, 26);

            // lblNotes
            lblNotes.ForeColor = Color.FromArgb(200, 200, 220);
            lblNotes.Font = new Font("Segoe UI", 9F);
            lblNotes.Location = new Point(15, 265);
            lblNotes.Size = new Size(100, 20);
            lblNotes.Text = "Notes";

            // txtNotes
            txtNotes.BackColor = Color.FromArgb(40, 40, 50);
            txtNotes.ForeColor = Color.White;
            txtNotes.Font = new Font("Segoe UI", 10F);
            txtNotes.Location = new Point(15, 285);
            txtNotes.Multiline = true;
            txtNotes.Size = new Size(270, 80);

            // btnAdd
            btnAdd.BackColor = Color.FromArgb(66, 133, 244);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(15, 385);
            btnAdd.Size = new Size(270, 40);
            btnAdd.Text = "✅ Enregistrer";
            btnAdd.Click += btnAdd_Click;

            // dgvMovements
            dgvMovements.BackgroundColor = Color.FromArgb(30, 30, 40);
            dgvMovements.BorderStyle = BorderStyle.None;
            dgvMovements.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 60);
            dgvMovements.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMovements.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dgvMovements.ColumnHeadersHeight = 35;
            dgvMovements.Columns.AddRange(new DataGridViewColumn[] { colId, colDate, colType, colProductCode, colProductName, colQuantity, colReference, colUser, colNotes });
            dgvMovements.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 50);
            dgvMovements.DefaultCellStyle.ForeColor = Color.White;
            dgvMovements.DefaultCellStyle.SelectionBackColor = Color.FromArgb(66, 133, 244);
            dgvMovements.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvMovements.Dock = DockStyle.Fill;
            dgvMovements.EnableHeadersVisualStyles = false;
            dgvMovements.GridColor = Color.FromArgb(60, 60, 70);
            dgvMovements.Location = new Point(300, 140);
            dgvMovements.RowTemplate.Height = 30;
            dgvMovements.AutoGenerateColumns = false;
            dgvMovements.AllowUserToAddRows = false;
            dgvMovements.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovements.MultiSelect = false;

            // Columns
            colId.DataPropertyName = "Id";
            colId.HeaderText = "ID";
            colId.Width = 50;
            colId.Visible = false;

            colDate.DataPropertyName = "Date";
            colDate.HeaderText = "Date";
            colDate.Width = 120;
            colDate.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            colType.DataPropertyName = "TypeName";
            colType.HeaderText = "Type";
            colType.Width = 80;

            colProductCode.DataPropertyName = "ProductCode";
            colProductCode.HeaderText = "Code";
            colProductCode.Width = 90;

            colProductName.DataPropertyName = "ProductName";
            colProductName.HeaderText = "Produit";
            colProductName.Width = 150;

            colQuantity.DataPropertyName = "Quantity";
            colQuantity.HeaderText = "Quantité";
            colQuantity.Width = 80;

            colReference.DataPropertyName = "Reference";
            colReference.HeaderText = "Référence";
            colReference.Width = 100;

            colUser.DataPropertyName = "UserName";
            colUser.HeaderText = "Utilisateur";
            colUser.Width = 120;

            colNotes.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNotes.DataPropertyName = "Notes";
            colNotes.HeaderText = "Notes";
            colNotes.Width = 150;
            colNotes.MinimumWidth = 150;

            // panelBottom
            panelBottom.BackColor = Color.FromArgb(20, 20, 30);
            panelBottom.Controls.Add(lblTotal);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 550);
            panelBottom.Size = new Size(900, 40);

            // lblTotal
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 10F);
            lblTotal.ForeColor = Color.FromArgb(160, 160, 180);
            lblTotal.Location = new Point(315, 10);
            lblTotal.Text = "Total: 0 mouvements";

            // Moves
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(2, 6, 13);
            Controls.Add(dgvMovements);
            Controls.Add(grpNewMovement);
            Controls.Add(panelBottom);
            Controls.Add(panelTop);
            Name = "Moves";
            Size = new Size(900, 590);
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMovements).EndInit();
            panelTop.ResumeLayout(false);
            tlpTop.ResumeLayout(false);
            tlpTop.PerformLayout();
            pnlSummary.ResumeLayout(false);
            grpNewMovement.ResumeLayout(false);
            grpNewMovement.PerformLayout();
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panelTop;
        private TableLayoutPanel tlpTop;
        private Label lblTitle;
        private Button btnDelete;
        private Button btnRefresh;
        private Button btnExport;
        private TextBox txtSearch;
        private ComboBox cboFilterType;
        private Panel pnlSummary;
        private Label lblSummaryEntries;
        private Label lblSummaryExits;
        private Label lblSummaryTotal;
        private GroupBox grpNewMovement;
        private Label lblProduct;
        private ComboBox cboProduct;
        private Label lblType;
        private RadioButton rbEntree;
        private RadioButton rbSortie;
        private Label lblQuantity;
        private NumericUpDown numQuantity;
        private Label lblReference;
        private TextBox txtReference;
        private Label lblNotes;
        private TextBox txtNotes;
        private Button btnAdd;
        private DataGridView dgvMovements;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn colProductCode;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colQuantity;
        private DataGridViewTextBoxColumn colReference;
        private DataGridViewTextBoxColumn colUser;
        private DataGridViewTextBoxColumn colNotes;
        private Panel panelBottom;
        private Label lblTotal;
    }
}
