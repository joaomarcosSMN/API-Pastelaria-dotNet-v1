CREATE OR ALTER PROCEDURE [dbo].[SP_ContarTarefasPorSubordinado]
	@IdSubordinado SMALLINT
	
AS
	/* 
	Documentação
	Módulo............: Tarefas
	Objetivo..........: Contar Tarefas Por Subordinado
	EX................: EXEC [dbo].[SP_ContarTarefasPorSubordinado] 2
	*/
	BEGIN
		SELECT COUNT(IdTarefa) AS Total 
			FROM [dbo].[Tarefa]
			WHERE IdSubordinado = @IdSubordinado 
				AND IdStatusTarefa IN (2,3,4)
		
	END