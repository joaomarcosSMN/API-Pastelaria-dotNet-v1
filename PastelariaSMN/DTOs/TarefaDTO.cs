using System;

namespace PastelariaSMN.DTOs
{
    public class TarefaDTO
    {
        public int IdTarefa { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLimite { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataConclusao { get; set; }
        public DateTime? DataCancelada { get; set; }
        public int IdGestor { get; set; }
        public int IdSubordinado{ get; set; }
        public int IdStatusTarefa { get; set; }
        public string NomeGestor { get; set; }
        public string NomeSubordinado { get; set; }
    }
}