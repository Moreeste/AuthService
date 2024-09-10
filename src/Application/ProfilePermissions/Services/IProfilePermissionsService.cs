using Application.ProfilePermissions.DTOs;

namespace Application.ProfilePermissions.Services
{
    public interface IProfilePermissionsService
    {
        Task<IEnumerable<ProfilePermissionsDTO>> GetProfilePermissions();
        Task<RegisterPermissionOutDTO> RegisterPermission();
        Task<DeletePermissionDTO> DeletePermission();
    }
}
