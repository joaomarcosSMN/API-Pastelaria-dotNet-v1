IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_ConsultarTarefa]') AND objectproperty(id, N'IsPROCEDURE')=1)
    DROP PROCEDURE [dbo].[SP_ConsultarTarefa]
GO
CREATE PROCEDURE [dbo].[SP_ConsultarTarefa]
    @IdTarefa SMALLINT
    
AS
    /* 
    Documenta��o
    M�dulo............: Usuario
    Objetivo..........: Consulta tarefa pelo ID
    EX................: EXEC [dbo].[SP_ConsultarTarefa] 55
    */
    BEGIN

		UPDATE TAREFA
			SET IdStatusTarefa = 4
			WHERE (IdTarefa = @IdTarefa)
			AND DataLimite < GETDATE()
			AND IdStatusTarefa IN (2,3)

     SELECT T.IdTarefa, 
			T.Descricao, 
			T.DataCadastro, 
			T.DataLimite, 
			T.DataConclusao, 
			T.DataCancelada, 
			T.IdGestor, 
			T.IdSubordinado, 
			T.IdStatusTarefa,
			ST.Nome
     
     FROM Tarefa AS T
		INNER JOIN StatusTarefa AS ST
			ON T.IdStatusTarefa = ST.IdStatusTarefa
		WHERE T.IdTarefa = @IdTarefa

    END