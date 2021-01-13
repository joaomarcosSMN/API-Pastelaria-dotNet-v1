using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PastelariaSMN.Models;

namespace PastelariaSMN.Data
{
    public class Repository : IRepository
    {
        public List<Comentario> ConsultarComentario(int TarefaId)
        {
            using (SqlConnection sqlConn = new SqlConnection(@"Server=DESKTOP-DU3ENNC\SQLEXPRESS;Database=PastelariaSMN;User Id=joaozinho;Password=belo1111;"))
            {
                using (SqlCommand sqlCmd = new SqlCommand("[dbo].[SP_ConsultarComentarioTarefa]", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    
                    sqlConn.Open();
                    var reader = sqlCmd.ExecuteReader();  // sqlCmd.ExecuteNonQuery()

                    var result = new List<Comentario>();
                    while (reader.Read())
                    {
                        result.Add(reader["IdComentario"].ToString());
                    }

                    //reader.NextResult()
                    
                    return lista;
                }
            }
        }
    }
}
