IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_CriarComentario]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_CriarComentario]
GO
CREATE PROCEDURE [dbo].[SP_CriarComentario]
    @Comentario VARCHAR(300),
    @IdTarefa SMALLINT,
	@IdUsuario SMALLINT

AS
	/* 
	Documentação
	Módulo............: Comentário
	Objetivo..........: Criar um comentário
	EX................: EXEC [dbo].[SP_CriarComentario] 'Teste comentario com novo formato', 4, 17
	*/
	BEGIN
        INSERT INTO [dbo].[Comentario]
			(Descricao, IdTarefa, IdUsuario)
			VALUES
			(@Comentario, @IdTarefa, @IdUsuario)

	END
