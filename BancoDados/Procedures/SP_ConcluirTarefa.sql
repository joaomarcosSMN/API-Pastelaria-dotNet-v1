CREATE OR ALTER PROCEDURE [dbo].[SP_ConcluirTarefa]
	@IdTarefa SMALLINT
	
AS
	/* 
	Documentação
	Módulo............: Tarefa
	Objetivo..........: Conclui a Tarefa
	EX................: EXEC [dbo].[SP_ConcluirTarefa] 2
	*/
	BEGIN

		UPDATE [dbo].[Tarefa]
			SET DataConclusao = GETDATE()
			WHERE IdTarefa = @IdTarefa
		
	END