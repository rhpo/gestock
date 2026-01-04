namespace GEStock
{
    partial class History
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panelTop = new Panel();
            tlpTop = new TableLayoutPanel();
            lblTitle = new Label();
            lblPeriod = new Label();
            dtpStart = new DateTimePicker();
            lblTo = new Label();
            dtpEnd = new DateTimePicker();
            btnFilter = new Button();
            btnReset = new Button();
            txtSearchProduct = new TextBox();
            btnExport = new Button();
            dgvHistory = new DataGridView();
            panelBottom = new Panel();
            lblTotal = new Label();
            lblEntrees = new Label();
            lblSorties = new Label();
            panelTop.SuspendLayout();
            tlpTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(20, 20, 30);
            panelTop.Controls.Add(tlpTop);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(15);
            panelTop.Size = new Size(900, 100);
            panelTop.TabIndex = 0;
            // 
            // tlpTop
            // 
            tlpTop.ColumnCount = 9;
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tlpTop.Controls.Add(lblTitle, 0, 0);
            tlpTop.Controls.Add(lblPeriod, 1, 0);
            tlpTop.Controls.Add(dtpStart, 2, 0);
            tlpTop.Controls.Add(lblTo, 3, 0);
            tlpTop.Controls.Add(dtpEnd, 4, 0);
            tlpTop.Controls.Add(btnFilter, 5, 0);
            tlpTop.Controls.Add(btnReset, 6, 0);
            tlpTop.Controls.Add(txtSearchProduct, 7, 0);
            tlpTop.Controls.Add(btnExport, 8, 0);
            tlpTop.Dock = DockStyle.Fill;
            tlpTop.Location = new Point(15, 15);
            tlpTop.Name = "tlpTop";
            tlpTop.RowCount = 1;
            tlpTop.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpTop.Size = new Size(870, 70);
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
            lblTitle.Size = new Size(134, 70);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Historique";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPeriod
            // 
            lblPeriod.AutoSize = true;
            lblPeriod.Dock = DockStyle.Fill;
            lblPeriod.Font = new Font("Segoe UI", 9F);
            lblPeriod.ForeColor = Color.FromArgb(200, 200, 220);
            lblPeriod.Location = new Point(143, 0);
            lblPeriod.Name = "lblPeriod";
            lblPeriod.Size = new Size(54, 70);
            lblPeriod.TabIndex = 1;
            lblPeriod.Text = "Période:";
            lblPeriod.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpStart
            // 
            dtpStart.CalendarMonthBackground = Color.FromArgb(40, 40, 50);
            dtpStart.Format = DateTimePickerFormat.Short;
            dtpStart.Location = new Point(203, 23);
            dtpStart.Margin = new Padding(3, 23, 3, 3);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(104, 23);
            dtpStart.TabIndex = 2;
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Dock = DockStyle.Fill;
            lblTo.Font = new Font("Segoe UI", 9F);
            lblTo.ForeColor = Color.FromArgb(200, 200, 220);
            lblTo.Location = new Point(313, 0);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(14, 70);
            lblTo.TabIndex = 3;
            lblTo.Text = "à";
            lblTo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dtpEnd
            // 
            dtpEnd.Format = DateTimePickerFormat.Short;
            dtpEnd.Location = new Point(333, 23);
            dtpEnd.Margin = new Padding(3, 23, 3, 3);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(104, 23);
            dtpEnd.TabIndex = 4;
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.FromArgb(66, 133, 244);
            btnFilter.Dock = DockStyle.Fill;
            btnFilter.FlatAppearance.BorderSize = 0;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnFilter.ForeColor = Color.White;
            btnFilter.Location = new Point(443, 20);
            btnFilter.Margin = new Padding(3, 20, 3, 20);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(74, 30);
            btnFilter.TabIndex = 5;
            btnFilter.Text = "Filtrer";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.FromArgb(171, 71, 188);
            btnReset.Dock = DockStyle.Fill;
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(523, 20);
            btnReset.Margin = new Padding(3, 20, 3, 20);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(84, 30);
            btnReset.TabIndex = 6;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // txtSearchProduct
            // 
            txtSearchProduct.BackColor = Color.FromArgb(40, 40, 50);
            txtSearchProduct.BorderStyle = BorderStyle.FixedSingle;
            txtSearchProduct.Dock = DockStyle.Fill;
            txtSearchProduct.Font = new Font("Segoe UI", 10F);
            txtSearchProduct.ForeColor = Color.White;
            txtSearchProduct.Location = new Point(613, 23);
            txtSearchProduct.Margin = new Padding(3, 23, 3, 3);
            txtSearchProduct.Name = "txtSearchProduct";
            txtSearchProduct.PlaceholderText = "Rechercher...";
            txtSearchProduct.Size = new Size(134, 25);
            txtSearchProduct.TabIndex = 7;
            txtSearchProduct.TextChanged += txtSearchProduct_TextChanged;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(52, 168, 83);
            btnExport.Dock = DockStyle.Fill;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(753, 20);
            btnExport.Margin = new Padding(3, 20, 3, 20);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(114, 30);
            btnExport.TabIndex = 8;
            btnExport.Text = "📊 Excel";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // dgvHistory
            // 
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.BackgroundColor = Color.FromArgb(30, 30, 40);
            dgvHistory.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(50, 50, 60);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvHistory.ColumnHeadersHeight = 35;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(40, 40, 50);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(66, 133, 244);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvHistory.DefaultCellStyle = dataGridViewCellStyle2;
            dgvHistory.Dock = DockStyle.Fill;
            dgvHistory.EnableHeadersVisualStyles = false;
            dgvHistory.GridColor = Color.FromArgb(60, 60, 70);
            dgvHistory.Location = new Point(0, 100);
            dgvHistory.MultiSelect = false;
            dgvHistory.Name = "dgvHistory";
            dgvHistory.ReadOnly = true;
            dgvHistory.RowTemplate.Height = 30;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.Size = new Size(900, 460);
            dgvHistory.TabIndex = 0;
            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.FromArgb(20, 20, 30);
            panelBottom.Controls.Add(lblTotal);
            panelBottom.Controls.Add(lblEntrees);
            panelBottom.Controls.Add(lblSorties);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 560);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(900, 40);
            panelBottom.TabIndex = 1;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 10F);
            lblTotal.ForeColor = Color.FromArgb(160, 160, 180);
            lblTotal.Location = new Point(15, 10);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(137, 19);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "Total: 0 mouvements";
            // 
            // lblEntrees
            // 
            lblEntrees.AutoSize = true;
            lblEntrees.Font = new Font("Segoe UI", 10F);
            lblEntrees.ForeColor = Color.FromArgb(52, 168, 83);
            lblEntrees.Location = new Point(200, 10);
            lblEntrees.Name = "lblEntrees";
            lblEntrees.Size = new Size(69, 19);
            lblEntrees.TabIndex = 1;
            lblEntrees.Text = "Entrées: 0";
            // 
            // lblSorties
            // 
            lblSorties.AutoSize = true;
            lblSorties.Font = new Font("Segoe UI", 10F);
            lblSorties.ForeColor = Color.FromArgb(234, 67, 53);
            lblSorties.Location = new Point(320, 10);
            lblSorties.Name = "lblSorties";
            lblSorties.Size = new Size(65, 19);
            lblSorties.TabIndex = 2;
            lblSorties.Text = "Sorties: 0";
            // 
            // History
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(2, 6, 13);
            Controls.Add(dgvHistory);
            Controls.Add(panelBottom);
            Controls.Add(panelTop);
            Name = "History";
            Size = new Size(900, 600);
            panelTop.ResumeLayout(false);
            tlpTop.ResumeLayout(false);
            tlpTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panelTop;
        private TableLayoutPanel tlpTop;
        private Label lblTitle;
        private Label lblPeriod;
        private DateTimePicker dtpStart;
        private Label lblTo;
        private DateTimePicker dtpEnd;
        private Button btnFilter;
        private Button btnReset;
        private TextBox txtSearchProduct;
        private Button btnExport;
        private DataGridView dgvHistory;
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
        private Label lblEntrees;
        private Label lblSorties;
    }
}
