IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_ConsultarUsuariosDoGestor]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_ConsultarUsuariosDoGestor]
GO
CREATE PROCEDURE [dbo].[SP_ConsultarUsuariosDoGestor]
	@IdGestor SMALLINT

AS
	/* 
	Documentação
	Módulo............: Usuário
	Objetivo..........: Consultar todos os usuários de acordo com IdGestor
	EX................: EXEC [dbo].[SP_ConsultarUsuariosDoGestor] 1
	*/
	BEGIN
		SELECT IdUsuario, Nome, Sobrenome, EstaAtivo
			FROM [dbo].[Usuario]
			WHERE IdGestor = @IdGestor

	END
