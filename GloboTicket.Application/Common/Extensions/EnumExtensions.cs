using System.ComponentModel;
using System.Reflection;
using GatewaySvc.Application.Common.Settings;
using GloboTicket.Application.Common.Settings;

namespace GloboTicket.Application.Common.Extensions
{
    public static class EnumExtensions
    {
        public static string GetMessage(this Error error)
        {
            var dbValue = ConfigProvider.Find(error);
            if (!string.IsNullOrEmpty(dbValue))
                return dbValue;

            var defaultVal = error.GetDescription();
            if (!string.IsNullOrEmpty(defaultVal))
                return defaultVal;

            return "One or more validations errors occured.";
        }

        public static string GetMessage(this Success success)
        {
            var dbValue = ConfigProvider.Find(success);
            if (!string.IsNullOrEmpty(dbValue))
                return dbValue;

            var defaultVal = success.GetDescription();
            if (!string.IsNullOrEmpty(defaultVal))
                return defaultVal;

            return "Operation successfully completed.";
        }

        public static string? GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field?.GetCustomAttribute<DescriptionAttribute>();
            return attribute?.Description;
        }

        public static bool IsAny<T>(this T value, params T[] choices)
        where T : Enum
        {
            return choices.Contains(value);
        }
    }
}
