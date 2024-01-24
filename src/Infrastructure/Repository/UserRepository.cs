﻿using Dapper;
using Domain.Model.Response;
using Domain.Model.User;
using Domain.Repository;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthServiceContext _authServiceContext;
        
        public UserRepository(AuthServiceContext authServiceContext)
        {
            _authServiceContext = authServiceContext;
        }

        public string GetId()
        {
            return Guid.NewGuid().ToString().ToUpper();
        }
        
        public async Task<UserModel?> GetUserById(string id)
        {
            string qry = "EXECUTE sp_GetUserById @IdUser";
            var parameters = new { IdUser = id };

            var result = await _authServiceContext.Database.GetDbConnection().QueryFirstOrDefaultAsync<UserModel>(qry, parameters);
            
            return result;
        }

        public async Task<UserModel?> GetUserByEmail(string email)
        {
            string qry = "EXECUTE sp_GetUserByEmail @Email";
            var parameters = new { Email = email };

            var result = await _authServiceContext.Database.GetDbConnection().QueryFirstOrDefaultAsync<UserModel>(qry, parameters);

            return result;
        }

        public async Task<UserModel?> GetUserByPhone(string phone)
        {
            string qry = "EXECUTE sp_GetUserByPhone @Phone";
            var parameters = new { Phone = phone };

            var result = await _authServiceContext.Database.GetDbConnection().QueryFirstOrDefaultAsync<UserModel>(qry, parameters);

            return result;
        }

        public async Task<bool> CreateUser(string idUser, string firstName, string middleName, string lastName, string secondLastName, int gender, DateTime birthDate, string email, string phoneNumber, string registrationUser, string password, string salt)
        {
            string qry = "EXECUTE sp_CreateUser @IdUser, @FirstName, @MiddleName, @LastName, @SecondLastName, @Gender, @BirthDate, @Email, @PhoneNumber, @RegistrationUser, @Password, @Salt";
            var parameters = new 
            {
                IdUser = idUser,
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                SecondLastName = secondLastName,
                Gender = gender,
                BirthDate = birthDate,
                Email = email,
                PhoneNumber = phoneNumber,
                RegistrationUser = registrationUser,
                Password = password,
                Salt = salt
            };

            var result = await _authServiceContext.Database.GetDbConnection().QueryFirstOrDefaultAsync<DbResponse>(qry, parameters);

            if (result == null)
            {
                throw new Exception("Ocurrió un error en la db");
            }

            if (!result.Success)
            {
                throw new Exception($"Error en db: {result.ErrorMessage}");
            }

            return true;
        }
    }
}
