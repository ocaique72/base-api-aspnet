namespace desafio.Models
{
    using System;

    public class ProductLog
    {
        public Guid Id { get; set; }
        public int ProductId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string ProductJson { get; set; }

    }

}
