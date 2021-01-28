using PastelariaSMN.Infra;
using System;

namespace PastelariaSMN.Models
{
    public class Email
    {
        public int IdEmail { get; set; }
        public string EnderecoEmail { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public void is_valid(NotificationList notification)
        {
            if (this.EnderecoEmail.Length > 254)
            {
                notification.AddNotification("EnderecoEmail de Email", "Seu EndereçoEmail de Email excedeu o limite de caracteres.");
            }
        }
    }
}