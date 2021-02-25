using PastelariaSMN.Infra;
using System;
using System.Collections.Generic;

namespace PastelariaSMN.Models
{
    public abstract class Usuario
    {
        public short IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Senha { get; set; }
        public bool EstaAtivo { get; set; } = true;
        public bool EGestor { get; set; }
        public int IdEndereco { get; set; }
        public Endereco Endereco { get; set; }
        public short IdEmail { get; set; }
        public Email Email { get; set; }
        public short IdTelefone { get; set; }
        public Telefone Telefone { get; set; }
        public Gestor Gestor { get; set; }

        public Usuario() {
            this.Email = new Email();
            this.Endereco = new Endereco();
            this.Telefone = new Telefone();
        }   
        public List<Tarefa> Tarefas { get; set; }

        public void is_valid(NotificationList notification)
        {

            if (this.Nome.Length > 30)
            {
                notification.AddNotification("Nome de Usuario", "Seu Nome de Usuário excedeu o limite de caracteres.");
            }
            if (this.Sobrenome.Length > 50)
            {
                notification.AddNotification("Sobrenome de Usuario", "Seu Sobrenome de Usuário excedeu o limite de caracteres.");
            }
            if (this.Senha.Length > 50)
            {
                notification.AddNotification("Senha de Usuario", "Sua Senha de Usuário excedeu o limite de caracteres.");
            }


            Email.is_valid(notification);
            Endereco.is_valid(notification);
            Telefone.is_valid(notification);


        }

        public void IsValidJustUser(NotificationList notification)
        {

            if (this.Nome.Length > 30)
            {
                notification.AddNotification("Nome de Usuario", "Seu Nome de Usuário excedeu o limite de caracteres.");
            }
            if (this.Sobrenome.Length > 50)
            {
                notification.AddNotification("Sobrenome de Usuario", "Seu Sobrenome de Usuário excedeu o limite de caracteres.");
            }
            if (this.Senha.Length > 50)
            {
                notification.AddNotification("Senha de Usuario", "Sua Senha de Usuário excedeu o limite de caracteres.");
            }
        }
    }
}