using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PastelariaSMN.Models;

namespace PastelariaSMN.Data
{
    public class Repository : IRepository
    {
        public int AlterarStatusDaTarefa(int idTarefa, int novoStatus)
        {
            using (SqlConnection sqlConn = new SqlConnection(@"Server=DESKTOP-DU3ENNC\SQLEXPRESS;Database=PastelariaSMN;User Id=joaozinho;Password=belo1111;"))
            {
                using (SqlCommand sqlCmd = new SqlCommand("[dbo].[SP_AlterarStatusDaTarefa]", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@IdTarefa ", idTarefa);
                    sqlCmd.Parameters.AddWithValue("@NovoStatus ", novoStatus);

                    sqlConn.Open();

                    return sqlCmd.ExecuteNonQuery();
                }
            }
        }

        public int AtivarUsuario(int idUsuario)
        {
            using (SqlConnection sqlConn = new SqlConnection(@"Server=DESKTOP-DU3ENNC\SQLEXPRESS;Database=PastelariaSMN;User Id=joaozinho;Password=belo1111;"))
            {
                using (SqlCommand sqlCmd = new SqlCommand("[dbo].[SP_AtivarUsuario]", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@IdUsuario ", idUsuario);

                    sqlConn.Open();
                    // Tarefa novaTarefa = null; 

                    return sqlCmd.ExecuteNonQuery();
                }
            }
        }
        public int AtivarDesativarUsuario(int idUsuario)
        {
            using (SqlConnection sqlConn = new SqlConnection(@"Server=DESKTOP-DU3ENNC\SQLEXPRESS;Database=PastelariaSMN;User Id=joaozinho;Password=belo1111;"))
            {
                using (SqlCommand sqlCmd = new SqlCommand("[dbo].[SP_AtivarDesativarUsuario]", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@IdUsuario ", idUsuario);

                    sqlConn.Open();
                    // Tarefa novaTarefa = null; 

                    return sqlCmd.ExecuteNonQuery();
                }
            }
        }

        public int AtualizarUsuario(int idUsuario, string nome, string sobrenome, string senha)
        {
            using (SqlConnection sqlConn = new SqlConnection(@"Server=DESKTOP-DU3ENNC\SQLEXPRESS;Database=PastelariaSMN;User Id=joaozinho;Password=belo1111;"))
            {
                using (SqlCommand sqlCmd = new SqlCommand("[dbo].[SP_AtualizarUsuario]", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    sqlCmd.Parameters.AddWithValue("@Nome", nome);
                    sqlCmd.Parameters.AddWithValue("@Sobrenome", sobrenome);
                    sqlCmd.Parameters.AddWithValue("@Senha", senha);

                    sqlConn.Open();
                    // Tarefa novaTarefa = null; 

                    return sqlCmd.ExecuteNonQuery();
                }
            }
        }

        public int CancelarTarefa(int idTarefa)
        {
            using (SqlConnection sqlConn = new SqlConnection(@"Server=DESKTOP-DU3ENNC\SQLEXPRESS;Database=PastelariaSMN;User Id=joaozinho;Password=belo1111;"))
            {
                using (SqlCommand sqlCmd = new SqlCommand("[dbo].[SP_CancelarTarefa]", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@IdTarefa", idTarefa);
                    sqlConn.Open();

                    return sqlCmd.ExecuteNonQuery();
                }
            }
        }

        public int ConcluirTarefa(int idTarefa)
        {
            using (SqlConnection sqlConn = new SqlConnection(@"Server=DESKTOP-DU3ENNC\SQLEXPRESS;Database=PastelariaSMN;User Id=joaozinho;Password=belo1111;"))
            {
                using (SqlCommand sqlCmd = new SqlCommand("[dbo].[SP_ConcluirTarefa]", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@IdTarefa", idTarefa);
                    sqlConn.Open();

                    return sqlCmd.ExecuteNonQuery();
                }
            }
        }

        // public List<Comentario> ConsultarComentario(int TarefaId)
        public Comentario[] ConsultarComentarios(int idTarefa)
        {
            using (SqlConnection sqlConn = new SqlConnection(@"Server=DESKTOP-DU3ENNC\SQLEXPRESS;Database=PastelariaSMN;User Id=joaozinho;Password=belo1111;"))
            {
                using (SqlCommand sqlCmd = new SqlCommand("[dbo].[SP_ConsultarComentarioTarefa]", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@IdTarefa ", idTarefa);
                    
                    sqlConn.Open();
                    var reader = sqlCmd.ExecuteReader();  // sqlCmd.ExecuteNonQuery()
                    
                    List<Comentario> resultado = new List<Comentario>();
                    Comentario comentario = null;
                    // var result = new List<Comentario>();

                    while (reader.Read())
                    {
                        comentario = new Comentario();
                        comentario.IdComentario = int.Parse(reader["IdComentario"].ToString());
                        comentario.Descricao = reader["Descricao"].ToString();
                        comentario.IdTarefa = int.Parse(reader["IdTarefa"].ToString());
                        resultado.Add(comentario);
                    }

                    //tarefa/1/comentario

                    //reader.NextResult()
                    sqlConn.Close();
                    return resultado.ToArray();
                }
            }
        }

        public Tarefa[] ConsultarTarefasGestor(int idGestor)
        {
        throw new NotImplementedException();
        }

        public Tarefa[] ConsultarTarefasGestorStatus(int idGestor, int idStatusTarefa)
        {
            using (SqlConnection sqlConn = new SqlConnection(@"Server=DESKTOP-DU3ENNC\SQLEXPRESS;Database=PastelariaSMN;User Id=joaozinho;Password=belo1111;"))
            {
                using (SqlCommand sqlCmd = new SqlCommand("[dbo].[SP_ConsultarTarefasGestorStatus]", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@IdGestor ", idGestor);
                    sqlCmd.Parameters.AddWithValue("@IdStatusTarefa ", idStatusTarefa);
                    
                    sqlConn.Open();
                    var reader = sqlCmd.ExecuteReader();  // sqlCmd.ExecuteNonQuery()
                    
                    List<Tarefa> resultado = new List<Tarefa>();
                    Tarefa tarefa = null;
                    // var result = new List<Comentario>();

                    while(reader.Read())
                    {
                        tarefa = new Tarefa();
                        tarefa.IdTarefa = int.Parse(reader["IdTarefa"].ToString());
                        tarefa.Descricao = reader["Descricao"].ToString();
                        tarefa.DataCadastro = DateTime.Parse(reader["DataCadastro"].ToString());
                        tarefa.DataLimite = DateTime.Parse(reader["DataLimite"].ToString());
                        if(reader["DataConclusao"].ToString() == "") {
                            tarefa.DataConclusao = null;
                        } else {
                            tarefa.DataConclusao = DateTime.Parse(reader["DataConclusao"].ToString());
                        }
                        if(reader["DataCancelada"].ToString() == "") {
                            tarefa.DataCancelada = null;
                        } else {
                            tarefa.DataCancelada = DateTime.Parse(reader["DataCancelada"].ToString());
                        }
                        resultado.Add(tarefa);
                    }
                    sqlConn.Close();
                    return resultado.ToArray();
                }
            }
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

        public Usuario[] ConsultarUsuario(int idUsuario)
        {
        throw new NotImplementedException();
        }

        public Usuario[] ConsultarUsuariosDoGestor(int idGestor)
        {
        throw new NotImplementedException();
        }

        public int ContarTarefasPorSubordinado(int idSubordinado)
        {
        throw new NotImplementedException();
        }

        public void CriarComentario(string comentario, int idTarefa)
        {
        throw new NotImplementedException();
        }

        public int CriarTarefa(string descricao, DateTime dataLimite, int idGestor, int idSubordinado, int idStatusTarefa)
        {
            using (SqlConnection sqlConn = new SqlConnection(@"Server=DESKTOP-DU3ENNC\SQLEXPRESS;Database=PastelariaSMN;User Id=joaozinho;Password=belo1111;"))
            {
                using (SqlCommand sqlCmd = new SqlCommand("[dbo].[SP_CriarTarefa]", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@Descricao", descricao);
                    sqlCmd.Parameters.AddWithValue("@DataLimite", dataLimite);
                    sqlCmd.Parameters.AddWithValue("@IdGestor", idGestor);
                    sqlCmd.Parameters.AddWithValue("@IdSubordinado", idSubordinado);
                    sqlCmd.Parameters.AddWithValue("@IdStatusTarefa", idStatusTarefa);

                    sqlConn.Open();
                    // Tarefa novaTarefa = null; 

                    return sqlCmd.ExecuteNonQuery();
                }

            }

        }

        public void CriarUsuario(string nome, string sobrenome, DateTime dataNascimento, string senha, bool eGestor, bool estaAtivo, int idGestor)
        {
        throw new NotImplementedException();
        }

        public int DesativarUsuario(int idUsuario)
        {
            using (SqlConnection sqlConn = new SqlConnection(@"Server=DESKTOP-DU3ENNC\SQLEXPRESS;Database=PastelariaSMN;User Id=joaozinho;Password=belo1111;"))
            {
                using (SqlCommand sqlCmd = new SqlCommand("[dbo].[SP_DesativarUsuario]", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@IdUsuario ", idUsuario);

                    sqlConn.Open();
                    // Tarefa novaTarefa = null; 

                    return sqlCmd.ExecuteNonQuery();
                }
            }
        }   

        public void EditarDataLimite(int idTarefa, DateTime novaDataLimite)
        {
        throw new NotImplementedException();
        }

        public Usuario VericarLogin(string email)
        {
        throw new NotImplementedException();
        }
  }
}
