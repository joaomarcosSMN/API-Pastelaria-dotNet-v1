IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_CriarUsuario]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_CriarUsuario]
GO

CREATE PROCEDURE [dbo].[SP_CriarUsuario]
	@Nome VARCHAR(30),
	@Sobrenome VARCHAR(50),
	@Data_Nascimento DATE,	
	@Senha VARCHAR(50),
	@E_Admin BIT,
	@Esta_Ativo BIT,
	@Fk_Cargo TINYINT

AS
	/* 
	Documentação
	Módulo............: Usuario
	Objetivo..........: Criar um novo usuario
	EX................: EXEC [dbo].[SP_CriarUsuario] 'Renan', 'Silva', '10/10/1990', '922ec9531b1f94add983a8ce2ebdc97b', 0, 1, 2
	*/

	BEGIN
		INSERT INTO Usuario
		(Nome, Sobrenome, Data_Nascimento, Senha, E_Admin, Esta_Ativo, Fk_Cargo)
		VALUES
		(@Nome, @Sobrenome, @Data_Nascimento, @Senha, @E_Admin, @Esta_Ativo, @Fk_Cargo)
		
	END
