﻿using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UniversityLifeApp.Domain.Enums;

namespace UniversityLifeApp.Application.Behaviours
{
    public class RequestValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public RequestValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var failures = _validators.Select(x => x.Validate(context))
                                 .SelectMany(x => x.Errors)
                                 .Where(x => x != null)
                                 .ToList();

            Dictionary<string, string> errors = new Dictionary<string, string>();

            foreach (var error in failures)
            {
                errors.Add(error.PropertyName, error.ErrorMessage);
            }

            if (failures.Count > 0)
            {
                return await Task.FromResult(
                    (TResponse)
                    typeof(TResponse)
                    .GetMethod(
                        "Error",
                        new[] {typeof(ErrorCodes) ,typeof(Dictionary<string,string>) })
                    ?.Invoke(
                        Activator.CreateInstance(typeof(TResponse)),
                        new object[] { ErrorCodes.VALIDATION_ERROR, errors }));
            }
            return await next();
        }
    }
}
