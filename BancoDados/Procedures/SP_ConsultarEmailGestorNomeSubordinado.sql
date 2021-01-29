/*Verifica se a procedure existe se existe da um drop apagando*/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_ConsultarEmailGestorNomeSubordinado]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_ConsultarEmailGestorNomeSubordinado]
GO
CREATE PROCEDURE [dbo].[SP_ConsultarEmailGestorNomeSubordinado]
	@IdTarefa SMALLINT
	
AS
	/* 
	Documentação
	Módulo............: Tabela
	Objetivo..........: Buscar email do gestor e nome do subordinado buscando por id da tarefa
	EX................: EXEC [dbo].[SP_ConsultarEmailGestorNomeSubordinado] 2
	*/
	BEGIN

		SELECT t.IdTarefa, 
			   ug.Nome AS NomeGestor,
			   ug.Sobrenome AS SobrenomeGestor, 
			   ge.EnderecoEmail AS EmailGestor,
			   us.Nome AS NomeSubordinado,
			   us.Sobrenome AS SobrenomeSubordinado,
			   se.EnderecoEmail AS EmailSubordinado

			FROM Tarefa as t
				INNER JOIN Usuario AS ug 
					ON ug.IdUsuario = t.IdGestor
				INNER JOIN Email AS ge 
					ON ge.IdUsuario = t.IdGestor
				INNER JOIN Usuario AS us 
					ON us.IdUsuario = t.IdSubordinado
				INNER JOIN Email AS se 
					ON se.IdUsuario = us.IdUsuario
		
			WHERE IdTarefa = @IdTarefa
		
	END
