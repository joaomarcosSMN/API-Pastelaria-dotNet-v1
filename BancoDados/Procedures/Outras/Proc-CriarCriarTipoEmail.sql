IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_CriarTipoEmail]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_CriarTipoEmail]
GO

CREATE PROCEDURE [dbo].[SP_CriarTipoEmail]
	@Tipo VARCHAR(20)
AS
	/* 
	Documentação
	Módulo............: Tipo_Email
	Objetivo..........: Criar um novo tipo de Email
	EX................: EXEC [dbo].[SP_CriarTipoEmail] 'Empresarial'
	*/
	BEGIN
		INSERT INTO Tipo_Email
		(Tipo)
		VALUES
		(@Tipo)
	END
