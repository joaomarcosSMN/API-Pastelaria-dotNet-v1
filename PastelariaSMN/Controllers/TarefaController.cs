using System;
using Microsoft.AspNetCore.Mvc;
using PastelariaSMN.Data;
using PastelariaSMN.DTOs;
using PastelariaSMN.Models;

namespace PastelariaSMN.Controllers
{
    
    [ApiController]
    [Route("api")]
    public class TarefaController : ControllerBase
    {
        public readonly ITarefaRepository _repo;
        public TarefaController(ITarefaRepository repo) 
        {
            _repo = repo;
        }
        
        [HttpPatch("tarefa/{idTarefa}/status")]
        public IActionResult AlterarStatusDaTarefa(int idTarefa, Tarefa tarefaEditada)
        {
            var result = _repo.AlterarStatusDaTarefa(idTarefa, tarefaEditada.IdStatusTarefa);
            return Ok(result);
        }
        
        [HttpPatch("tarefa/{idTarefa}/cancelar")]
        public IActionResult CancelarTarefa(int idTarefa)
        {
            var result = _repo.CancelarTarefa(idTarefa);
            return Ok(result);
        }

        [HttpGet("tarefa/{IdTarefa}/comentarios")]
        public IActionResult ConsultarComentarioTarefa(int idTarefa)
        {
            var result = _repo.ConsultarComentarioTarefa(idTarefa);
            return Ok(result);
        }

        [HttpPost("tarefa/criar")]
        public IActionResult CriarTarefa(Tarefa novaTarefa)
        {
            
            var result = _repo.CriarTarefa(novaTarefa.Descricao, 
                                           novaTarefa.DataLimite,
                                           novaTarefa.IdGestor,
                                           novaTarefa.IdSubordinado,
                                           novaTarefa.IdStatusTarefa);
            return Ok(result);
        }

        [HttpPatch("tarefa/{idTarefa}/datalimite")]
        public IActionResult EditarDataLimite(int idTarefa, Tarefa tarefaEditada)
        {           
            var result = _repo.EditarDataLimite(idTarefa, tarefaEditada.DataLimite);
            return Ok(result);
        }


        [HttpPatch("tarefa/{idTarefa}/concluir")]
        public IActionResult ConcluirTarefa(int idTarefa)
        {
            var result = _repo.ConcluirTarefa(idTarefa);
            return Ok(result);
        }

        [HttpGet("usuario/{idSubordinado}/tarefa/quantidade")]
        public IActionResult ContarTarefasPorSubordinado(int idSubordinado)
        {
            var result = _repo.ContarTarefasPorSubordinado(idSubordinado);
            return Ok(result);
        }


        [HttpGet("usuario/gestor/{idGestor}/tarefa/total")]
        public IActionResult ConsultarTotalTarefasGestor(int idGestor)
        {
            var result = _repo.ConsultarTotalTarefasGestor(idGestor);
            return Ok(result);
        }

        [HttpGet("usuario/gestor/{idGestor}/tarefa/todas")]
        public IActionResult ConsultarTodasTarefasGestor(int idGestor)
        {
            var result = _repo.ConsultarTodasTarefasGestor(idGestor);
            return Ok(result);
        }

        [HttpGet("usuario/gestor/{idGestor}/tarefa/status/{idStatusTarefa}")]
        public IActionResult ConsultarTarefasGestorStatus(int idGestor, int idStatusTarefa)
        {
            var result = _repo.ConsultarTarefasGestorStatus(idGestor, idStatusTarefa);
            return Ok(result);
        }

        [HttpGet("usuario/gestor/{idGestor}/tarefa/pendentes")]
        public IActionResult ConsultarTarefasGestor(int idGestor)
        {
            var result = _repo.ConsultarTarefasGestor(idGestor);
            return Ok(result);
        }

        [HttpGet("usuario/{idSubordinado}/tarefa/todas")]
        public IActionResult ConsultarTarefasUsuario(int idSubordinado)
        {
            var result = _repo.ConsultarTarefasUsuario(idSubordinado);
            return Ok(result);
        }

        [HttpGet("usuario/{idSubordinado}/tarefa/status/{idStatusTarefa}")]
        public IActionResult ConsultarTarefasStatusUsuario(int idSubordinado, int idStatusTarefa)
        {
            var result = _repo.ConsultarTarefasStatusUsuario(idSubordinado, idStatusTarefa);
            return Ok(result);
        }

        // post - usuario/0/tarefa
        // get - usuario/0/tarefa/pendentes
        // get - usuario/0/tarefa/0/

    }
}