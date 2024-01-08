using Application.Modules.User.DTOs;

namespace Application.Modules.User.Services
{
    public interface IUserService
    {
        Task<UserDTO> GetUserById(string id);
    }
}
