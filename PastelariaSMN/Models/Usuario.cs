using PastelariaSMN.Infra;
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
        public bool EGestor { get; set; } = false;
        public int? IdGestor { get; set; } = null;
        public Usuario Gestor { get; set; }
        public int IdEndereco { get; set; }
        public Endereco Endereco { get; set; }
        public int IdEmail { get; set; }
        public Email Email { get; set; }
        public int IdTelefone { get; set; }
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
    
        public List<Tarefa> Tarefas { get; set; }

        public bool is_valid(NotificationList notification)
        {
            if (this.Nome.Length > 30 || this.Nome.Length == 0)
            {
               notification.AddNotification("error nome", "message do nome");
                
            }
            if (this.Sobrenome.Length > 50 || this.Sobrenome.Length == 0)
            {
                notification.AddNotification("error sobrenome", "message do sobrenome");
            }
            if (this.Senha.Length > 50 || this.Senha.Length == 0)
            {
                //Aqui adicionaremos à notification.
            }
           /* if (!Telefone.is_valid())
            {
                return false;
                //Aqui adicionaremos à notification.
            }
            if (!Endereco.is_valid())
            {
                //Aqui adicionaremos à notification.
            }
            if (!Email.is_valid())
            {
                //Aqui adicionaremos à notification.
            }*/

            return true;
        }
    }
}