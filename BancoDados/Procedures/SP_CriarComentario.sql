CREATE OR ALTER PROCEDURE [dbo].[SP_CriarComentario]
    @Comentario VARCHAR(300),
    @IdTarefa SMALLINT,
	@IdUsuario SMALLINT

AS
	/* 
	Documenta��o
	M�dulo............: Coment�rio
	Objetivo..........: Criar um coment�rio
	EX................: EXEC [dbo].[SP_CriarComentario] 'Teste comentario com novo formato', 4, 17
	*/
	BEGIN
        INSERT INTO [dbo].[Comentario]
			(Descricao, IdTarefa, IdUsuario)
			VALUES
			(@Comentario, @IdTarefa, @IdUsuario)

	END
