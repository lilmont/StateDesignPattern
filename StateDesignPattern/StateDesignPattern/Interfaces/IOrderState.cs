using StateDesignPattern.Context;
using StateDesignPattern.Responses;

namespace StateDesignPattern.Interfaces;

public interface IOrderState
{
    Response ConfirmOrder(OrderContext context, Guid orderId);
    Response ShipOrder(OrderContext context, Guid orderId);
    Response DeliverOrder(OrderContext context, Guid orderId);
    Response CancelOrder(OrderContext context, Guid orderId);
}
