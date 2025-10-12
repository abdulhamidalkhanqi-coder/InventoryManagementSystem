using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repositories;

namespace InventoryManagementSystem.Repositories;

public interface IInventoryRepository : IRepository<Inventory>
{
    Task<int> GetQuantityForProductAsync(int productId);
}