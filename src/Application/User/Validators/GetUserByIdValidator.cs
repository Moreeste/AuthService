using Application.User.Queries;
using Domain.Utilities;
using FluentValidation;

namespace Application.User.Validators
{
    public class GetUserByIdValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdValidator(IValidations validations)
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().Length(36).Must(validations.ValidateId);
        }
    }
}
