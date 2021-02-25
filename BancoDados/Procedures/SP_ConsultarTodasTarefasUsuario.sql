IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_ConsultarTodasTarefasUsuario]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_ConsultarTodasTarefasUsuario]
GO
CREATE PROCEDURE [dbo].[SP_ConsultarTodasTarefasUsuario]
	@IdUsuario SMALLINT

AS
	/* 
	Documenta��o
	M�dulo............: Tarefa
	Objetivo..........: Consulta as tarefas de um usu�rio espec�fico
	EX................: EXEC [dbo].[SP_ConsultarTodasTarefasUsuario] 15
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
			   t.IdStatusTarefa,
			   st.Nome

			FROM [dbo].[Tarefa] AS t
				INNER JOIN [dbo].[StatusTarefa] AS st
					ON t.IdStatusTarefa = st.IdStatusTarefa
				INNER JOIN [dbo].[Usuario] AS ug 
					ON t.IdGestor = ug.IdUsuario 
				INNER JOIN [dbo].[Usuario] AS us
					ON t.IdSubordinado = us.IdUsuario
			WHERE t.IdSubordinado = @IdUsuario
				OR t.IdGestor = @IdUsuario
	END