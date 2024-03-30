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

        public ProfileService(IUtilities utilities, IProfileRepository profileRepository)
        {
            _utilities = utilities;
            _profileRepository = profileRepository;
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
    }
}
