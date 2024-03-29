﻿using Domain.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Application.Validations
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationTasks = _validators.Select(async x => await x.ValidateAsync(context, cancellationToken));
                var validationResults = await Task.WhenAll(validationTasks);
                var failures = validationResults.SelectMany(x => x.Errors).Where(x => x != null).ToList();

                if (failures.Count > 0)
                {
                    string errorMessage = GenerateErrorMessage(failures);
                    throw new CustomValidationException(errorMessage);
                }
            }

            return await next();
        }

        private string GenerateErrorMessage(List<ValidationFailure> failures)
        {
            return string.Join(" ", failures.Select(failure => failure.ErrorMessage));
        }
    }
}
