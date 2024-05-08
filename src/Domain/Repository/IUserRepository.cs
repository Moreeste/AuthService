using Domain.Model.Response;
using Domain.Model.User;
using System;

namespace Domain.Repository
{
    public interface IUserRepository
    {
        Task<bool> CreateUser(string idUser, string firstName, string? middleName, string lastName, string? secondLastName, int gender, DateTime birthDate, string email, string phoneNumber, string registrationUser, string password, string salt);
        Task<IEnumerable<UserModel>> GetUsers();
        Task<UserModel?> GetUserById(string id);
        Task<UserModel?> GetUserByEmail(string email);
        Task<UserModel?> GetUserByPhone(string phone);
        Task<bool> BlockUser(string? idUser);
    }
}
