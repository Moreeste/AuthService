using Application.User.DTOs;

namespace Application.User.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsers(int page, int pageSize);
        Task<UserDTO> GetUserById(string id);
    }
}
