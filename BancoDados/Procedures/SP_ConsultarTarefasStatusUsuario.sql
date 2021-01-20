IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_ConsultarTarefasStatusUsuario]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_ConsultarTarefasStatusUsuario]
GO
CREATE PROCEDURE [dbo].[SP_ConsultarTarefasStatusUsuario]
(@IdUsuario SMALLINT, @IdStatusTarefa TINYINT)	
AS
	/* 
	Documentação
	Módulo............: Tarefa
	Objetivo..........: Consulta as tarefas de um usuário específico, que possuem um status específico
	EX................: EXEC [dbo].[SP_ConsultarTarefasStatusUsuario] 1, 1
	*/
	BEGIN
		SELECT IdTarefa, Descricao, DataCadastro, DataLimite, DataConclusao, DataCancelada, IdGestor, IdSubordinado, IdStatusTarefa  
			FROM Tarefa 
			WHERE IdSubordinado = @IdUsuario AND IdStatusTarefa = @IdStatusTarefa
	END