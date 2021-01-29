IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_ConcluirTarefa]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_ConcluirTarefa]
GO
CREATE PROCEDURE [dbo].[SP_ConcluirTarefa]
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