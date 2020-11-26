using FluentValidation;
using Layered.Common.Contract;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Layered.Common.Core
{
    /// <summary>
    /// Extensions method for helping and providing a better way,
    /// for using the fluent validations for dfl purposes.
    /// </summary>
    public static class CustomValidatorOptions
    {
        /// <summary>
        /// Converts different parameters into the message property.
        /// With this it is possible to pass typesafe parameters and pass it through the message.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="rule"></param>
        /// <param name="errorMessage"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, TProperty> WithMessage<T, TProperty>(
            this IRuleBuilderOptions<T, TProperty> rule, 
            string errorMessage,
            string[] args
            )
        {
            var merged = new string[] 
            {
                errorMessage,
                string.Join(",", args)
            };

            return rule.WithMessage(string.Join("|", merged));
        }

        /// <summary>
        /// Provide a simple preconfigured interface for the MinimumLength validator.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruleBuilder"></param>
        /// <param name="minimumLength"></param>
        /// <param name="validationKey">
        /// The validationKey (<see cref="ValidationKey"/>) 
        /// which is describing the message key in ui.
        /// </param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, string> MinimumLengthConfigured<T>(
            this IRuleBuilder<T, string> ruleBuilder,
            int minimumLength,
            string validationKey = ValidationKey.MinLength
            ) => ruleBuilder
                .MinimumLength(minimumLength)
                .WithSeverity(Severity.Error)
                .WithMessage(
                    validationKey,
                    new string[] { minimumLength.ToString(CultureInfo.InvariantCulture) });

        /// <summary>
        /// Provide a simple preconfigured interface for the MaximumLength validator.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruleBuilder"></param>
        /// <param name="maximumLength"></param>
        /// <param name="validationKey">
        /// The validationKey (<see cref="ValidationKey"/>) 
        /// which is describing the message key in ui.
        /// </param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, string> MaximumLengthConfigured<T>(
            this IRuleBuilder<T, string> ruleBuilder,
            int maximumLength,
            string validationKey = ValidationKey.MaxLength
            ) => ruleBuilder
                .MaximumLength(maximumLength)
                .WithSeverity(Severity.Error)
                .WithMessage(
                    validationKey,
                    new string[] { maximumLength.ToString(CultureInfo.InvariantCulture) });

        /// <summary>
        /// Provide a simple preconfigured interface for the GreaterThan validator.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="ruleBuilder"></param>
        /// <param name="valueToCompare"></param>
        /// <param name="validationKey">
        /// The validationKey (<see cref="ValidationKey"/>) 
        /// which is describing the message key in ui.
        /// </param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, TProperty> GreaterThanConfigured<T, TProperty>(
            this IRuleBuilder<T, TProperty> ruleBuilder, 
            TProperty valueToCompare,
            string validationKey = ValidationKey.Min
            ) where TProperty : IComparable<TProperty>, IComparable
                => ruleBuilder
                .GreaterThan(valueToCompare)
                .WithSeverity(Severity.Error)
                .WithMessage(
                    validationKey,
                    new string[] { valueToCompare.ToString() });

        /// <summary>
        /// Provide a simple preconfigured interface for the Must validator.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="ruleBuilder"></param>
        /// <param name="predicate"></param>
        /// <param name="validationKey">
        /// The validationKey (<see cref="ValidationKey"/>) 
        /// which is describing the message key in ui.
        /// </param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, TProperty> MustConfigured<T, TProperty>(
            this IRuleBuilder<T, TProperty> ruleBuilder, 
            Func<TProperty, bool> predicate,
            string validationKey = ValidationKey.Exists)
            =>  ruleBuilder
                .Must(predicate)
                .WithSeverity(Severity.Error)
                .WithMessage(validationKey);

        /// <summary>
        /// Provide a simple preconfigured interface for the Must validator for using the complete model inside the validator.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="ruleBuilder"></param>
        /// <param name="predicate"></param>
        /// <param name="validationKey"></param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, TProperty> MustConfigured<T, TProperty>(
            this IRuleBuilder<T, TProperty> ruleBuilder, 
            Func<T, TProperty, bool> predicate,
            string validationKey = ValidationKey.Exists)
            =>  ruleBuilder
                .Must(predicate)
                .WithSeverity(Severity.Error)
                .WithMessage(validationKey);

        /// <summary>
        /// Provide a simple preconfigured interface for the Empty validator.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="ruleBuilder"></param>
        /// <param name="validationKey">
        /// The validationKey (<see cref="ValidationKey"/>) 
        /// which is describing the message key in ui.
        /// </param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, TProperty> NotNullConfigured<T, TProperty>(
            this IRuleBuilder<T, TProperty> ruleBuilder,
            string validationKey = ValidationKey.Required)
            => ruleBuilder
                .NotNull()
                .WithSeverity(Severity.Error)
                .WithMessage(validationKey);

        /// <summary>
        /// Provide a pre configured credit card validation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruleBuilder"></param>
        /// <param name="validationKey"></param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, string> CreditCardConfigured<T>(
            this IRuleBuilder<T, string> ruleBuilder,
            string validationKey = ValidationKey.Invalid)
            => ruleBuilder
                .CreditCard()
                .WithSeverity(Severity.Error)
                .WithMessage(validationKey);

        /// <summary>
        /// Provide a pre configured validator for regular expressions
        /// <see cref="RegularExpression"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruleBuilder"></param>
        /// <param name="regex"></param>
        /// <param name="validationKey"></param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, string> MatchesConfigured<T>(
            this IRuleBuilder<T, string> ruleBuilder,
            Regex regex,
            string validationKey = ValidationKey.Invalid)
            => ruleBuilder
                .Matches(regex)
                .WithSeverity(Severity.Error)
                .WithMessage(validationKey);
    }
}
