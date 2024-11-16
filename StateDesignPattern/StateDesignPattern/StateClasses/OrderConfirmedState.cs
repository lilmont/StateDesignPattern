using StateDesignPattern.Context;
using StateDesignPattern.Interfaces;
using StateDesignPattern.Responses;

namespace StateDesignPattern.StateClasses;

public class OrderConfirmedState : IOrderState
{   
    public Response ConfirmOrder(OrderContext context, Guid orderId)
    {
        Console.WriteLine("Order is already confirmed.");
        return new Response
        {
            IsSuccess = false,
            Message = "Order is already confirmed."
        };
    }

    public Response ShipOrder(OrderContext context, Guid orderId)
    {
        Console.WriteLine("Order shipped.");
        context.TransitionToState(new OrderShippedState(), orderId);
        return new Response
        {
            IsSuccess = true,
            Message = "Order shipped."
        };
    }

    public Response DeliverOrder(OrderContext context, Guid orderId)
    {
        Console.WriteLine("Cannot deliver order. Order needs to be shipped first.");
        return new Response
        {
            IsSuccess = false,
            Message = "Cannot deliver order. Order needs to be shipped first."
        };
    }

    public Response CancelOrder(OrderContext context, Guid orderId)
    {
        Console.WriteLine("Order cancelled.");
        return new Response
        {
            IsSuccess = true,
            Message = "Order cancelled."
        };
    }
}
