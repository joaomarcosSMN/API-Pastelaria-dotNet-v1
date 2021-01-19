using System;
using System.Collections.Generic;
using PastelariaSMN.Models;

namespace PastelariaSMN.Data
{

  public class TarefaRepository : BaseRepository, ITarefaRepository
  {
    private enum Procedures 
    {
      SP_AlterarStatusDaTarefa,
      SP_CancelarTarefa,
      SP_ConcluirTarefa,
      SP_ConsultarComentarioTarefa,
      SP_ConsultarTarefasGestor,
      SP_ConsultarTarefasGestorStatus,
      SP_ConsultarTarefasStatusUsuario,
      SP_ConsultarTarefasUsuario,
      SP_ConsultarTodasTarefasGestor,
      SP_ConsultarTotalTarefasGestor,
      SP_ContarTarefasPorSubordinado,
      SP_CriarComentario,
      SP_CriarTarefa,
      SP_EditarDataLimite,

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
      SetProcedure(Procedures.SP_CancelarTarefa);

      AddParameter("IdTarefa", idTarefa);

      return ExecuteNonQuery();
    }

    public int ConcluirTarefa(int idTarefa)
    {
      SetProcedure(Procedures.SP_ConcluirTarefa);

      AddParameter("IdTarefa", idTarefa);

      return ExecuteNonQuery();
    }

    public Comentario[] ConsultarComentarioTarefa(int TarefaId)
    {
      SetProcedure(Procedures.SP_ConsultarComentarioTarefa);
      AddParameter("IdTarefa", TarefaId);

      List<Comentario> result = new List<Comentario>();

      var reader = ExecuteReader();
      while(reader.Read())
      {
        result.Add( new Comentario {
          IdComentario = (short)reader["IdComentario"],
          Descricao = (string)reader["Descricao"],
          IdTarefa = (short)reader["IdTarefa"]
        });
      }
      return result.ToArray();

    }

    public Tarefa[] ConsultarTarefasGestor(int idGestor)
    {
      SetProcedure(Procedures.SP_ConsultarTarefasGestor);
      AddParameter("IdGestor", idGestor);

      List<Tarefa> result = new List<Tarefa>();

      var reader = ExecuteReader();
      while(reader.Read())
      {
        result.Add( new Tarefa {
          IdTarefa = (short)reader["IdTarefa"],
          Descricao = (string)reader["Descricao"],
          DataCadastro = (DateTime)reader["DataCadastro"],
          DataLimite = (DateTime)reader["DataLimite"],
          IdGestor = (short)reader["IdGestor"],
          IdSubordinado = (short)reader["IdSubordinado"],
          IdStatusTarefa = (byte)reader["IdStatusTarefa"]
        });
      }
      return result.ToArray();
    }

//  ToDo
//  Tratamendo para o retorno de data cancelada e de conclusao
    public Tarefa[] ConsultarTarefasGestorStatus(int idGestor, int idStatusTarefa)
    {
      SetProcedure(Procedures.SP_ConsultarTarefasGestorStatus);
      AddParameter("IdGestor", idGestor);
      AddParameter("IdStatusTarefa", idStatusTarefa);

      List<Tarefa> result = new List<Tarefa>();

      var reader = ExecuteReader();
      while(reader.Read())
      {
        result.Add( new Tarefa {
          IdTarefa = (short)reader["IdTarefa"],
          Descricao = (string)reader["Descricao"],
          DataCadastro = (DateTime)reader["DataCadastro"],
          DataLimite = (DateTime)reader["DataLimite"],
          IdGestor = (short)reader["IdGestor"],
          IdSubordinado = (short)reader["IdSubordinado"],
          IdStatusTarefa = (byte)reader["IdStatusTarefa"]
        });
      }
      return result.ToArray();
    }

//  ToDo
//  Tratamendo para o retorno de data cancelada e de conclusao
    public Tarefa[] ConsultarTarefasStatusUsuario(int idUsuario, int idStatusTarefa)
    {
      SetProcedure(Procedures.SP_ConsultarTarefasGestorStatus);
      AddParameter("IdGestor", idUsuario);
      AddParameter("IdStatusTarefa", idStatusTarefa);

      List<Tarefa> result = new List<Tarefa>();

      var reader = ExecuteReader();
      while(reader.Read())
      {
        result.Add( new Tarefa {
          IdTarefa = (short)reader["IdTarefa"],
          Descricao = (string)reader["Descricao"],
          DataCadastro = (DateTime)reader["DataCadastro"],
          DataLimite = (DateTime)reader["DataLimite"],
          IdGestor = (short)reader["IdGestor"],
          IdSubordinado = (short)reader["IdSubordinado"],
          IdStatusTarefa = (byte)reader["IdStatusTarefa"],
          DataCancelada = (DateTime)reader["DataCancelada"],
          DataConclusao = (DateTime)reader["DataConclusao"]
        });
      }
      return result.ToArray();
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