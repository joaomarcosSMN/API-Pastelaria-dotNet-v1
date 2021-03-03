using System;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace PastelariaSMN.Infra
{
    public class EmailSent
    {

        // public static async Task<bool> EmailConfirmation(repo, options, idTarefa)
        // {
        //     var emailData = repo.ConsultarEmailGestorNomeSubordinado(idTarefa);

        //     string body = $"O seu subordinado { emailData.Subordinado.Nome } { emailData.Subordinado.Sobrenome } concluiu uma tarefa";

        //     EmailSent.SendEmail(_options, emailData.Gestor.Email.EnderecoEmail, "Uma tarefa foi concluida por um subordinado seu!", body);

        //     return true;
        // }  

        // public static void SendEmail(EmailSettings emailSettings, string recepient, string subject, string body)
        public async Task SendEmail(EmailSettings emailSettings, string recepient, string subject, string body)
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

                await smtp.SendMailAsync(email);

            }

            
        }
    }
}