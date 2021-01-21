using System;
using System.Collections.Generic;
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
    public string AlterarStatusDaTarefa(int idTarefa, int novoStatus)
    {
      SetProcedure(Procedures.SP_AlterarStatusDaTarefa);

      AddParameter("IdTarefa", idTarefa);
      AddParameter("NovoStatus", novoStatus);
      var retorno = ExecuteNonQuery();

      if(retorno>0){
        return "Requisição bem Sucedida";
      }
      else{
        return "Algo de errado não está certo.";
      }
      
    }

    public int CancelarTarefa(int idTarefa)
    {
      SetProcedure(Procedures.SP_CancelarTarefa);

      AddParameter("IdTarefa", idTarefa);

      return ExecuteNonQuery();
    }

    public string ConcluirTarefa(int idTarefa)
    {

      SetProcedure(Procedures.SP_ConcluirTarefa);

      AddParameter("IdTarefa", idTarefa);

      if(ExecuteNonQuery() > 0)
      {
        SetProcedure(Procedures.SP_ConsultarEmailGestorNomeSubordinado);

        AddParameter("IdTarefa", idTarefa);

        var result = new SendMailsDTO();

        var reader = ExecuteReader();
        if(reader.Read())
        {
          result.NomeGestor = (string)reader["NomeGestor"];
          result.NomeSubordinado = (string)reader["NomeSubordinado"];
          result.EmailGestor = (string)reader["EmailGestor"];
          result.EmailSubordinado = (string)reader["EmailSubordinado"];
        }

        string body = "O seu subordinado " + result.NomeSubordinado + " concluiu uma tarefa";

        EnviarEmail(result.EmailGestor, "Uma tarefa foi concluida por um subordinado seu!", body);
      }

      return "Tarefa concluída e email enviado com sucesso";
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

    public TarefaDTO[] ConsultarTarefasUsuario(int idUsuario)
    {
      SetProcedure(Procedures.SP_ConsultarTarefasUsuario);
      AddParameter("IdUsuario", idUsuario);

      List<TarefaDTO> result = new List<TarefaDTO>();

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

        result.Add(tarefa);
      }
      return result.ToArray();
    }

    public TarefaDTO[] ConsultarTodasTarefasGestor(int idGestor)
    {
      SetProcedure(Procedures.SP_ConsultarTodasTarefasGestor);
      AddParameter("IdGestor", idGestor);

      List<TarefaDTO> result = new List<TarefaDTO>();

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

      var readerIdTarefa = ExecuteReader();
      
      
      readerIdTarefa.Read();
      int idTarefa = int.Parse(readerIdTarefa["IdTarefa"].ToString());

      // readerIdTarefa.Close();

      if(idTarefa > 0)
      {
        SetProcedure(Procedures.SP_ConsultarEmailGestorNomeSubordinado);

        AddParameter("IdTarefa", idTarefa);

        var result = new SendMailsDTO();

        var reader = ExecuteReader();
        if(reader.Read())
        {
          result.NomeGestor = (string)reader["NomeGestor"];
          result.NomeSubordinado = (string)reader["NomeSubordinado"];
          result.EmailGestor = (string)reader["EmailGestor"];
          result.EmailSubordinado = (string)reader["EmailSubordinado"];
        }

        // string body = "O seu gestor " + result.NomeGestor + " criou uma tarefa";
        string body = $"O seu gestor { result.NomeGestor } criou uma tarefa com a descrição: '{ descricao }'.";

        EnviarEmail(result.EmailSubordinado, $"Uma tarefa foi criada para você pelo seu gestor { result.NomeGestor }", body);
      }

      return 200;
     
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