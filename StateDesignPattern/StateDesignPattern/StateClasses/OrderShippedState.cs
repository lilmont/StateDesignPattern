using StateDesignPattern.Context;
using StateDesignPattern.Interfaces;
using StateDesignPattern.Responses;

namespace StateDesignPattern.StateClasses;

public class OrderShippedState : IOrderState
{
    public Response ConfirmOrder(OrderContext context, Guid orderId)
    {
        Console.WriteLine("Cannot confirm order. Order is already shipped.");
        return new Response
        {
            IsSuccess = false,
            Message = "Cannot confirm order. Order is already shipped."
        };
    }

    public Response ShipOrder(OrderContext context, Guid orderId)
    {
        Console.WriteLine("Order is already shipped.");
        return new Response
        {
            IsSuccess = false,
            Message = "Order is already shipped."
        };
    }

    public Response DeliverOrder(OrderContext context, Guid orderId)
    {
        Console.WriteLine("Order delivered.");
        context.TransitionToState(new OrderDeliveredState(), orderId);
        return new Response
        {
            IsSuccess = true,
            Message = "Order delivered."
        };
    }

    public Response CancelOrder(OrderContext context, Guid orderId)
    {
        Console.WriteLine("Cannot cancel order. Order is already shipped.");
        return new Response
        {
            IsSuccess = false,
            Message = "Cannot cancel order. Order is already shipped."
        };
    }
}
