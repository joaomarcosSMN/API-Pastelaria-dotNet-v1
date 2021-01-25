using System;
using System.Net.Mail;
using Microsoft.Extensions.Options;

namespace PastelariaSMN.Infra
{
    public static class EmailSent
    {
        // public static void SendEmail(EmailSettings emailSettings, string recepient, string subject, string body)
        public static void SendEmail(EmailSettings emailSettings, string recepient, string subject, string body)
        {
            //instancio a classe MailMessage, responsável por atribuir
            //os valores para as variáveis declaradas no método
            MailMessage email = new MailMessage();

            //endereço do remetente, chamo o método From que recebe uma nova
            //instância de MailAdress passando como parâmetro a variável from
            email.From = new MailAddress(emailSettings.SMTPEmail);

            //destinatário, uso método Add, já que posso enviar para várias pessoas
            email.To.Add(new MailAddress(recepient));

            //defino o assunto
            email.Subject = subject;

            //defino o corpo da mensagem
            email.Body = body;

            //defino que o formato do texto será HTML
            email.IsBodyHtml = emailSettings.EmailIsBodyHtml;

            using (var smtp = new System.Net.Mail.SmtpClient())
            {
                smtp.Host = emailSettings.SMTPHostname;
                smtp.Port = emailSettings.SMTPPort;
                smtp.EnableSsl = emailSettings.SMTPEnableSs1;
                smtp.Credentials = new System.Net.NetworkCredential(emailSettings.SMTPEmail, emailSettings.SMTPPassword);

                //Exemplo de anexo de texto:
                //mailMessage.Attachments.Add(new System.Net.Mail.Attachment(
                //   new MemoryStream(Encoding.UTF8.GetBytes("conteudo do arquivo")),
                //   "anexo.txt", System.Net.Mime.MediaTypeNames.Text.Plain));

                smtp.Send(email);
            }
        }
    }
}