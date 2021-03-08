using System;
using PastelariaSMN.Infra;

namespace PastelariaSMN.Models
{
    public class Comentario
    {
        public int IdComentario { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public int IdTarefa { get; set; }
        public Tarefa Tarefa { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public Comentario()
        {
            this.Usuario = new Subordinado();
        }

        public void is_valid(NotificationList notification)
        {
            if (this.Descricao.Length > 200)
            {
                notification.AddNotification("Descricao da Tarefa", "Sua Descrição da Tarefa excedeu o limite de caracteres.");
            }
        }


    }

    
}