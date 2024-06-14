using Dapper;
using Domain.Exceptions;
using Domain.Model.Response;
using Domain.Model.User;
using Domain.Repository;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UserPropertiesRepository : IUserPropertiesRepository
    {
        private readonly AuthServiceContext _authServiceContext;

        public UserPropertiesRepository(AuthServiceContext authServiceContext)
        {
            _authServiceContext = authServiceContext;
        }

        public async Task<UserPropertiesModel?> GetUserProperties(string? idUser)
        {
            string qry = "EXECUTE sp_GetUserProperties @IdUser;";
            var parameters = new { IdUser = idUser };

            var result = await _authServiceContext.Database.GetDbConnection().QueryFirstOrDefaultAsync<UserPropertiesModel>(qry, parameters);

            return result;
        }

        public async Task<bool> UpdateUserProfile(string idUser, string idProfile, string updateUser)
        {
            string qry = "EXECUTE sp_UpdateUserPropertiesProfile @IdUser, @IdProfile, @UpdateUser;";
            var parameters = new
            {
                IdUser = idUser,
                IdProfile = idProfile,
                UpdateUser = updateUser
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

        public async Task<bool> UpdateUserStatus(string idUser, int idStatus, string updateUser)
        {
            string qry = "EXECUTE sp_UpdateUserPropertiesStatus @IdUser, @IdStatus, @UpdateUser;";
            var parameters = new
            {
                IdUser = idUser,
                IdStatus = idStatus,
                UpdateUser = updateUser
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
    }
}
