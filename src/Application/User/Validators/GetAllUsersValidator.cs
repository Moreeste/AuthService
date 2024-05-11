using Application.User.Queries;
using FluentValidation;

namespace Application.User.Validators
{
    public class GetAllUsersValidator : AbstractValidator<GetAllUsersQuery>
    {
        public GetAllUsersValidator()
        {
            RuleFor(x => x.Page).GreaterThan(0).LessThanOrEqualTo(1000);
            RuleFor(x => x.PageSize).GreaterThan(0).LessThanOrEqualTo(100);
        }
    }
}
