using Application.UserProperties.Commands;
using Application.Validations;
using FluentValidation;

namespace Application.UserProperties.Validators
{
    public class UpdateUserStatusValidator : AbstractValidator<UpdateUserStatusCommand>
    {
        public UpdateUserStatusValidator(ICommonValidations commonValidations)
        {
            RuleFor(x => x.IdUser).NotNull().NotEmpty().Length(36).Must(commonValidations.BeValidId);
            RuleFor(x => x.IdStatus).NotNull().MustAsync(commonValidations.BeValidStatusId);
            RuleFor(x => x.UpdateUser).NotNull().NotEmpty().Length(36).Must(commonValidations.BeValidId);
        }
    }
}
