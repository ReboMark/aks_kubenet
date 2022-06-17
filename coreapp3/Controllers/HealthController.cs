using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace coreapp3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private readonly IConfiguration _config;
        public HealthController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("/health")]
        [AllowAnonymous]
        public string Get()
        {
            return $"{DateTime.Now.ToUniversalTime().ToString("yyyy/MM/dd HH:mm:ss")} Coreapp3 Service";
        }
    }
}
