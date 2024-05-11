using Application.User.DTOs;
using Domain.Utilities;

namespace Application.User.Services
{
    public interface IUserService
    {
        Task<PagedList<UserDTO>> GetAllUsers(int page, int pageSize);
        Task<UserDTO> GetUserById(string id);
    }
}
