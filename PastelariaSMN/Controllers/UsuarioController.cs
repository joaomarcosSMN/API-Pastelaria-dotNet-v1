using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
                
        [HttpPost("gestor/criar")]
        public IActionResult CriarGestor(Gestor novoUsuario)
        {
            novoUsuario.is_valid(_notifications);
            if (_notifications.HasNotifications)
            {
                return BadRequest(_notifications.Notifications);
            }

            var result = _repo.CriarGestor(novoUsuario);
            
            return Ok(result);
        }

        [HttpPost("subordinado/criar")]
        public IActionResult CriarSubordinado(Subordinado novoUsuario)
        {
            novoUsuario.is_valid(_notifications);
            if (_notifications.HasNotifications)
            {
                return BadRequest(_notifications.Notifications);
            }
            var result = _repo.CriarSubordinado(novoUsuario);
                                                
            return Ok(result);
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
            Console.WriteLine(token);
            result.Token = token;
            result.Senha = "";
            return (result);
        }

        // ROTAS PARA TESTAR A USABILIDADE DO AUTHORIZE E DO CLAIMS DO TOKEN
        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "gestor")]
        public string Employee() => "Gestor";

        [HttpGet]
        [Route("manager")]
        [Authorize(Roles = "subordinado,gestor")]
        public String Manager() 
        {
            var result = User.Claims.ToList();
            var result2 = User.Claims.ToList()[0];
            Console.WriteLine(result2.Value);
            return User.Claims.ToList()[2].Value;
        }


        /*[HttpPost("subordinado/login")]
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
        */

        /*[HttpPost("gestor/login")]
            public async Task<ActionResult<dynamic>> VerificarLoginGestor(Gestor login)
            {   
                var result = _repo.VerificarLoginGestor(login.Email.EnderecoEmail);
            
                string hash = Cryptography.GerarHash(login.Senha);

                if(result == null || hash != result.Senha)
                {
                    return BadRequest("Email ou senha incorreta");
                }

                var token = TokenService.GenerateToken(result, result);

                result.Senha = "";

                return new
                {
                    result = result,
                    token = token
                };
            }
         */


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