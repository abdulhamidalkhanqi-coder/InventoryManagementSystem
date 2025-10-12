using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly IInventoryRepository _repo;
    public InventoryController(IInventoryRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var i = await _repo.GetByIdAsync(id);
        if (i == null) return NotFound();
        return Ok(i);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Inventory inventory)
    {
        await _repo.AddAsync(inventory);
        await _repo.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = inventory.InventoryId }, inventory);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] Inventory dto)
    {
        var i = await _repo.GetByIdAsync(id);
        if (i == null) return NotFound();
        i.Quantity = dto.Quantity;
        _repo.Update(i);
        await _repo.SaveChangesAsync();
        return NoContent();
    }
}
