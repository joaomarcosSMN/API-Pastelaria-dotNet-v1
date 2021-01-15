using Microsoft.AspNetCore.Mvc;
using PastelariaSMN.Data;
using PastelariaSMN.DTOs;
using PastelariaSMN.Models;

namespace PastelariaSMN.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        public readonly IUsuarioRepository _repo;
        public UsuarioController(IUsuarioRepository repo) 
        { 
            _repo = repo;
        }

        [HttpPatch("{idUsuario}/status")]
        public IActionResult AtivarDesativarUsuario(int idUsuario)
        {
            var result = _repo.AtivarDesativarUsuario(idUsuario);
            return Ok(result);
        }

        [HttpPatch("{idUsuario}/atualizar")]
        public IActionResult AtualizarUsuario(int idUsuario, Usuario novoUsuario)
        {
            var result = _repo.AtualizarUsuario(idUsuario, 
                                                novoUsuario.Nome, 
                                                novoUsuario.Sobrenome, 
                                                novoUsuario.Senha);
            return Ok(result);
        }

        [HttpGet("{idUsuario}")]
        public IActionResult ConsultarUsuario(int idUsuario)
        {
            var result = _repo.ConsultarUsuario(idUsuario);
            return Ok(result);
        }

        [HttpGet("{idGestor}/subordinados")]
        public IActionResult ConsultarUsuariosDoGestor(int idGestor)
        {
            var result = _repo.ConsultarUsuariosDoGestor(idGestor);
            return Ok(result);
        }
                
        [HttpPost("criar")]
        public IActionResult CriarUsuario(Usuario novoUsuario)
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

        [HttpPost("login")]
        public  IActionResult VerificarLogin(LoginDTO login)
        {
            var result = _repo.VerificarLogin(login.Email, login.Senha);
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