using Application.User.DTOs;
using MediatR;

namespace Application.User.Queries
{
    public sealed record GetAllUsersQuery : IRequest<IEnumerable<UserDTO>>;
}
