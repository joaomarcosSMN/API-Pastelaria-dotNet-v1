CREATE OR ALTER PROCEDURE [dbo].[SP_ConcluirTarefa]
	@IdTarefa SMALLINT
	
AS
	/* 
	Documenta��o
	M�dulo............: Tarefa
	Objetivo..........: Conclui a Tarefa
	EX................: EXEC [dbo].[SP_ConcluirTarefa] 2
	*/
	BEGIN

		UPDATE [dbo].[Tarefa]
			SET DataConclusao = GETDATE(),
				IdStatusTarefa = 1
			WHERE IdTarefa = @IdTarefa
		
	END