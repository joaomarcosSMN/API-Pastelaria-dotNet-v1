using System;
using System.Collections.Generic;
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
            //ToDo (jm) Está retornando campos Telefone, Email, Endereço
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
            var result = _repo.CriarUsuario(novoUsuario);
                                                
            return Ok(result);
        }

        [HttpPost("login")]
        public IActionResult VerificarLogin(Usuario login)
        {   
            var result = _repo.VerificarLogin(login.Email.EnderecoEmail);
            
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