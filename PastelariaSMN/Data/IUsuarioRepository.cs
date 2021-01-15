using System;
using PastelariaSMN.Models;

namespace PastelariaSMN.Data
{
    public interface IUsuarioRepository
    {
        int CriarUsuario(string nome, string sobrenome, DateTime dataNascimento, string senha, bool eGestor, bool estaAtivo, int? idGestor);
        Usuario[] ConsultarUsuariosDoGestor(int idGestor);
        Usuario ConsultarUsuario(int idUsuario);
        bool VerificarLogin(string email, string senha);
        int AtualizarUsuario(int idUsuario, string nome, string sobrenome, string senha);
        int AtivarDesativarUsuario(int idUsuario);
    }
}