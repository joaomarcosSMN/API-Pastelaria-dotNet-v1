IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_ConsultarTarefasUsuario]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_ConsultarTarefasUsuario]
GO
CREATE PROCEDURE [dbo].[SP_ConsultarTarefasUsuario]
	@IdUsuario SMALLINT

AS
	/* 
	Documenta��o
	M�dulo............: Tarefa
	Objetivo..........: Consulta as tarefas de um usu�rio espec�fico
	EX................: EXEC [dbo].[SP_ConsultarTarefasUsuario] 2
	*/
	BEGIN
		SELECT IdTarefa, Descricao, DataCadastro, DataLimite, DataConclusao, DataCancelada, t.IdGestor, t.IdSubordinado, IdStatusTarefa,
			   ug.Nome + ' ' + ug.Sobrenome AS NomeGestor, us.Nome + ' ' + us.Sobrenome AS NomeSubordinado
			FROM [dbo].[Tarefa] AS t

			INNER JOIN Usuario AS ug 
				ON ug.IdUsuario = t.IdGestor
			INNER JOIN Usuario AS us
				ON us.IdUsuario = t.IdSubordinado

			WHERE t.IdSubordinado = @IdUsuario

	END