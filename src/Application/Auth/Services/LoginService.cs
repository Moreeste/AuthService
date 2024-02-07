using Application.Auth.DTOs;
using Domain.Repository;
using Domain.Services;
using Domain.Utilities;

namespace Application.Auth.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUtilities _utilities;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordRepository _passwordRepository;
        private readonly IPasswordService _passwordService;

        public LoginService(IUtilities utilities, IUserRepository userRepository, IPasswordRepository passwordRepository, IPasswordService passwordService)
        {
            _utilities = utilities;
            _userRepository = userRepository;
            _passwordRepository = passwordRepository;
            _passwordService = passwordService;
        }

        public async Task<LoginDTO> Login(string email, string password)
        {
            var user = await _userRepository.GetUserByEmail(email);

            if (user == null)
            {
                throw new Exception("No existe el usuario.");
            }

            if (user.Status == 2)
            {
                throw new Exception("Usuario inactivo.");
            }

            if (user.Status == 3)
            {
                throw new Exception("Usuario bloqueado.");
            }

            var passwordInfo = await _passwordRepository.GetPassword(user.IdUser);

            if (passwordInfo == null)
            {
                throw new Exception("Usuario no cuenta con contraseña válida.");
            }

            var date = _utilities.GetDateTime();
            if (date > passwordInfo.ExpirationDate)
            {
                throw new Exception("Contraseña expirada, favor de cambiarla y volver a iniciar sesión.");
            }

            int iterations = _passwordService.GetIterations(user.IdUser);
            string hashedPassword = _passwordService.GenerateHash(password, passwordInfo.Salt, iterations);

            if (passwordInfo.Password != hashedPassword)
            {
                throw new Exception("Contraseña incorrecta.");
            }

            return null;
        }
    }
}
