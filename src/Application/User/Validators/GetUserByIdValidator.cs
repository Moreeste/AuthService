using Application.User.Queries;
using Application.Validations;
using FluentValidation;

namespace Application.User.Validators
{
    public class GetUserByIdValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdValidator(ICommonValidations commonValidations)
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().Length(36).Must(commonValidations.BeValidId);
        }
    }
}
