IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_CriarComentario]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_CriarComentario]
GO
CREATE PROCEDURE [dbo].[SP_CriarComentario]
    @Comentario VARCHAR(300),
    @IdTarefa SMALLINT

AS
	/* 
	Documentação
	Módulo............: Comentário
	Objetivo..........: Criar um comentário
	EX................: EXEC [dbo].[SP_CriarComentario] 'Faltou energia dia 17/12', 1
	*/
	BEGIN
        INSERT INTO [dbo].[Comentario]
			(Descricao, IdTarefa)
			VALUES
			(@Comentario, @IdTarefa)

	END

