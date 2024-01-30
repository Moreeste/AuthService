using Application.Login.DTOs;

namespace Application.Login.Services
{
    public interface ILoginService
    {
        Task<LoginDTO> Login(string email, string password);
    }
}
