CREATE OR ALTER PROCEDURE [dbo].[SP_CancelarTarefa]
	@IdTarefa SMALLINT

AS
	/* 
	Documentação
	Módulo............: Tarefa
	Objetivo..........: Cancelar a tarefa
	EX................: EXEC [dbo].[SP_CancelarTarefa] 1
	*/
	BEGIN
		UPDATE Tarefa 
			SET DataCancelada = GETDATE(),
				IdStatusTarefa = 5
			WHERE IdTarefa = @IdTarefa

	END
