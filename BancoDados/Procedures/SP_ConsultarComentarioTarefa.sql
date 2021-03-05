CREATE OR ALTER PROCEDURE [dbo].[SP_ConsultarComentarioTarefa]
    @IdTarefa SMALLINT

AS
	/* 
	Documentação
	Módulo............: Comentário
	Objetivo..........: Consultar comentários pelo IdTarefa
	EX................: EXEC [dbo].[SP_ConsultarComentarioTarefa] 4
	*/
	BEGIN
        SELECT c.IdComentario, 
			   c.Descricao, 
			   c.DataCadastro, 
			   c.IdTarefa, 
			   c.IdUsuario,
			   u.Nome
			FROM [dbo].[Comentario] AS c
				INNER JOIN [dbo].[Usuario] AS u
					ON c.IdUsuario = u.IdUsuario
			WHERE IdTarefa = @IdTarefa

	END


