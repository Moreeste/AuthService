using Domain.Model.Password;

namespace Domain.Repository
{
    public interface IPasswordRepository
    {
        Task<PasswordModel?> GetPassword(string? idUser);
        Task<bool> SetFailedAttempt(string? idUser);
    }
}
