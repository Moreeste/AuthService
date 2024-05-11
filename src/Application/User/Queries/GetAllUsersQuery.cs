using Application.User.DTOs;
using Domain.Utilities;
using MediatR;

namespace Application.User.Queries
{
    public sealed record GetAllUsersQuery(int Page, int PageSize) : IRequest<PagedList<UserDTO>>;
}
