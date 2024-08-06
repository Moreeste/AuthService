using Application.Endpoint.Queries;
using Application.Validations;
using FluentValidation;

namespace Application.Endpoint.Validators
{
    public class GetEndpointsValidator : AbstractValidator<GetEndpointsQuery>
    {
        public GetEndpointsValidator(ICommonValidations commonValidations)
        {
            RuleFor(x => x.Path).MaximumLength(100).Must(commonValidations.BeTextAndSlash);
            RuleFor(x => x.Method).MaximumLength(10).Must(commonValidations.BeAValidHttpMethod);
            RuleFor(x => x.Page).NotEmpty().MaximumLength(4).Must(commonValidations.BeValidPositiveInteger)
                .Must(text => commonValidations.BeTextNumberWithinRange(text, 1, 1000));
            RuleFor(x => x.PageSize).NotEmpty().MaximumLength(3).Must(commonValidations.BeValidPositiveInteger)
                .Must(text => commonValidations.BeTextNumberWithinRange(text, 1, 100));
        }
    }
}
