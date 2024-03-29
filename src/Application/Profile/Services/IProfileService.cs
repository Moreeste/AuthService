using Application.Profile.DTOs;

namespace Application.Profile.Services
{
    public interface IProfileService
    {
        Task<IEnumerable<ProfileDTO>> GetProfiles();
        Task<CreateProfileOutDTO> CreateProfile(string description, string registrationUser);
    }
}
