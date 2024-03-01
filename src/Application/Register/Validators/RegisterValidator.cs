﻿using Application.Register.Commands;
using Application.Validations;
using FluentValidation;

namespace Application.Register.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterValidator(ICommonValidations commonValidations)
        {
            RuleFor(x => x.Email).NotNull().NotEmpty().MaximumLength(100).EmailAddress();
            RuleFor(x => x.PhoneNumber).NotNull().NotEmpty().Length(10).Must(commonValidations.BeValidPhoneNumber);
            RuleFor(x => x.FirstName).NotNull().NotEmpty().MaximumLength(30).Must(commonValidations.BeValidName);
            RuleFor(x => x.MiddleName).NotEmpty().MaximumLength(30).Must(commonValidations.BeValidName);
            RuleFor(x => x.LastName).NotNull().NotEmpty().MaximumLength(30).Must(commonValidations.BeValidName);
            RuleFor(x => x.SecondLastName).NotEmpty().MaximumLength(30).Must(commonValidations.BeValidName);
            RuleFor(x => x.Gender).NotNull().MustAsync(commonValidations.BeValidGenderId);
            RuleFor(x => x.BirthDate).NotNull().Must(commonValidations.BeValidBirthDate);
            RuleFor(x => x.Password).NotNull().NotEmpty().MinimumLength(8).MaximumLength(32);
        }
    }
}
