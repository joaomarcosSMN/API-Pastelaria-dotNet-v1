IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_ConsultarTarefasAndamento]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_ConsultarTarefasAndamento]
GO
CREATE PROCEDURE [dbo].[SP_ConsultarTarefasAndamento]
	@IdUsuario SMALLINT

AS
	/* 
	Documentação
	Módulo............: Tarefa
	Objetivo..........: Consultar tarefas atrasadas, futuras e agendadas
	EX................: EXEC [dbo].[SP_ConsultarTarefasAndamento] 15
	*/
	BEGIN
		SELECT IdTarefa, Descricao, DataCadastro, DataLimite, DataConclusao, DataCancelada, IdGestor, IdSubordinado, IdStatusTarefa   
			FROM Tarefa 
			WHERE IdStatusTarefa IN (2,3,4) 
				AND (IdGestor = @IdUsuario OR IdSubordinado = @IdUsuario)

	END
