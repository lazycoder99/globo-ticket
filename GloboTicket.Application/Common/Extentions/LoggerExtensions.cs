using System.Reflection;
using System.Runtime.CompilerServices;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace GatewaySvc.Application.Common
{
    public static class LoggerExtensions
    {
        public static void LogCallerMemberName(this ILogger logger, [CallerMemberName] string methodName = "",
            [CallerFilePath] string filePath = "")
        {
            var type = Path.GetFileNameWithoutExtension(filePath);
            var namespaceName = Assembly.GetExecutingAssembly()?.GetName()?.Name;
            var fullName = $"{namespaceName}.{type}";


            logger.LogInformation("Method {MethodName} invoked, [{fullName}]", methodName, fullName);
        }

        public static void LogValidationErrors(this ILogger logger, List<ValidationFailure> errors)
        {
            using (LogContext.PushProperty("Errors", errors, true))
            {
                logger.LogWarning("One or more validation errors occured");
            }
        }

        public static void LogData(this ILogger logger, string message, object? data)
        {
            using (LogContext.PushProperty("Data", data, true))
            {
                logger.LogInformation(message);
            }
        }
    }
}
