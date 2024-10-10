using cqrs.Models;
using MediatR;

namespace cqrs.Queries;

// Query to retrieve user by Id
public class GetUserByIdQuery : IRequest<User>
{
    public Guid UserId { get; set; }

    public GetUserByIdQuery(Guid userId)
    {
        UserId = userId;
    }
}
