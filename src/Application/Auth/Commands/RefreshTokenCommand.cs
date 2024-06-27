using Application.Auth.DTOs;
using MediatR;

namespace Application.Auth.Commands
{
    public sealed record RefreshTokenCommand(string ExpiredToken, string RefreshToken) : IRequest<LoginDTO>;
}
