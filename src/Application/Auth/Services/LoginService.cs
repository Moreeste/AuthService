using Application.Auth.DTOs;
using Domain.Enums;
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
        private readonly IUserLoginRepository _userLoginRepository;

        public LoginService(IUtilities utilities, IUserRepository userRepository, IUserPropertiesRepository userPropertiesRepository, IPasswordRepository passwordRepository, IPasswordService passwordService, ITokenService tokenService, IUserLoginRepository userLoginRepository)
        {
            _utilities = utilities;
            _userRepository = userRepository;
            _userPropertiesRepository = userPropertiesRepository;
            _passwordRepository = passwordRepository;
            _passwordService = passwordService;
            _tokenService = tokenService;
            _userLoginRepository = userLoginRepository;
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

            if (userProperties.Status == (int)UserStatus.Inactive)
            {
                throw new BusinessException("Usuario inactivo.");
            }

            if (userProperties.Status == (int)UserStatus.Blocked)
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
            
            await _userLoginRepository.RegisterLogin(user.IdUser, jwt.Creation, jwt.Token, jwt.TokenExpiration, jwt.RefreshToken, jwt.RefreshTokenExpiration, false, null);

            return new LoginDTO()
            {
                Token = jwt.Token,
                TokenExpiration = jwt.TokenExpiration,
                RefreshToken = jwt.RefreshToken,
                RefreshTokenExpiration = jwt.RefreshTokenExpiration
            };
        }

        public async Task<LoginDTO> RefreshToken(string expiredToken, string refreshToken)
        {
            var idUser = _tokenService.GetIdUser(expiredToken);

            if (string.IsNullOrEmpty(idUser))
            {
                throw new BusinessException("El token no contiene un usuario válido.");
            }

            var user = await _userRepository.GetUserById(idUser);

            if (user == null)
            {
                throw new SearchException("No existe el usuario.");
            }

            var login = await _userLoginRepository.GetLogin(idUser, expiredToken, refreshToken);

            if (login == null)
            {
                throw new SearchException("No se encontró login.");
            }

            var jwt = _tokenService.GenerateToken(user);

            await _userLoginRepository.RegisterLogin(user.IdUser, jwt.Creation, jwt.Token, jwt.TokenExpiration, jwt.RefreshToken, jwt.RefreshTokenExpiration, true, refreshToken);

            return new LoginDTO()
            {
                Token = jwt.Token,
                TokenExpiration = jwt.TokenExpiration,
                RefreshToken = jwt.RefreshToken,
                RefreshTokenExpiration = jwt.RefreshTokenExpiration
            };
        }
    }
}
