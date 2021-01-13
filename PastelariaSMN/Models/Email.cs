namespace PastelariaSMN.Models
{
    public class Email
    {
        public int IdEmail { get; set; }
        public string EnderecoEmail { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}