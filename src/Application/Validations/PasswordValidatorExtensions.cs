using FluentValidation;

namespace Application.Validations
{
    public static class PasswordValidatorExtensions
    {
        public static IRuleBuilderOptions<T, string> MustBeValidPassword<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotNull().WithMessage("La contraseña es requerida.")
                .NotEmpty().WithMessage("La contraseña no puede estar vacía.")
                .MinimumLength(8).WithMessage("La contraseña debe tener al menos 8 caracteres.")
                .MaximumLength(32).WithMessage("La contraseña debe tener menos de 32 caracteres.")
                .Matches("[A-Z]").WithMessage("La contraseña debe contener al menos una letra mayúscula.")
                .Matches("[a-z]").WithMessage("La contraseña debe contener al menos una letra minúscula.")
                .Matches("[0-9]").WithMessage("La contraseña debe contener al menos un número.")
                .Matches(@"[^\w\d]").WithMessage("La contraseña debe contener al menos un carácter especial.");
        }
    }
}
