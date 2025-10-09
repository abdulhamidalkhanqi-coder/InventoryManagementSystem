namespace InventoryManagementSystem.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        
        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
