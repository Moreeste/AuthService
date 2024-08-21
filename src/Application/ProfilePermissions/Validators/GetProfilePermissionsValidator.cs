using Application.ProfilePermissions.Queries;
using FluentValidation;

namespace Application.ProfilePermissions.Validators
{
    public class GetProfilePermissionsValidator : AbstractValidator<GetProfilePermissionsQuery>
    {
        public GetProfilePermissionsValidator()
        {
            
        }
    }
}
