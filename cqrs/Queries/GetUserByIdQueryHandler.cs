using cqrs.Models;
using MediatR;

namespace cqrs.Queries;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
{
    private readonly UserDbContext _context;

    public GetUserByIdQueryHandler(UserDbContext context)
    {
        _context = context;
    }

    public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Users.FindAsync(request.UserId) ?? new User { };
    }
}
