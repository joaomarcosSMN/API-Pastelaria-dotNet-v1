IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_ConcluirTarefa]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_ConcluirTarefa]
GO
CREATE PROCEDURE [dbo].[SP_ConcluirTarefa]
	@IdTarefa SMALLINT
	
AS
	/* 
	Documenta��o
	M�dulo............: Tarefa
	Objetivo..........: Conclui a Tarefa
	EX................: EXEC [dbo].[SP_ConcluirTarefa] 1
	*/
	BEGIN

		UPDATE [dbo].[Tarefa]
			SET DataConclusao = GETDATE(), IdStatusTarefa = 1
			WHERE IdTarefa = @IdTarefa
		
	END
	