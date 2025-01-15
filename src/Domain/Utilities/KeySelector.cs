using Domain.Model.ProfilePermission;
using Domain.Model.User;
using System.Linq.Expressions;

namespace Domain.Utilities
{
    public static class KeySelector
    {
        public static Expression<Func<BasicUserModel, object>> GetBasicUserModelSortProperty(string? sortColumn)
        {
            return sortColumn?.ToLower() switch
            {
                "firstname" => user => user.FirstName ?? string.Empty,
                "lastname" => user => user.LastName ?? string.Empty,
                "birthdate" => user => user.BirthDate,
                _ => user => user.FirstName ?? string.Empty
            };
        }

        public static Expression<Func<ProfilePermissionModel, object>> GetProfilePermissionModelSortProperty(string? sortColumn)
        {
            return sortColumn?.ToLower() switch
            {
                "profile" => permission => permission.Profile ?? string.Empty,
                "endpoint" => permission => permission.Endpoint ?? string.Empty,
                _ => permission => permission.Profile ?? string.Empty
            };
        }
    }
}
