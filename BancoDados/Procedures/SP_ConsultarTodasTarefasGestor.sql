IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_ConsultarTodasTarefasGestor]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_ConsultarTodasTarefasGestor]
GO
CREATE PROCEDURE [dbo].[SP_ConsultarTodasTarefasGestor]
	@IdGestor SMALLINT

AS
	/* 
	Documenta��o
	M�dulo............: Tarefa
	Objetivo..........: Consultar todas as tarefas de acordo com IdGestor
	EX................: EXEC [dbo].[SP_ConsultarTodasTarefasGestor] 1
	*/
	BEGIN
		SELECT IdTarefa, Descricao, DataCadastro, DataLimite, DataConclusao, DataCancelada, t.IdGestor, t.IdSubordinado, IdStatusTarefa,
			   ug.Nome + ' ' + ug.Sobrenome AS NomeGestor, us.Nome + ' ' + us.Sobrenome AS NomeSubordinado
			FROM [dbo].[Tarefa] AS t

			INNER JOIN Usuario AS ug 
				ON ug.IdUsuario = t.IdGestor
			INNER JOIN Usuario AS us
				ON us.IdUsuario = t.IdSubordinado
			
			WHERE t.IdGestor = @IdGestor 

	END
