using System;
using PastelariaSMN.DTOs;
using PastelariaSMN.Models;

namespace PastelariaSMN.Data
{
    public interface IUsuarioRepository
    {
        int CriarUsuario(Usuario novoUsuario);
        Usuario[] ConsultarUsuariosDoGestor(int idGestor);
        Usuario ConsultarUsuario(int idUsuario); 
        Usuario VerificarLogin(string email, string senha);
        int AtualizarUsuario(int idUsuario, string nome, string sobrenome, string senha);
        int AtivarDesativarUsuario(int idUsuario);
    }
}