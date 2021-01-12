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
        public bool EstaCancelada { get; set; } = false;
        public int IdGestor { get; set; }
        public Usuario Gestor { get; set; }
        public int IdSubordinado{ get; set; }
        public Usuario Subordinado { get; set; }
        public int IdStatusTarefa { get; set; }
        public StatusTarefa Status { get; set; }

    }
}