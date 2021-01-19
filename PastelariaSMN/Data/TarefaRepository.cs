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
        Tarefa tarefa = new Tarefa();

        tarefa.IdTarefa = (short)reader["IdTarefa"];
        tarefa.Descricao = (string)reader["Descricao"];
        tarefa.DataCadastro = (DateTime)reader["DataCadastro"];
        tarefa.DataLimite = (DateTime)reader["DataLimite"];
        tarefa.IdGestor = (short)reader["IdGestor"];
        tarefa.IdSubordinado = (short)reader["IdSubordinado"];
        tarefa.IdStatusTarefa = (byte)reader["IdStatusTarefa"];

        if(reader["DataConclusao"].ToString() != "")
          tarefa.DataConclusao = (DateTime)reader["DataConclusao"];
        if(reader["DataCancelada"].ToString() != "")
          tarefa.DataCancelada = (DateTime)reader["DataCancelada"];

        result.Add(tarefa);
      };
      return result.ToArray();
    }
    

//  ToDo
//  Tratamendo para o retorno de data cancelada e de conclusao
    public Tarefa[] ConsultarTarefasStatusUsuario(int idUsuario, int idStatusTarefa)
    {
      SetProcedure(Procedures.SP_ConsultarTarefasStatusUsuario);
      AddParameter("IdUsuario", idUsuario);
      AddParameter("IdStatusTarefa", idStatusTarefa);

      List<Tarefa> result = new List<Tarefa>();

      var reader = ExecuteReader();
      while(reader.Read())
      {
        Tarefa tarefa = new Tarefa();

        tarefa.IdTarefa = (short)reader["IdTarefa"];
        tarefa.Descricao = (string)reader["Descricao"];
        tarefa.DataCadastro = (DateTime)reader["DataCadastro"];
        tarefa.DataLimite = (DateTime)reader["DataLimite"];
        tarefa.IdGestor = (short)reader["IdGestor"];
        tarefa.IdSubordinado = (short)reader["IdSubordinado"];
        tarefa.IdStatusTarefa = (byte)reader["IdStatusTarefa"];

        if(reader["DataConclusao"].ToString() != "")
          tarefa.DataConclusao = (DateTime)reader["DataConclusao"];
        if(reader["DataCancelada"].ToString() != "")
          tarefa.DataCancelada = (DateTime)reader["DataCancelada"];

        result.Add(tarefa);
      }
      return result.ToArray();
    }

    public Tarefa[] ConsultarTarefasUsuario(int idUsuario)
    {
      SetProcedure(Procedures.SP_ConsultarTarefasUsuario);
      AddParameter("IdUsuario", idUsuario);

      List<Tarefa> result = new List<Tarefa>();

      var reader = ExecuteReader();
      while(reader.Read())
      {
        Tarefa tarefa = new Tarefa();

        tarefa.IdTarefa = (short)reader["IdTarefa"];
        tarefa.Descricao = (string)reader["Descricao"];
        tarefa.DataCadastro = (DateTime)reader["DataCadastro"];
        tarefa.DataLimite = (DateTime)reader["DataLimite"];
        tarefa.IdGestor = (short)reader["IdGestor"];
        tarefa.IdSubordinado = (short)reader["IdSubordinado"];
        tarefa.IdStatusTarefa = (byte)reader["IdStatusTarefa"];

        if(reader["DataConclusao"].ToString() != "")
          tarefa.DataConclusao = (DateTime)reader["DataConclusao"];
        if(reader["DataCancelada"].ToString() != "")
          tarefa.DataCancelada = (DateTime)reader["DataCancelada"];

        result.Add(tarefa);
      }
      return result.ToArray();
    }

    public Tarefa[] ConsultarTodasTarefasGestor(int idGestor)
    {
      SetProcedure(Procedures.SP_ConsultarTodasTarefasGestor);
      AddParameter("IdGestor", idGestor);

      List<Tarefa> result = new List<Tarefa>();

      var reader = ExecuteReader();
      while(reader.Read())
      {
        Tarefa tarefa = new Tarefa();

        tarefa.IdTarefa = (short)reader["IdTarefa"];
        tarefa.Descricao = (string)reader["Descricao"];
        tarefa.DataCadastro = (DateTime)reader["DataCadastro"];
        tarefa.DataLimite = (DateTime)reader["DataLimite"];
        tarefa.IdStatusTarefa = (byte)reader["IdStatusTarefa"];

        if(reader["DataConclusao"].ToString() != "")
          tarefa.DataConclusao = (DateTime)reader["DataConclusao"];
        if(reader["DataCancelada"].ToString() != "")
          tarefa.DataCancelada = (DateTime)reader["DataCancelada"];

        result.Add(tarefa);
      }
      return result.ToArray();
    }

    public int ConsultarTotalTarefasGestor(int idGestor)
    {
      SetProcedure(Procedures.SP_ConsultarTotalTarefasGestor);

            AddParameter("IdGestor", idGestor);

            var reader = ExecuteReader();
            reader.Read();
            return (int)reader["TotalTarefas"];
    }

    public int ContarTarefasPorSubordinado(int idSubordinado)
    {
      SetProcedure(Procedures.SP_ContarTarefasPorSubordinado);

            AddParameter("IdSubordinado", idSubordinado);

            var reader = ExecuteReader();
            reader.Read();
            return (int)reader["Total"];
    }

    public int CriarComentario(string comentario, int idTarefa)
    {
      SetProcedure(Procedures.SP_CriarComentario);
            AddParameter("Comentario", comentario);
            AddParameter("IdTarefa", idTarefa);
            return ExecuteNonQuery();
    }

    public int CriarTarefa(string descricao, DateTime dataLimite, int idGestor, int idSubordinado, int idStatusTarefa)
    {
      SetProcedure(Procedures.SP_CriarTarefa);

      AddParameter("Descricao", descricao);
      AddParameter("DataLimite", dataLimite);
      AddParameter("IdGestor", idGestor);
      AddParameter("IdSubordinado", idSubordinado);
      AddParameter("IdStatusTarefa", idStatusTarefa);
                   
      return ExecuteNonQuery();
    }

    public int EditarDataLimite(int idTarefa, DateTime novaDataLimite)
    {
      SetProcedure(Procedures.SP_CriarTarefa);

      AddParameter("IdTarefa", idTarefa);
      AddParameter("DataLimite", novaDataLimite);

      return ExecuteNonQuery();
    }
  }
}