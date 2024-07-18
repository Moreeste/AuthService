using Domain.Model.Password;

namespace Domain.Repository
{
    public interface IPasswordRepository
    {
        Task<PasswordModel?> GetPassword(string? idUser);
        Task<bool> SavePassword(string? idUser, string? password, string? salt);
        Task<bool> SetFailedAttempt(string? idUser);
        Task<bool> ResetFailedAttempts(string? idUser);
    }
}
