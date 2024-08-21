using Application.ProfilePermissions.DTOs;
using MediatR;

namespace Application.ProfilePermissions.Commands
{
    public sealed record DeletePermissionCommand(string IdPermission, string IdUser) : IRequest<DeletePermissionDTO>;
}
