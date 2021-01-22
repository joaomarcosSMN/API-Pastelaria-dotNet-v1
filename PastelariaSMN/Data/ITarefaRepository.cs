using System;
using PastelariaSMN.Controllers;
using PastelariaSMN.DTOs;
using PastelariaSMN.Models;

namespace PastelariaSMN.Data
{
    public interface ITarefaRepository
    {
        Comentario[] ConsultarComentarioTarefa(int TarefaId);
        int CriarTarefa(string descricao, DateTime dataLimite, int idGestor, int idSubordinado, int idStatusTarefa);
        int EditarDataLimite(int idTarefa, DateTime novaDataLimite);
        int CriarComentario(string comentario, int idTarefa);
        int ContarTarefasPorSubordinado(int idSubordinado);
        int ConsultarTotalTarefasGestor(int idGestor);
        TarefaDTO[] ConsultarTarefasUsuario(int idUsuario);
        Tarefa[] ConsultarTarefasStatusUsuario(int idUsuario, int idStatusTarefa);
        Tarefa[] ConsultarTarefasGestorStatus(int idGestor, int idStatusTarefa);
        Tarefa[] ConsultarTarefasGestor(int idGestor);
        string ConcluirTarefa(int idTarefa);
        int CancelarTarefa(int idTarefa);
        RepositoryResult<int> AlterarStatusDaTarefa(int idTarefa, int novoStatus);
        TarefaDTO[] ConsultarTodasTarefasGestor(int idGestor);
    }
}