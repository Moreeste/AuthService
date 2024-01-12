using Dapper;
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
    }
}
