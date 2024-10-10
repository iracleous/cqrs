namespace cqrs.Events;

public class InMemoryEventStore : IEventStore<OrderEvent, Guid>
{
    private readonly Dictionary<Guid, List<OrderEvent>> _store = 
        new Dictionary<Guid, List<OrderEvent>>();

    public void SaveEvent(OrderEvent orderEvent)
    {
        if (!_store.ContainsKey(orderEvent.OrderId))
        {
            _store[orderEvent.OrderId] = new List<OrderEvent>();
        }

        _store[orderEvent.OrderId].Add(orderEvent);
    }

    public IEnumerable<OrderEvent> GetEvents(Guid orderId)
    {
        return _store.ContainsKey(orderId) ? _store[orderId] : new List<OrderEvent>();
    }
}

