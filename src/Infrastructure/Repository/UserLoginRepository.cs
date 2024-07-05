using Dapper;
using Domain.Exceptions;
using Domain.Model.Response;
using Domain.Model.Token;
using Domain.Repository;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace Infrastructure.Repository
{
    public class UserLoginRepository : IUserLoginRepository
    {
        private readonly AuthServiceContext _authServiceContext;

        public UserLoginRepository(AuthServiceContext authServiceContext)
        {
            _authServiceContext = authServiceContext;
        }

        public async Task<bool> RegisterLogin(string? idUser, DateTime loginDate, string? token, DateTime tokenExpiration, string? refreshToken, DateTime refreshTokenExpiration, bool refreshed, string? refreshedBy)
        {
            string qry = "EXECUTE sp_RegisterLogin @IdUser, @LoginDate, @Token, @TokenExpiration, @RefreshToken, @RefreshTokenExpiration, @Refreshed, @RefreshedBy;";
            var parameters = new
            {
                IdUser = idUser,
                LoginDate = loginDate,
                Token = token,
                TokenExpiration = tokenExpiration,
                RefreshToken = refreshToken,
                RefreshTokenExpiration = refreshTokenExpiration,
                Refreshed = refreshed,
                RefreshedBy = refreshedBy
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

        public async Task<TokenModel?> GetLogin(string? idUser, string? token, string? refreshToken)
        {
            string qry = "EXECUTE sp_GetLogin @IdUser, @Token, @RefreshToken;";
            var parameters = new
            {
                IdUser = idUser,
                Token = token,
                RefreshToken = refreshToken
            };

            var result = await _authServiceContext.Database.GetDbConnection().QueryFirstOrDefaultAsync<TokenModel>(qry, parameters);

            return result;
        }
    }
}
