using Dapper;
using Domain.Model.User;
using Domain.Repository;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class CatalogueRepository : ICatalogueRepository
    {
        private readonly AuthServiceContext _authServiceContext;

        public CatalogueRepository(AuthServiceContext authServiceContext)
        {
            _authServiceContext = authServiceContext;
        }

        public async Task<IEnumerable<Gender>> GetGenders()
        {
            string qry = "EXECUTE sp_GetGenders;";

            var result = await _authServiceContext.Database.GetDbConnection().QueryAsync<Gender>(qry);

            return result;
        }

        public async Task<IEnumerable<UserStatus>> GetUserStatus()
        {
            string qry = "EXECUTE sp_GetUserStatus;";

            var result = await _authServiceContext.Database.GetDbConnection().QueryAsync<UserStatus>(qry);

            return result;
        }
    }
}
