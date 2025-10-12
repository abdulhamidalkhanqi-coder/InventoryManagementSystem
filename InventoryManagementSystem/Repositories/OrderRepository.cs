using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext ctx) : base(ctx) { }

    public async Task<IEnumerable<Order>> GetByCustomerAsync(int customerId) =>
        await _ctx.Orders
            .Include(o => o.OrderDetails)
            .Where(o => o.CustomerId == customerId)
            .ToListAsync();
}