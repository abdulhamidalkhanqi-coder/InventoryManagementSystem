namespace InventoryManagementSystem.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string? ContactInfo { get; set; }

       
        public ICollection<Order>? Orders { get; set; }
    }
}
