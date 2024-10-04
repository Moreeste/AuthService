using Application.ProfilePermissions.DTOs;
using MediatR;

namespace Application.ProfilePermissions.Commands
{
    public sealed record RegisterPermissionCommand(string? IdProfile, string? IdEndpoint, string RegistrationUser) : IRequest<RegisterPermissionOutDTO>;
}
