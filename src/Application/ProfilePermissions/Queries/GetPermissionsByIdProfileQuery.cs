using Application.ProfilePermissions.DTOs;
using MediatR;

namespace Application.ProfilePermissions.Queries
{
    public sealed record GetPermissionsByIdProfileQuery(string? IdProfile) : IRequest<IEnumerable<ProfilePermissionsDTO>>;
}
