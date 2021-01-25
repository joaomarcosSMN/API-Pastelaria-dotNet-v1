using System;
using System.Collections.Generic;
using PastelariaSMN.Controllers;
using PastelariaSMN.DTOs;
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
      SP_ConsultarEmailGestorNomeSubordinado,

    }
    public RepositoryResult<int> AlterarStatusDaTarefa(int idTarefa, int novoStatus)
    {

    SetProcedure(Procedures.SP_AlterarStatusDaTarefa);

    AddParameter("IdTarefa", idTarefa);
    AddParameter("NovoStatus", novoStatus);

    var retorno = ExecuteNonQuery();

    if(retorno == 0)
        return RepositoryResult<int>.Error("Algo deu errado. Contate o servidor.");
        
    return RepositoryResult<int>.Sucess(retorno);

    }

    public RepositoryResult<int> CancelarTarefa(int idTarefa)
    {

    SetProcedure(Procedures.SP_CancelarTarefa);

    AddParameter("IdTarefa", idTarefa);

    var retorno =  ExecuteNonQuery();

    if(retorno == 0)
        return RepositoryResult<int>.Error("Algo deu errado. Contate o servidor.");

    return RepositoryResult<int>.Sucess(retorno);

    }

    public RepositoryResult<int> ConcluirTarefa(RepositoryResult<int> idTarefa)
    {

    SetProcedure(Procedures.SP_ConcluirTarefa);

    AddParameter("IdTarefa", idTarefa);

    var retorno = ExecuteNonQuery();

    if (retorno == 0)
        return RepositoryResult<int>.Error("Algo deu errado. Contate o servidor.");

    return RepositoryResult<int>.Sucess(retorno);

    }

    public RepositoryResult<Comentario[]> ConsultarComentarioTarefa(int TarefaId)
    {
      SetProcedure(Procedures.SP_ConsultarComentarioTarefa);
      AddParameter("IdTarefa", TarefaId);

      List<Comentario> retorno = new List<Comentario>();

      var reader = ExecuteReader();
      while(reader.Read())
      {
        retorno.Add( new Comentario {
          IdComentario = (short)reader["IdComentario"],
          Descricao = (string)reader["Descricao"],
          IdTarefa = (short)reader["IdTarefa"]
        });
      }
    if (retorno == null)
        return RepositoryResult<Comentario[]>.Error("Algo deu errado. Contate o servidor.");

    return RepositoryResult<Comentario[]>.Sucess(retorno.ToArray());

    }

    public RepositoryResult<Tarefa[]> ConsultarTarefasGestor(int idGestor)
    {
        SetProcedure(Procedures.SP_ConsultarTarefasGestor);
        AddParameter("IdGestor", idGestor);

        List<Tarefa> retorno = new List<Tarefa>();

        var reader = ExecuteReader();
        while(reader.Read())
        {
            retorno.Add( new Tarefa {
            IdTarefa = (short)reader["IdTarefa"],
            Descricao = (string)reader["Descricao"],
            DataCadastro = (DateTime)reader["DataCadastro"],
            DataLimite = (DateTime)reader["DataLimite"],
            IdGestor = (short)reader["IdGestor"],
            IdSubordinado = (short)reader["IdSubordinado"],
            IdStatusTarefa = (byte)reader["IdStatusTarefa"]
            });
        }
        if (retorno == null)
                return RepositoryResult<Tarefa[]>.Error("Algo deu errado. Contate o servidor.");

            return RepositoryResult<Tarefa[]>.Sucess(retorno.ToArray());
        }

//  ToDo JM
//  Tratamendo para o retorno de data cancelada e de conclusao
    public RepositoryResult<Tarefa[]> ConsultarTarefasGestorStatus(int idGestor, int idStatusTarefa)
    {
      SetProcedure(Procedures.SP_ConsultarTarefasGestorStatus);
      AddParameter("IdGestor", idGestor);
      AddParameter("IdStatusTarefa", idStatusTarefa);

      List<Tarefa> retorno = new List<Tarefa>();

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

        retorno.Add(tarefa);
      };
      if (retorno == null)
        return RepositoryResult<Tarefa[]>.Error("Algo deu errado. Contate o servidor.");

      return RepositoryResult<Tarefa[]>.Sucess(retorno.ToArray());
    }
    

