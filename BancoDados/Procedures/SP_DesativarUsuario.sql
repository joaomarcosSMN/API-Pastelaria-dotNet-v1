CREATE OR ALTER PROCEDURE [dbo].[SP_DesativarUsuario]
	@IdUsuario SMALLINT
	
AS
	/* 
	Documenta��o
	M�dulo............: Usuario
	Objetivo..........: Desativa o Usu�rio alterando o status do campo EstaAtivo para 0
	EX................: EXEC [dbo].[SP_DesativarUsuario] 1
	*/
	BEGIN
		UPDATE [dbo].[Usuario]
			SET EstaAtivo = 0
			WHERE IdUsuario = @IdUsuario
		
	END