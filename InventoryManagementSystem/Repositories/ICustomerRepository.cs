using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer?> GetByNameAsync(string name);
    }
}
