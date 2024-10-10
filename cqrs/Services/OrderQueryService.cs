using cqrs.Events;
using cqrs.Models;

namespace cqrs.Services;

public class OrderQueryService
{
    private readonly IEventStore<OrderEvent, Guid> _eventStore;

    public OrderQueryService(IEventStore<OrderEvent, Guid> eventStore)
    {
        _eventStore = eventStore;
    }

    public Order GetOrder(Guid orderId)
    {
        var events = _eventStore.GetEvents(orderId);
        var order = new Order(orderId);

        foreach (var @event in events)
        {
            if (@event is ItemAddedToOrder itemAddedEvent)
            {
                order.AddItem(itemAddedEvent.Product, itemAddedEvent.Quantity, itemAddedEvent.PricePerUnit);
            }
        }

        return order;
    }
}
