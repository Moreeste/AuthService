using Application.Auth.Commands;
using Application.Validations;
using FluentValidation;

namespace Application.Auth.Validators
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordValidator(ICommonValidations commonValidations)
        {
            RuleFor(x => x.IdUser).NotNull().NotEmpty().Length(36).Must(commonValidations.BeValidId);
            RuleFor(x => x.CurrentPassword).MustBeValidPassword();
            RuleFor(x => x.NewPassword).MustBeValidPassword();
        }
    }
}
