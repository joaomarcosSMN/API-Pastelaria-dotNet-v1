 IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_VerificarLogin]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_VerificarLogin]
GO
CREATE PROCEDURE [dbo].[SP_VerificarLogin]
    @Email VARCHAR(254)

AS
	/* 
	Documentação
	Módulo............: Usuario, Email
	Objetivo..........: Consultar o login de acordo com a coluna Usuario.Senha e Email.EnderecoEmail
	EX................: EXEC [dbo].[SP_VericarLogin] 'joaozin@email.co'
	*/
	BEGIN
		SELECT e.EnderecoEmail, 
				u.Senha,
				u.EGestor
			FROM Email AS e
				INNER JOIN [dbo].[Usuario] AS u WITH(NOLOCK)
					ON e.IdUsuario = u.IdUsuario
			WHERE e.EnderecoEmail = @Email

	END
