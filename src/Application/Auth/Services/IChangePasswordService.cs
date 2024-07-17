namespace Application.Auth.Services
{
    public interface IChangePasswordService
    {
        Task<bool> ChangePassword(string idUser, string currentPassword, string newPassword);
    }
}
