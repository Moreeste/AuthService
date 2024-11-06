using Domain.Model.ProfilePermission;

namespace Domain.Repository
{
    public interface IProfilePermissionRepository
    {
        Task<ProfilePermissionModel?> GetProfilePermission(string? idProfile, string? idEndpoint);
        Task<ProfilePermissionModel?> GetProfilePermissionById(string idPermission);
        Task<IEnumerable<ProfilePermissionModel>?> GetProfilePermissionsByIdProfile(string? idProfile);
        Task<IEnumerable<ProfilePermissionModel>?> GetProfilePermissionsByIdEndpoint(string idEndpoint);
        Task<bool> RegisterProfilePermission(string idPermission, string? idProfile, string? idEndpoint, string registrationUser);
        Task<bool> UpdateProfilePermission(string idPermission, bool active, string updateUser);
    }
}
