using Application.Register.Commands;
using Application.Register.DTOs;
using Domain.Repository;

namespace Application.Register.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly IUserRepository _userRepository;

        public RegisterService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<RegisterDTO> Register(RegisterCommand register)
        {
            var userEmail = _userRepository.GetUserByEmail(register.Email);

            if (userEmail != null)
            {
                throw new Exception($"Ya existe un usuario registrado con el email {register.Email}.");
            }

            var userPhone = _userRepository.GetUserByPhone(register.PhoneNumber);

            if (userPhone != null)
            {
                throw new Exception($"Ya existe un usuario registrado con el teléfono {register.PhoneNumber}.");
            }

            return new RegisterDTO() { IdUser = "000000000" };
        }
    }
}
