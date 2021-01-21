using System;
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
            try
            {
                var result = _repo.AtivarDesativarUsuario(idUsuario);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPatch("{idUsuario}/atualizar")]
        public IActionResult AtualizarUsuario(int idUsuario, Usuario novoUsuario)
        {
            try
            {
                var result = _repo.AtualizarUsuario(idUsuario, 
                                                    novoUsuario.Nome, 
                                                    novoUsuario.Sobrenome, 
                                                    novoUsuario.Senha);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{idUsuario}")]
        public IActionResult ConsultarUsuario(int idUsuario)
        {
            try
            {
                var result = _repo.ConsultarUsuario(idUsuario);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{idGestor}/subordinados")]
        public IActionResult ConsultarUsuariosDoGestor(int idGestor)
        {
            try
            {
                var result = _repo.ConsultarUsuariosDoGestor(idGestor);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }            
        }
                
        [HttpPost("criar")]
        public IActionResult CriarUsuario(NovoUsuarioDTO novoUsuario)
        {
            try
            {
                var result = _repo.CriarUsuario(novoUsuario.Nome, 
                                                novoUsuario.Sobrenome,
                                                novoUsuario.DataNascimento, 
                                                novoUsuario.Senha,
                                                novoUsuario.EGestor,
                                                novoUsuario.EstaAtivo,
                                                novoUsuario.IdGestor,
                                                
                                                novoUsuario.EnderecoEmail,
                                                
                                                novoUsuario.DDD,
                                                novoUsuario.NumeroTelefone,
                                                novoUsuario.IdTipo,
                                                
                                                novoUsuario.Rua,
                                                novoUsuario.Bairro,
                                                novoUsuario.NumeroEnderco,
                                                novoUsuario.Complemento,
                                                novoUsuario.CEP,
                                                novoUsuario.Cidade,
                                                novoUsuario.UF);
                                                
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }  

        }

        [HttpPost("login")]
        public  IActionResult VerificarLogin(LoginDTO login)
        {
            try
            {
                var result = _repo.VerificarLogin(login.Email, login.Senha);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }             
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