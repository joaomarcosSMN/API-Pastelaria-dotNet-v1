namespace PastelariaSMN.Models
{
    public class Telefone
    {
        public int TelefoneId { get; set; }
        public int Numero { get; set; }
        public int DDD { get; set; }
        public int TipoId { get; set; }
        public TipoTelefone TipoTelefone { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}