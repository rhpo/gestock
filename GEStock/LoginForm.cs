using System;
using System.Drawing;
using System.Windows.Forms;
using GEStock.Services;

namespace GEStock
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Veuillez saisir le nom d'utilisateur et le mot de passe.",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = AuthService.Login(username, password);

            if (user != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.",
                    "Erreur d'authentification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Centrer le formulaire
            this.CenterToScreen();
        }
    }
}
