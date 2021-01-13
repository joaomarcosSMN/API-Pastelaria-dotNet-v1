IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_CriarEmail]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_CriarEmail]
GO

CREATE PROCEDURE [dbo].[SP_CriarEmail]
	@Endereco VARCHAR(254),
	@E_Login BIT,
	@Fk_Tipo_Email TINYINT,
	@Fk_Usuario SMALLINT

AS
	/* 
	Documentação
	Módulo............: Email
	Objetivo..........: Criar um novo Email
	EX................: EXEC [dbo].[SP_CriarEmail] 'ianko@gmail.com', 1, 1, 1
	*/
	BEGIN
		INSERT INTO Email
		(Endereco, E_Login, Fk_Tipo_Email, Fk_Usuario)
		VALUES
		(@Endereco, @E_Login, @Fk_Tipo_Email, @Fk_Usuario)
	END