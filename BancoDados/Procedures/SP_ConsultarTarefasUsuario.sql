CREATE OR ALTER PROCEDURE [dbo].[SP_ConsultarTarefasUsuario]
	@IdUsuario SMALLINT

AS
	/* 
	Documentação
	Módulo............: Tarefa
	Objetivo..........: Consulta as tarefas de um usuário específico
	EX................: EXEC [dbo].[SP_ConsultarTarefasUsuario] 28
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
			   t.IdStatusTarefa  
			FROM [dbo].[Tarefa] AS t
				INNER JOIN [dbo].[Usuario] AS ug 
					ON t.IdGestor = ug.IdUsuario 
				INNER JOIN [dbo].[Usuario] AS us
					ON t.IdSubordinado = us.IdUsuario
			WHERE IdSubordinado = @IdUsuario
	END