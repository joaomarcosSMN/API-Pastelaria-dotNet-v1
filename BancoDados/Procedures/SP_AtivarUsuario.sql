CREATE OR ALTER PROCEDURE [dbo].[SP_AtivarUsuario]
	@IdUsuario SMALLINT
	
AS
	/* 
	Documentação
	Módulo............: Usuario
	Objetivo..........: Ativa o Usuário alterando o status do campo EstaAtivo para 1
	EX................: EXEC [dbo].[SP_AtivarUsuario] 1
	*/
	BEGIN
		UPDATE Usuario
			SET EstaAtivo = 1
			WHERE IdUsuario = @IdUsuario
		
	END
