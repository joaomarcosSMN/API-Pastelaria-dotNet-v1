namespace PastelariaSMN.Models
{
    public class Comentario
    {
        public int IdComentario { get; set; }
        public string Descricao { get; set; }
        public int IdTarefa { get; set; }
        public Tarefa Tarefa { get; set; }

        // Acho que em nenhum caso precisa instanciar Tarefa no construtor
        public Comentario() 
        {

        }
    }

    
}