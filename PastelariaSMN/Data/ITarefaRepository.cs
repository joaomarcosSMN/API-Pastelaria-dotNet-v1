using System;
using PastelariaSMN.Controllers;
using PastelariaSMN.Models;

namespace PastelariaSMN.Data
{
    public interface ITarefaRepository
    {
        int CriarTarefa(string descricao, DateTime dataLimite, int idGestor, int idSubordinado, int idStatusTarefa);
        int EditarDataLimite(int idTarefa, DateTime novaDataLimite);
        int CriarComentario(string comentario, int idTarefa, int idUsuario);
        
        // Mudança 
        int ConsultarTotalTarefas(int idUsuario);
        // int ContarTarefasPorSubordinado(int idSubordinado);
        // int ConsultarTotalTarefasGestor(int idGestor);      

        //Mudança
        Tarefa[] ConsultarTodasTarefasUsuario(int idUsuario);
        // Tarefa[] ConsultarTarefasUsuario(int idUsuario);
        
        // Mudança
        Tarefa[] ConsultarTarefasPorStatus(int idUsuario, int idStatusTarefa);
        // Tarefa[] ConsultarTarefasStatusUsuario(int idUsuario, int idStatusTarefa);
        // Tarefa[] ConsultarTarefasGestorStatus(int idGestor, int idStatusTarefa);
        // Tarefa[] ConsultarTarefasGestor(int idGestor);
        
        // Mudança
        Tarefa[] ConsultarTarefasAndamento(int idUsuario);
        int ConcluirTarefa(int idTarefa);
        int CancelarTarefa(int idTarefa);
        int AlterarStatusDaTarefa(int idTarefa, int novoStatus);
        // Tarefa[] ConsultarTodasTarefasGestor(int idGestor);
        Comentario[] ConsultarComentarioTarefa(int TarefaId);
        Tarefa ConsultarEmailGestorNomeSubordinado(int idTarefa);
        Tarefa ConsultarTarefa(int idTarefa);
    }
}