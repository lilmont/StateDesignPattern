using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StateDesignPattern.Context;
using StateDesignPattern.Data;
using StateDesignPattern.Interfaces;
using StateDesignPattern.Models;
using StateDesignPattern.StateClasses;

namespace StateDesignPattern.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : Controller
{
    private readonly AppDbContext _context;
    public OrdersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] Order order)
    {
        order.OrderStatus = "OrderPlacedState";
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(Guid id)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == id);

        if (order == null)
            return NotFound();

        return Ok(order);
    }

    [HttpPost("{id}/confirm")]
    public async Task<IActionResult> ConfirmOrder(Guid id)
    {
        var order = await _context.Orders.FindAsync(id);

        if (order == null)
            return NotFound();

        var stateTypeName = $"StateDesignPattern.StateClasses.{order.OrderStatus}";
        var stateType = Type.GetType(stateTypeName);

        if (stateType == null)
            return BadRequest("Invalid order status for transition.");

        var stateInstance = Activator.CreateInstance(stateType) as IOrderState;
        if (stateInstance == null)
            return BadRequest("Failed to create order state instance.");

        var context = new OrderContext(stateInstance, _context, id);
        var res = context.ConfirmOrder();

        if (res.IsSuccess)
            return Ok(res.Message);

        return BadRequest(res.Message);
    }

    [HttpPost("{id}/ship")]
    public async Task<IActionResult> ShipOrder(Guid id)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(p => p.OrderId == id);

        if (order == null)
            return NotFound();

        var stateTypeName = $"StateDesignPattern.StateClasses.{order.OrderStatus}";
        var stateType = Type.GetType(stateTypeName);

        if (stateType == null)
            return BadRequest("Invalid order status for transition.");

        var stateInstance = Activator.CreateInstance(stateType) as IOrderState;
        if (stateInstance == null)
            return BadRequest("Failed to create order state instance.");

        var context = new OrderContext(stateInstance, _context, id);
        var res = context.ShipOrder();

        if (res.IsSuccess)
            return Ok(res.Message);

        return BadRequest(res.Message);
    }

    [HttpPost("{id}/deliver")]
    public async Task<IActionResult> DeliverOrder(Guid id)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(p => p.OrderId == id);

        if (order == null)
            return NotFound();

        var stateTypeName = $"StateDesignPattern.StateClasses.{order.OrderStatus}";
        var stateType = Type.GetType(stateTypeName);

        if (stateType == null)
            return BadRequest("Invalid order status for transition.");

        var stateInstance = Activator.CreateInstance(stateType) as IOrderState;
        if (stateInstance == null)
            return BadRequest("Failed to create order state instance.");

        var context = new OrderContext(stateInstance, _context, id);
        var res = context.DeliverOrder();

        if (res.IsSuccess)
            return Ok(res.Message);

        return BadRequest(res.Message);
    }
}
