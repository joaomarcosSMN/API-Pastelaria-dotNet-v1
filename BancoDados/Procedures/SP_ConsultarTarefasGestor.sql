CREATE OR ALTER PROCEDURE [dbo].[SP_ConsultarTarefasGestor]
	@IdGestor SMALLINT

AS
	/* 
	Documentação
	Módulo............: Tarefa
	Objetivo..........: Consultar tarefas atrasadas, futuras e agendadas
	EX................: EXEC [dbo].[SP_ConsultarTarefasGestor] 4
	*/
	BEGIN

		EXEC [dbo].[SP_VerificarAtraso] @IdGestor

		SELECT IdTarefa, Descricao, DataCadastro, DataLimite, DataConclusao, DataCancelada, IdGestor, IdSubordinado, IdStatusTarefa   
			FROM Tarefa 
			WHERE IdStatusTarefa IN (2,3,4) 
				AND IdGestor = @IdGestor 

	END
