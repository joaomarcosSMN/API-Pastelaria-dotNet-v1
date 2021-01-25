using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PastelariaSMN.Data;
using PastelariaSMN.DTOs;
using PastelariaSMN.Infra;
using PastelariaSMN.Models;

namespace PastelariaSMN.Controllers
{
    
    [ApiController]
    [Route("api")]
    public class TarefaController : BaseController
    {
        public readonly ITarefaRepository _repo;
        public readonly EmailSettings _options;
        public TarefaController(EmailSettings options, ITarefaRepository repo) 
        {
            _options = options;
            _repo = repo;
        }
        
        [HttpPatch("tarefa/{idTarefa}/status")]
        public IActionResult AlterarStatusDaTarefa(int idTarefa, Tarefa tarefaEditada)
        {
            // TODO: Implementar o exception filter como middleware 
            try
            {
                var result = _repo.AlterarStatusDaTarefa(idTarefa, tarefaEditada.IdStatusTarefa);

                if(result.success) 
                    return Ok();
                

                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }
        
        [HttpPatch("tarefa/{idTarefa}/cancelar")]
        public IActionResult CancelarTarefa(int idTarefa)
        {
            try
            {
                var result = _repo.CancelarTarefa(idTarefa);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("tarefa/{IdTarefa}/comentarios")]
        public IActionResult ConsultarComentarioTarefa(int idTarefa)
        {
            try
            {
                var result = _repo.ConsultarComentarioTarefa(idTarefa);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
            
        }

        [HttpPost("tarefa/comentario/criar")]
        public IActionResult CriarComentario(Comentario novoComentario)
        {
            
            var result = _repo.CriarComentario(novoComentario.Descricao, 
                                               novoComentario.IdTarefa
                                               );
            return Ok(result);
        }

        [HttpPost("tarefa/criar")]
        public IActionResult CriarTarefa(Tarefa novaTarefa)
        {
            try 
            {
                var result = _repo.CriarTarefa(novaTarefa.Descricao, 
                                               novaTarefa.DataLimite,
                                               novaTarefa.IdGestor,
                                               novaTarefa.IdSubordinado,
                                               novaTarefa.IdStatusTarefa);

                // result retorna int idTarefa da tarefa recem criada
                var emailData = _repo.ConsultarEmailGestorNomeSubordinado(result);
                
                // string body = "O seu gestor " + result.NomeGestor + " criou uma tarefa";
                string body = $"O seu gestor { emailData.NomeGestor } criou uma tarefa com a descrição: '{ novaTarefa.Descricao }'.";

                EmailSent.SendEmail(_options, emailData.EmailSubordinado, $"Uma tarefa foi criada para você pelo seu gestor { emailData.NomeGestor }", body);

                return Ok($"Tarefa com id {result} foi criada");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPatch("tarefa/{idTarefa}/datalimite")]
        public IActionResult EditarDataLimite(int idTarefa, Tarefa tarefaEditada)
        {           
            try
            {
                var result = _repo.EditarDataLimite(idTarefa, tarefaEditada.DataLimite);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }


        [HttpPatch("tarefa/{idTarefa}/concluir")]
        public IActionResult ConcluirTarefa(int idTarefa)
        {
            try
            {
                var result = _repo.ConcluirTarefa(idTarefa);

                var emailData = _repo.ConsultarEmailGestorNomeSubordinado(idTarefa);

                string body = $"O seu subordinado {emailData.NomeSubordinado} concluiu uma tarefa";

                EmailSent.SendEmail(_options, emailData.EmailGestor, "Uma tarefa foi concluida por um subordinado seu!", body);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("usuario/{idSubordinado}/tarefa/quantidade")]
        public IActionResult ContarTarefasPorSubordinado(int idSubordinado)
        {
            try
            {
                var result = _repo.ContarTarefasPorSubordinado(idSubordinado);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }


        [HttpGet("usuario/gestor/{idGestor}/tarefa/total")]
        public IActionResult ConsultarTotalTarefasGestor(int idGestor)
        {
            try
            {
                var result = _repo.ConsultarTotalTarefasGestor(idGestor);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("usuario/gestor/{idGestor}/tarefa/todas")]
        public IActionResult ConsultarTodasTarefasGestor(int idGestor)
        {
            try
            {
                var result = _repo.ConsultarTodasTarefasGestor(idGestor);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("usuario/gestor/{idGestor}/tarefa/status/{idStatusTarefa}")]
        public IActionResult ConsultarTarefasGestorStatus(int idGestor, int idStatusTarefa)
        {
            try
            {
                var result = _repo.ConsultarTarefasGestorStatus(idGestor, idStatusTarefa);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // TODO: Usar método encapsulado no baseController para retorno de error
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("usuario/gestor/{idGestor}/tarefa/pendentes")]
        public IActionResult ConsultarTarefasGestor(int idGestor)
        {
            try
            {
                var result = _repo.ConsultarTarefasGestor(idGestor);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }

        }

        [HttpGet("usuario/{idSubordinado}/tarefa/todas")]
        public IActionResult ConsultarTarefasUsuario(int idSubordinado)
        {
            try
            {
                var result = _repo.ConsultarTarefasUsuario(idSubordinado);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("usuario/{idSubordinado}/tarefa/status/{idStatusTarefa}")]
        public IActionResult ConsultarTarefasStatusUsuario(int idSubordinado, int idStatusTarefa)
        {
            try
            {
                var result = _repo.ConsultarTarefasStatusUsuario(idSubordinado, idStatusTarefa);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        // post - usuario/0/tarefa
        // get - usuario/0/tarefa/pendentes
        // get - usuario/0/tarefa/0/

    }
}