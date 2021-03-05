CREATE OR ALTER PROCEDURE [dbo].[SP_ConsultarUsuario]
	@IdUsuario SMALLINT
	
AS
	/* 
	Documenta��o
	M�dulo............: Usuario
	Objetivo..........: Consulta Usu�rio por IdUsuario
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
			   g.Sobrenome AS SobrenomeGestor,
			   g.IdUsuario AS IdUsuarioGestor,

			   em.IdEmail,
			   em.EnderecoEmail,

			   t.IdTelefone,
			   t.DDD,
			   t.Numero AS NumeroTelefone,

			   en.IdEndereco,
			   en.UF,
			   en.Cidade,
			   en.Bairro,
			   en.Rua,
			   en.Numero AS NumeroEndereco,
			   en.Complemento,
			   en.CEP

			FROM [dbo].[Usuario] AS u
				LEFT JOIN [dbo].[Usuario] AS g
					ON u.IdGestor = g.IdUsuario
				INNER JOIN [dbo].[Email] AS em
					ON u.IdUsuario = em.IdUsuario
				INNER JOIN [dbo].[Telefone] AS t
					ON u.IdUsuario = t.IdUsuario
				INNER JOIN [dbo].[Endereco] AS en
					ON u.IdUsuario = en.IdUsuario
			WHERE u.IdUsuario = @IdUsuario
		
	END
