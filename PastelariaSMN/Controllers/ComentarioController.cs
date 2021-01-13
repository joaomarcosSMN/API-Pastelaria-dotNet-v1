using Microsoft.AspNetCore.Mvc;
using PastelariaSMN.Data;

namespace PastelariaSMN.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComentarioController : ControllerBase
    {
        public readonly IRepository _repo;

        public ComentarioController(IRepository repo) 
        {
            _repo = repo;
        }

    }
}