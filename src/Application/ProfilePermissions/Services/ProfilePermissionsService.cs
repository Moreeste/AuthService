using Application.ProfilePermissions.DTOs;
using Domain.Exceptions;
using Domain.Repository;
using Domain.Utilities;

namespace Application.ProfilePermissions.Services
{
    public class ProfilePermissionsService : IProfilePermissionsService
    {
        private readonly IUtilities _utilities;
        private readonly IProfilePermissionRepository _profilePermissionRepository;
        private readonly IProfileRepository _profileRepository;
        private readonly IEndpointRepository _endpointRepository;

        public ProfilePermissionsService(IUtilities utilities, IProfilePermissionRepository profilePermissionRepository, IProfileRepository profileRepository, IEndpointRepository endpointRepository)
        {
            _utilities = utilities;
            _profilePermissionRepository = profilePermissionRepository;
            _profileRepository = profileRepository;
            _endpointRepository = endpointRepository;
        }

        public async Task<IEnumerable<ProfilePermissionsDTO>> GetProfilePermissions()
        {
            throw new NotImplementedException();
        }

        public async Task<RegisterPermissionOutDTO> RegisterPermission(string? idProfile, string? idEndpoint, string registrationUser)
        {
            var profile = await _profileRepository.GetProfileById(idProfile);

            if (profile == null)
            {
                throw new BusinessException("No existe el perfil.");
            }

            var endpoint = await _endpointRepository.GetEndpointById(idEndpoint);

            if (endpoint == null)
            {
                throw new BusinessException("No existe el endpoint.");
            }

            var idPermission = _utilities.GenerateId();

            await _profilePermissionRepository.RegisterProfilePermission(idPermission, idProfile, idEndpoint, registrationUser);

            return new RegisterPermissionOutDTO
            {
                IdPermission = idPermission
            };
        }

        public async Task<DeletePermissionDTO> DeletePermission(string idPermission, string updaterUser)
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
