using Application.Auth.Commands;
using Application.Auth.DTOs;

namespace Application.Auth.Services
{
    public interface IRegisterService
    {
        Task<RegisterDTO> Register(RegisterCommand register);
    }
}
