using Microsoft.AspNetCore.Mvc;
using WebApplication1.Helpers;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PocLoggerController(ILogger<PocLoggerController> logger) : ControllerBase
    {
        private readonly ILogger<PocLoggerController> _logger = logger;

        [HttpGet("LogInformation")]
        public IActionResult LogInformation()
        {
            try
            {
                throw new Exception("This is a simulated exception!");
            }
            catch (Exception ex)
            {
                _logger.LogCustomInformation(HttpContext, "This is relevant info!", ex);
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
                _logger.LogCustomWarning(HttpContext, "This is relevant info!", ex);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("LogError")]
        public IActionResult LogError()
        {
            try
            {
                throw new Exception("This is a simulated exception!");
            }
            catch (Exception ex)
            {
                _logger.LogCustomError(HttpContext, "This is relevant info!", ex);
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
                _logger.LogCustomCritical(HttpContext, "This is relevant info!", ex);
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}

