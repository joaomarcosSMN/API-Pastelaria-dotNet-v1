using System;
using Microsoft.AspNetCore.Mvc;
using PastelariaSMN.Data;
using PastelariaSMN.Models;

namespace PastelariaSMN.Controllers
{
    
    [ApiController]
    // [Route("api/[controller]")]
    [Route("api")]
    public class TarefaController : ControllerBase
    {
        public readonly IRepository _repo;
        public TarefaController(IRepository repo) 
        {
            _repo = repo;
        }

        [HttpGet("tarefa/{IdTarefa}/comentarios")]
        public IActionResult GetComentarioByIdTarefa(int idTarefa)
        {
            var result = _repo.ConsultarComentarios(idTarefa);
            return Ok(result);
        }

        [HttpPost("tarefa/criar")]
        public IActionResult PostTarefa(Tarefa novaTarefa)
        {
            var descricao = novaTarefa.Descricao;
            var dataLimite = novaTarefa.DataLimite;
            var idGestor = novaTarefa.IdGestor;
            var idSubordinado = novaTarefa.IdSubordinado;
            var idStatusTarefa = novaTarefa.IdStatusTarefa;  
            
            var result = _repo.CriarTarefa(descricao, 
                                           dataLimite,
                                           idGestor,
                                           idSubordinado,
                                           idStatusTarefa);
            return Ok(result);
        }

        [HttpPatch("tarefa/{idTarefa}/datalimite")]
        public IActionResult PatchDataLimite(int idTarefa, Tarefa tarefaEditada)
        {           
            var result = _repo.EditarDataLimite(idTarefa, tarefaEditada.DataLimite);
            return Ok(result);
        }

        [HttpPatch("tarefa/{idTarefa}/status")]
        // public IActionResult AtualizarStatusTarefa(int idTarefa, int novoStatus)
        public IActionResult AtualizarStatusTarefa(int idTarefa, Tarefa tarefaEditada)
        {
            var result = _repo.AlterarStatusDaTarefa(idTarefa, tarefaEditada.IdStatusTarefa);
            return Ok(result);
        }

        [HttpPatch("tarefa/{idTarefa}/concluir")]
        public IActionResult ConcluirTarefa(int idTarefa)
        {
            var result = _repo.ConcluirTarefa(idTarefa);
            return Ok(result);
        }

        [HttpGet("usuario/{idSubordinado}/tarefa/quantidade")]
        public IActionResult GetQuantidadeTarefasFromSubordinado(int idSubordinado)
        {
            var result = _repo.ContarTarefasPorSubordinado(idSubordinado);
            return Ok(result);
        }

        [HttpPatch("tarefa/{idTarefa}/cancelar")]
        public IActionResult CancelarTarefa(int idTarefa)
        {
            var result = _repo.CancelarTarefa(idTarefa);
            return Ok(result);
            
        }

        [HttpGet("usuario/gestor/{idGestor}/tarefa/total")]
        public IActionResult GetQuantidadeTarefasFromGestor(int idGestor)
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


        // post - usuario/0/tarefa
        // get - usuario/0/tarefa/pendentes
        // get - usuario/0/tarefa/0/

    }
}