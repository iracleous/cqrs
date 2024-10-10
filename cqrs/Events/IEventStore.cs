using Microsoft.Extensions.Logging;

namespace cqrs.Events;

public interface IEventStore<T, K>
{
    void SaveEvent(T tEvent);
    IEnumerable<T> GetEvents(K tId);
}
