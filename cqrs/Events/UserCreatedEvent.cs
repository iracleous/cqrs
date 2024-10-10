namespace cqrs.Events;

public class UserCreatedEvent
{
    public string UserId { get; }
    public string Name { get; }
    public string Email { get; }

    public UserCreatedEvent(string userId, string name, string email)
    {
        UserId = userId;
        Name = name;
        Email = email;
    }
}
