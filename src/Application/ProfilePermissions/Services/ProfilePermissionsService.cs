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

        public async Task<RegisterPermissionOutDTO> RegisterPermission(string? idProfile, string? idEndpoint, string registrationUser)
        {
            throw new NotImplementedException();
        }

        public async Task<DeletePermissionDTO> DeletePermission()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PermissionsByProfileDTO>> GetPermissionsByIdProfile(string? idProfile)
        {
            var permissions = await _profilePermissionRepository.GetProfilePermissionsByIdProfile(idProfile);

            if (permissions == null)
            {
                return Enumerable.Empty<PermissionsByProfileDTO>();
            }

            return permissions.Select(model => new PermissionsByProfileDTO
            {
                IdPermission = model.IdPermission,
                IdEndpoint = model.IdEndpoint,
                Endpoint = model.Endpoint,
                Active = model.Active
            });
        }
    }
}
