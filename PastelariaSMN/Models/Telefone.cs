namespace PastelariaSMN.Models
{
    public class Telefone
    {
        public int IdTelefone { get; set; }
        public int Numero { get; set; }
        public int DDD { get; set; }
        public int IdTipo { get; set; }
        public TipoTelefone TipoTelefone { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}