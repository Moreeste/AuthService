using Domain.Exceptions;
using Domain.Repository;
using Domain.Services;

namespace Application.Auth.Services
{
    public class ChangePasswordService : IChangePasswordService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordRepository _passwordRepository;
        private readonly IPasswordService _passwordService;

        public ChangePasswordService(IUserRepository userRepository, IPasswordRepository passwordRepository, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _passwordRepository = passwordRepository;
            _passwordService = passwordService;

        }

        public async Task<bool> ChangePassword(string idUser, string currentPassword, string newPassword)
        {
            if (currentPassword == newPassword)
            {
                throw new BusinessException("La nueva contraseña debe ser diferente a la actual.");
            }

            var user = await _userRepository.GetUserById(idUser);

            if (user == null)
            {
                throw new SearchException("No existe el usuario.");
            }

            var passwordInfo = await _passwordRepository.GetPassword(user.IdUser);

            if (passwordInfo == null)
            {
                throw new BusinessException("Usuario no cuenta con contraseña válida.");
            }

            int iterations = _passwordService.GetIterations(user.IdUser);
            string hashedPassword = _passwordService.GenerateHash(currentPassword, passwordInfo.Salt, iterations);

            if (passwordInfo.Password != hashedPassword)
            {
                throw new BusinessException("Contraseña actual incorrecta.");
            }

            string newSalt = _passwordService.GenerateSalt();
            string newHashedPassword = _passwordService.GenerateHash(newPassword, newSalt, iterations);

            bool saved = await _passwordRepository.ChangePassword(idUser, newHashedPassword, newSalt);

            return saved;
        }
    }
}
