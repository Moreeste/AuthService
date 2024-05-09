using Domain.Model.User;

namespace Domain.Repository
{
    public interface IUserPropertiesRepository
    {
        Task<UserPropertiesModel?> GetUserProperties(string? idUser);
    }
}
