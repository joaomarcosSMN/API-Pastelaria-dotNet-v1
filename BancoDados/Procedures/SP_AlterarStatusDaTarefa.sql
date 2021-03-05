CREATE OR ALTER PROCEDURE [dbo].[SP_AlterarStatusDaTarefa]
	@IdTarefa SMALLINT, 
	@NovoStatus TINYINT
	
AS
	/* 
	Documentação
	Módulo............: Tarefa
	Objetivo..........: Alterar o Status Da Tarefa
	EX................: EXEC [dbo].[SP_AlterarStatusDaTarefa] 1, 3
	*/
	BEGIN

		UPDATE [dbo].[Tarefa]
			SET IdStatusTarefa = @NovoStatus
			WHERE IdTarefa = @IdTarefa
		
	END