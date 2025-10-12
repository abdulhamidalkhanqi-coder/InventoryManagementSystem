using InventoryManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InventoryManagementSystem.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext _ctx;
    public Repository(AppDbContext ctx) => _ctx = ctx;

    public async Task AddAsync(T entity) => await _ctx.Set<T>().AddAsync(entity);

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) =>
        await _ctx.Set<T>().Where(predicate).ToListAsync();

    public async Task<IEnumerable<T>> GetAllAsync() => await _ctx.Set<T>().ToListAsync();

    public async Task<T?> GetByIdAsync(int id) => await _ctx.Set<T>().FindAsync(id);

    public void Remove(T entity) => _ctx.Set<T>().Remove(entity);

    public void Update(T entity) => _ctx.Set<T>().Update(entity);

    public async Task SaveChangesAsync() => await _ctx.SaveChangesAsync();
}

