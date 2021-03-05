CREATE OR ALTER PROCEDURE [dbo].[SP_ConsultarTodasTarefasGestor]
	@IdGestor SMALLINT

AS
	/* 
	Documentação
	Módulo............: Tarefa
	Objetivo..........: Consultar todas as tarefas de acordo com IdGestor
	EX................: EXEC [dbo].[SP_ConsultarTodasTarefasGestor] 4
	*/
	BEGIN
		
		EXEC [dbo].[SP_VerificarAtraso] @IdGestor
		
		SELECT IdTarefa, Descricao, DataCadastro, DataLimite, DataConclusao, DataCancelada, IdStatusTarefa
			FROM Tarefa 
			WHERE IdGestor = @IdGestor 

	END
