using Application.Login.DTOs;
using MediatR;

namespace Application.Login.Commands
{
    public sealed record LoginCommand(string Email, string Password) : IRequest<LoginDTO>;
}
