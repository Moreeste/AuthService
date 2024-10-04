using Application.ProfilePermissions.DTOs;

namespace Application.ProfilePermissions.Services
{
    public interface IProfilePermissionsService
    {
        Task<IEnumerable<ProfilePermissionsDTO>> GetProfilePermissions();
        Task<RegisterPermissionOutDTO> RegisterPermission(string? idProfile, string? idEndpoint, string registrationUser);
        Task<DeletePermissionDTO> DeletePermission();
        Task<IEnumerable<PermissionsByProfileDTO>> GetPermissionsByIdProfile(string? idProfile);
    }
}
