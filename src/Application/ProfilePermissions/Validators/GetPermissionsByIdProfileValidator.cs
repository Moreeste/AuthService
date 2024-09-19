using Application.ProfilePermissions.Queries;
using Application.Validations;
using FluentValidation;

namespace Application.ProfilePermissions.Validators
{
    public class GetPermissionsByIdProfileValidator : AbstractValidator<GetPermissionsByIdProfileQuery>
    {
        public GetPermissionsByIdProfileValidator(ICommonValidations commonValidations)
        {
            RuleFor(x => x.IdProfile).NotNull().NotEmpty().Length(36).Must(commonValidations.BeValidId);
        }
    }
}
