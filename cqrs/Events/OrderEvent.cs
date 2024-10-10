namespace cqrs.Events;

public abstract class OrderEvent
{
    public Guid OrderId { get; private set; }
    public DateTime OccurredOn { get; private set; } = DateTime.UtcNow;

    public OrderEvent(Guid orderId)
    {
        OrderId = orderId;
    }
}

public class ItemAddedToOrder : OrderEvent
{
    public string Product { get; private set; }
    public int Quantity { get; private set; }
    public decimal PricePerUnit { get; private set; }

    public ItemAddedToOrder(Guid orderId, string product, int quantity, decimal pricePerUnit)
        : base(orderId)
    {
        Product = product;
        Quantity = quantity;
        PricePerUnit = pricePerUnit;
    }
}
