using Application.Auth.DTOs;
using Domain.Repository;

namespace Application.Auth.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordRepository _passwordRepository;

        public LoginService(IUserRepository userRepository, IPasswordRepository passwordRepository)
        {
            _userRepository = userRepository;
            _passwordRepository = passwordRepository;
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

            if (DateTime.Now > passwordInfo.ExpirationDate)
            {
                throw new Exception("Contraseña expirada, favor de cambiarla y volver a iniciar sesión.");
            }

            return null;
        }
    }
}
