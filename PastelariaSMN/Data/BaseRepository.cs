using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
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

        
        public void EnviarEmail(string recepient, string subject, string body)

        {
            //instancio a classe MailMessage, responsável por atribuir
            //os valores para as variáveis declaradas no método
            MailMessage email = new MailMessage();

            //endereço do remetente, chamo o método From que recebe uma nova
            //instância de MailAdress passando como parâmetro a variável from
            email.From = new MailAddress("pastelaria.smn@gmail.com");

            //destinatário, uso método Add, já que posso enviar para várias pessoas
            email.To.Add(new MailAddress(recepient));

            //defino o assunto
            email.Subject = subject;

            //defino o corpo da mensagem
            email.Body = body;

            //defino que o formato do texto será HTML
            email.IsBodyHtml = true;

            using (var smtp = new System.Net.Mail.SmtpClient())
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("pastelaria.smn@gmail.com", "$abcd1234");

                //Exemplo de anexo de texto:
                //mailMessage.Attachments.Add(new System.Net.Mail.Attachment(
                //   new MemoryStream(Encoding.UTF8.GetBytes("conteudo do arquivo")),
                //   "anexo.txt", System.Net.Mime.MediaTypeNames.Text.Plain));

                smtp.Send(email);
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


}
