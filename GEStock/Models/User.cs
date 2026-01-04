using System;

namespace GEStock.Models
{
    public enum UserRole
    {
        Administrateur = 1,      // Gère les produits et supervise les mouvements
        Magasinier = 2,          // Enregistre les entrées et sorties de stock
        UtilisateurSimple = 3    // Consulte les produits et les statistiques
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public User()
        {
            IsActive = true;
            CreatedAt = DateTime.Now;
        }

        public string GetRoleName()
        {
            return Role switch
            {
                UserRole.Administrateur => "Administrateur",
                UserRole.Magasinier => "Magasinier",
                UserRole.UtilisateurSimple => "Utilisateur Simple",
                _ => "Inconnu"
            };
        }
    }
}
