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

	@Email VARCHAR(254),

	@DDD TINYINT,
	@Telefone INT,
	@IdTipoTelefone TINYINT,
	
	@Rua VARCHAR(70),
	@Bairro VARCHAR(60),
	@Numero VARCHAR(10),
	@Complemento VARCHAR(50),
	@CEP VARCHAR(8),
	@Cidade VARCHAR(32),
	@UF VARCHAR(2)
AS
	/* 
	Documentação
	Módulo............: Usuario
	Objetivo..........: Criar um usuario
	EX................: EXEC [dbo].[SP_CriarUsuario] 'Ianko', 'Cavalcanti', '11/11/1995', '7015c24fe4751a169a54d2f64d12b77f', 0, 1, 1, 'joaomarcoslucenaf@gmail.com', 83, 999887766, 2, 'Av. Ruy Carneiro', 'Tambau', '500', 'Bloco B', '58000500', 'Joao Pessoa', 'PB' 
	*/
	BEGIN

		DECLARE @idUsuario SMALLINT

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

		SET @idUsuario = SCOPE_IDENTITY()

		INSERT INTO Email
			(EnderecoEmail, IdUsuario)
			VALUES
				(@Email, @idUsuario)

		INSERT INTO Telefone
			(Numero, DDD, IdTipoTelefone, IdUsuario)
			VALUES
				(@Telefone, @DDD, @IdTipoTelefone, @idUsuario)

		INSERT INTO Endereco
			(Rua, Bairro, Numero, Complemento, CEP, Cidade, UF, IdUsuario)
			VALUES
				(@Rua, @Bairro, @Numero, @Complemento, @CEP, @Cidade, @UF, @idUsuario)
			
	END
