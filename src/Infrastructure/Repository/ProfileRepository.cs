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

        public async Task<bool> CreateProfile(string idProfile, string? description, string? registrationUser)
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

        public async Task<Profile?> GetProfileByName(string? profileName)
        {
            string qry = "EXECUTE sp_GetProfileByName @Description;";
            var parameters = new
            {
                Description = profileName
            };

            var result = await _authServiceContext.Database.GetDbConnection().QueryFirstOrDefaultAsync<Profile>(qry, parameters);

            return result;
        }

        public async Task<Profile?> GetProfileById(string? idProfile)
        {
            string qry = "EXECUTE sp_GetProfileById @IdProfile;";
            var parameters = new
            {
                IdProfile = idProfile
            };

            var result = await _authServiceContext.Database.GetDbConnection().QueryFirstOrDefaultAsync<Profile>(qry, parameters);

            return result;
        }
    }
}
