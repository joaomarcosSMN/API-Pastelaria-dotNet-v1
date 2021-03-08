using System;
using PastelariaSMN.Models;

namespace PastelariaSMN.Data
{
    public interface ITarefaRepository
    {
        int CriarTarefa(string descricao, DateTime dataLimite, int idGestor, int idSubordinado, int idStatusTarefa);
        int EditarDataLimite(int idTarefa, DateTime novaDataLimite);
        int CriarComentario(string comentario, int idTarefa, int idUsuario);
        int ConsultarTotalTarefas(int idUsuario);
        Tarefa[] ConsultarTodasTarefasUsuario(int idUsuario);
        Tarefa[] ConsultarTarefasPorStatus(int idUsuario, int idStatusTarefa);
        Tarefa[] ConsultarTarefasAndamento(int idUsuario);
        int ConcluirTarefa(int idTarefa);
        int CancelarTarefa(int idTarefa);
        int AlterarStatusDaTarefa(int idTarefa, int novoStatus);
        Comentario[] ConsultarComentarioTarefa(int TarefaId);
        Tarefa ConsultarEmailGestorNomeSubordinado(int idTarefa);
        Tarefa ConsultarTarefa(int idTarefa);
    }
}