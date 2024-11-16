using StateDesignPattern.Context;
using StateDesignPattern.Interfaces;
using StateDesignPattern.Responses;

namespace StateDesignPattern.StateClasses;

public class OrderPlacedState : IOrderState
{
    public Response CancelOrder(OrderContext context, Guid orderId)
    {
        Console.WriteLine("Order cancelled.");
        return new Response
        {
            IsSuccess = true,
            Message = "Order cancelled."
        };
    }

    public Response ConfirmOrder(OrderContext context, Guid orderId)
    {
        Console.WriteLine("Order confirmed.");
        context.TransitionToState(new OrderConfirmedState(), orderId);
        return new Response
        {
            IsSuccess = true,
            Message = "Order confirmed."
        };
    }

    public Response DeliverOrder(OrderContext context, Guid orderId)
    {
        Console.WriteLine("Cannot deliver order. Order needs to be confirmed and shipped first.");
        return new Response
        {
            IsSuccess = false,
            Message = "Cannot deliver order. Order needs to be confirmed and shipped first."
        };
    }

    public Response ShipOrder(OrderContext context, Guid orderId)
    {
        Console.WriteLine("Cannot ship order. Order needs to be confirmed first.");
        return new Response
        {
            IsSuccess = false,
            Message = "Cannot ship order. Order needs to be confirmed first."
        };
    }
}
