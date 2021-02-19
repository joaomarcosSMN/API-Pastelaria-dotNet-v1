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
	EX................: EXEC [dbo].[SP_ConsultarTarefasUsuario] 3
	*/
	BEGIN
		SELECT t.IdTarefa, 
			   t.Descricao, 
			   t.DataCadastro, 
			   t.DataLimite, 
			   t.DataConclusao, 
			   t.DataCancelada, 
			   t.IdGestor, 
			   ug.Nome AS NomeGestor, 
			   t.IdSubordinado, 
			   us.Nome AS NomeSubordinado, 
			   t.IdStatusTarefa  
			FROM [dbo].[Tarefa] AS t
				INNER JOIN [dbo].[Usuario] AS ug 
					ON t.IdGestor = ug.IdUsuario 
				INNER JOIN [dbo].[Usuario] AS us
					ON t.IdSubordinado = us.IdUsuario
			WHERE IdSubordinado = @IdUsuario
	END