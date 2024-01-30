using Application.Auth.DTOs;

namespace Application.Auth.Services
{
    public interface ILoginService
    {
        Task<LoginDTO> Login(string email, string password);
    }
}
