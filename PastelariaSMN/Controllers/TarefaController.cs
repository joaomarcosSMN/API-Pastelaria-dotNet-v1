using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PastelariaSMN.Data;
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
        public readonly NotificationList _notifications;
        public TarefaController(EmailSettings options, ITarefaRepository repo, NotificationList notifications) 
        {
            _options = options;
            _repo = repo;
            _notifications = notifications;
        }
        
        [HttpPut("tarefa/{idTarefa}/status")]
        public IActionResult AlterarStatusDaTarefa(int idTarefa, Tarefa tarefaEditada)
        {
            tarefaEditada.is_validStatus(_notifications);

            if(_notifications.HasNotifications)
            {
                return BadRequest(_notifications.Notifications);
            }

            var result = _repo.AlterarStatusDaTarefa(idTarefa, tarefaEditada.IdStatusTarefa);
            
            if(result == 0) {
                return BadRequest("Não foi possível fazer a alteração"); 
            }
            return Ok("Alteração feita com sucesso.");
           
        }
        
        [HttpPut("tarefa/{idTarefa}/cancelar")]
        public IActionResult CancelarTarefa(int idTarefa)
        {
                       
            var result = _repo.CancelarTarefa(idTarefa);
            if(result == 0)
            {
                return NotFound("Tarefa não encontrada");
            }
            return Ok(result);
            
        }

        // AQUI
        [HttpGet("tarefa/{IdTarefa}/comentarios")]
        public IActionResult ConsultarComentarioTarefa(int idTarefa)
        {
            
            var result = _repo.ConsultarComentarioTarefa(idTarefa);
            if (!result.Any())
            {
                return BadRequest("Tarefa não possui comentarios.");
            }
            return Ok(result); 
            
        }

        // AQUI
        [HttpPost("tarefa/{idTarefa}/comentario/criar")]
        public IActionResult CriarComentario(Comentario novoComentario, int idTarefa)
        {
            novoComentario.is_valid(_notifications);

            if(_notifications.HasNotifications)
            {
                return BadRequest(_notifications.Notifications);
            }

            var result = _repo.CriarComentario(novoComentario.Descricao,
                                               idTarefa, 
                                               novoComentario.IdUsuario
                                               );
            if(result == 0)
            {
                return BadRequest("Tarefa não criada");
            }
            return Ok(result);
        }

        [HttpPost("tarefa/criar")]
        public IActionResult CriarTarefa(Tarefa novaTarefa)
        {
            novaTarefa.is_valid(_notifications);

            if(_notifications.HasNotifications)
            {
                return BadRequest(_notifications.Notifications);
            }
            
            var result = _repo.CriarTarefa(novaTarefa.Descricao, 
                                            novaTarefa.DataLimite,
                                            novaTarefa.IdGestor,
                                            novaTarefa.IdSubordinado,
                                            novaTarefa.IdStatusTarefa);
            if(result == 0)
            {
                return BadRequest("Tarefa não criada");
            }

            // result retorna int idTarefa da tarefa recem criada
            var emailData = _repo.ConsultarEmailGestorNomeSubordinado(result);
            
            // string body = "O seu gestor " + result.NomeGestor + " criou uma tarefa";
            string body = $"O seu gestor { emailData.Gestor.Nome } { emailData.Gestor.Sobrenome } criou uma tarefa com a descrição: '{ novaTarefa.Descricao }'.";

            EmailSent.SendEmail(_options, emailData.Subordinado.Email.EnderecoEmail, $"Uma tarefa foi criada para você pelo seu gestor { emailData.Gestor.Nome } { emailData.Gestor.Sobrenome }", body);

            return Ok($"Tarefa com id {result} foi criada");

        }

        [HttpPut("tarefa/{idTarefa}/datalimite")]
        public IActionResult EditarDataLimite(int idTarefa, Tarefa tarefaEditada)
        {           
            Console.WriteLine(tarefaEditada.DataLimite.GetType() +" "+ tarefaEditada.DataLimite);
            var result = _repo.EditarDataLimite(idTarefa, tarefaEditada.DataLimite);
            if(result == 0)
            {
                Console.WriteLine(tarefaEditada.DataLimite);
                Console.WriteLine(tarefaEditada.DataLimite.GetType());
                
                return BadRequest("Data limite não editada");
            }
            Console.WriteLine("ok");
            return Ok(result);
            
        }

        [HttpPut("tarefa/{idTarefa}/concluir")]
        public IActionResult ConcluirTarefa(int idTarefa)
        {
            var result = _repo.ConcluirTarefa(idTarefa);

            if(result == 0)
            {
                return BadRequest("Tarefa não concluida");
            }

            var emailData = _repo.ConsultarEmailGestorNomeSubordinado(idTarefa);

            string body = $"O seu subordinado { emailData.Subordinado.Nome } { emailData.Subordinado.Sobrenome } concluiu uma tarefa";

            EmailSent.SendEmail(_options, emailData.Gestor.Email.EnderecoEmail, "Uma tarefa foi concluida por um subordinado seu!", body);

            return Ok(result);
        }

        // Mudança
        [HttpGet("usuario/{idUsuario}/tarefa/total")]
        public IActionResult ConsultarTotalTarefas(int idUsuario)
        {
            
            var result = _repo.ConsultarTotalTarefas(idUsuario);
            return Ok(result);
            
        }

        // [HttpGet("usuario/{idSubordinado}/tarefa/quantidade")]
        // public IActionResult ContarTarefasPorSubordinado(int idSubordinado)
        // {
            
        //     var result = _repo.ContarTarefasPorSubordinado(idSubordinado);
        //     return Ok(result);
            
        // }

        // [HttpGet("usuario/gestor/{idGestor}/tarefa/total")]
        // public IActionResult ConsultarTotalTarefasGestor(int idGestor)
        // {
        //     var result = _repo.ConsultarTotalTarefasGestor(idGestor);
        //     return Ok(result);
        // }

        [HttpGet("usuario/{idUsuario}/tarefa/todas")]
        public IActionResult ConsultarTodasTarefasUsuario(int idUsuario)
        {
            var result = _repo.ConsultarTodasTarefasUsuario(idUsuario);
            if(!result.Any())
            {
                return BadRequest("Usuario não tem tarefas");
            }
            return Ok(result);
        }

        // [HttpGet("usuario/gestor/{idGestor}/tarefa/todas")]
        // public IActionResult ConsultarTodasTarefasGestor(int idGestor)
        // {
        //     var result = _repo.ConsultarTodasTarefasGestor(idGestor);
        //     if(!result.Any())
        //     {
        //         return BadRequest("Gestor não tem tarefas");
        //     }
        //     return Ok(result);
        // }

        [HttpGet("usuario/{idUsuario}/tarefa/status/{idStatusTarefa}")]
        public IActionResult ConsultarTarefasPorStatus(int idUsuario, int idStatusTarefa)
        {
            var result = _repo.ConsultarTarefasPorStatus(idUsuario, idStatusTarefa);
            if(!result.Any())
            {
                return BadRequest("O usuário não tem tarefas com esse status");
            }
            return Ok(result);
        }

        // [HttpGet("usuario/gestor/{idGestor}/tarefa/status/{idStatusTarefa}")]
        // public IActionResult ConsultarTarefasGestorStatus(int idGestor, int idStatusTarefa)
        // {
        //     var result = _repo.ConsultarTarefasGestorStatus(idGestor, idStatusTarefa);
        //     if(!result.Any())
        //     {
        //         return BadRequest("Gestor não tem tarefas com esse status");
        //     }
        //     return Ok(result);
        // }

        [HttpGet("usuario/{idUsuario}/tarefa/andamento")]
        public IActionResult ConsultarTarefasAndamento(int idUsuario)
        {
            var result = _repo.ConsultarTarefasAndamento(idUsuario);
            if(!result.Any())
            {
                return BadRequest("O usuário não tem tarefas em andamento");
            }
            return Ok(result);
        }

        // [HttpGet("usuario/gestor/{idGestor}/tarefa/pendentes")]
        // public IActionResult ConsultarTarefasGestor(int idGestor)
        // {
        //     var result = _repo.ConsultarTarefasGestor(idGestor);
        //     if(!result.Any())
        //     {
        //         return BadRequest("Gestor não tem tarefas pendentes");
        //     }
        //     return Ok(result);
        // }

        // [HttpGet("usuario/{idSubordinado}/tarefa/todas")]
        // public IActionResult ConsultarTarefasUsuario(int idSubordinado)
        // {
        //     var result = _repo.ConsultarTarefasUsuario(idSubordinado);
        //     if(!result.Any())
        //     {
        //         return BadRequest("Usuario não tem tarefas");
        //     }
        //     return Ok(result);
        // }

        // [HttpGet("usuario/{idSubordinado}/tarefa/status/{idStatusTarefa}")]
        // public IActionResult ConsultarTarefasStatusUsuario(int idSubordinado, int idStatusTarefa)
        // {
        //     var result = _repo.ConsultarTarefasStatusUsuario(idSubordinado, idStatusTarefa);
        //     if(!result.Any())
        //     {
        //         return BadRequest("Usuario não tem tarefas com esse status");
        //     }
        //     return Ok(result);
        // }

        [HttpGet("tarefa/{idTarefa}")]
        public IActionResult ConsultarTarefa(int idTarefa)
        {
            var result = _repo.ConsultarTarefa(idTarefa);
            if(result.IdTarefa == 0)
            {
                return BadRequest("Tarefa não existe");
            }
            return Ok(result);
        }

        // post - usuario/0/tarefa
        // get - usuario/0/tarefa/pendentes
        // get - usuario/0/tarefa/0/

    }
}