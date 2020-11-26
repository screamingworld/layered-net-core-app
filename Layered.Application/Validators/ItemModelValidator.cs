using Layered.Application.Contract.Models;
using Layered.Business.Contract.Abstractions;
using Layered.Common.Core;
using System;

namespace FluentValidation.Application.Validators
{
    public class ItemModelValidator : AbstractValidator<ItemModel>
    {
        public ItemModelValidator(IItemDataService itemDataService)
        {
            if (itemDataService == null)
                throw new ArgumentNullException(nameof(itemDataService));

            RuleFor(x => x.Id).NotNullConfigured();
            RuleFor(x => x.Name).MinimumLengthConfigured(6);
            RuleFor(x => x.Description).MaximumLengthConfigured(100);
            RuleFor(x => x.Position).GreaterThanConfigured(0);
        }
    }
}
