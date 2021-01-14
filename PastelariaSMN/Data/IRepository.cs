using System;
using PastelariaSMN.Models;

namespace PastelariaSMN.Data
{
    public interface IRepository
    {

        // PROC 006
        Comentario[] ConsultarComentarios(int TarefaId);
        // PROC 007
        int CriarTarefa(string descricao, 
                        DateTime dataLimite,
                        int idGestor,
                        int idSubordinado,
                        int idStatusTarefa);
        int EditarDataLimite(int idTarefa, DateTime novaDataLimite);
        int DesativarUsuario(int idUsuario);
        int CriarUsuario(string nome, string sobrenome, DateTime dataNascimento, string senha, bool eGestor, bool estaAtivo, int? idGestor);
        int CriarComentario(string comentario, int idTarefa);
        int ContarTarefasPorSubordinado(int idSubordinado);
        Usuario[] ConsultarUsuariosDoGestor(int idGestor);
        Usuario ConsultarUsuario(int idUsuario);
        int ConsultarTotalTarefasGestor(int idGestor);
        Usuario VericarLogin(string email);
        Tarefa[] ConsultarTarefasUsuario(int idUsuario);
        Tarefa[] ConsultarTarefasStatusUsuario(int idUsuario, int idStatusTarefa);
        Tarefa[] ConsultarTarefasGestorStatus(int idGestor, int idStatusTarefa);
        Tarefa[] ConsultarTarefasGestor(int idGestor);
        Comentario[] ConsultarComentarioTarefa(int idTarefa);
        int ConcluirTarefa(int idTarefa);
        int CancelarTarefa(int idTarefa);
        // PROC 013
        int AtualizarUsuario(int idUsuario, string nome, string sobrenome, string senha);
        //PROC 021
        int AtivarUsuario(int idUsuario);
        int AtivarDesativarUsuario(int idUsuario);
        int AlterarStatusDaTarefa(int idTarefa, int novoStatus);
        Tarefa[] ConsultarTodasTarefasGestor(int idGestor);
    }
}