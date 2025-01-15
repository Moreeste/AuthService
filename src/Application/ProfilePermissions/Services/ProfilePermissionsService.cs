using Application.ProfilePermissions.DTOs;
using Domain.Exceptions;
using Domain.Model.ProfilePermission;
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

        public async Task<PagedList<ProfilePermissionsDTO>> GetProfilePermissions(string? idProfile, string? idEndpoint, string? active, string? sortColumn, string? sortOrder, int page, int pageSize)
        {
            IEnumerable<ProfilePermissionModel>? profilePermissions = Enumerable.Empty<ProfilePermissionModel>();

            if (string.IsNullOrEmpty(idProfile) && string.IsNullOrEmpty(idEndpoint))
            {
                profilePermissions = await _profilePermissionRepository.GetProfilePermissions();
            }
            else if (!string.IsNullOrEmpty(idProfile))
            {
                profilePermissions = await _profilePermissionRepository.GetProfilePermissionsByIdProfile(idProfile);
            }
            else if (!string.IsNullOrEmpty(idEndpoint))
            {
                profilePermissions = await _profilePermissionRepository.GetProfilePermissionsByIdEndpoint(idEndpoint);
            }

            IQueryable<ProfilePermissionModel>? profilePermissionsQuery = profilePermissions?.AsQueryable();

            if (!string.IsNullOrEmpty(idProfile) && !string.IsNullOrEmpty(idEndpoint))
            {
                profilePermissionsQuery = profilePermissionsQuery?.Where(x => x.IdEndpoint != null && x.IdEndpoint.ToLower() == idEndpoint.ToLower());
            }

            if (!string.IsNullOrEmpty(active))
            {
                if (active == "1")
                {
                    profilePermissionsQuery = profilePermissionsQuery?.Where(x => x.Active == true);
                }
                else if (active == "0")
                {
                    profilePermissionsQuery = profilePermissionsQuery?.Where(x => x.Active == false);
                }
            }

            if (!string.IsNullOrEmpty(sortColumn))
            {
                var sortProperty = KeySelector.GetProfilePermissionModelSortProperty(sortColumn);

                if (sortOrder?.ToLower() == "desc")
                {
                    profilePermissionsQuery = profilePermissionsQuery?.OrderByDescending(sortProperty);
                }
                else
                {
                    profilePermissionsQuery = profilePermissionsQuery?.OrderBy(sortProperty);
                }
            }

            throw new NotImplementedException();
        }

        public async Task<RegisterPermissionOutDTO> RegisterPermission(string? idProfile, string? idEndpoint, string registrationUser)
        {
            if (idProfile == "00000000-0000-0000-0000-000000000000")
            {
                throw new BusinessException("No es necesario asignar permisos a los administradores.");
            }

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

            if (endpoint.IsPublic)
            {
                throw new BusinessException("No es necesario asignar permisos a los endpoints publicos.");
            }

            if (endpoint.IsForEveryone)
            {
                throw new BusinessException("No es necesario asignar permisos a los endpoints generales para usuarios registrados.");
            }

            var permission = await _profilePermissionRepository.GetProfilePermission(idProfile, idEndpoint);

            if (permission != null)
            {
                if (permission.Active)
                {
                    throw new BusinessException("Ya existe el permiso.");
                }
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
            var permission = await _profilePermissionRepository.GetProfilePermissionById(idPermission);

            if (permission == null)
            {
                throw new BusinessException("No existe el permiso.");
            }

            bool permissionUpdated = await _profilePermissionRepository.UpdateProfilePermission(idPermission, false, updaterUser);

            return new DeletePermissionDTO
            {
                Deleted = permissionUpdated
            };
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
