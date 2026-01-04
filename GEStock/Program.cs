using System;

namespace GEStock
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Initialiser la base de données
            try
            {
                var db = Data.DatabaseManager.Instance;
                System.Diagnostics.Debug.WriteLine($"Database initialized at: {db.GetDatabasePath()}");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    $"Erreur lors de l'initialisation de la base de données:\n{ex.Message}",
                    "Erreur critique",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }

            // Afficher le formulaire de connexion
            using (var loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Si authentification réussie, ouvrir le formulaire principal
                    Application.Run(new Form1());
                }
            }
        }
    }
}
