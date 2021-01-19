IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_CriarUsuario]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_CriarUsuario]
GO
CREATE PROCEDURE [dbo].[SP_CriarUsuario]
	@Nome VARCHAR(30),
	@Sobrenome VARCHAR(50),
	@DataNascimento DATE,
	@Senha VARCHAR(50),
	@EGestor BIT,
	@EstaAtivo BIT,
	@IdGestor SMALLINT = NULL,

	@Email VARCHAR(254)
AS
	/* 
	Documentação
	Módulo............: Usuario
	Objetivo..........: Criar um usuario
	EX................: EXEC [dbo].[SP_CriarUsuario] 'Onersio', 'Silva', '10/10/1995', '7015c24fe4751a169a54d2f64d12b77f', 0, 1, 1, 'onersiosilva@gmail.com'
	*/
	BEGIN
		INSERT INTO [dbo].[Usuario]
			(Nome, 
			 Sobrenome, 
			 DataNascimento,
			 Senha,
			 EGestor,
			 EstaAtivo,
			 IdGestor)
			VALUES
			(@Nome, 
			 @Sobrenome,
			 @DataNascimento,
			 @Senha, 
			 @EGestor, 
			 @EstaAtivo, 
			 @IdGestor)

			 INSERT INTO Email
			(EnderecoEmail, IdUsuario)
				VALUES
			(@Email, SCOPE_IDENTITY())
			
	END
