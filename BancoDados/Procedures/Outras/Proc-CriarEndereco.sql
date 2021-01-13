IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_CriarEndereco]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_CriarEndereco]
GO

CREATE PROCEDURE [dbo].[SP_CriarEndereco]
	@Rua VARCHAR(70),
	@Bairro VARCHAR(60),
	@Numero VARCHAR(10),
	@Complemento VARCHAR(50),
	@CEP VARCHAR(8),
	@Cidade VARCHAR(32),
	@UF VARCHAR(2),
	@Fk_Usuario SMALLINT

AS
	/* 
	Documentação
	Módulo............: Endereco
	Objetivo..........: Criar um novo Endereco
	EX................: EXEC [dbo].[SP_CriarEndereco] 'Av. Ruy Carneiro', 'Tambau', '500', 'Bloco A', '55555333', 'João Pessoa', 'PB', 1
	*/
	BEGIN

		INSERT INTO Endereco
		(Rua, Bairro, Numero, Complemento, CEP, Cidade, UF, Fk_Usuario)
		VALUES
		(@Rua, @Bairro, @Numero, @Complemento, @CEP, @Cidade, @UF, @Fk_Usuario)
	END