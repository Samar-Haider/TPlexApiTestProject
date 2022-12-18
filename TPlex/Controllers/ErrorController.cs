using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace TPlex.Controllers
{
    
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly ILogger<ErrorController> logger;    
        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            bool success = false;
            string message = String.Empty;
            object response = null;
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (statusCode)
            {
                case 404:
                    message = "The resource you requested could not be found";
                    response = new { success = success, message = message };
                    logger.LogWarning($"404 error occured. Path = " +
                   $"{statusCodeResult?.OriginalPath} and QueryString = " +
                   $"{statusCodeResult?.OriginalQueryString}");
                    break;
            }

            return NotFound(response);
        }

        [HttpGet]
        [Route("Error")]
        public IActionResult Error()
        {
            bool success = false;
            string message = String.Empty;
            object response = null;

            // Retrieve the exception Details
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            response = new { success = success };
            // LogError() method logs the exception under Error category in the log
            logger.LogError($"The path {exceptionHandlerPathFeature?.Path} " +
                $"threw an exception {exceptionHandlerPathFeature?.Error}");

            return NotFound(response);
        }

    }
}
