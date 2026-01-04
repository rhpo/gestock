namespace GEStock
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            lblSlogan = new Label();
            panel1 = new Panel();
            fullScreenButton = new Button();
            historyButton = new Button();
            mouvementsButton = new Button();
            dashboardButton = new Button();
            productsButton = new Button();
            aboutButton = new Button();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            mainView = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(74, 13);
            label1.Name = "label1";
            label1.Size = new Size(212, 65);
            label1.TabIndex = 1;
            label1.Text = "GEStock";
            // 
            // lblSlogan
            // 
            lblSlogan.AutoSize = true;
            lblSlogan.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblSlogan.ForeColor = Color.FromArgb(150, 150, 170);
            lblSlogan.Location = new Point(80, 75);
            lblSlogan.Name = "lblSlogan";
            lblSlogan.Size = new Size(164, 15);
            lblSlogan.TabIndex = 10;
            lblSlogan.Text = "Ease your Stock Management.";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(5, 12, 19);
            panel1.Controls.Add(fullScreenButton);
            panel1.Controls.Add(historyButton);
            panel1.Controls.Add(mouvementsButton);
            panel1.Controls.Add(dashboardButton);
            panel1.Controls.Add(productsButton);
            panel1.Controls.Add(aboutButton);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblSlogan);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(305, 631);
            panel1.TabIndex = 2;
            // 
            // fullScreenButton
            // 
            fullScreenButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            fullScreenButton.BackColor = Color.FromArgb(5, 12, 19);
            fullScreenButton.Cursor = Cursors.Hand;
            fullScreenButton.FlatAppearance.BorderColor = Color.FromArgb(0, 114, 213);
            fullScreenButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 114, 213);
            fullScreenButton.FlatStyle = FlatStyle.Flat;
            fullScreenButton.Font = new Font("Inter SemiBold", 10F, FontStyle.Bold);
            fullScreenButton.ForeColor = SystemColors.ControlLightLight;
            fullScreenButton.Location = new Point(20, 384);
            fullScreenButton.Name = "fullScreenButton";
            fullScreenButton.Size = new Size(264, 42);
            fullScreenButton.TabIndex = 8;
            fullScreenButton.Text = "🖥️ Plein Écran";
            fullScreenButton.UseVisualStyleBackColor = false;
            fullScreenButton.Click += fullScreenButton_Click;
            // 
            // historyButton
            // 
            historyButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            historyButton.BackColor = Color.FromArgb(5, 12, 19);
            historyButton.Cursor = Cursors.Hand;
            historyButton.FlatAppearance.BorderColor = Color.FromArgb(0, 114, 213);
            historyButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 114, 213);
            historyButton.FlatStyle = FlatStyle.Flat;
            historyButton.Font = new Font("Inter SemiBold", 12F, FontStyle.Bold);
            historyButton.ForeColor = SystemColors.ControlLightLight;
            historyButton.Image = Properties.Resources.history_1_;
            historyButton.ImageAlign = ContentAlignment.MiddleLeft;
            historyButton.Location = new Point(20, 270);
            historyButton.Name = "historyButton";
            historyButton.Padding = new Padding(30, 0, 0, 0);
            historyButton.Size = new Size(264, 42);
            historyButton.TabIndex = 7;
            historyButton.Text = "Historique";
            historyButton.TextAlign = ContentAlignment.MiddleLeft;
            historyButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            historyButton.UseVisualStyleBackColor = false;
            historyButton.Click += historyButton_Click;
            // 
            // mouvementsButton
            // 
            mouvementsButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            mouvementsButton.BackColor = Color.FromArgb(5, 12, 19);
            mouvementsButton.Cursor = Cursors.Hand;
            mouvementsButton.FlatAppearance.BorderColor = Color.FromArgb(0, 114, 213);
            mouvementsButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 114, 213);
            mouvementsButton.FlatStyle = FlatStyle.Flat;
            mouvementsButton.Font = new Font("Inter SemiBold", 12F, FontStyle.Bold);
            mouvementsButton.ForeColor = SystemColors.ControlLightLight;
            mouvementsButton.Image = Properties.Resources.arrow_left_right_1_;
            mouvementsButton.ImageAlign = ContentAlignment.MiddleLeft;
            mouvementsButton.Location = new Point(20, 220);
            mouvementsButton.Name = "mouvementsButton";
            mouvementsButton.Padding = new Padding(30, 0, 0, 0);
            mouvementsButton.Size = new Size(264, 42);
            mouvementsButton.TabIndex = 6;
            mouvementsButton.Text = "Mouvements";
            mouvementsButton.TextAlign = ContentAlignment.MiddleLeft;
            mouvementsButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            mouvementsButton.UseVisualStyleBackColor = false;
            mouvementsButton.Click += mouvementsButton_Click;
            // 
            // dashboardButton
            // 
            dashboardButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dashboardButton.BackColor = Color.FromArgb(5, 12, 19);
            dashboardButton.Cursor = Cursors.Hand;
            dashboardButton.FlatAppearance.BorderColor = Color.FromArgb(0, 114, 213);
            dashboardButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 114, 213);
            dashboardButton.FlatStyle = FlatStyle.Flat;
            dashboardButton.Font = new Font("Inter SemiBold", 12F, FontStyle.Bold);
            dashboardButton.ForeColor = SystemColors.ControlLightLight;
            dashboardButton.Image = Properties.Resources.layout_dashboard_1_;
            dashboardButton.ImageAlign = ContentAlignment.MiddleLeft;
            dashboardButton.Location = new Point(20, 120);
            dashboardButton.Name = "dashboardButton";
            dashboardButton.Padding = new Padding(30, 0, 0, 0);
            dashboardButton.Size = new Size(264, 42);
            dashboardButton.TabIndex = 5;
            dashboardButton.Text = "Dashboard";
            dashboardButton.TextAlign = ContentAlignment.MiddleLeft;
            dashboardButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            dashboardButton.UseVisualStyleBackColor = false;
            dashboardButton.Click += dashboardButton_Click;
            // 
            // productsButton
            // 
            productsButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            productsButton.BackColor = Color.FromArgb(5, 12, 19);
            productsButton.Cursor = Cursors.Hand;
            productsButton.FlatAppearance.BorderColor = Color.FromArgb(0, 114, 213);
            productsButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 114, 213);
            productsButton.FlatStyle = FlatStyle.Flat;
            productsButton.Font = new Font("Inter SemiBold", 12F, FontStyle.Bold);
            productsButton.ForeColor = SystemColors.ControlLightLight;
            productsButton.Image = Properties.Resources.package_3_;
            productsButton.ImageAlign = ContentAlignment.MiddleLeft;
            productsButton.Location = new Point(20, 170);
            productsButton.Name = "productsButton";
            productsButton.Padding = new Padding(30, 0, 0, 0);
            productsButton.Size = new Size(264, 42);
            productsButton.TabIndex = 4;
            productsButton.Text = "Produits";
            productsButton.TextAlign = ContentAlignment.MiddleLeft;
            productsButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            productsButton.UseVisualStyleBackColor = false;
            productsButton.Click += productsButton_Click;
            // 
            // aboutButton
            // 
            aboutButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            aboutButton.BackColor = Color.FromArgb(5, 12, 19);
            aboutButton.Cursor = Cursors.Hand;
            aboutButton.FlatAppearance.BorderColor = Color.FromArgb(0, 114, 213);
            aboutButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 114, 213);
            aboutButton.FlatStyle = FlatStyle.Flat;
            aboutButton.Font = new Font("Inter SemiBold", 12F, FontStyle.Bold);
            aboutButton.ForeColor = SystemColors.ControlLightLight;
            aboutButton.Location = new Point(20, 320);
            aboutButton.Name = "aboutButton";
            aboutButton.Padding = new Padding(30, 0, 0, 0);
            aboutButton.Size = new Size(264, 42);
            aboutButton.TabIndex = 9;
            aboutButton.Text = "ℹ️ À Propos";
            aboutButton.TextAlign = ContentAlignment.MiddleLeft;
            aboutButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            aboutButton.UseVisualStyleBackColor = false;
            aboutButton.Click += aboutButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Image = Properties.Resources.gestock;
            pictureBox1.Location = new Point(24, 23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(51, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(mainView);
            panel2.Location = new Point(306, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(918, 631);
            panel2.TabIndex = 3;
            panel2.Paint += panel2_Paint;
            // 
            // mainView
            // 
            mainView.BackColor = Color.FromArgb(2, 6, 13);
            mainView.Dock = DockStyle.Fill;
            mainView.Location = new Point(0, 0);
            mainView.Name = "mainView";
            mainView.Size = new Size(918, 631);
            mainView.TabIndex = 0;
            mainView.Paint += mainView_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(2, 6, 13);
            ClientSize = new Size(1226, 631);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "GEStock  - An organized way to manage your products.";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Label lblSlogan;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Button productsButton;
        private Button historyButton;
        private Button mouvementsButton;
        private Button dashboardButton;
        private Button fullScreenButton;
        private Button aboutButton;
        private Panel panel2;
        private Panel mainView;
    }
}
