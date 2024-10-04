using Application.ProfilePermissions.Commands;
using Application.Validations;
using FluentValidation;

namespace Application.ProfilePermissions.Validators
{
    public class RegisterPermissionValidator : AbstractValidator<RegisterPermissionCommand>
    {
        public RegisterPermissionValidator(ICommonValidations commonValidations)
        {
            RuleFor(x => x.IdProfile).NotNull().NotEmpty().Length(36).Must(commonValidations.BeValidId);
            RuleFor(x => x.IdEndpoint).NotNull().NotEmpty().Length(36).Must(commonValidations.BeValidId);
            RuleFor(x => x.RegistrationUser).NotNull().NotEmpty().Length(36).Must(commonValidations.BeValidId);
        }
    }
}
