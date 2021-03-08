using System;
using System.Collections.Generic;
using PastelariaSMN.Infra;
using PastelariaSMN.Models;

namespace PastelariaSMN.Data
{

  public class TarefaRepository : BaseRepository, ITarefaRepository
  {
    public TarefaRepository(Connection conn) : base(conn)
    {
    
    }
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
      SP_ConsultarTarefa,

      ////////////////////////////
       SP_ConsultarTotalTarefas, 
       SP_ConsultarTodasTarefasUsuario,
       SP_ConsultarTarefasPorStatus,
       SP_ConsultarTarefasAndamento
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

    // AQUI
    public Comentario[] ConsultarComentarioTarefa(int idTarefa)
    {
      SetProcedure(Procedures.SP_ConsultarComentarioTarefa);
      AddParameter("IdTarefa", idTarefa);

      List<Comentario> retorno = new List<Comentario>();

      var reader = ExecuteReader();
      while(reader.Read())
      {
        Comentario comentario = new Comentario();
         
        comentario.IdComentario = (short)reader["IdComentario"];
        comentario.Descricao = (string)reader["Descricao"];
        comentario.DataCadastro = (DateTime)reader["DataCadastro"];
        comentario.IdTarefa = (short)reader["IdTarefa"];
        comentario.IdUsuario = (short)reader["IdUsuario"];
        comentario.Usuario.Nome = (string)reader["Nome"];

        retorno.Add(comentario);
      }
    
      return retorno.ToArray();
    }

    public Tarefa[] ConsultarTarefasAndamento(int idUsuario)
    {
        SetProcedure(Procedures.SP_ConsultarTarefasAndamento);
        AddParameter("idUsuario", idUsuario);

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
          tarefa.Status.Nome = (string)reader["Nome"];

          retorno.Add( tarefa);
        }
        
        return retorno.ToArray();
    }
     public Tarefa[] ConsultarTarefasPorStatus(int idUsuario, int idStatusTarefa)
    {
      SetProcedure(Procedures.SP_ConsultarTarefasPorStatus);
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
      return retorno.ToArray();
    }

    //Mudança
    public Tarefa[] ConsultarTodasTarefasUsuario(int idUsuario)
    {
      SetProcedure(Procedures.SP_ConsultarTodasTarefasUsuario);
      AddParameter("IdUsuario", idUsuario);

      List<Tarefa> retorno = new List<Tarefa>();

      var reader = ExecuteReader();
      while(reader.Read())
      {
        Tarefa tarefa = new Tarefa();

        tarefa.IdTarefa = (short)reader["IdTarefa"];
        tarefa.Descricao = (string)reader["Descricao"];
        tarefa.DataCadastro = (DateTime)reader["DataCadastro"];
        tarefa.DataLimite = (DateTime)reader["DataLimite"];
        tarefa.IdStatusTarefa = (byte)reader["IdStatusTarefa"];
        tarefa.IdGestor = (short)reader["IdGestor"];
        tarefa.IdSubordinado = (short)reader["IdSubordinado"];
        tarefa.Gestor.Nome = (string)reader["NomeGestor"];
        tarefa.Subordinado.Nome = (string)reader["NomeSubordinado"];
        tarefa.Status.Nome = (string)reader["Nome"];

        if(reader["DataConclusao"].ToString() != "")
          tarefa.DataConclusao = (DateTime)reader["DataConclusao"];
        if(reader["DataCancelada"].ToString() != "")
          tarefa.DataCancelada = (DateTime)reader["DataCancelada"];

        retorno.Add(tarefa);
      }
      return retorno.ToArray();
    }
    public int ConsultarTotalTarefas(int idUsuario)
    {
      SetProcedure(Procedures.SP_ConsultarTotalTarefas);

      AddParameter("IdUsuario", idUsuario);

      var reader = ExecuteReader();
      reader.Read();
      return (int)reader["Total"];
    }

    public int CriarComentario(string comentario, int idTarefa, int idUsuario)
    {
      SetProcedure(Procedures.SP_CriarComentario);
      AddParameter("Comentario", comentario);
      AddParameter("IdTarefa", idTarefa);
      AddParameter("IdUsuario", idUsuario);
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

      readerIdTarefa.Close();

      return idTarefa;
    }

    public int EditarDataLimite(int idTarefa, DateTime novaDataLimite)
    {
      SetProcedure(Procedures.SP_EditarDataLimite);

      AddParameter("IdTarefa", idTarefa);
      AddParameter("DataLimite", novaDataLimite);

      return ExecuteNonQuery();
    }
    public Tarefa ConsultarEmailGestorNomeSubordinado(int idTarefa)
    {
      SetProcedure(Procedures.SP_ConsultarEmailGestorNomeSubordinado);

      AddParameter("IdTarefa", idTarefa);

      var result = new Tarefa();

        var reader = ExecuteReader();
        if (reader.Read())
        {
            result.Gestor.Nome = (string)reader["NomeGestor"];
            result.Gestor.Sobrenome = (string)reader["SobrenomeGestor"];
            result.Gestor.Email.EnderecoEmail = (string)reader["EmailGestor"];
            result.Subordinado.Nome = (string)reader["NomeSubordinado"];
            result.Subordinado.Sobrenome = (string)reader["SobrenomeSubordinado"];
            result.Subordinado.Email.EnderecoEmail = (string)reader["EmailSubordinado"];
        }

        return result;
    }
    public Tarefa ConsultarTarefa(int idTarefa)
    {
      SetProcedure(Procedures.SP_ConsultarTarefa);
      AddParameter("IdTarefa", idTarefa);

      var tarefa = new Tarefa();

      var reader = ExecuteReader();
      if(reader.Read())
      {
          tarefa.IdTarefa = (short)reader["IdTarefa"];
          tarefa.Descricao = (string)reader["Descricao"];
          tarefa.DataCadastro = (DateTime)reader["DataCadastro"];
          tarefa.DataLimite = (DateTime)reader["DataLimite"];

          if(reader["DataConclusao"].ToString() != "")
          tarefa.DataConclusao = (DateTime)reader["DataConclusao"];
          if(reader["DataCancelada"].ToString() != "")
          tarefa.DataCancelada = (DateTime)reader["DataCancelada"];

          tarefa.IdGestor = (short)reader["IdGestor"];
          tarefa.IdSubordinado = (short)reader["IdSubordinado"];
          tarefa.IdStatusTarefa = (byte)reader["IdStatusTarefa"];
          tarefa.Status.Nome = (string)reader["Nome"];
      }

      return tarefa;
    }
  }
}