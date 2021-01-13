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
	@IdGestor SMALLINT = NULL
AS
	/* 
	Documentação
	Módulo............: Usuario
	Objetivo..........: Criar um usuario
	EX................: EXEC [dbo].[SP_CriarUsuario] 'Joao', 'Silva', '10/10/1995', '7015c24fe4751a169a54d2f64d12b77f', 0, 1, 1
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
			RETURN SCOPE_IDENTITY()
	END
