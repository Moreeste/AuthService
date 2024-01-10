using Application.User.DTOs;

namespace Application.User.Services
{
    public interface IUserService
    {
        Task<UserDTO> GetUserById(string id);
    }
}
