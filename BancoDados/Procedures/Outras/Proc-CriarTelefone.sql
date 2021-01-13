IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_CriarTelefone]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_CriarTelefone]
GO

CREATE PROCEDURE [dbo].[SP_CriarTelefone]
	@NumTel VARCHAR(9),
	@DDD VARCHAR(2),
	@Fk_Tipo_Telefone TINYINT,
	@Fk_Usuario SMALLINT

AS
	/* 
	Documentação
	Módulo............: Telefone
	Objetivo..........: Criar um novo Telefone
	EX................: EXEC [dbo].[SP_CriarTelefone] '989898988', '83', 1, 1
	*/
	BEGIN
		INSERT INTO Telefone
		(Numero, DDD, Fk_Tipo_Telefone, Fk_Usuario)
		VALUES
		(@NumTel, @DDD, @Fk_Tipo_Telefone, @Fk_Usuario)
	END
