using Album.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Album.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloController : Controller
    {
        private readonly ILogger<HelloController> _logger;

        public HelloController(ILogger<HelloController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{name?}")]
        public string Index(string name)
        {
            _logger.LogInformation("Hello Api is called",
            DateTime.UtcNow.ToLongTimeString());
            var result = GreetingService.CheckNameExists(name);
            return result;

        }
    }
}
