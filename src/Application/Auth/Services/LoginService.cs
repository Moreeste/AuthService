using Application.Auth.DTOs;
using Domain.Repository;

namespace Application.Auth.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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

            return null;
        }
    }
}
