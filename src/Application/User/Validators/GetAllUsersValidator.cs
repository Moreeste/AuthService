﻿using Application.User.Queries;
using Application.Validations;
using FluentValidation;

namespace Application.User.Validators
{
    public class GetAllUsersValidator : AbstractValidator<GetAllUsersQuery>
    {
        public GetAllUsersValidator(ICommonValidations commonValidations)
        {
            RuleFor(x => x.Page).NotEmpty().MaximumLength(4).Must(commonValidations.BeValidPositiveInteger)
                .Must(text => commonValidations.BeTextNumberWithinRange(text, 1, 1000));
            RuleFor(x => x.PageSize).NotEmpty().MaximumLength(3).Must(commonValidations.BeValidPositiveInteger)
                .Must(text => commonValidations.BeTextNumberWithinRange(text, 1, 100));
        }
    }
}
