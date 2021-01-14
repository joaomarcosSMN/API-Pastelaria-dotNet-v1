using System;
using Microsoft.AspNetCore.Mvc;
using PastelariaSMN.Data;
using PastelariaSMN.Models;

namespace PastelariaSMN.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
        public readonly IRepository _repo;
        public TarefaController(IRepository repo) 
        {
            _repo = repo;
        }

        [HttpGet("{IdTarefa}/comentarios")]
        public IActionResult GetComentarioByIdTarefa(int idTarefa)
        {
            var result = _repo.ConsultarComentarios(idTarefa);
            return Ok(result);
        }

        [HttpPost("CriarTarefa")]
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

        [HttpPut("att/{idTarefa}")]
        public IActionResult AtualizarStatusTarefa(int idTarefa, int novoStatus)
        {
            var result = _repo.AlterarStatusDaTarefa(idTarefa, novoStatus);
            return Ok(result);
        }

        [HttpPatch("{idTarefa/concluir}")]
        public IActionResult ConcluirTarefa(int idTarefa)
        {
            var result = _repo.ConcluirTarefa(idTarefa);
            return Ok(result);
            
        }

        [HttpPatch("{idTarefa/cancelar}")]
        public IActionResult CancelarTarefa(int idTarefa)
        {
            var result = _repo.CancelarTarefa(idTarefa);
            return Ok(result);
            
        }
    }
}