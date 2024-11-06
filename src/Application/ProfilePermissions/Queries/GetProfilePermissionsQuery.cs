using Application.ProfilePermissions.DTOs;
using Domain.Utilities;
using MediatR;

namespace Application.ProfilePermissions.Queries
{
    public sealed record GetProfilePermissionsQuery(string? IdProfile, string? IdEndpoint, string? Active, string? SortColumn, string? SortOrder, string Page, string PageSize) : IRequest<PagedList<ProfilePermissionsDTO>>;
}
