using StateDesignPattern.Enums;

namespace StateDesignPattern.Models;

public class Order
{
    public Guid OrderId { get; set; }
    public required string OrderTitle { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public OrderStateEnum OrderStatus { get; set; }
}
