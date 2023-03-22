using System.ComponentModel;

namespace desafio.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool HasPendingLogUpdate { get; set; }
    }
}

