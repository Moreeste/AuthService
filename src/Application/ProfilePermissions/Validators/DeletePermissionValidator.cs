using Application.ProfilePermissions.Commands;
using Application.Validations;
using FluentValidation;

namespace Application.ProfilePermissions.Validators
{
    public class DeletePermissionValidator : AbstractValidator<DeletePermissionCommand>
    {
        public DeletePermissionValidator(ICommonValidations commonValidations)
        {
            RuleFor(x => x.IdPermission).NotNull().NotEmpty().Length(36).Must(commonValidations.BeValidId);
            RuleFor(x => x.UpdaterUser).NotNull().NotEmpty().Length(36).Must(commonValidations.BeValidId);
        }
    }
}
