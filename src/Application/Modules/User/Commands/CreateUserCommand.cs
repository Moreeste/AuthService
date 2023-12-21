using Application.Modules.User.DTOs;
using MediatR;

namespace Application.Modules.User.Commands
{
    public sealed record CreateUserCommand(string Name) : IRequest<UserDTO>;
}
