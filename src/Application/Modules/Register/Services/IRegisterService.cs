using Application.Modules.Register.Commands;
using Application.Modules.Register.DTOs;

namespace Application.Modules.Register.Services
{
    public interface IRegisterService
    {
        Task<RegisterDTO> Register(RegisterCommand register);
    }
}
