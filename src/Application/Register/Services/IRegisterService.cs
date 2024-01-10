using Application.Register.Commands;
using Application.Register.DTOs;

namespace Application.Register.Services
{
    public interface IRegisterService
    {
        Task<RegisterDTO> Register(RegisterCommand register);
    }
}
