using Application.Profile.DTOs;

namespace Application.Profile.Services
{
    public interface IProfileService
    {
        Task<IEnumerable<ProfileDTO>> GetProfiles();
    }
}
