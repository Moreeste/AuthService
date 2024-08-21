using Application.ProfilePermissions.DTOs;
using MediatR;

namespace Application.ProfilePermissions.Queries
{
    public sealed record GetProfilePermissionsQuery : IRequest<IEnumerable<ProfilePermissionsDTO>>;
}
