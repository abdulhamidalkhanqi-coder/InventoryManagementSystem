using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;



namespace InventoryManagementSystem.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext ctx) : base(ctx) { }

        public async Task<Customer?> GetByNameAsync(string name) =>
            await _ctx.Customers.FirstOrDefaultAsync(c => c.CustomerName == name);
    }
}
