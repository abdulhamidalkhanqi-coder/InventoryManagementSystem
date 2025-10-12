using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repo;
    public ProductsController(IProductRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var p = await _repo.GetByIdAsync(id);
        if (p == null) return NotFound();
        return Ok(p);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Product product)
    {
        await _repo.AddAsync(product);
        await _repo.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = product.ProductId }, product);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] Product dto)
    {
        var p = await _repo.GetByIdAsync(id);
        if (p == null) return NotFound();
        p.ProductName = dto.ProductName;
        p.Price = dto.Price;
        p.Description = dto.Description;
        _repo.Update(p);
        await _repo.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var p = await _repo.GetByIdAsync(id);
        if (p == null) return NotFound();
        _repo.Remove(p);
        await _repo.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet("low-stock/{threshold:int}")]
    public async Task<IActionResult> LowStock(int threshold) => Ok(await _repo.GetLowStockAsync(threshold));
}
