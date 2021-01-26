using System;
using PastelariaSMN.Controllers;
using PastelariaSMN.DTOs;
using PastelariaSMN.Models;

namespace PastelariaSMN.Data
{
    public interface ITarefaRepository
    {
        RepositoryResult<int> CriarTarefa(string descricao, DateTime dataLimite, int idGestor, int idSubordinado, int idStatusTarefa);
        RepositoryResult<int> EditarDataLimite(int idTarefa, DateTime novaDataLimite);
        RepositoryResult<int> CriarComentario(string comentario, int idTarefa);
        RepositoryResult<int> ContarTarefasPorSubordinado(int idSubordinado);
        RepositoryResult<int> ConsultarTotalTarefasGestor(int idGestor);
        RepositoryResult<TarefaDTO[]> ConsultarTarefasUsuario(int idUsuario);
        RepositoryResult<Tarefa[]> ConsultarTarefasStatusUsuario(int idUsuario, int idStatusTarefa);
        RepositoryResult<Tarefa[]> ConsultarTarefasGestorStatus(int idGestor, int idStatusTarefa);
        RepositoryResult<Tarefa[]> ConsultarTarefasGestor(int idGestor);
        RepositoryResult<int> ConcluirTarefa(RepositoryResult<int> idTarefa);
        RepositoryResult<int> CancelarTarefa(int idTarefa);
        RepositoryResult<int> AlterarStatusDaTarefa(int idTarefa, int novoStatus);
        RepositoryResult<TarefaDTO[]> ConsultarTodasTarefasGestor(int idGestor);
        RepositoryResult<Comentario[]> ConsultarComentarioTarefa(int TarefaId);
        SendMailsDTO ConsultarEmailGestorNomeSubordinado(RepositoryResult<int> idTarefa);
    }
}