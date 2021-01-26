using System;
using PastelariaSMN.DTOs;
using PastelariaSMN.Models;

namespace PastelariaSMN.Data
{
    public interface IUsuarioRepository
    {
        public int CriarUsuario(string nome, string sobrenome, DateTime dataNascimento, string senha, bool eGestor, bool estaAtivo, int? idGestor,
                            string email,
                            int DDD, int telefone, int idTipoTelefone,
                            string rua, string bairro, string numero, string complemento, string CEP, string cidade, string UF);
        Usuario[] ConsultarUsuariosDoGestor(int idGestor);
        UsuarioDTO ConsultarUsuario(int idUsuario);
        bool VerificarLogin(string email, string senha);
        int AtualizarUsuario(int idUsuario, string nome, string sobrenome, string senha);
        int AtivarDesativarUsuario(int idUsuario);
    }
}