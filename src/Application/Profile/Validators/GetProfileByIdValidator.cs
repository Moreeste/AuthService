using Application.Profile.Queries;
using Application.Validations;
using FluentValidation;

namespace Application.User.Validators
{
    public class CreateProfileValidator : AbstractValidator<GetProfileByIdQuery>
    {
        public CreateProfileValidator(ICommonValidations commonValidations)
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().Length(36).Must(commonValidations.BeValidId);
        }
    }
}
