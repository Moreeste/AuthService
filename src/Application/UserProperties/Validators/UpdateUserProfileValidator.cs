using Application.UserProperties.Commands;
using Application.Validations;
using FluentValidation;

namespace Application.UserProperties.Validators
{
    public class UpdateUserProfileValidator : AbstractValidator<UpdateUserProfileCommand>
    {
        public UpdateUserProfileValidator(ICommonValidations commonValidations)
        {
            RuleFor(x => x.IdUser).NotNull().NotEmpty().Length(36).Must(commonValidations.BeValidId);
            RuleFor(x => x.IdProfile).NotNull().NotEmpty().Length(36).Must(commonValidations.BeValidId);
            RuleFor(x => x.UpdateUser).NotNull().NotEmpty().Length(36).Must(commonValidations.BeValidId);
        }
    }
}
