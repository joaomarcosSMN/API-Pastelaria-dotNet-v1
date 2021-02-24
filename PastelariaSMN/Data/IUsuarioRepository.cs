using System;
using PastelariaSMN.Models;

namespace PastelariaSMN.Data
{
    public interface IUsuarioRepository
    {
        int CriarGestor(Gestor novoUsuario);
        int CriarSubordinado(Subordinado novoUsuario);
        Subordinado[] ConsultarUsuariosDoGestor(int idGestor);
        Usuario ConsultarUsuario(int idUsuario); 
        Gestor ConsultarGestor(int idUsuario); 
        Subordinado ConsultarSubordinado(int idUsuario); 
        Gestor VerificarLoginGestor(string email);
        Subordinado VerificarLoginSubordinado(string email);
        int AtualizarUsuario(int idUsuario, string nome, string sobrenome, string senha);
        int AtivarDesativarUsuario(int idUsuario);
    }
}