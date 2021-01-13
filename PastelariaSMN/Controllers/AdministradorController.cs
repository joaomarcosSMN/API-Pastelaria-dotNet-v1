using Microsoft.AspNetCore.Mvc;

namespace PastelariaSMN.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdministradorController : ControllerBase
    {
        public AdministradorController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("hello world!");
        }
    }
}