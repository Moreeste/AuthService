using Dapper;
using Domain.Exceptions;
using Domain.Model.ProfilePermission;
using Domain.Model.Response;
using Domain.Repository;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ProfilePermissionRepository : IProfilePermissionRepository
    {
        private readonly AuthServiceContext _authServiceContext;

        public ProfilePermissionRepository(AuthServiceContext authServiceContext)
        {
            _authServiceContext = authServiceContext;
        }

        public async Task<IEnumerable<ProfilePermissionModel>?> GetProfilePermissions()
        {
            string qry = "EXECUTE sp_GetProfilePermissions;";
            
            var result = await _authServiceContext.Database.GetDbConnection().QueryAsync<ProfilePermissionModel>(qry);

            return result;
        }

        public async Task<ProfilePermissionModel?> GetProfilePermission(string? idProfile, string? idEndpoint)
        {
            string qry = "EXECUTE sp_GetProfilePermission @IdProfile, @IdEndpoint;";
            var parameters = new
            {
                IdProfile = idProfile,
                IdEndpoint = idEndpoint
            };

            var result = await _authServiceContext.Database.GetDbConnection().QueryFirstOrDefaultAsync<ProfilePermissionModel>(qry, parameters);

            return result;
        }

        public async Task<ProfilePermissionModel?> GetProfilePermissionById(string idPermission)
        {
            string qry = "EXECUTE sp_GetProfilePermissionById @IdPermission;";
            var parameters = new
            {
                IdPermission = idPermission
            };

            var result = await _authServiceContext.Database.GetDbConnection().QueryFirstOrDefaultAsync<ProfilePermissionModel>(qry, parameters);

            return result;
        }

        public async Task<IEnumerable<ProfilePermissionModel>?> GetProfilePermissionsByIdProfile(string? idProfile)
        {
            string qry = "EXECUTE sp_GetProfilePermissionsByIdProfile @IdProfile;";
            var parameters = new
            {
                IdProfile = idProfile
            };

            var result = await _authServiceContext.Database.GetDbConnection().QueryAsync<ProfilePermissionModel>(qry, parameters);

            return result;
        }

        public async Task<IEnumerable<ProfilePermissionModel>?> GetProfilePermissionsByIdEndpoint(string idEndpoint)
        {
            string qry = "EXECUTE sp_GetProfilePermissionsByIdEndpoint @IdEndpoint;";
            var parameters = new
            {
                IdEndpoint = idEndpoint
            };

            var result = await _authServiceContext.Database.GetDbConnection().QueryAsync<ProfilePermissionModel>(qry, parameters);

            return result;
        }

        public async Task<bool> RegisterProfilePermission(string idPermission, string? idProfile, string? idEndpoint, string registrationUser)
        {
            string qry = "EXECUTE sp_RegisterProfilePermission @IdPermission, @IdProfile, @IdEndpoint, @RegistrationUser;";
            var parameters = new
            {
                IdPermission = idPermission,
                IdProfile = idProfile,
                IdEndpoint = idEndpoint,
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

        public async Task<bool> UpdateProfilePermission(string idPermission, bool active, string updateUser)
        {
            string qry = "EXECUTE sp_UpdateProfilePermission @IdPermission, @Active, @UpdateUser;";
            var parameters = new
            {
                IdPermission = idPermission,
                Active = active,
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
