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

        [HttpPatch("{idUsuario}/status")]
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
        
        [HttpPost("criar")]
        public IActionResult PostUsuario(Usuario novoUsuario)
        {
  
            var result = _repo.CriarUsuario(novoUsuario.Nome, 
                                            novoUsuario.Sobrenome,
                                            novoUsuario.DataNascimento, 
                                            novoUsuario.Senha,
                                            novoUsuario.EGestor,
                                            novoUsuario.EstaAtivo,
                                            novoUsuario.IdGestor);
            return Ok(result);
        }

        [HttpGet("{idGestor}/subordinados")]
        public IActionResult GetSubordinadosByGestor(int idGestor)
        {
            var result = _repo.ConsultarUsuariosDoGestor(idGestor);
            return Ok(result);
        }

        [HttpGet("{idUsuario}")]
        public IActionResult GetUsuarioById(int idUsuario)
        {
            var result = _repo.ConsultarUsuario(idUsuario);
            return Ok(result);
        }


        // [HttpPatch("{idUsuario}/desativar")]
        // public IActionResult UpdateDesativarUsuario(int idUsuario)
        // {
        //     var result = _repo.DesativarUsuario(idUsuario);
        //     return Ok(result);
        // }

        // [HttpPatch("{idUsuario}/ativar")]
        // public IActionResult UpdateAtivarUsuario(int idUsuario)
        // {
        //     var result = _repo.AtivarUsuario(idUsuario);
        //     return Ok(result);
        // }
    }
}