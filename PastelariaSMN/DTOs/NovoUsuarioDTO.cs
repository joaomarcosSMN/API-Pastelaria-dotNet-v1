using System;

namespace PastelariaSMN.DTOs
{
    public class NovoUsuarioDTO
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Senha { get; set; }
        public bool EstaAtivo { get; set; } = true;
        public bool EGestor { get; set; }
        public int? IdGestor { get; set; } = null;

        public string EnderecoEmail { get; set; }

        public int NumeroTelefone { get; set; }
        public int DDD { get; set; }
        public int IdTipo { get; set; }

        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string NumeroEnderco { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
    }
}