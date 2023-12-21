using Application.Modules.User.DTOs;
using MediatR;

namespace Application.Modules.User.Queries
{
    public sealed record GetUserByIdQuery(string Id) : IRequest<UserDTO>;
}
