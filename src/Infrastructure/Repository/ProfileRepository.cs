using Dapper;
using Domain.Model.User;
using Domain.Repository;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly AuthServiceContext _authServiceContext;

        public ProfileRepository(AuthServiceContext authServiceContext)
        {
            _authServiceContext = authServiceContext;
        }

        public async Task<IEnumerable<Profile>?> GetProfiles()
        {
            string qry = "EXECUTE sp_GetProfiles;";

            var result = await _authServiceContext.Database.GetDbConnection().QueryAsync<Profile>(qry);

            return result;
        }
    }
}
