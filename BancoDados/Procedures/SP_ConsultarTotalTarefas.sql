CREATE OR ALTER PROCEDURE [dbo].[SP_ConsultarTotalTarefas]
	@IdUsuario SMALLINT

AS
	/* 
	Documentação
	Módulo............: Tarefa
	Objetivo..........: Consultar o total de tarefas atrasadas, futuras e agendadas
	EX................: EXEC [dbo].[SP_ConsultarTotalTarefas] 2
	*/
	BEGIN
		SELECT COUNT(IdTarefa) AS Total FROM [dbo].[Tarefa]
			WHERE IdStatusTarefa IN (2, 3, 4)
				AND (IdGestor = @IdUsuario OR IdSubordinado = @IdUsuario)

	END
