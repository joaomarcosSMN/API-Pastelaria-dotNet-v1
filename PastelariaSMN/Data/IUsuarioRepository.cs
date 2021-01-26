using System;
using PastelariaSMN.DTOs;
using PastelariaSMN.Models;

namespace PastelariaSMN.Data
{
    public interface IUsuarioRepository
    {
        public RepositoryResult<int> CriarUsuario(string nome, string sobrenome, DateTime dataNascimento, string senha, bool eGestor, bool estaAtivo, int? idGestor,
                            string email,
                            int DDD, int telefone, int idTipoTelefone,
                            string rua, string bairro, string numero, string complemento, string CEP, string cidade, string UF);
        RepositoryResult<Usuario[]> ConsultarUsuariosDoGestor(int idGestor);
        RepositoryResult<UsuarioDTO> ConsultarUsuario(int idUsuario);
        bool VerificarLogin(string email, string senha);
        RepositoryResult<int> AtualizarUsuario(int idUsuario, string nome, string sobrenome, string senha);
        RepositoryResult<int> AtivarDesativarUsuario(int idUsuario);
    }
}