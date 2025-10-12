using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext ctx) : base(ctx) { }

    public async Task<Product?> GetByNameAsync(string name) =>
        await _ctx.Products.FirstOrDefaultAsync(p => p.ProductName == name);

    public async Task<Product?> GetBySkuAsync(string sku)
    {
        // SKU not included in model by default; placeholder in case you add it
        return null;
    }

    public async Task<IEnumerable<Product>> GetLowStockAsync(int threshold) =>
        await _ctx.Products
            .Where(p => p.Inventory != null && p.Inventory.Quantity <= threshold)
            .ToListAsync();
}