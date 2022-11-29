﻿namespace MunApi.Models.Entities
{
    public class ProductEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        
        public ICollection<OrderEntity> Orders { get; set; }
    }
}
