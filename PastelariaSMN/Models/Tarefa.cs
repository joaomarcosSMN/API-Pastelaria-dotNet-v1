using System;
using PastelariaSMN.Infra;

namespace PastelariaSMN.Models
{
    public class Tarefa
    {
        public int IdTarefa { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLimite { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public DateTime? DataConclusao { get; set; } = null;
        public DateTime? DataCancelada { get; set; } = null;
        public int IdGestor { get; set; }
        public Gestor Gestor { get; set; }
        public int IdSubordinado{ get; set; }
        public Subordinado Subordinado { get; set; }
        public int IdStatusTarefa { get; set; }
        public StatusTarefa Status { get; set; }
        
        public Tarefa() { 
            this.Subordinado = new Subordinado();
            this.Gestor = new Gestor();
            this.Status = new StatusTarefa();
        }
        public void is_valid(NotificationList notification)
        {
            if (this.Descricao.Length > 300)
            {
                notification.AddNotification("Descricao da Tarefa", "Sua Descrição da Tarefa excedeu o limite de caracteres.");
            }

            if (this.IdStatusTarefa < 1 || this.IdStatusTarefa > 5)
            {
                notification.AddNotification("Status da Tarefa", "O status da Tarefa nao pode ser menor que 0 ou maior que 5");
            }
        }
        public void is_validStatus(NotificationList notification)
        {
            if (this.IdStatusTarefa < 1 || this.IdStatusTarefa > 5)
            {
                notification.AddNotification("Status da Tarefa", "O status da Tarefa nao pode ser menor que 0 ou maior que 5");
            }
        }

    }
}