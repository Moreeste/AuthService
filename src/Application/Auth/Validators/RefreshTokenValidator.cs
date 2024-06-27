using Application.Auth.Commands;
using Application.Validations;
using FluentValidation;

namespace Application.Auth.Validators
{
    public class RefreshTokenValidator : AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenValidator(ICommonValidations commonValidations)
        {
            RuleFor(x => x.ExpiredToken).NotNull().NotEmpty().MaximumLength(500).Must(commonValidations.BeAValidJwt);
            RuleFor(x => x.RefreshToken).NotNull().NotEmpty().MaximumLength(200).Must(commonValidations.BeAValidBase64String);
        }
    }
}
