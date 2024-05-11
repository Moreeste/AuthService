using Application.User.DTOs;
using Domain.Utilities;
using MediatR;

namespace Application.User.Queries
{
    public sealed record GetAllUsersQuery(string Page, string PageSize) : IRequest<PagedList<UserDTO>>;
}
