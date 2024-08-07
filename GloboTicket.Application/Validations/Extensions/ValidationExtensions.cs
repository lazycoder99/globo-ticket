﻿using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;
using GloboTicket.Application.Validations.CustomValidator;

namespace GloboTicket.Application.Validations.Extensions
{
    public static class ValidationExtensions
    {
        public static async Task<ValidationResult> Validate<T>(this T model, IValidator<T> validator)
        {
            return await validator.ValidateAsync(model);
        }

        public static async Task<ValidationResult> Validate<T>(this T model, IValidator<T> validator, Action<ValidationStrategy<T>> options, CancellationToken cancellation = default)
        {
            return await validator.ValidateAsync(model, options, cancellation);
        }

        /// <summary>
        /// Defines a 'valid phone number' validator on the current rule builder.
        /// Validation will fail if the property is not a valid phone number/>.
        /// </summary>
        /// <typeparam name="T">Type of object being validated</typeparam>
        /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, string?> IsValidPhone<T>(this IRuleBuilder<T, string?> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new IsValidMobileNumber<T>());
        }

        public static IRuleBuilderOptions<T, string?> IsValidCreditCard<T>(this IRuleBuilder<T, string?> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new LuhnCreditCardValidator<T>());
        }
    }
}
