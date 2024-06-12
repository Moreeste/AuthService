using Domain.Model.User;

namespace Domain.Repository
{
    public interface ICatalogueRepository
    {
        Task <IEnumerable<Gender>> GetGenders();
        Task<IEnumerable<UserStatus>> GetUserStatus();
    }
}
