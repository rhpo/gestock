using System;

namespace GEStock.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int MinQuantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? ImagePath { get; set; }

        public Product()
        {
            CreatedAt = DateTime.Now;
            MinQuantity = 10;
        }

        public bool IsLowStock()
        {
            return Quantity <= MinQuantity;
        }
    }
}
