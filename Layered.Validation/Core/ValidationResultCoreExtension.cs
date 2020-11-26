using FluentValidation;
using FluentValidation.Results;
using System;
using System.Linq;

namespace Layered.Common.Core
{
    public static class ValidationResultCoreExtension
    {
        public static bool HasErrors(this ValidationResult validationResult)
        {
            if (validationResult == null) throw new ArgumentNullException(nameof(validationResult));

            return validationResult.Errors.Any(x => x.Severity == Severity.Error);
        }

        public static void AddError(
            this ValidationResult validationResult,
            string propertyName,
            string errorMessage,
            params string[] args)
        {
            if (validationResult == null) throw new ArgumentNullException(nameof(validationResult));

            var merged = new string[]
            {
                errorMessage,
                string.Join(",", args)
            };

            validationResult.Errors.Add(new ValidationFailure(propertyName, string.Join("|", merged)));
        }
    }
}
