namespace InventoryManagementSystem.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? Description { get; set; }

        public int QuantityInStock { get; set; }
        public Inventory? Inventory { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}

