using Application.Profile.Commands;
using Application.Validations;
using FluentValidation;

namespace Application.Profile.Validators
{
    public class CreateProfileValidator : AbstractValidator<CreateProfileCommand>
    {
        public CreateProfileValidator(ICommonValidations commonValidations)
        {
            RuleFor(x => x.Description).NotNull().NotEmpty().MinimumLength(2).MaximumLength(50).Must(commonValidations.BeOnlyLettersAndNumbers);
            RuleFor(x => x.RegistrationUser).NotNull().NotEmpty().Length(36).Must(commonValidations.BeValidId);
        }
    }
}
