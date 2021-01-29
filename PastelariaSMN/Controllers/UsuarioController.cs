using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPatch("{idUsuario}/status")]
        public IActionResult AtivarDesativarUsuario(int idUsuario)
        {
            var result = _repo.AtivarDesativarUsuario(idUsuario);
            return Ok(result);
        }

        [HttpPatch("{idUsuario}/atualizar")]
        public IActionResult AtualizarSubordinado(int idUsuario, Subordinado novoUsuario)
        {
            string hash = Cryptography.GerarHash(novoUsuario.Senha);
            
            var result = _repo.AtualizarUsuario(idUsuario, 
                                                novoUsuario.Nome, 
                                                novoUsuario.Sobrenome, 
                                                hash);
            return Ok(result);
        }

        [HttpPatch("gestor/{idUsuario}/atualizar")]
        public IActionResult AtualizarGestor(int idUsuario, Gestor novoUsuario)
        {
            string hash = Cryptography.GerarHash(novoUsuario.Senha);
            
            var result = _repo.AtualizarUsuario(idUsuario, 
                                                novoUsuario.Nome, 
                                                novoUsuario.Sobrenome, 
                                                hash);
            return Ok(result);
        }

        [HttpGet("gestor/{idUsuario}")]
        public IActionResult ConsultarGestor(int idUsuario)
        {
                var result = _repo.ConsultarGestor(idUsuario);
                return Ok(result);
        }
        
        [HttpGet("subordinado/{idUsuario}")]
        public IActionResult ConsultarSubordinado(int idUsuario)
        {
                var result = _repo.ConsultarSubordinado(idUsuario);
                return Ok(result);
        }

        [HttpGet("gestor/{idGestor}/subordinados")]
        public IActionResult ConsultarUsuariosDoGestor(int idGestor)
        {
            var result = _repo.ConsultarUsuariosDoGestor(idGestor);
            if (result.Any())
            {
                return BadRequest("Gestor não possui usuários.");
            }
            return Ok(result);                
        }
                
        [HttpPost("gestor/criar")]
        public IActionResult CriarGestor(Gestor novoUsuario)
        {
            var result = _repo.CriarGestor(novoUsuario);
                                                
            return Ok(result);
        }

        [HttpPost("subordinado/criar")]
        public IActionResult CriarSubordinado(Subordinado novoUsuario)
        {
            var result = _repo.CriarSubordinado(novoUsuario);
                                                
            return Ok(result);
        }

        [HttpPost("gestor/login")]
        public IActionResult VerificarLoginGestor(Gestor login)
        {   
            var result = _repo.VerificarLoginGestor(login.Email.EnderecoEmail);
            
            string hash = Cryptography.GerarHash(login.Senha);

            if(result == null || hash != result.Senha)
            {
                return BadRequest("Email ou senha incorreta");
            }
            else 
            {
                return Ok("Login válido");
            }
        }

        [HttpPost("subordinado/login")]
        public IActionResult VerificarLoginSubordinado(Subordinado login)
        {   
            var result = _repo.VerificarLoginSubordinado(login.Email.EnderecoEmail);
            
            string hash = Cryptography.GerarHash(login.Senha);

            if(result == null || hash != result.Senha)
            {
                return BadRequest("Email ou senha incorreta");
            }
            else 
            {
                return Ok("Login válido");
            }
        }

        [HttpPost("Teste")]
        public IActionResult Teste(Usuario usuario)
        {
            usuario.is_valid(_notifications);
            if (_notifications.HasNotifications)
            {
                return BadRequest(_notifications.Notifications);
            }
            return Ok();
        }
    }
}