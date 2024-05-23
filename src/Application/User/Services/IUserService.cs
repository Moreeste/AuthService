using Application.User.DTOs;
using Domain.Model.User;
using Domain.Utilities;

namespace Application.User.Services
{
    public interface IUserService
    {
        Task<PagedList<BasicUserModel>> GetAllUsers(string? searchTerm, string? sortColumn, string? sortOrder, int page, int pageSize);
        Task<UserDTO> GetUserById(string id);
    }
}
