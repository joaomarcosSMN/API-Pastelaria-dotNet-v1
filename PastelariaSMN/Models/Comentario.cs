namespace PastelariaSMN.Models
{
    public class Comentario
    {
        public int ComentarioId { get; set; }
        public string Descricao { get; set; }
        public int TarefaId { get; set; }
        public Tarefa Tarefa { get; set; }
    }
}