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
		SELECT u.IdUsuario, 
			   u.Nome, 
			   u.Sobrenome, 
			   u.DataNascimento, 
			   u.EGestor, 
			   u.EstaAtivo, 
			   u.IdGestor,
			   g.Nome AS NomeGestor,
			   g.Sobrenome AS SobrenomeGestor

			FROM [dbo].[Usuario] AS u
				LEFT JOIN [dbo].[Usuario] AS g
					ON u.IdGestor = g.IdUsuario
			WHERE u.IdUsuario = @IdUsuario
		
	END
