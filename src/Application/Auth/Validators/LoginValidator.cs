using Application.Auth.Commands;
using FluentValidation;

namespace Application.Auth.Validators
{
    public class LoginValidator : AbstractValidator<LoginCommand>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).NotNull().NotEmpty().MaximumLength(100).EmailAddress();
            RuleFor(x => x.Password).NotNull().NotEmpty().MinimumLength(8).MaximumLength(32);
        }
    }
}