//  ToDo
//  Tratamendo para o retorno de data cancelada e de conclusao
    public RepositoryResult<Tarefa[]> ConsultarTarefasStatusUsuario(int idUsuario, int idStatusTarefa)
    {
      SetProcedure(Procedures.SP_ConsultarTarefasStatusUsuario);
      AddParameter("IdUsuario", idUsuario);
      AddParameter("IdStatusTarefa", idStatusTarefa);

      List<Tarefa> retorno = new List<Tarefa>();

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

        retorno.Add(tarefa);
      }
        if (retorno == null)
            return RepositoryResult<Tarefa[]>.Error("Algo deu errado. Contate o servidor.");

        return RepositoryResult<Tarefa[]>.Sucess(retorno.ToArray());
    }

    public RepositoryResult<TarefaDTO[]> ConsultarTarefasUsuario(int idUsuario)
    {
      SetProcedure(Procedures.SP_ConsultarTarefasUsuario);
      AddParameter("IdUsuario", idUsuario);

      List<TarefaDTO> retorno = new List<TarefaDTO>();

      var reader = ExecuteReader();
      while(reader.Read())
      {
        TarefaDTO tarefa = new TarefaDTO();

        tarefa.IdTarefa = (short)reader["IdTarefa"];
        tarefa.Descricao = (string)reader["Descricao"];
        tarefa.DataCadastro = (DateTime)reader["DataCadastro"];
        tarefa.DataLimite = (DateTime)reader["DataLimite"];
        tarefa.IdStatusTarefa = (byte)reader["IdStatusTarefa"];
        tarefa.IdGestor = (short)reader["IdGestor"];
        tarefa.IdSubordinado = (short)reader["IdSubordinado"];
        tarefa.NomeGestor = (string)reader["NomeGestor"];
        tarefa.NomeSubordinado = (string)reader["NomeSubordinado"];

        if(reader["DataConclusao"].ToString() != "")
          tarefa.DataConclusao = (DateTime)reader["DataConclusao"];
        if(reader["DataCancelada"].ToString() != "")
          tarefa.DataCancelada = (DateTime)reader["DataCancelada"];

        retorno.Add(tarefa);
      }
        if (retorno == null)
            return RepositoryResult<TarefaDTO[]>.Error("Algo deu errado. Contate o servidor.");

        return RepositoryResult<TarefaDTO[]>.Sucess(retorno.ToArray());
    }

    public RepositoryResult<TarefaDTO[]> ConsultarTodasTarefasGestor(int idGestor)
    {
      SetProcedure(Procedures.SP_ConsultarTodasTarefasGestor);
      AddParameter("IdGestor", idGestor);

      List<TarefaDTO> retorno = new List<TarefaDTO>();

      var reader = ExecuteReader();
      while(reader.Read())
      {
        TarefaDTO tarefa = new TarefaDTO();

        tarefa.IdTarefa = (short)reader["IdTarefa"];
        tarefa.Descricao = (string)reader["Descricao"];
        tarefa.DataCadastro = (DateTime)reader["DataCadastro"];
        tarefa.DataLimite = (DateTime)reader["DataLimite"];
        tarefa.IdStatusTarefa = (byte)reader["IdStatusTarefa"];
        tarefa.IdGestor = (short)reader["IdGestor"];
        tarefa.IdSubordinado = (short)reader["IdSubordinado"];
        tarefa.NomeGestor = (string)reader["NomeGestor"];
        tarefa.NomeSubordinado = (string)reader["NomeSubordinado"];

        if(reader["DataConclusao"].ToString() != "")
          tarefa.DataConclusao = (DateTime)reader["DataConclusao"];
        if(reader["DataCancelada"].ToString() != "")
          tarefa.DataCancelada = (DateTime)reader["DataCancelada"];

        retorno.Add(tarefa);
      }
      if (retorno == null)
        return RepositoryResult<TarefaDTO[]>.Error("Algo deu errado. Contate o servidor.");

      return RepositoryResult<TarefaDTO[]>.Sucess(retorno.ToArray());
    }

    public RepositoryResult<int> ConsultarTotalTarefasGestor(int idGestor)
    {
      SetProcedure(Procedures.SP_ConsultarTotalTarefasGestor);

      AddParameter("IdGestor", idGestor);

      var reader = ExecuteReader();
      reader.Read();
      var retorno = reader["TotalTarefas"];
      if ((int)retorno == 0)
        return RepositoryResult<int>.Error("Algo deu errado. Contate o servidor.");

      return RepositoryResult<int>.Sucess((int)retorno);
        }

    public RepositoryResult<int> ContarTarefasPorSubordinado(int idSubordinado)
    {
      SetProcedure(Procedures.SP_ContarTarefasPorSubordinado);

      AddParameter("IdSubordinado", idSubordinado);

      var reader = ExecuteReader();
      reader.Read();
      var retorno = reader["Total"];
      if ((int)retorno == 0)
          return RepositoryResult<int>.Error("Algo deu errado. Contate o servidor.");

      return RepositoryResult<int>.Sucess((int)retorno);
    }

    public RepositoryResult<int> CriarComentario(string comentario, int idTarefa)
    {
      SetProcedure(Procedures.SP_CriarComentario);
      AddParameter("Comentario", comentario);
      AddParameter("IdTarefa", idTarefa);
      var retorno = ExecuteNonQuery();
      if (retorno == 0)
        return RepositoryResult<int>.Error("Algo deu errado. Contate o servidor.");

      return RepositoryResult<int>.Sucess(retorno);
    }

    public RepositoryResult<int> CriarTarefa(string descricao, DateTime dataLimite, int idGestor, int idSubordinado, int idStatusTarefa)
    {
      SetProcedure(Procedures.SP_CriarTarefa);

      AddParameter("Descricao", descricao);
      AddParameter("DataLimite", dataLimite);
      AddParameter("IdGestor", idGestor);
      AddParameter("IdSubordinado", idSubordinado);
      AddParameter("IdStatusTarefa", idStatusTarefa);

      var readerIdTarefa = ExecuteReader();
      readerIdTarefa.Read();
      int idTarefa = int.Parse(readerIdTarefa["IdTarefa"].ToString());
      if (readerIdTarefa["IdTarefa"] == null)
        return RepositoryResult<int>.Error("Algo deu errado. Contate o servidor.");

      return RepositoryResult<int>.Sucess(idTarefa);

        }

    public RepositoryResult<int> EditarDataLimite(int idTarefa, DateTime novaDataLimite)
    {
      SetProcedure(Procedures.SP_CriarTarefa);

      AddParameter("IdTarefa", idTarefa);
      AddParameter("DataLimite", novaDataLimite);

      var retorno = ExecuteNonQuery();
      if (retorno == 0)
        return RepositoryResult<int>.Error("Algo deu errado. Contate o servidor.");

      return RepositoryResult<int>.Sucess(idTarefa);
    }
    public SendMailsDTO ConsultarEmailGestorNomeSubordinado(RepositoryResult<int> idTarefa)
    {
        SetProcedure(Procedures.SP_ConsultarEmailGestorNomeSubordinado);

        AddParameter("IdTarefa", idTarefa);

        var result = new SendMailsDTO();

        var reader = ExecuteReader();
        if (reader.Read())
        {
            result.NomeGestor = (string)reader["NomeGestor"];
            result.NomeSubordinado = (string)reader["NomeSubordinado"];
            result.EmailGestor = (string)reader["EmailGestor"];
            result.EmailSubordinado = (string)reader["EmailSubordinado"];
        }

        return result;

    }
  }
}