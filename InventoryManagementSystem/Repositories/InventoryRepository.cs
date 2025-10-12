using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Repositories;

public class InventoryRepository : Repository<Inventory>, IInventoryRepository
{
    public InventoryRepository(AppDbContext ctx) : base(ctx) { }

    public async Task<int> GetQuantityForProductAsync(int productId)
    {
        var inv = await _ctx.Inventories.FirstOrDefaultAsync(i => i.ProductId == productId);
        return inv?.Quantity ?? 0;
    }
}

