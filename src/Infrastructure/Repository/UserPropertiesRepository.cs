using Dapper;
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
    }
}
