IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_ConsultarTarefasUsuario]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_ConsultarTarefasUsuario]
GO
CREATE PROCEDURE [dbo].[SP_ConsultarTarefasUsuario]
	@IdUsuario SMALLINT

AS
	/* 
	Documentação
	Módulo............: Tarefa
	Objetivo..........: Consulta as tarefas de um usuário específico
	EX................: EXEC [dbo].[SP_ConsultarTarefasUsuario] 1
	*/
	BEGIN
		SELECT IdTarefa, Descricao, DataCadastro, DataLimite, DataConclusao, DataCancelada, IdGestor, IdSubordinado, IdStatusTarefa  
			FROM [dbo].[Tarefa] 
			WHERE IdSubordinado = @IdUsuario
	END