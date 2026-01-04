using System;

namespace GEStock.Models
{
    public enum MovementType
    {
        Entree = 1,    // Stock entry
        Sortie = 2     // Stock exit
    }

    public class Movement
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public MovementType Type { get; set; }
        public int Quantity { get; set; }
        public string Reference { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public Movement()
        {
            CreatedAt = DateTime.Now;
        }

        public string GetTypeName()
        {
            return Type == MovementType.Entree ? "Entrée" : "Sortie";
        }
    }
}
