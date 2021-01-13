using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PastelariaSMN.Models;

namespace PastelariaSMN.Data
{
    public class Repository : IRepository
    {
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

    public int CriarTarefa(string descricao, 
                            DateTime dataLimite,
                            int idGestor,
                            int idSubordinado,
                            int idStatusTarefa)
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

    // Comentario[] IRepository.ConsultarComentario(int TarefaId)
    // {
    //   throw new System.NotImplementedException();
    // }
  }
}
