using Application.Endpoint.Queries;
using Application.Validations;
using FluentValidation;

namespace Application.Endpoint.Validators
{
    public class GetEndpointByIdValidator : AbstractValidator<GetEndpointByIdQuery>
    {
        public GetEndpointByIdValidator(ICommonValidations commonValidations)
        {
            RuleFor(x => x.IdEndpoint).NotNull().NotEmpty().Length(36).Must(commonValidations.BeValidId);
        }
    }
}
