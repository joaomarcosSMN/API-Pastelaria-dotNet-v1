using System;
using PastelariaSMN.Models;

namespace PastelariaSMN.Data
{
    public interface IRepository
    {

        // PROC 006
        Comentario[] ConsultarComentarios(int TarefaId);
        // PROC 007
        int CriarTarefa(string descricao, 
                        DateTime dataLimite,
                        int idGestor,
                        int idSubordinado,
                        int idStatusTarefa);
    }
}