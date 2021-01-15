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
        public Comentario[] ConsultarComentarioTarefa(int idTarefa)
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
            using (SqlConnection sqlConn = new SqlConnection(@"Server=DESKTOP-DU3ENNC\SQLEXPRESS;Database=PastelariaSMN;User Id=joaozinho;Password=belo1111;"))
            {
                using (SqlCommand sqlCmd = new SqlCommand("[dbo].[SP_ConsultarTarefasGestor]", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@IdGestor", idGestor);

                    sqlConn.Open();
                    var reader = sqlCmd.ExecuteReader();

                    List<Tarefa> resultado = new List<Tarefa>();
                    Tarefa tarefa = null;

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
                        tarefa.IdGestor = int.Parse(reader["IdGestor"].ToString());
                        tarefa.IdSubordinado = int.Parse(reader["IdSubordinado"].ToString());
                        tarefa.IdStatusTarefa = int.Parse(reader["IdStatusTarefa"].ToString());
                        resultado.Add(tarefa);
                    }

                    return resultado.ToArray();
                }
            }
        }

        public Tarefa[] ConsultarTarefasGestorStatus(int idGestor, int idStatusTarefa)
        {
            using (SqlConnection sqlConn = new SqlConnection(@"Server=DESKTOP-DU3ENNC\SQLEXPRESS;Database=PastelariaSMN;User Id=joaozinho;Password=belo1111;"))
            {
                using (SqlCommand sqlCmd = new SqlCommand("[dbo].[SP_ConsultarTarefasGestorStatus]", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@IdGestor", idGestor);
                    sqlCmd.Parameters.AddWithValue("@IdStatusTarefa", idStatusTarefa);
                    
                    sqlConn.Open();
                    var reader = sqlCmd.ExecuteReader();  // sqlCmd.ExecuteNonQuery()
                    
                    List<Tarefa> resultado = new List<Tarefa>();
                    Tarefa tarefa = null;

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
                    // sqlConn.Close();
                    return resultado.ToArray();
                }
            }
        }

        public Tarefa[] ConsultarTarefasStatusUsuario(int idSubordinado, int idStatusTarefa)
        {
            using (SqlConnection sqlConn = new SqlConnection(@"Server=DESKTOP-DU3ENNC\SQLEXPRESS;Database=PastelariaSMN;User Id=joaozinho;Password=belo1111;"))
            {
                using (SqlCommand sqlCmd = new SqlCommand("[dbo].[SP_ConsultarTarefasStatusUsuario]", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@IdUsuario", idSubordinado);
                    sqlCmd.Parameters.AddWithValue("@IdStatusTarefa", idStatusTarefa);
                    
                    sqlConn.Open();
                    var reader = sqlCmd.ExecuteReader();  // sqlCmd.ExecuteNonQuery()
                    
                    List<Tarefa> resultado = new List<Tarefa>();
                    Tarefa tarefa = null;

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
                        tarefa.IdGestor = int.Parse(reader["IdGestor"].ToString());
                        tarefa.IdSubordinado = int.Parse(reader["IdSubordinado"].ToString());
                        tarefa.IdStatusTarefa = int.Parse(reader["IdStatusTarefa"].ToString());
                        
                        resultado.Add(tarefa);
                    }
                    // sqlConn.Close();
                    return resultado.ToArray();
                }
            }
        }

        public Tarefa[] ConsultarTarefasUsuario(int idSubordinado)
        {
            using (SqlConnection sqlConn = new SqlConnection(@"Server=DESKTOP-DU3ENNC\SQLEXPRESS;Database=PastelariaSMN;User Id=joaozinho;Password=belo1111;"))
            {
                using (SqlCommand sqlCmd = new SqlCommand("[dbo].[SP_ConsultarTarefasUsuario]", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@IdUsuario", idSubordinado);

                    sqlConn.Open();
                    var reader = sqlCmd.ExecuteReader();

                    List<Tarefa> resultado = new List<Tarefa>();
                    Tarefa tarefa = null;

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
                        tarefa.IdGestor = int.Parse(reader["IdGestor"].ToString());
                        tarefa.IdSubordinado = int.Parse(reader["IdSubordinado"].ToString());
                        tarefa.IdStatusTarefa = int.Parse(reader["IdStatusTarefa"].ToString());
                        resultado.Add(tarefa);
                    }

                    return resultado.ToArray();
                }
            }
        }

        public Tarefa[] ConsultarTodasTarefasGestor(int idGestor)
        {
            using (SqlConnection sqlConn = new SqlConnection(@"Server=DESKTOP-DU3ENNC\SQLEXPRESS;Database=PastelariaSMN;User Id=joaozinho;Password=belo1111;"))
            {
                using (SqlCommand sqlCmd = new SqlCommand("[dbo].[SP_ConsultarTodasTarefasGestor]", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@IdGestor", idGestor);

                    sqlConn.Open();
                    var reader = sqlCmd.ExecuteReader();

                    List<Tarefa> resultado = new List<Tarefa>();
                    Tarefa tarefa = null;

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

                    return resultado.ToArray();
                }
            }
        }

        public int ConsultarTotalTarefasGestor(int idGestor)
        {
            using (SqlConnection sqlConn = new SqlConnection(@"Server=DESKTOP-DU3ENNC\SQLEXPRESS;Database=PastelariaSMN;User Id=joaozinho;Password=belo1111;"))
            {
                using (SqlCommand sqlCmd = new SqlCommand("[dbo].[SP_ConsultarTotalTarefasGestor]", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@IdGestor", idGestor);

                    sqlConn.Open();
                    var reader = sqlCmd.ExecuteReader();
                    reader.Read();
                    var total = int.Parse(reader["Total"].ToString());

                    return total;
                }
            }
        }

        public Usuario ConsultarUsuario(int idUsuario)
        {
            using (SqlConnection sqlConn = new SqlConnection(@"Server=DESKTOP-DU3ENNC\SQLEXPRESS;Database=PastelariaSMN;User Id=joaozinho;Password=belo1111;"))
            {
                using (SqlCommand sqlCmd = new SqlCommand("[dbo].[SP_ConsultarUsuario]", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    sqlConn.Open();
                    var reader = sqlCmd.ExecuteReader();

                    Usuario usuario = null;
                    reader.Read();
                    
                    usuario = new Usuario();
                    usuario.IdUsuario = int.Parse(reader["IdUsuario"].ToString());
                    usuario.Nome = reader["Nome"].ToString();
                    usuario.Sobrenome = reader["Sobrenome"].ToString();
                    usuario.DataNascimento = DateTime.Parse(reader["DataNascimento"].ToString());
                    usuario.EGestor = bool.Parse(reader["EGestor"].ToString());
                    usuario.EstaAtivo = bool.Parse(reader["EstaAtivo"].ToString());
                    // usuario.IdGestor = (reader["IdGestor"].ToString() == "") ? null : int.Parse(reader["IdGestor"].ToString());
                    if( reader["IdGestor"].ToString() == "" ) {
                        usuario.IdGestor = null;
                    } else {
                        usuario.IdGestor = int.Parse(reader["IdGestor"].ToString());
                    }
                    
                    return usuario;
                }
            }
        }

        public Usuario[] ConsultarUsuariosDoGestor(int idGestor)
        {
            using (SqlConnection sqlConn = new SqlConnection(@"Server=DESKTOP-DU3ENNC\SQLEXPRESS;Database=PastelariaSMN;User Id=joaozinho;Password=belo1111;"))
            {
                using (SqlCommand sqlCmd = new SqlCommand("[dbo].[SP_ConsultarUsuariosDoGestor]", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@IdGestor", idGestor);

                    sqlConn.Open();
                    var reader = sqlCmd.ExecuteReader();

                    List<Usuario> resultado = new List<Usuario>();
                    Usuario subordinado = null;

                    while(reader.Read())
                    {
                        subordinado = new Usuario();
                        subordinado.IdUsuario = int.Parse(reader["IdUsuario"].ToString());
                        subordinado.Nome = reader["Nome"].ToString();
                        subordinado.Sobrenome = reader["Sobrenome"].ToString();
                        subordinado.EstaAtivo = bool.Parse(reader["EstaAtivo"].ToString());
                        resultado.Add(subordinado);
                    }

                    return resultado.ToArray();
                }
            }
        }

        public int ContarTarefasPorSubordinado(int idSubordinado)
        {
            using (SqlConnection sqlConn = new SqlConnection(@"Server=DESKTOP-DU3ENNC\SQLEXPRESS;Database=PastelariaSMN;User Id=joaozinho;Password=belo1111;"))
            {
                using (SqlCommand sqlCmd = new SqlCommand("[dbo].[SP_ContarTarefasPorSubordinado]", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@IdSubordinado", idSubordinado);

                    sqlConn.Open();
                    var reader = sqlCmd.ExecuteReader();
                    reader.Read();
                    var total = int.Parse(reader["Total"].ToString());

                    return total;
                }
            }
        }

        public int CriarComentario(string comentario, int idTarefa)
        {
            using (SqlConnection sqlConn = new SqlConnection(@"Server=DESKTOP-DU3ENNC\SQLEXPRESS;Database=PastelariaSMN;User Id=joaozinho;Password=belo1111;"))
            {
                using (SqlCommand sqlCmd = new SqlCommand("[dbo].[SP_CriarComentario]", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@Comentario", comentario);
                    sqlCmd.Parameters.AddWithValue("@IdTarefa", idTarefa);

                    sqlConn.Open();

                    return sqlCmd.ExecuteNonQuery();
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

                    return sqlCmd.ExecuteNonQuery();
                }

            }

        }
        // quando IdGestor estava int?, erro => não é possivel converter int? para int
        public int CriarUsuario(string nome, string sobrenome, DateTime dataNascimento, string senha, bool eGestor, bool estaAtivo, int? idGestor = null)
        {
            using (SqlConnection sqlConn = new SqlConnection(@"Server=DESKTOP-DU3ENNC\SQLEXPRESS;Database=PastelariaSMN;User Id=joaozinho;Password=belo1111;"))
            {
                using (SqlCommand sqlCmd = new SqlCommand("[dbo].[SP_CriarUsuario]", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@Nome", nome);
                    sqlCmd.Parameters.AddWithValue("@Sobrenome", sobrenome);
                    sqlCmd.Parameters.AddWithValue("@DataNascimento", dataNascimento);
                    sqlCmd.Parameters.AddWithValue("@Senha", senha);
                    if(eGestor) {
                        sqlCmd.Parameters.AddWithValue("@EGestor", 1);
                    } else {
                        sqlCmd.Parameters.AddWithValue("@EGestor", 0);
                    }
                    if(estaAtivo) {
                        sqlCmd.Parameters.AddWithValue("@EstaAtivo", 1);
                    } else {
                        sqlCmd.Parameters.AddWithValue("@EstaAtivo", 0);
                    }
                    if(idGestor > 0) {
                        sqlCmd.Parameters.AddWithValue("@IdGestor", idGestor);
                    }

                    sqlConn.Open();

                    return sqlCmd.ExecuteNonQuery();
                }

            }
        }


        public int EditarDataLimite(int idTarefa, DateTime novaDataLimite)
        {
            using (SqlConnection sqlConn = new SqlConnection(@"Server=DESKTOP-DU3ENNC\SQLEXPRESS;Database=PastelariaSMN;User Id=joaozinho;Password=belo1111;"))
            {
                using (SqlCommand sqlCmd = new SqlCommand("[dbo].[SP_EditarDataLimite]", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@IdTarefa", idTarefa);
                    sqlCmd.Parameters.AddWithValue("@DataLimite", novaDataLimite);

                    sqlConn.Open();

                    return sqlCmd.ExecuteNonQuery();
                }
            }
        }
  
        public bool VerificarLogin(string email, string senha)
        {
             using (SqlConnection sqlConn = new SqlConnection(@"Server=DESKTOP-DU3ENNC\SQLEXPRESS;Database=PastelariaSMN;User Id=joaozinho;Password=belo1111;"))
            {
                using (SqlCommand sqlCmd = new SqlCommand("[dbo].[SP_VerificarLogin]", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@Email", email);

                    sqlConn.Open();

                    var reader = sqlCmd.ExecuteReader();
                    reader.Read();
                    var emailDb = reader["EnderecoEmail"].ToString();
                    var senhaDb = reader["Senha"].ToString();

                    sqlConn.Open();

                    if( email != emailDb || senha != senhaDb ) {
                        return false;
                    } else {
                        return true;
                    }
                }
            }
        }


    // public int DesativarUsuario(int idUsuario)
    // {
    //     using (SqlConnection sqlConn = new SqlConnection(@"Server=DESKTOP-DU3ENNC\SQLEXPRESS;Database=PastelariaSMN;User Id=joaozinho;Password=belo1111;"))
    //     {
    //         using (SqlCommand sqlCmd = new SqlCommand("[dbo].[SP_DesativarUsuario]", sqlConn))
    //         {
    //             sqlCmd.CommandType = CommandType.StoredProcedure;
    //             sqlCmd.Parameters.AddWithValue("@IdUsuario ", idUsuario);

    //             sqlConn.Open();

    //             return sqlCmd.ExecuteNonQuery();
    //         }
    //     }
    // } 

    // public int AtivarUsuario(int idUsuario)
    // {
    //     using (SqlConnection sqlConn = new SqlConnection(@"Server=DESKTOP-DU3ENNC\SQLEXPRESS;Database=PastelariaSMN;User Id=joaozinho;Password=belo1111;"))
    //     {
    //         using (SqlCommand sqlCmd = new SqlCommand("[dbo].[SP_AtivarUsuario]", sqlConn))
    //         {
    //             sqlCmd.CommandType = CommandType.StoredProcedure;
    //             sqlCmd.Parameters.AddWithValue("@IdUsuario ", idUsuario);

    //             sqlConn.Open();
    //             // Tarefa novaTarefa = null; 

    //             return sqlCmd.ExecuteNonQuery();
    //         }
    //     }
    // }
  }
}
