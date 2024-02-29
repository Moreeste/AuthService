using Application.Register.Commands;
using Domain.Utilities;
using FluentValidation;

namespace Application.Register.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterValidator(IValidations validations)
        {
            RuleFor(x => x.Email).NotNull().NotEmpty().MaximumLength(100).EmailAddress();
            RuleFor(x => x.PhoneNumber).NotNull().NotEmpty().Length(10).Must(validations.BeValidPhoneNumber);
            RuleFor(x => x.FirstName).NotNull().NotEmpty().MaximumLength(30).Must(validations.BeValidName);
            RuleFor(x => x.MiddleName).NotEmpty().MaximumLength(30).Must(validations.BeValidName);
            RuleFor(x => x.LastName).NotNull().NotEmpty().MaximumLength(30).Must(validations.BeValidName);
            RuleFor(x => x.SecondLastName).NotEmpty().MaximumLength(30).Must(validations.BeValidName);
            RuleFor(x => x.Gender).NotNull();
            RuleFor(x => x.BirthDate).NotNull().Must(validations.BeValidBirthDate);
            RuleFor(x => x.Password).NotNull().NotEmpty().MinimumLength(8).MaximumLength(32);
        }
    }
}
