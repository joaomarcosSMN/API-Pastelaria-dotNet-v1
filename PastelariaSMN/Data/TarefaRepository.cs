using System;
using PastelariaSMN.Models;

namespace PastelariaSMN.Data
{

  public class TarefaRepository : BaseRepository, ITarefaRepository
  {
    private enum Procedures 
    {
      SP_AlterarStatusDaTarefa,

    }
    public int AlterarStatusDaTarefa(int idTarefa, int novoStatus)
    {
      SetProcedure(Procedures.SP_AlterarStatusDaTarefa);

      AddParameter("IdTarefa", idTarefa);
      AddParameter("NovoStatus", novoStatus);

      return ExecuteNonQuery();
    }

    public int CancelarTarefa(int idTarefa)
    {
      SetProcedure(Procedures.SP_AlterarStatusDaTarefa);

      AddParameter("IdTarefa", idTarefa);

      return ExecuteNonQuery();
    }

    public int ConcluirTarefa(int idTarefa)
    {
      throw new NotImplementedException();
    }

    public Comentario[] ConsultarComentarioTarefa(int TarefaId)
    {
      throw new NotImplementedException();
    }

    public Tarefa[] ConsultarTarefasGestor(int idGestor)
    {
      throw new NotImplementedException();
    }

    public Tarefa[] ConsultarTarefasGestorStatus(int idGestor, int idStatusTarefa)
    {
      throw new NotImplementedException();
    }

    public Tarefa[] ConsultarTarefasStatusUsuario(int idUsuario, int idStatusTarefa)
    {
      throw new NotImplementedException();
    }

    public Tarefa[] ConsultarTarefasUsuario(int idUsuario)
    {
      throw new NotImplementedException();
    }

    public Tarefa[] ConsultarTodasTarefasGestor(int idGestor)
    {
      throw new NotImplementedException();
    }

    public int ConsultarTotalTarefasGestor(int idGestor)
    {
      throw new NotImplementedException();
    }

    public int ContarTarefasPorSubordinado(int idSubordinado)
    {
      throw new NotImplementedException();
    }

    public int CriarComentario(string comentario, int idTarefa)
    {
      throw new NotImplementedException();
    }

    public int CriarTarefa(string descricao, DateTime dataLimite, int idGestor, int idSubordinado, int idStatusTarefa)
    {
      throw new NotImplementedException();
    }

    public int EditarDataLimite(int idTarefa, DateTime novaDataLimite)
    {
      throw new NotImplementedException();
    }
  }
}