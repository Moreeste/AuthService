using Application.Profile.DTOs;
using Domain.Repository;

namespace Application.Profile.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
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
    }
}
