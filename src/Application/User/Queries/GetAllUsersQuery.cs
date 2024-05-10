using Application.User.DTOs;
using MediatR;

namespace Application.User.Queries
{
    public sealed record GetAllUsersQuery(int Page, int PageSize) : IRequest<IEnumerable<UserDTO>>;
}
