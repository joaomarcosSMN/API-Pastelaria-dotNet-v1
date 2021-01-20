IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_ConsultarTarefasGestor]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_ConsultarTarefasGestor]
GO
CREATE PROCEDURE [dbo].[SP_ConsultarTarefasGestor]
	@IdGestor SMALLINT

AS
	/* 
	Documentação
	Módulo............: Tarefa
	Objetivo..........: Consultar tarefas atrasadas, futuras e agendadas
	EX................: EXEC [dbo].[SP_ConsultarTarefasGestor] 1
	*/
	BEGIN
		SELECT IdTarefa, Descricao, DataCadastro, DataLimite, DataConclusao, DataCancelada, IdGestor, IdSubordinado, IdStatusTarefa   
			FROM Tarefa 
			WHERE IdStatusTarefa IN (2,3,4) 
				AND IdGestor = @IdGestor 

	END
