IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_ConsultarComentarioTarefa]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_ConsultarComentarioTarefa]
GO
CREATE PROCEDURE [dbo].[SP_ConsultarComentarioTarefa]
    @IdTarefa SMALLINT

AS
	/* 
	Documentação
	Módulo............: Comentário
	Objetivo..........: Consultar comentários pelo IdTarefa
	EX................: EXEC [dbo].[SP_ConsultarComentarioTarefa] 1
	*/
	BEGIN
        SELECT IdComentario, Descricao, IdTarefa 
			FROM Comentario
			WHERE IdTarefa = @IdTarefa

	END


