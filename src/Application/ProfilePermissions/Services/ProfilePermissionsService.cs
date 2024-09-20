using Application.ProfilePermissions.DTOs;
using Domain.Repository;

namespace Application.ProfilePermissions.Services
{
    public class ProfilePermissionsService : IProfilePermissionsService
    {
        private readonly IProfilePermissionRepository _profilePermissionRepository;

        public ProfilePermissionsService(IProfilePermissionRepository profilePermissionRepository)
        {
            _profilePermissionRepository = profilePermissionRepository;
        }

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
            var permissions = await _profilePermissionRepository.GetProfilePermissionsByIdProfile(idProfile);

            if (permissions == null)
            {
                return Enumerable.Empty<ProfilePermissionsDTO>();
            }

            return permissions.Select(model => new ProfilePermissionsDTO
            {
                IdPermission = model.IdPermission,
                IdProfile = model.IdProfile,
                Profile = model.Profile,
                IdEndpoint = model.IdEndpoint,
                Endpoint = model.Endpoint,
                Active = model.Active
            });
        }
    }
}
