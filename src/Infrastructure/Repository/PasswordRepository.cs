using Dapper;
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

        public async Task<bool> SetFailedAttempt(string? idUser)
        {
            string qry = "EXECUTE sp_SetFailedAttempt @IdUser;";
            var parameters = new { IdUser = idUser };

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
