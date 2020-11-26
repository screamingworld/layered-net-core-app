using FluentValidation;
using FluentValidation.Results;
using Layered.Common.Contract;
using Layered.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Layered.Common.WebCore
{
    public static class ValidationResultWebCoreExtension
    {
        public static bool HasErrors(this ValidationResult validationResult)
        {
            if (validationResult == null) throw new ArgumentNullException(nameof(validationResult));

            return validationResult.Errors.Any(x => x.Severity == Severity.Error);
        }

        public static ValidationResponseModel ToValidationResponseModel(this ValidationResult validationResult)
        {
            if (validationResult == null) throw new ArgumentNullException(nameof(validationResult));

            var result = new ValidationResponseModel();
            result.AddFailures(ConvertToValidationItemModelList(validationResult.Errors));
            return result;
        }

        public static ValidationResultResponseModel<TResult> ToValidationResultResponseModel<TResult>(this ValidationResult validationResult, TResult model)
        {
            if (validationResult == null)
                throw new ArgumentNullException(nameof(validationResult));

            var result = new ValidationResultResponseModel<TResult>(model);

            result.AddFailures(ConvertToValidationItemModelList(validationResult.Errors));

            return result;
        }

        private static List<ValidationItemModel> ConvertToValidationItemModelList(IEnumerable<ValidationFailure> failures)
        {
            var result = new List<ValidationItemModel>();
            
            foreach (var failure in failures)
            {
                var messageParts = failure.ErrorMessage.Split('|').ToList();
                var validationKey = messageParts[0];
                var args = new List<string>();
                var field = failure.PropertyName
                    .Replace("[", ".")
                    .Replace("]", "")
                    .ToDottedCamelCase();
                if (messageParts.Count > 1)
                    args = messageParts[1].Split(',').ToList();

                var validationModel = new ValidationItemModel
                {
                    Field = field,
                    Key = validationKey,
                    FailureType = failure.Severity == Severity.Warning 
                        ? FailureType.Warning.ToString().ToCamelCase() 
                        : FailureType.Error.ToString().ToCamelCase(),
                };
                ((List<string>)validationModel.Args).AddRange(args);

                result.Add(validationModel);
            }

            return result;
        }
    }
}
