CREATE OR ALTER PROCEDURE [dbo].[SP_EditarDataLimite]
	@IdTarefa SMALLINT,
	@DataLimite DATETIME

AS
	/* 
	Documentação
	Módulo............: Tarefa
	Objetivo..........: Alterar a data limite da tarefa
	EX................: EXEC [dbo].[SP_EditarDataLimite] 1, '20210102 03:30:00 PM'
	*/
	BEGIN
		UPDATE [dbo].[Tarefa]
			SET DataLimite = @DataLimite
			WHERE IdTarefa = @IdTarefa

	END
