using System;
using System.Collections.Generic;
using PastelariaSMN.Models;

namespace PastelariaSMN.Data
{
  public class UsuarioRepository : BaseRepository, IUsuarioRepository
  {
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
            usuario.IdUsuario = (int)reader["IdUsuario"];
            usuario.Nome = (string)reader["Nome"];
            usuario.Sobrenome = (string)reader["Sobrenome"];
            usuario.DataNascimento = (DateTime)reader["DataNascimento"];
            usuario.EGestor = (bool)reader["EGestor"];
            usuario.EstaAtivo = (bool)reader["EstaAtivo"];

            var idGestor = (string)reader["IdGestor"];
            if(idGestor != "" )
                usuario.IdGestor = int.Parse(idGestor);
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

    public int CriarUsuario(string nome, string sobrenome, DateTime dataNascimento, string senha, bool eGestor, bool estaAtivo, int? idGestor)
    {
        SetProcedure(Procedures.SP_CriarUsuario);

        AddParameter("Nome", nome);
        AddParameter("Sobrenome", sobrenome);
        AddParameter("DataNascimento", dataNascimento);
        AddParameter("Senha", senha);
        AddParameter("EGestor", eGestor ? 1 : 0);
        AddParameter("EstaAtivo", estaAtivo ? 1 : 0);
        AddParameter("IdGestor", idGestor > 0 ? idGestor : null);

        return ExecuteNonQuery();
    }

    /* ToDo
        FALTANDO CONSERTAR VerificarLogin
    */
    public bool VerificarLogin(string email, string senha)
    {
        SetProcedure(Procedures.SP_VerificarLogin);

        AddParameter("Email", email);

        return CheckLogin(email, senha);
    }
  }
}