using Application.Auth.Commands;
using Application.Validations;
using FluentValidation;

namespace Application.Auth.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterValidator(ICommonValidations commonValidations)
        {
            RuleFor(x => x.Email).NotNull().NotEmpty().MaximumLength(100).EmailAddress();
            RuleFor(x => x.PhoneNumber).NotNull().NotEmpty().Length(10).Must(commonValidations.BeValidPhoneNumber);
            RuleFor(x => x.FirstName).NotNull().NotEmpty().MaximumLength(30).Must(commonValidations.BeRequiredName);
            RuleFor(x => x.MiddleName).MaximumLength(30).Must(commonValidations.BeOptionalName);
            RuleFor(x => x.LastName).NotNull().NotEmpty().MaximumLength(30).Must(commonValidations.BeRequiredName);
            RuleFor(x => x.SecondLastName).MaximumLength(30).Must(commonValidations.BeOptionalName);
            RuleFor(x => x.Gender).NotNull().MustAsync(commonValidations.BeValidGenderId);
            RuleFor(x => x.BirthDate).NotNull().Must(commonValidations.BeValidBirthDate);
            RuleFor(x => x.Password).MustBeValidPassword();
        }
    }
}
