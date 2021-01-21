IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_ConsultarTotalTarefasGestor]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_ConsultarTotalTarefasGestor]
GO
CREATE PROCEDURE [dbo].[SP_ConsultarTotalTarefasGestor]
	@IdGestor SMALLINT

AS
	/* 
	Documentação
	Módulo............: Tarefa
	Objetivo..........: Consultar o total de tarefas atrasadas, futuras e agendadas
	EX................: EXEC [dbo].[SP_ConsultarTotalTarefasGestor] 1
	*/
	BEGIN
		SELECT COUNT(IdTarefa) AS Total FROM [dbo].[Tarefa]
			WHERE IdStatusTarefa IN (2, 3, 4)
				AND IdGestor = @IdGestor 

	END
