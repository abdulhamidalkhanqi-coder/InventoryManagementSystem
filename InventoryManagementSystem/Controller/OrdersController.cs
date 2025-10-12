using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderRepository _repo;
    public OrdersController(IOrderRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var o = await _repo.GetByIdAsync(id);
        if (o == null) return NotFound();
        return Ok(o);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Order order)
    {
        // Basic example: Order with OrderDetails. Business logic like stock decrement should be added in services.
        await _repo.AddAsync(order);
        await _repo.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = order.OrderId }, order);
    }

    [HttpGet("by-customer/{customerId:int}")]
    public async Task<IActionResult> ByCustomer(int customerId) => Ok(await _repo.GetByCustomerAsync(customerId));
}
