using Application.Auth.Services;
using Application.Register.Commands;
using Application.Register.DTOs;
using Domain.Repository;

namespace Application.Register.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;

        public RegisterService(IUserRepository userRepository, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        public async Task<RegisterDTO> Register(RegisterCommand register)
        {
            var userEmail = await _userRepository.GetUserByEmail(register.Email);

            if (userEmail != null)
            {
                throw new Exception($"Ya existe un usuario registrado con el email {register.Email}.");
            }

            var userPhone = await _userRepository.GetUserByPhone(register.PhoneNumber);

            if (userPhone != null)
            {
                throw new Exception($"Ya existe un usuario registrado con el teléfono {register.PhoneNumber}.");
            }

            int iterations = _passwordService.GetIterations("E2C76764-1050-4301-906E-EBFDBB54C9E1");
            byte[] salt = _passwordService.GenerateSalt();
            string hashedPassword = _passwordService.GenerateHash(register.Password, salt, iterations);

            return new RegisterDTO() { IdUser = hashedPassword };
        }
    }
}
