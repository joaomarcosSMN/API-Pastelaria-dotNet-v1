using System;
using System.Collections.Generic;
using PastelariaSMN.Infra;
using PastelariaSMN.Models;

namespace PastelariaSMN.Data
{
  public class UsuarioRepository : BaseRepository, IUsuarioRepository
  {
    public UsuarioRepository(Connection conn) : base(conn)
    {

    }
    private enum Procedures 
    {
        SP_AtivarDesativarUsuario,
        SP_AtualizarUsuario,
        SP_CriarUsuario,
        SP_ConsultarUsuario,
        SP_ConsultarUsuariosDoGestor,
        SP_VerificarLogin
    }
    public int AtivarDesativarUsuario(int idUsuario)
    {
        SetProcedure(Procedures.SP_AtivarDesativarUsuario);

        AddParameter("IdUsuario", idUsuario);

        return ExecuteNonQuery();
    }

    public int AtualizarUsuario(int idUsuario, string nome, string sobrenome, string senha)
    {
        SetProcedure(Procedures.SP_AtualizarUsuario);

        AddParameter("IdUsuario", idUsuario);
        AddParameter("Nome", nome);
        AddParameter("Sobrenome", sobrenome);
        AddParameter("Senha", senha);

        return ExecuteNonQuery();
    }

    public Usuario ConsultarUsuario(int idUsuario)
    {
        SetProcedure(Procedures.SP_ConsultarUsuario);
        AddParameter("IdUsuario", idUsuario);

        var usuario = new Usuario();

        var reader = ExecuteReader();
        if(reader.Read())
        {
            usuario.IdUsuario = (short)reader["IdUsuario"];
            usuario.Nome = (string)reader["Nome"];
            usuario.Sobrenome = (string)reader["Sobrenome"];
            usuario.DataNascimento = (DateTime)reader["DataNascimento"];
            usuario.EGestor = (bool)reader["EGestor"];
            usuario.EstaAtivo = (bool)reader["EstaAtivo"];

            var idGestor = reader["IdGestor"].ToString();
            if(idGestor != "" )
            {
                usuario.Gestor.IdUsuario = int.Parse(idGestor);
                usuario.Gestor.Nome = (string)reader["NomeGestor"];
                usuario.Gestor.Sobrenome = (string)reader["SobrenomeGestor"];
            }
        }

        return usuario;
    }


    public Usuario[] ConsultarUsuariosDoGestor(int idGestor)
    {
        SetProcedure(Procedures.SP_ConsultarUsuariosDoGestor);
        AddParameter("IdGestor", idGestor);

        List<Usuario> resultado = new List<Usuario>();

        var reader = ExecuteReader();
        while(reader.Read())
        {
            resultado.Add(new Usuario 
            {
                IdUsuario = int.Parse(reader["IdUsuario"].ToString()),
                Nome = reader["Nome"].ToString(),
                Sobrenome = reader["Sobrenome"].ToString(),
                EstaAtivo = bool.Parse(reader["EstaAtivo"].ToString())
            });
        }
        return resultado.ToArray();
    }

    public int CriarUsuario(Usuario novoUsuario)
    {
        SetProcedure(Procedures.SP_CriarUsuario);

        string hash = Cryptography.GerarHash(novoUsuario.Senha);

        AddParameter("Nome", novoUsuario.Nome);
        AddParameter("Sobrenome", novoUsuario.Sobrenome);
        AddParameter("DataNascimento", novoUsuario.DataNascimento);
        AddParameter("Senha", hash);
        AddParameter("EGestor", novoUsuario.EGestor ? 1 : 0);
        AddParameter("EstaAtivo", novoUsuario.EstaAtivo ? 1 : 0);
        AddParameter("IdGestor", novoUsuario.IdGestor > 0 ? novoUsuario.IdGestor : null);

        AddParameter("Email", novoUsuario.Email.EnderecoEmail);

        AddParameter("DDD", novoUsuario.Telefone.DDD);
        AddParameter("Telefone", novoUsuario.Telefone.Numero);
        AddParameter("IdTipoTelefone", novoUsuario.Telefone.IdTipo);

        AddParameter("Rua", novoUsuario.Endereco.Rua);
        AddParameter("Bairro", novoUsuario.Endereco.Bairro);
        AddParameter("Numero", novoUsuario.Endereco.Numero);
        AddParameter("Complemento", novoUsuario.Endereco.Complemento);
        AddParameter("CEP", novoUsuario.Endereco.CEP);
        AddParameter("Cidade", novoUsuario.Endereco.Cidade);
        AddParameter("UF", novoUsuario.Endereco.UF);

        return ExecuteNonQuery();
    }

    public Usuario VerificarLogin(string email)
    {
        // string hash = Cryptography.GerarHash(senha);

        SetProcedure(Procedures.SP_VerificarLogin);
        AddParameter("Email", email);

        var reader = ExecuteReader();
        if(reader.Read()) 
        {
            var usuario = new Usuario();

            usuario.Email.EnderecoEmail = reader["EnderecoEmail"].ToString();
            usuario.Senha = reader["Senha"].ToString();

            return usuario;
        }

        return null;

        // TODO: A responsábilidade de verificar, validar, orquestrar as camadas é do controller
    }
  }
}