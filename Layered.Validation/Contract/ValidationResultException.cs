using FluentValidation.Results;
using System;

namespace Layered.Common.Contract
{
    [Serializable]
    public class ValidationResultException : Exception
    {
        public ValidationResultException(ValidationResult validationResult)
        {
            ValidationResult = validationResult ?? throw new ArgumentNullException(nameof(validationResult));
        }

        public ValidationResult ValidationResult { get; }
    }
}
