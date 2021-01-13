using System;

namespace PastelariaSMN.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Senha { get; set; }
        public bool EstaAtivo { get; set; } = true;
        public bool EGestor { get; set; }
        public int? IdGestor { get; set; }
        public Usuario Gestor { get; set; }
    }
}