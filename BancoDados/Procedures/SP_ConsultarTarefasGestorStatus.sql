IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_ConsultarTarefasGestorStatus]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_ConsultarTarefasGestorStatus]
GO
CREATE PROCEDURE [dbo].[SP_ConsultarTarefasGestorStatus]
	@IdGestor SMALLINT,
	@IdStatusTarefa TINYINT

AS
	/* 
	Documentação
	Módulo............: Tarefa
	Objetivo..........: Consultar tarefas de acordo com IdStatusTarefa e IdGestor
	EX................: EXEC [dbo].[SP_ConsultarTarefasGestorStatus] 1, 3
	*/
	BEGIN
		SELECT IdTarefa, Descricao, DataCadastro, DataLimite, DataConclusao, DataCancelada
			FROM [dbo].[Tarefa] 
			WHERE IdGestor = @IdGestor AND IdStatusTarefa = @IdStatusTarefa

	END
