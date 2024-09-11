using Newtonsoft.Json.Linq;
using Serilog.Events;
using Serilog.Formatting;

namespace WebApplication1.Helpers
{
    public class CustomJsonFormatter : ITextFormatter
    {
        public void Format(LogEvent logEvent, TextWriter output)
        {
            output.WriteLine("{");

            output.WriteLine($"  \"Time\": \"{logEvent.Timestamp:yyyy-MM-ddTHH:mm:ss.fffZ}\",");
            output.WriteLine($"  \"Level\": \"{logEvent.Level}\",");

            if (!logEvent.Properties.ContainsKey("ExceptionDetails"))
            {
                foreach (var property in logEvent.Properties)
                {
                    if (property.Key != "EventId")
                        output.WriteLine($"  \"{property.Key}\": {property.Value}");
                }
            }
            else
            {
                var property = logEvent.Properties.First(p => p.Key == "ExceptionDetails");
                output.WriteLine("  \"ExceptionDetails\": {");
                string[] detailsVal = property.Value.ToString().Replace("\"", string.Empty).Split(",");

                foreach (string item in detailsVal)
                {
                    string[] props = item.Split(':');
                    output.WriteLine($"     \"{props[0]}\": \"{props[1]}\"");
                }
                output.WriteLine("  }");
            }
            output.WriteLine("}");
        }
    }
}
