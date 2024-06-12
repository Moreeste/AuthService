using Application.Profile.DTOs;
using Domain.Exceptions;
using Domain.Repository;
using Domain.Utilities;

namespace Application.Profile.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUtilities _utilities;
        private readonly IProfileRepository _profileRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserPropertiesRepository _userPropertiesRepository;

        public ProfileService(IUtilities utilities, IProfileRepository profileRepository, IUserRepository userRepository, IUserPropertiesRepository userPropertiesRepository)
        {
            _utilities = utilities;
            _profileRepository = profileRepository;
            _userRepository = userRepository;
            _userPropertiesRepository = userPropertiesRepository;
        }

        public async Task<IEnumerable<ProfileDTO>> GetProfiles()
        {
            var profiles = await _profileRepository.GetProfiles();

            if (profiles == null)
            {
                return Enumerable.Empty<ProfileDTO>();
            }

            var result = profiles.Select(profile => new ProfileDTO
            {
                Id = profile.IdProfile,
                Description = profile.Description,
                Active = profile.Active,
            });

            return result;
        }

        public async Task<CreateProfileOutDTO> CreateProfile(string? description, string? registrationUser)
        {
            var profile = await _profileRepository.GetProfileByName(description == null ? string.Empty : description.ToUpper());

            if (profile != null)
            {
                throw new BusinessException($"Ya existe el perfil {profile.Description}.");
            }

            string id = _utilities.GenerateId();
            bool profileCreated = await _profileRepository.CreateProfile(id, description, registrationUser);

            return new CreateProfileOutDTO
            {
                IdProfile = id
            };
        }

        public async Task<ProfileDTO> GetProfileById(string id)
        {
            var profile = await _profileRepository.GetProfileById(id);

            if (profile == null)
            {
                throw new SearchException("No existe el perfil.");
            }

            var result = new ProfileDTO
            {
                Id = profile.IdProfile,
                Description = profile.Description,
                Active = profile.Active,
            };

            return result;
        }

        public async Task<ProfileDTO> GetMyProfile(string idUser)
        {
            var user = await _userRepository.GetUserById(idUser);

            if (user == null)
            {
                throw new SearchException("No existe el usuario.");
            }

            var userProperties = await _userPropertiesRepository.GetUserProperties(idUser);

            if (userProperties == null)
            {
                throw new SearchException("El usuario no cuenta con propiedades.");
            }

            if (string.IsNullOrEmpty(userProperties.Profile))
            {
                throw new BusinessException("El usuario no tiene perfil asignado.");
            }
            
            var profile = await _profileRepository.GetProfileById(userProperties.Profile);

            if (profile == null)
            {
                throw new SearchException("No existe el perfil asignado al usuario.");
            }

            var result = new ProfileDTO
            {
                Id = profile.IdProfile,
                Description = profile.Description,
                Active = profile.Active,
            };

            return result;
        }
    }
}
