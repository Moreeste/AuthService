using Application.User.Queries;
using Application.Validations;
using FluentValidation;

namespace Application.User.Validators
{
    public class GetAllUsersValidator : AbstractValidator<GetAllUsersQuery>
    {
        public GetAllUsersValidator(ICommonValidations commonValidations)
        {
            RuleFor(x => x.Page).NotEmpty().MaximumLength(4).Must(commonValidations.BeInteger);
            RuleFor(x => x.PageSize).NotEmpty().MaximumLength(3).Must(commonValidations.BeInteger);
        }
    }
}
