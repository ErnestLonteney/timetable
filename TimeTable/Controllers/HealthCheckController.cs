using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TimeTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private readonly ILogger _logger;
        public HealthCheckController(ILogger logger)
        {
            _logger = logger;
        }
         
        
        [Route("check")]
        [HttpGet]
        public string Check()
        {
            _logger.LogDebug("Check was called");

            return "OK";
        }
        
    }
}
