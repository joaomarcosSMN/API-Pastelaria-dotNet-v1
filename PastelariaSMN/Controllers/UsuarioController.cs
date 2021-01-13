using Microsoft.AspNetCore.Mvc;
using PastelariaSMN.Data;
using PastelariaSMN.Models;

namespace PastelariaSMN.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        public readonly IRepository _repo;
        public UsuarioController(IRepository repo) 
        { 
            _repo = repo;
        }

        [HttpPatch("{idUsuario}/desativar")]
        public IActionResult UpdateDesativarUsuario(int idUsuario)
        {
            var result = _repo.DesativarUsuario(idUsuario);
            return Ok(result);
        }

        [HttpPatch("{idUsuario}/ativar")]
        public IActionResult UpdateAtivarUsuario(int idUsuario)
        {
            var result = _repo.AtivarUsuario(idUsuario);
            return Ok(result);
        }

        [HttpPatch("{idUsuario}/alterarstatus")]
        public IActionResult UpdateAtivarDesativarUsuario(int idUsuario)
        {
            var result = _repo.AtivarDesativarUsuario(idUsuario);
            return Ok(result);
        }

        [HttpPatch("{idUsuario}/atualizar")]
        public IActionResult UpdateUsuario(int idUsuario, Usuario novoUsuario)
        {
            var nome = novoUsuario.Nome;
            var sobrenome = novoUsuario.Sobrenome;
            var senha = novoUsuario.Senha;

            var result = _repo.AtualizarUsuario(idUsuario, nome, sobrenome, senha);
            return Ok(result);
        }
    }
}