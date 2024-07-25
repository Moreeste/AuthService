using Application.Endpoint.Commands;
using Application.Validations;
using FluentValidation;

namespace Application.Endpoint.Validators
{
    public class CreateEndpointValidator : AbstractValidator<RegisterEndpointCommand>
    {
        public CreateEndpointValidator(ICommonValidations commonValidations)
        {
            RuleFor(x => x.IdUser).NotNull().NotEmpty().Length(36).Must(commonValidations.BeValidId);
            RuleFor(x => x.Path).NotNull().NotEmpty().MaximumLength(100).Must(commonValidations.BeValidEndpoint);
        }
    }
}
