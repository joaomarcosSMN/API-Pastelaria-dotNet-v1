using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PastelariaSMN.Data;
using PastelariaSMN.Infra;
using PastelariaSMN.Models;

namespace PastelariaSMN.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : BaseController
    {
        public readonly IUsuarioRepository _repo;
        public readonly NotificationList _notifications;

        public UsuarioController(IUsuarioRepository repo, NotificationList notifications) 
        { 
            _repo = repo;
            _notifications = notifications;
        }

        [HttpPut("{idUsuario}/status")]
        public IActionResult AtivarDesativarUsuario(int idUsuario)
        {
            var result = _repo.AtivarDesativarUsuario(idUsuario);
            if (result == 0)
            {
                return NotFound("Usuário não encontrado");
            }
            return Ok("Status do usuário alterado");
        }

        [HttpPut("{idUsuario}/atualizar")]
        public IActionResult AtualizarSubordinado(int idUsuario, Subordinado novoUsuario)
        {

            novoUsuario.IsValidJustUser(_notifications);

            string hash = Cryptography.GerarHash(novoUsuario.Senha);
            var result = _repo.AtualizarUsuario(idUsuario, 
                                                novoUsuario.Nome, 
                                                novoUsuario.Sobrenome, 
                                                hash);
            if (result == 0)
            {
                return NotFound("Usuário não encontrado");
            }
            return Ok(result);
        }

        [HttpPut("gestor/{idUsuario}/atualizar")]
        public IActionResult AtualizarGestor(int idUsuario, Gestor novoUsuario)
        {

            novoUsuario.IsValidJustUser(_notifications);

            if(_notifications.HasNotifications)
            {
                return BadRequest(_notifications.Notifications);
            }

            string hash = Cryptography.GerarHash(novoUsuario.Senha);
            
            var result = _repo.AtualizarUsuario(idUsuario, 
                                                novoUsuario.Nome, 
                                                novoUsuario.Sobrenome, 
                                                hash);
            if (result == 0)
            {
                return NotFound("Usuário não encontrado");
            }
            return Ok(result);
        }

        [HttpGet("{idUsuario}")]
        public IActionResult ConsultarUsuario(int idUsuario)
        {
            var result = _repo.ConsultarUsuario(idUsuario);
            if (result.IdUsuario == 0)
            {

                return NotFound("Usuário não encontrado");
            }
            return Ok(result);
        }

        [HttpGet("gestor/{idUsuario}")]
        public IActionResult ConsultarGestor(int idUsuario)
        {
            var result = _repo.ConsultarGestor(idUsuario);
            if (result.IdUsuario == 0)
            {
                return NotFound("Usuário não encontrado");
            }
            return Ok(result);
        }
        
        [HttpGet("subordinado/{idUsuario}")]
        public IActionResult ConsultarSubordinado(int idUsuario)
        {
            var result = _repo.ConsultarSubordinado(idUsuario);
            if (result.IdUsuario == 0)
            {
                return NotFound("Usuário não encontrado");
            }
            return Ok(result);
        }

        [Authorize(Roles = "gestor")]
        [HttpGet("gestor/{idGestor}/subordinados")]
        public IActionResult ConsultarUsuariosDoGestor(int idGestor)
        {
            var result = _repo.ConsultarUsuariosDoGestor(idGestor);
            if (!result.Any())
            {
                return BadRequest("Gestor não possui usuários.");
            }
            return Ok(result);                
        }

        [Authorize(Roles = "gestor")]
        [HttpPost("gestor/criar")]
        public IActionResult CriarGestor(Gestor novoUsuario)
        {
            novoUsuario.is_valid(_notifications);
            if (_notifications.HasNotifications)
            {
                return BadRequest(_notifications.Notifications);
            }

            if(_repo.VerificarEmailUnique(novoUsuario.Email.EnderecoEmail))
            {
                return BadRequest("O email usado no cadastro já existe no banco, tente novamente");
            }
            else
            {
                var result = _repo.CriarGestor(novoUsuario);
                return Ok(result);
            }
            
        }

        [Authorize(Roles = "gestor")]
        [HttpPost("subordinado/criar")]
        public IActionResult CriarSubordinado(Subordinado novoUsuario)
        {
            novoUsuario.is_valid(_notifications);
            if (_notifications.HasNotifications)
            {
                return BadRequest(_notifications.Notifications);
            }

            if(_repo.VerificarEmailUnique(novoUsuario.Email.EnderecoEmail))
            {
                return BadRequest("O email usado no cadastro já existe no banco, tente novamente");
            }
            else
            {
                var result = _repo.CriarSubordinado(novoUsuario);
                return Ok(result);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<dynamic>> VerificarLogin(UsuarioLogin login)
        {
            var result = _repo.VerificarLogin(login.Email.EnderecoEmail);

            string hash = Cryptography.GerarHash(login.Senha);

            if (result == null || hash != result.Senha)
            {
                return BadRequest("Email ou senha incorreta");
            }
            var token = TokenService.GenerateToken(result);
            result.Token = token;
            result.Senha = "";
            return (result);
        }

    }
}