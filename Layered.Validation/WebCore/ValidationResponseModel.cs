using Layered.Common.Contract;
using Layered.Common.Core;
using System.Collections.Generic;

namespace Layered.Common.WebCore
{
    public class ValidationResponseModel
    {
        private readonly List<ValidationItemModel> _failures = new List<ValidationItemModel>();

        public IEnumerable<ValidationItemModel> Failures => _failures;

        public void AddFailures(IEnumerable<ValidationItemModel> failures)
        {
            _failures.AddRange(failures);
        }

        public void AddError(
            string field, 
            string validationKey)
        {
            _failures.Add(new ValidationItemModel
            {
                FailureType = FailureType.Error.ToString().ToCamelCase(),
                Field = field.ToCamelCase(),
                Key = validationKey.ToCamelCase(),
            });
        }
    }
}
