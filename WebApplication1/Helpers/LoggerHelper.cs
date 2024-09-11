using System.Diagnostics;

namespace WebApplication1.Helpers
{
    internal static class LoggerHelper
    {
        internal static string FilterStackTrace(Exception ex)
        {
            StackTrace stackTrace = new(ex, true);

            return string.Join(",", stackTrace.GetFrames()
                .Select(f => $"{f.GetMethod()?.DeclaringType?.Name}.{f.GetMethod()?.Name}.Line_{f.GetFileLineNumber()}"));
        }

        internal static string FormatMessage(HttpContext httpContext, string? addInfo, Exception ex)
        {
            string formattedMessage =
                  $"Environment:{GetEnvironment()},"
                + $"Exception:{ex.Message},"
                + $"InnerException:{ex.InnerException?.Message ?? "N/A"},"
                + $"AdditionalInfo:{addInfo},"
                + $"ConnectionId:{httpContext.Connection.Id},"
                + $"RequestPath:{httpContext.Request.Path},"
                + $"RequestId:{httpContext.TraceIdentifier},"
                + $"Controller:{httpContext.Request.Path},"
                + $"StackTrace:{FilterStackTrace(ex)}";

            return formattedMessage;
        }

        internal static string GetEnvironment()
        {
            return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Unknown";
        }

        public static void LogCustomInformation(this ILogger logger, HttpContext httpContext, string additionalInfo, Exception ex)
        {
            string formattedMessage = FormatMessage(httpContext, additionalInfo, ex);
            logger.LogInformation("{@ExceptionDetails}", formattedMessage);
        }

        public static void LogCustomWarning(this ILogger logger, HttpContext httpContext, string additionalInfo, Exception ex)
        {
            string formattedMessage = FormatMessage(httpContext, additionalInfo, ex);
            logger.LogWarning("{@ExceptionDetails}", formattedMessage);
        }

        public static void LogCustomError(this ILogger logger, HttpContext httpContext, string additionalInfo, Exception ex)
        {
            string formattedMessage = FormatMessage(httpContext, additionalInfo, ex);
            logger.LogError("{@ExceptionDetails}", formattedMessage);
        }

        public static void LogCustomCritical(this ILogger logger, HttpContext httpContext, string additionalInfo, Exception ex)
        {
            string formattedMessage = FormatMessage(httpContext, additionalInfo, ex);
            logger.LogCritical("{@ExceptionDetails}", formattedMessage);
        }
    }
}
