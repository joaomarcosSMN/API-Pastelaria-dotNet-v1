IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_ContarTarefasPorSubordinado]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_ContarTarefasPorSubordinado]
GO
CREATE PROCEDURE [dbo].[SP_ContarTarefasPorSubordinado]
	@IdSubordinado SMALLINT
	
AS
	/* 
	Documentação
	Módulo............: Tarefas
	Objetivo..........: Contar Tarefas Por Subordinado
	EX................: EXEC [dbo].[SP_ContarTarefasPorSubordinado] 1
	*/
	BEGIN
		SELECT COUNT(IdTarefa) AS Total 
			FROM [dbo].[Tarefa]
			WHERE IdSubordinado = @IdSubordinado 
				AND IdStatusTarefa IN (2,3,4)
		
	END