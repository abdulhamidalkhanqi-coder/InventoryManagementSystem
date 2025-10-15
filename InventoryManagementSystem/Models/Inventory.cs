namespace InventoryManagementSystem.Models
{
    public class Inventory
    {
        public int InventoryId { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int QuantityAvailable { get; set; }

      
        public DateTime LastUpdated { get; set; }

        public int Quantity { get; set; }
    }
}
