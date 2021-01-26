using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using PastelariaSMN.DTOs;
using PastelariaSMN.Infra;

namespace PastelariaSMN.Data
{
    public abstract class BaseRepository 
    {
        public BaseRepository() 
        {
        
            conn = new Connection();
        }

        private Connection conn;
        private SqlCommand command;

        protected void SetProcedure(object procedureName)
        {
            command = new SqlCommand(procedureName.ToString(), conn.connection);
            command.CommandType = CommandType.StoredProcedure;
        }
        protected void AddParameter(string name, object value)
        {
            command.Parameters.AddWithValue("@" + name, value);
        }

        protected int ExecuteNonQuery()
        {
            conn.OpenConnection();
            var retorno = command.ExecuteNonQuery();
            // CloseConnection();
            return retorno;
        }

        protected SqlDataReader ExecuteReader()
        {
            conn.OpenConnection();
            var reader = command.ExecuteReader();
            // CloseConnection();
            return reader;
        
        }

        // protected void connection.OpenConnection() {
        //     if(connection.State == ConnectionState.Closed)
        //         connection.Open();
        // }

        // TODO: Mover esquema de login para classe do usuário
        
        protected bool CheckLogin(string email, string senha)
        {
            conn.OpenConnection();

            var reader = command.ExecuteReader();
            reader.Read();

            var login = new LoginDTO 
            {
                Email = reader["EnderecoEmail"].ToString(),
                Senha = reader["Senha"].ToString()
            };

            // connection.Close();

            if( email != login.Email || senha != login.Senha) {
                return false;
            } else {
                return true;
            }
        }
            

        ///////
        

        
        
        // TODO: Mover envio de email para uma classe especifica de emails
        // public void EnviarEmail(string recepient, string subject, string body)

        // {
        //     //instancio a classe MailMessage, responsável por atribuir
        //     //os valores para as variáveis declaradas no método
        //     MailMessage email = new MailMessage();

        //     //endereço do remetente, chamo o método From que recebe uma nova
        //     //instância de MailAdress passando como parâmetro a variável from
        //     email.From = new MailAddress("pastelaria.smn@gmail.com");

        //     //destinatário, uso método Add, já que posso enviar para várias pessoas
        //     email.To.Add(new MailAddress(recepient));

        //     //defino o assunto
        //     email.Subject = subject;

        //     //defino o corpo da mensagem
        //     email.Body = body;

        //     //defino que o formato do texto será HTML
        //     email.IsBodyHtml = true;

        //     using (var smtp = new System.Net.Mail.SmtpClient())
        //     {
        //         smtp.Host = "smtp.gmail.com";
        //         smtp.Port = 587;
        //         smtp.EnableSsl = true;
        //         smtp.Credentials = new System.Net.NetworkCredential("pastelaria.smn@gmail.com", "$abcd1234");

        //         //Exemplo de anexo de texto:
        //         //mailMessage.Attachments.Add(new System.Net.Mail.Attachment(
        //         //   new MemoryStream(Encoding.UTF8.GetBytes("conteudo do arquivo")),
        //         //   "anexo.txt", System.Net.Mime.MediaTypeNames.Text.Plain));

        //         smtp.Send(email);
        //     }
        // }

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
