using Application.User.DTOs;

namespace Application.User.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsers();
        Task<UserDTO> GetUserById(string id);
    }
}
