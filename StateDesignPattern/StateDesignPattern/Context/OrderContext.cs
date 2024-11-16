using Microsoft.EntityFrameworkCore;
using StateDesignPattern.Data;
using StateDesignPattern.Interfaces;
using StateDesignPattern.Models;
using StateDesignPattern.Responses;

namespace StateDesignPattern.Context;

public class OrderContext
{
    private IOrderState _currentState;
    private readonly AppDbContext _dbContext;
    private Guid _orderId;

    public OrderContext(IOrderState state, AppDbContext dbContext, Guid orderId)
    {
        _dbContext = dbContext;
        _orderId = orderId;
        TransitionToState(state, orderId);
    }

    public void TransitionToState(IOrderState state, Guid orderId)
    {
        var currentOrder = _dbContext.Orders.FirstOrDefault(p=>p.OrderId == orderId);

        if (currentOrder != null)
        {
            currentOrder.OrderStatus = state.GetType().Name;
            _dbContext.SaveChanges();

            _currentState = state;
            Console.WriteLine($"Order has transitioned to: {state.GetType().Name}");
        }
    }

    public Response ConfirmOrder() => _currentState.ConfirmOrder(this, _orderId);
    public Response ShipOrder() => _currentState.ShipOrder(this, _orderId);
    public Response DeliverOrder() => _currentState.DeliverOrder(this, _orderId);
    public Response CancelOrder() => _currentState.CancelOrder(this, _orderId);
}
