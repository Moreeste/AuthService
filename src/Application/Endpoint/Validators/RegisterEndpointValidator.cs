using Application.Endpoint.Commands;
using Application.Validations;
using FluentValidation;

namespace Application.Endpoint.Validators
{
    public class RegisterEndpointValidator : AbstractValidator<RegisterEndpointCommand>
    {
        public RegisterEndpointValidator(ICommonValidations commonValidations)
        {
            RuleFor(x => x.IdUser).NotNull().NotEmpty().Length(36).Must(commonValidations.BeValidId);
            RuleFor(x => x.Path).NotNull().NotEmpty().MaximumLength(100).Must(commonValidations.BeValidEndpoint);
            RuleFor(x => x.Method).NotNull().NotEmpty().MaximumLength(10).Must(commonValidations.BeValidHttpMethod);
        }
    }
}
