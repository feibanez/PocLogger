using Microsoft.AspNetCore.Mvc;
using WebApplication1.Helpers;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PocLoggerController(ILogger<PocLoggerController> logger) : ControllerBase
    {
        private readonly ILogger<PocLoggerController> _logger = logger;
        private readonly string _environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Unknown";

        [HttpGet("LogInformation")]
        public IActionResult LogInformation()
        {
            try
            {
                throw new Exception("This is a simulated exception!");
            }
            catch (Exception ex)
            {
                _logger.LogInformation(message: LogHelpers.FormatMessage(_environment, "This is relevant info!" ,ex));
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("LogWarning")]
        public IActionResult LogWarning()
        {
            try
            {
                throw new Exception("This is a simulated exception!");
            }
            catch (Exception ex)
            {
                _logger.LogWarning(message: LogHelpers.FormatMessage(_environment, "This is relevant info!", ex));
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("LogCritical")]
        public IActionResult LogCritical()
        {
            try
            {
                throw new Exception("This is a simulated exception!");
            }
            catch (Exception ex)
            {
                _logger.LogCritical(message: LogHelpers.FormatMessage(_environment, "This is relevant info!", ex));
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}

