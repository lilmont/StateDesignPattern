using StateDesignPattern.Context;
using StateDesignPattern.Interfaces;
using StateDesignPattern.Responses;

namespace StateDesignPattern.StateClasses;

public class OrderDeliveredState : IOrderState
{
    public Response ConfirmOrder(OrderContext context, Guid orderId)
    {
        Console.WriteLine("Cannot confirm order. Order is already delivered.");
        return new Response
        {
            IsSuccess = false,
            Message = "Cannot confirm order. Order is already delivered."
        };
    }

    public Response ShipOrder(OrderContext context, Guid orderId)
    {
        Console.WriteLine("Cannot ship order. Order is already delivered.");
        return new Response
        {
            IsSuccess = false,
            Message = "Cannot ship order. Order is already delivered."
        };
    }

    public Response DeliverOrder(OrderContext context, Guid orderId)
    {
        Console.WriteLine("Order is already delivered.");
        return new Response
        {
            IsSuccess = false,
            Message = "Order is already delivered."
        };
    }

    public Response CancelOrder(OrderContext context, Guid orderId)
    {
        Console.WriteLine("Cannot cancel order. Order is already delivered.");
        return new Response
        {
            IsSuccess = false,
            Message = "Cannot cancel order. Order is already delivered."
        };
    }
}
