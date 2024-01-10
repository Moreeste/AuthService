using Application.User.DTOs;
using MediatR;

namespace Application.User.Commands
{
    public sealed record CreateUserCommand(string Name) : IRequest<UserDTO>;
}
