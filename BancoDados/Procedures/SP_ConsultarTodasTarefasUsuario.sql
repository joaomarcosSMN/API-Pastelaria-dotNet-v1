CREATE OR ALTER PROCEDURE [dbo].[SP_ConsultarTodasTarefasUsuario]
	@IdUsuario SMALLINT

AS
	/* 
	Documenta��o
	M�dulo............: Tarefa
	Objetivo..........: Consulta as tarefas de um usu�rio espec�fico
	EX................: EXEC [dbo].[SP_ConsultarTodasTarefasUsuario] 6
	*/
	BEGIN

		EXEC [dbo].[SP_VerificarAtraso] @IdUsuario

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