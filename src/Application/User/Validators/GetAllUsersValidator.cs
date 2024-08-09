using Application.User.Queries;
using Application.Validations;
using FluentValidation;

namespace Application.User.Validators
{
    public class GetAllUsersValidator : AbstractValidator<GetAllUsersQuery>
    {
        public GetAllUsersValidator(ICommonValidations commonValidations)
        {
            RuleFor(x => x.idProfile).MaximumLength(36);
            RuleFor(x => x.SearchTerm).MaximumLength(20);
            RuleFor(x => x.SortColumn).MaximumLength(10);
            RuleFor(x => x.SortOrder).MaximumLength(4);
            RuleFor(x => x.Page).NotEmpty().MaximumLength(4).Must(commonValidations.BePositiveInteger)
                .Must(text => commonValidations.BeTextNumberWithinRange(text, 1, 1000));
            RuleFor(x => x.PageSize).NotEmpty().MaximumLength(3).Must(commonValidations.BePositiveInteger)
                .Must(text => commonValidations.BeTextNumberWithinRange(text, 1, 100));
        }
    }
}
