using PastelariaSMN.Infra;

namespace PastelariaSMN.Models
{
    public class Comentario
    {
        public int IdComentario { get; set; }
        public string Descricao { get; set; }
        public int IdTarefa { get; set; }
        public Tarefa Tarefa { get; set; }

        // Acho que em nenhum caso precisa instanciar Tarefa no construtor

        public void is_valid(NotificationList notification)
        {
            if (this.Descricao.Length > 200)
            {
                notification.AddNotification("Descricao da Tarefa", "Sua Descrição da Tarefa excedeu o limite de caracteres.");
            }
        }


    }

    
}