using Domain.Model.ProfilePermission;
using Domain.Repository;
using Infrastructure.Database;

namespace Infrastructure.Repository
{
    public class ProfilePermissionRepository : IProfilePermissionRepository
    {
        private readonly AuthServiceContext _authServiceContext;

        public ProfilePermissionRepository(AuthServiceContext authServiceContext)
        {
            _authServiceContext = authServiceContext;
        }

        public async Task<ProfilePermissionModel> GetProfilePermission(string idProfile, string idEndpoint)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProfilePermissionModel>> GetProfilePermissionsByIdProfile(string idProfile)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProfilePermissionModel>> GetProfilePermissionsByIdEndpoint(string idEndpoint)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterProfilePermission(string idPermission, string idProfile, string idEndpoint, string registrationUser)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateProfilePermission(string idPermission, bool active, string updateUser)
        {
            throw new NotImplementedException();
        }
    }
}
