using System;

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
        }
    }
}