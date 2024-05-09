using Application.Auth.DTOs;
using Domain.Exceptions;
using Domain.Repository;
using Domain.Services;
using Domain.Utilities;

namespace Application.Auth.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUtilities _utilities;
        private readonly IUserRepository _userRepository;
        private readonly IUserPropertiesRepository _userPropertiesRepository;
        private readonly IPasswordRepository _passwordRepository;
        private readonly IPasswordService _passwordService;
        private readonly ITokenService _tokenService;

        public LoginService(IUtilities utilities, IUserRepository userRepository, IUserPropertiesRepository userPropertiesRepository, IPasswordRepository passwordRepository, IPasswordService passwordService, ITokenService tokenService)
        {
            _utilities = utilities;
            _userRepository = userRepository;
            _userPropertiesRepository = userPropertiesRepository;
            _passwordRepository = passwordRepository;
            _passwordService = passwordService;
            _tokenService = tokenService;
        }

        public async Task<LoginDTO> Login(string email, string password)
        {
            var user = await _userRepository.GetUserByEmail(email);

            if (user == null)
            {
                throw new SearchException("No existe el usuario.");
            }

            var userProperties = await _userPropertiesRepository.GetUserProperties(user.IdUser);
            
            if (userProperties == null)
            {
                throw new SearchException("No existen propiedades para el usuario.");
            }

            if (userProperties.Status == 2)
            {
                throw new BusinessException("Usuario inactivo.");
            }

            if (userProperties.Status == 3)
            {
                throw new BusinessException("Usuario bloqueado.");
            }

            var passwordInfo = await _passwordRepository.GetPassword(user.IdUser);

            if (passwordInfo == null)
            {
                throw new BusinessException("Usuario no cuenta con contraseña válida.");
            }

            var date = _utilities.GetDateTime();

            if (date > passwordInfo.ExpirationDate)
            {
                throw new BusinessException("Contraseña expirada, favor de cambiarla y volver a iniciar sesión.");
            }

            int iterations = _passwordService.GetIterations(user.IdUser);
            string hashedPassword = _passwordService.GenerateHash(password, passwordInfo.Salt, iterations);

            if (passwordInfo.Password != hashedPassword)
            {
                throw new BusinessException("Contraseña incorrecta.");
            }

            var jwt = _tokenService.GenerateToken(user);

            return new LoginDTO()
            {
                Token = jwt.Token,
                Expiration = jwt.Expiration
            };
        }
    }
}
