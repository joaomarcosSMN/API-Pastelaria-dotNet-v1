using System.Net.Mail;
using System.Threading.Tasks;

namespace PastelariaSMN.Infra
{
    public class EmailSent
    {
        public async Task SendEmail(EmailSettings emailSettings, string recepient, string subject, string body)
        {
            MailMessage email = new MailMessage();

            email.From = new MailAddress(emailSettings.SMTPEmail);

            email.To.Add(new MailAddress(recepient));

            email.Subject = subject;

            email.Body = body;

            email.IsBodyHtml = emailSettings.EmailIsBodyHtml;

            using (var smtp = new System.Net.Mail.SmtpClient())
            {
                smtp.Host = emailSettings.SMTPHostname;
                smtp.Port = emailSettings.SMTPPort;
                smtp.EnableSsl = emailSettings.SMTPEnableSs1;
                smtp.Credentials = new System.Net.NetworkCredential(emailSettings.SMTPEmail, emailSettings.SMTPPassword);

                await smtp.SendMailAsync(email);

            }

            
        }
    }
}