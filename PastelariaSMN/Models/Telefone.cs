using PastelariaSMN.Infra;

namespace PastelariaSMN.Models
{
    public class Telefone
    {
        public int IdTelefone { get; set; }
        public int Numero { get; set; }
        public byte DDD { get; set; }
        public byte IdTipo { get; set; }
        public TipoTelefone TipoTelefone { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public void is_valid(NotificationList notification)
        {
            if (this.Numero > 999999999)
            {
                notification.AddNotification("Numero de Telefone", "Seu número de telefone excedeu o limite de caracteres.");
            }
            if (this.DDD >= 99 )
            {
                notification.AddNotification("DDD do Telefone", "Seu DDD do telefone excedeu o limite de caracteres.");
            }
            if (this.IdTipo >= 4)
            {
                notification.AddNotification("IdTipo do Telefone", "Seu IdTipo do telefone excedeu o limite de caracteres.");
            }
        }
    }

}