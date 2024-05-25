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
    }
}
