using Domain.Model.User;

namespace Domain.Repository
{
    public interface IProfileRepository
    {
        Task<IEnumerable<Profile>?> GetProfiles();
        Task<bool> CreateProfile(string idProfile, string? description, string? registrationUser);
        Task<Profile?> GetProfileByName(string? profileName);
    }
}
