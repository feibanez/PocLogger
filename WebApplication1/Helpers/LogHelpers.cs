using System.Diagnostics;

namespace WebApplication1.Helpers
{
    internal static class LogHelpers
    {
        internal static string FilterStackTrace(Exception ex)
        {
            StackTrace stackTrace = new(ex, true);

            return string.Join(Environment.NewLine, stackTrace.GetFrames()
                .Select(f => $"{f.GetMethod()?.DeclaringType?.Name}.{f.GetMethod()?.Name}"));
        }

        internal static string FormatMessage(string environment, string? addInfo, Exception ex)
        {
            string formattedMessage = $@"
            Environment: {environment}
            Exception: {ex.Message}
            InnerException: {ex.InnerException?.Message ?? "N/A"}
            Additional Info: {addInfo}
            StackTrace: {FilterStackTrace(ex)}
            ";

            return formattedMessage;
        }
    }
}
