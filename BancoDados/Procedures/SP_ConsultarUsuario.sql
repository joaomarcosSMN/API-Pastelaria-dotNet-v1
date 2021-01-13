IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_ConsultarUsuario]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_ConsultarUsuario]
GO
CREATE PROCEDURE [dbo].[SP_ConsultarUsuario]
	@IdUsuario SMALLINT
	
AS
	/* 
	Documentação
	Módulo............: Usuario
	Objetivo..........: Consulta Usuário por IdUsuario
	EX................: EXEC [dbo].[SP_ConsultarUsuario] 1
	*/
	BEGIN
		SELECT IdUsuario, Nome, Sobrenome, DataNascimento, EGestor, EstaAtivo, IdGestor
			FROM [dbo].[Usuario]
			WHERE IdUsuario = @IdUsuario
		
	END
