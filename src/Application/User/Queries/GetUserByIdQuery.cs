using Application.User.DTOs;
using MediatR;

namespace Application.User.Queries
{
    public sealed record GetUserByIdQuery(string Id) : IRequest<UserDTO>;
}
