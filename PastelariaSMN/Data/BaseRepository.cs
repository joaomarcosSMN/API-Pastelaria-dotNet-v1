using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using PastelariaSMN.DTOs;
using PastelariaSMN.Models;

namespace PastelariaSMN.Data
{
    public abstract class BaseRepository : IDisposable
    {
        public BaseRepository()
        {
            connection = new SqlConnection(@"Server=DESKTOP-DU3ENNC\SQLEXPRESS;Database=PastelariaSMN;User Id=joaozinho;Password=belo1111;");
        }

        private SqlConnection connection;
        private SqlCommand command;

        protected void SetProcedure(object procedureName)
        {
            command = new SqlCommand(procedureName.ToString(), connection);
            command.CommandType = CommandType.StoredProcedure;
        }
        protected void AddParameter(string name, object value)
        {
            command.Parameters.AddWithValue("@" + name, value);
        }

        protected int ExecuteNonQuery()
        {
            OpenConnection();
            var retorno = command.ExecuteNonQuery();
            // CloseConnection();
            return retorno;
        }

        protected SqlDataReader ExecuteReader()
        {
            OpenConnection();
            var reader = command.ExecuteReader();
            // CloseConnection();
            return reader;
        }

        protected void OpenConnection() {
            if(connection.State == ConnectionState.Closed)
                connection.Open();
        }
        // protected void CloseConnection() {
        //     if(connection.State == ConnectionState.Open)
        //         connection.Close();
        // }

        // protected Usuario[] ReturnArrayUsuarios()
        // {
        //     connection.Open();
        //     var reader = command.ExecuteReader();
        //     reader.Read();

        //     List<Usuario> resultado = new List<Usuario>();

        //     while(reader.Read())
        //     {
        //         resultado.Add(new Usuario 
        //             {
        //                 IdUsuario = int.Parse(reader["IdUsuario"].ToString()),
        //                 Nome = reader["Nome"].ToString(),
        //                 Sobrenome = reader["Sobrenome"].ToString(),
        //                 EstaAtivo = bool.Parse(reader["EstaAtivo"].ToString())
        //             });
        //     }

        //     connection.Close();
        //     return resultado.ToArray();
        // }

        protected bool CheckLogin(string email, string senha)
        {
            connection.Open();

            var reader = command.ExecuteReader();
            reader.Read();

            var login = new LoginDTO 
            {
                Email = reader["EnderecoEmail"].ToString(),
                Senha = reader["Senha"].ToString()
            };

            connection.Close();

            if( email != login.Email || senha != login.Senha) {
                return false;
            } else {
                return true;
            }
        }

            
        public void Dispose()
        {
            if(connection.State == ConnectionState.Open)
                connection.Close();
        }

        public string GerarHashMd5(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Converter a String para array de bytes, que é como a biblioteca trabalha.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Cria-se um StringBuilder para recompôr a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop para formatar cada byte como uma String em hexadecimal
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

  }

    /*
    public static class ReadExtentions
    {
        public static type ReadColumn<type>(this SqlDataReader reader, string name)
        {
            return (type)reader[name];
        }
    }
    */
     
}


// protected Usuario ReturnUsuario()
// {
//     connection.Open();
//     var reader = command.ExecuteReader();
//     reader.Read();
    
//     var usuario = new Usuario
//     {
//         IdUsuario = int.Parse(reader["IdUsuario"].ToString()),
//         Nome = reader["Nome"].ToString(),
//         Sobrenome = reader["Sobrenome"].ToString(),
//         DataNascimento = DateTime.Parse(reader["DataNascimento"].ToString()),
//         EGestor = bool.Parse(reader["EGestor"].ToString()),
//         EstaAtivo = bool.Parse(reader["EstaAtivo"].ToString()),
//         IdGestor = reader["IdGestor"].ToString() == "" 
//             ? (int?)null 
//             : int.Parse(reader["IdGestor"].ToString())
//     };

//     connection.Close();
//     return usuario;
// }