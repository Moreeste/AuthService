using Application.Profile.Queries;
using Application.Validations;
using FluentValidation;

namespace Application.Profile.Validators
{
    public class GetMyProfileValidator : AbstractValidator<GetMyProfileQuery>
    {
        public GetMyProfileValidator(ICommonValidations commonValidations)
        {
            RuleFor(x => x.IdUser).NotNull().NotEmpty().Length(36).Must(commonValidations.BeValidId);
        }
    }
}
