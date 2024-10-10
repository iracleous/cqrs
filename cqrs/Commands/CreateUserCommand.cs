using MediatR;

namespace cqrs.Commands;

// Command to create a new user
public class CreateUserCommand : IRequest<Guid>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
