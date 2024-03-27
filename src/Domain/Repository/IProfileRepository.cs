using Domain.Model.User;

namespace Domain.Repository
{
    public interface IProfileRepository
    {
        Task<IEnumerable<Profile>?> GetProfiles();
    }
}
