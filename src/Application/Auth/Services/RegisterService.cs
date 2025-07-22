using Application.Auth.Commands;
using Application.Auth.DTOs;
using Domain.Exceptions;
using Domain.Repository;
using Domain.Services;
using Domain.Utilities;

namespace Application.Auth.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly IUtilities _utilities;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;

        public RegisterService(IUtilities utilities, IUserRepository userRepository, IPasswordService passwordService)
        {
            _utilities = utilities;
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        public async Task<RegisterDTO> Register(RegisterCommand register)
        {
            var userEmail = await _userRepository.GetUserByEmail(register.Email);

            if (userEmail != null)
            {
                throw new BusinessException($"Ya existe un usuario registrado con el email {register.Email}.");
            }

            var userPhone = await _userRepository.GetUserByPhone(register.PhoneNumber);

            if (userPhone != null)
            {
                throw new BusinessException($"Ya existe un usuario registrado con el teléfono {register.PhoneNumber}.");
            }

            string idUser = _utilities.GenerateId();
            int iterations = _passwordService.GetIterations(idUser);
            string salt = _passwordService.GenerateSalt();
            string hashedPassword = _passwordService.GenerateHash(register.Password, salt, iterations);

            bool userCreated = await _userRepository.CreateUser(
                idUser,
                register.FirstName,
                register.LastName,
                register.Gender,
                register.BirthDate,
                register.Email,
                register.PhoneNumber,
                idUser,
                hashedPassword,
                salt);

            return new RegisterDTO() { IdUser = idUser };
        }
    }
}
