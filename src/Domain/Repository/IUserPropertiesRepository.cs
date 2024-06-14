using Domain.Model.User;

namespace Domain.Repository
{
    public interface IUserPropertiesRepository
    {
        Task<UserPropertiesModel?> GetUserProperties(string? idUser);
        Task<bool> UpdateUserProfile(string idUser, string idProfile, string updateUser);
        Task<bool> UpdateUserStatus(string idUser, int idStatus, string updateUser);
    }
}
