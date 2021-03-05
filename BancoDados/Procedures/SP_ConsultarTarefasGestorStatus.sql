CREATE OR ALTER PROCEDURE [dbo].[SP_ConsultarTarefasGestorStatus]
	@IdGestor SMALLINT,
	@IdStatusTarefa TINYINT

AS
	/* 
	Documentação
	Módulo............: Tarefa
	Objetivo..........: Consultar tarefas de acordo com IdStatusTarefa e IdGestor
	EX................: EXEC [dbo].[SP_ConsultarTarefasGestorStatus] 4, 2
	*/
	BEGIN

		EXEC [dbo].[SP_VerificarAtraso] @IdGestor

		SELECT IdTarefa, Descricao, DataCadastro, DataLimite, DataConclusao, DataCancelada
			FROM [dbo].[Tarefa] 
			WHERE IdGestor = @IdGestor AND IdStatusTarefa = @IdStatusTarefa

	END
