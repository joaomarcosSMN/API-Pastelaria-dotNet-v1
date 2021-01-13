IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_DesativarUsuario]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_DesativarUsuario]
GO
CREATE PROCEDURE [dbo].[SP_DesativarUsuario]
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