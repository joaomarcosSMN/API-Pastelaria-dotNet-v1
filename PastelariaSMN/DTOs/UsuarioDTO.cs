using System;

namespace PastelariaSMN.DTOs
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Senha { get; set; }
        public bool EstaAtivo { get; set; }
        public bool EGestor { get; set; }
        public int? IdGestor { get; set; }
        public string NomeGestor { get; set; }
    }
}