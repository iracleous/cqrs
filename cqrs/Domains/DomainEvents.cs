namespace cqrs.Domains;

public static class DomainEvents
{
    // List of registered event handlers
    private static List<Delegate> _handlers;

    public static void Register<T>(Action<T> eventHandler) where T : class
    {
        if (_handlers == null)
            _handlers = new List<Delegate>();

        _handlers.Add(eventHandler);
    }

    public static void Raise<T>(T domainEvent) where T : class
    {
        foreach (var handler in _handlers.OfType<Action<T>>())
        {
            handler(domainEvent);
        }
    }

    public static void ClearHandlers()
    {
        _handlers?.Clear();
    }
}
