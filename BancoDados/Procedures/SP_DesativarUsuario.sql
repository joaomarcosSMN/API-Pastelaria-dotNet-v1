CREATE OR ALTER PROCEDURE [dbo].[SP_DesativarUsuario]
	@IdUsuario SMALLINT
	
AS
	/* 
	Documentação
	Módulo............: Usuario
	Objetivo..........: Desativa o Usuário alterando o status do campo EstaAtivo para 0
	EX................: EXEC [dbo].[SP_DesativarUsuario] 1
	*/
	BEGIN
		UPDATE [dbo].[Usuario]
			SET EstaAtivo = 0
			WHERE IdUsuario = @IdUsuario
		
	END