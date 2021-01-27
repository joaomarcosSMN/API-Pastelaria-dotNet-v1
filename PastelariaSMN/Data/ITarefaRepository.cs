using System;
using PastelariaSMN.Controllers;
using PastelariaSMN.DTOs;
using PastelariaSMN.Models;

namespace PastelariaSMN.Data
{
    public interface ITarefaRepository
    {
        int CriarTarefa(string descricao, DateTime dataLimite, int idGestor, int idSubordinado, int idStatusTarefa);
        int EditarDataLimite(int idTarefa, DateTime novaDataLimite);
        int CriarComentario(string comentario, int idTarefa);
        int ContarTarefasPorSubordinado(int idSubordinado);
        int ConsultarTotalTarefasGestor(int idGestor);
        Tarefa[] ConsultarTarefasUsuario(int idUsuario);
        Tarefa[] ConsultarTarefasStatusUsuario(int idUsuario, int idStatusTarefa);
        Tarefa[] ConsultarTarefasGestorStatus(int idGestor, int idStatusTarefa);
        Tarefa[] ConsultarTarefasGestor(int idGestor);
        int ConcluirTarefa(int idTarefa);
        int CancelarTarefa(int idTarefa);
        int AlterarStatusDaTarefa(int idTarefa, int novoStatus);
        Tarefa[] ConsultarTodasTarefasGestor(int idGestor);
        Comentario[] ConsultarComentarioTarefa(int TarefaId);
        SendMailsDTO ConsultarEmailGestorNomeSubordinado(int idTarefa);
    }
}