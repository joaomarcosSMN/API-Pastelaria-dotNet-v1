IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_AlterarStatusDaTarefa]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_AlterarStatusDaTarefa]
GO
CREATE PROCEDURE [dbo].[SP_AlterarStatusDaTarefa]
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