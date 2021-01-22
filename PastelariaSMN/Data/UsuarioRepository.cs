using System;
using System.Collections.Generic;
using PastelariaSMN.DTOs;
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

    public UsuarioDTO ConsultarUsuario(int idUsuario)
    {
        SetProcedure(Procedures.SP_ConsultarUsuario);
        AddParameter("IdUsuario", idUsuario);

        var usuario = new UsuarioDTO();

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
            {
                usuario.IdGestor = int.Parse(idGestor);
                usuario.NomeGestor = (string)reader["EstaAtivo"];
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

    public int CriarUsuario(string nome, string sobrenome, DateTime dataNascimento, string senha, bool eGestor, bool estaAtivo, int? idGestor,
                            string email,
                            int DDD, int telefone, int idTipoTelefone,
                            string rua, string bairro, string numero, string complemento, string CEP, string cidade, string UF)
    {
        SetProcedure(Procedures.SP_CriarUsuario);

        string hash = GerarHashMd5(senha);

        AddParameter("Nome", nome);
        AddParameter("Sobrenome", sobrenome);
        AddParameter("DataNascimento", dataNascimento);
        AddParameter("Senha", hash);
        AddParameter("EGestor", eGestor ? 1 : 0);
        AddParameter("EstaAtivo", estaAtivo ? 1 : 0);
        AddParameter("IdGestor", idGestor > 0 ? idGestor : null);

        AddParameter("Email", email);

        AddParameter("DDD", DDD);
        AddParameter("Telefone", telefone);
        AddParameter("IdTipoTelefone", idTipoTelefone);

        AddParameter("Rua", rua);
        AddParameter("Bairro", bairro);
        AddParameter("Numero", numero);
        AddParameter("Complemento", complemento);
        AddParameter("CEP", CEP);
        AddParameter("Cidade", cidade);
        AddParameter("UF", UF);


        return ExecuteNonQuery();
    }

    /* ToDo
        FALTANDO CONSERTAR VerificarLogin
    */
    public bool VerificarLogin(string email, string senha)
    {
        string hash = GerarHashMd5(senha);

        SetProcedure(Procedures.SP_VerificarLogin);

        AddParameter("Email", email);

        // TODO: A responsábilidade de verificar, validar, orquestrar as camadas é do controller
        return CheckLogin(email, hash);
    }
  }
}