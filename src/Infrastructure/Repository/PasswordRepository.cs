using Dapper;
using Domain.Exceptions;
using Domain.Model.Password;
using Domain.Model.Response;
using Domain.Repository;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class PasswordRepository : IPasswordRepository
    {
        private readonly AuthServiceContext _authServiceContext;

        public PasswordRepository(AuthServiceContext authServiceContext)
        {
            _authServiceContext = authServiceContext;
        }

        public async Task<PasswordModel?> GetPassword(string? idUser)
        {
            string qry = "EXECUTE sp_GetPassword @IdUser;";
            var parameters = new { IdUser = idUser };

            var result = await _authServiceContext.Database.GetDbConnection().QueryFirstOrDefaultAsync<PasswordModel>(qry, parameters);

            return result;
        }

        public async Task<bool> SavePassword(string? idUser, string? password, string? salt)
        {
            string qry = "EXECUTE sp_SavePassword @IdUser, @Password, @Salt;";
            var parameters = new 
            { 
                IdUser = idUser,
                Password = password,
                Salt = salt
            };

            var result = await _authServiceContext.Database.GetDbConnection().QueryFirstOrDefaultAsync<DbResponse>(qry, parameters);

            if (result == null)
            {
                throw new DataBaseException(qry, parameters);
            }

            if (!result.Success)
            {
                throw new DataBaseException(qry, parameters, result.ErrorMessage);
            }

            return true;
        }

        public async Task<bool> SetFailedAttempt(string? idUser)
        {
            string qry = "EXECUTE sp_SetFailedAttempt @IdUser;";
            var parameters = new { IdUser = idUser };

            var result = await _authServiceContext.Database.GetDbConnection().QueryFirstOrDefaultAsync<DbResponse>(qry, parameters);

            if (result == null)
            {
                throw new DataBaseException(qry, parameters);
            }

            if (!result.Success)
            {
                throw new DataBaseException(qry, parameters, result.ErrorMessage);
            }

            return true;
        }

        public async Task<bool> ResetFailedAttempts(string? idUser)
        {
            string qry = "EXECUTE sp_ResetFailedAttempts @IdUser;";
            var parameters = new { IdUser = idUser };

            var result = await _authServiceContext.Database.GetDbConnection().QueryFirstOrDefaultAsync<DbResponse>(qry, parameters);

            if (result == null)
            {
                throw new DataBaseException(qry, parameters);
            }

            if (!result.Success)
            {
                throw new DataBaseException(qry, parameters, result.ErrorMessage);
            }

            return true;
        }
    }
}
