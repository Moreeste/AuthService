using Application.ProfilePermissions.DTOs;

namespace Application.ProfilePermissions.Services
{
    public class ProfilePermissionsService : IProfilePermissionsService
    {
        public async Task<IEnumerable<ProfilePermissionsDTO>> GetProfilePermissions()
        {
            throw new NotImplementedException();
        }

        public async Task<RegisterPermissionOutDTO> RegisterPermission()
        {
            throw new NotImplementedException();
        }

        public async Task<DeletePermissionDTO> DeletePermission()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProfilePermissionsDTO>> GetPermissionsByIdProfile(string? idProfile)
        {
            throw new NotImplementedException();
        }
    }
}
