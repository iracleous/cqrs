using cqrs.Events;
using cqrs.Models;

namespace cqrs.Services;

public class OrderCommandHandler
{
    private readonly IEventStore<OrderEvent, Guid> _eventStore;

    public OrderCommandHandler(IEventStore<OrderEvent, Guid> eventStore)
    {
        _eventStore = eventStore;
    }

    public void HandleAddItemToOrder(Guid orderId, string product, int quantity, decimal pricePerUnit)
    {
        var order = new Order(orderId);
        order.AddItem(product, quantity, pricePerUnit);

        var itemAddedEvent = new ItemAddedToOrder(orderId, product, quantity, pricePerUnit);
        _eventStore.SaveEvent(itemAddedEvent);
    }
}
 
