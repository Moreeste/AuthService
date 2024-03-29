using Dapper;
using Domain.Exceptions;
using Domain.Model.Response;
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

        public async Task<bool> CreateProfile(string idProfile, string description, string registrationUser)
        {
            string qry = "EXECUTE sp_CreateProfile @IdProfile, @Description, @RegistrationUser;";
            var parameters = new
            {
                IdProfile = idProfile,
                Description = description,
                RegistrationUser = registrationUser
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
