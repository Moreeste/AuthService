using Application.ProfilePermissions.DTOs;
using Domain.Utilities;

namespace Application.ProfilePermissions.Services
{
    public interface IProfilePermissionsService
    {
        Task<PagedList<ProfilePermissionsDTO>> GetProfilePermissions(string? idProfile, string? idEndpoint, string? active, string? sortColumn, string? sortOrder, int page, int pageSize);
        Task<RegisterPermissionOutDTO> RegisterPermission(string? idProfile, string? idEndpoint, string registrationUser);
        Task<DeletePermissionDTO> DeletePermission(string idPermission, string updaterUser);
        Task<IEnumerable<PermissionsByProfileDTO>> GetPermissionsByIdProfile(string? idProfile);
    }
}
