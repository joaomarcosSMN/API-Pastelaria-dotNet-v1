namespace PastelariaSMN.Models
{
    public class Email
    {
        public int EmailId { get; set; }
        public string EnderecoEmail { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}