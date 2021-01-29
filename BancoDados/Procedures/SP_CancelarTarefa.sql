IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_CancelarTarefa]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_CancelarTarefa]
GO
CREATE PROCEDURE [dbo].[SP_CancelarTarefa]
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
