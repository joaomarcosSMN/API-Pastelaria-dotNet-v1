using Microsoft.AspNetCore.Mvc;
using PastelariaSMN.Data;
using PastelariaSMN.Models;

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

        [HttpPost("criar")]
        public IActionResult PostComentario(Comentario novoComentario)
        {
            
            var result = _repo.CriarComentario(novoComentario.Descricao, 
                                               novoComentario.IdTarefa
                                               );
            return Ok(result);
        }

    }
}