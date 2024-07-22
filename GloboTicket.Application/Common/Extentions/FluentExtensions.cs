﻿using FluentValidation;
using GatewaySvc.Application.Common.Settings;
using GloboTicket.Application.Common.Settings;

namespace GatewaySvc.Application.Common
{
    public static class FluentExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> WithError<T, TProperty>(
            this IRuleBuilderOptions<T, TProperty> rule, Error error, params object[] values)
        {
            var errorMessage = error.GetMessage();

            try
            {
                if (values.Length > 0)
                    errorMessage = string.Format(errorMessage, values);
            }
            catch (Exception)
            {
                // ignored
            }

            rule.WithMessage(errorMessage);
            rule.WithErrorCode(((int)error).ToString());

            return rule;
        }
    }
}
