using Domain.Model.User;

namespace Domain.Repository
{
    public interface IUserRepository
    {
        Task<UserModel?> GetUserById(string id);
        Task<UserModel?> GetUserByEmail(string email);
        Task<UserModel?> GetUserByPhone(string phone);
    }
}
