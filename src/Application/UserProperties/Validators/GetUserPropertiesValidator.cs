using Application.UserProperties.Queries;
using Application.Validations;
using FluentValidation;

namespace Application.UserProperties.Validators
{
    public class GetUserPropertiesValidator : AbstractValidator<GetUserPropertiesQuery>
    {
        public GetUserPropertiesValidator(ICommonValidations commonValidations)
        {
            RuleFor(x => x.IdUser).NotNull().NotEmpty().Length(36).Must(commonValidations.BeValidId);
        }
    }
}
