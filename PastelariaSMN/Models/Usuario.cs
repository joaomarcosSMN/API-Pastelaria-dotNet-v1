using System;
using System.Collections.Generic;

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
        public int? IdGestor { get; set; } = null;
        public Usuario Gestor { get; set; }
        public Endereco Endereco { get; set; }
        public Email Email { get; set; }
        public Telefone Telefone { get; set; }

        //TODO: Mapear os relacionamentos entre as entidades e eliminar as DTOs que forem possíveis
        // public List<Tarefa> Tarefas { get; set;}

        public Usuario() {
            this.Email = new Email();
        }

        // public Usuario(string email, string senha)
        // {
        //     this.Email = new Email();
        //     this.Email.EnderecoEmail = email;
        //     this.Senha = senha;
        // }
    
    }
}