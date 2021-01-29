IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_ConsultarUsuario]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_ConsultarUsuario]
GO
CREATE PROCEDURE [dbo].[SP_ConsultarUsuario]
	@IdUsuario SMALLINT
	
AS
	/* 
	Documenta��o
	M�dulo............: Usuario
	Objetivo..........: Consulta Usu�rio por IdUsuario
	EX................: EXEC [dbo].[SP_ConsultarUsuario] 1
	*/
	BEGIN
		SELECT u.IdUsuario, u.Nome, u.Sobrenome, u.DataNascimento, u.EGestor, u.EstaAtivo, u.IdGestor,
			   ug.Nome AS NomeGestor,
			   ug.Sobrenome AS SobrenomeGestor
			FROM [dbo].[Usuario] AS u

			INNER JOIN Usuario AS ug 
				ON ug.IdUsuario = u.IdGestor

			WHERE u.IdUsuario = @IdUsuario
		
	END

	--passar o nome do gestor no lugar do id dele? ou os dois?