using PastelariaSMN.Infra;

namespace PastelariaSMN.Models
{
    public class Endereco
    {
        public int IdEndereco { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public void is_valid(NotificationList notification)
        {
            if (this.Rua.Length > 70)
            {
                notification.AddNotification("Rua do Endereco", "Sua Rua do Endere�o excedeu o limite de caracteres");
            }
            if (this.Bairro.Length > 60)
            {
                notification.AddNotification("Bairro do Endereco", "Seu Bairro do Endere�o excedeu o limite de caracteres");
            }
            if (this.Numero.Length > 10)
            {
                notification.AddNotification("Numero do Endereco", "Seu N�mero do Endere�o excedeu o limite de caracteres");
            }
            if (this.Complemento.Length > 50)
            {
                notification.AddNotification("Complemento do Endereco", "Seu Complemento de Endere�o excedeu o limite de caracteres");
            }
            if (this.CEP.Length > 8)
            {
                notification.AddNotification("CEP do Endereco", "Seu CEP do Endere�o excedeu o limite de caracteres");
            }
            if (this.Cidade.Length > 32)
            {
                notification.AddNotification("Cidade do Endereco", "Sua Cidade do Endere�o excedeu o limite de caracteres");
            }
            if (this.UF.Length > 2)
            {
                notification.AddNotification("UF do Endereco", "Seu UF do Endere�o excedeu o limite de caracteres");
            }
        }
    }
}