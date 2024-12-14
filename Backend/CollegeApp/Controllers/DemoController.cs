using CollegeApp.MyLogging;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors(PolicyName = "AllowOnlyGoogle")]
    public class DemoController : ControllerBase
    {
        private readonly IMyLogger _myLogger;
        private readonly ILogger<DemoController> _myLoggerFactory;
        public DemoController(IMyLogger myLogger, ILogger<DemoController> myLoggerFactory)
        {
            _myLogger = myLogger;
            _myLoggerFactory = myLoggerFactory;
        }

        [HttpGet]
        [EnableCors(PolicyName = "AllowMicrosoft")]
        [DisableCors]
        public ActionResult Index()
        {
            _myLogger.Log("Index method started");
            _myLoggerFactory.LogTrace("1");
            _myLoggerFactory.LogDebug("2");
            _myLoggerFactory.LogInformation("3");
            _myLoggerFactory.LogWarning("4");
            _myLoggerFactory.LogError("5");
            _myLoggerFactory.LogCritical("6");
            return Ok();
        }
    }
}
