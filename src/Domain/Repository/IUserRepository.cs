﻿using Domain.Model.User;

namespace Domain.Repository
{
    public interface IUserRepository
    {
        Task<bool> CreateUser(string idUser, string firstName, string lastName, int gender, string birthDate, string email, string phoneNumber, string registrationUser, string password, string salt);
        Task<IEnumerable<BasicUserModel>> GetUsers();
        Task<UserModel?> GetUserById(string id);
        Task<UserModel?> GetUserByEmail(string email);
        Task<UserModel?> GetUserByPhone(string phone);
        Task<bool> BlockUser(string? idUser);
    }
}
