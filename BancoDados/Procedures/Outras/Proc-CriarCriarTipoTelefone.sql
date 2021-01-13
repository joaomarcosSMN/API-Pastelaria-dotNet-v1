IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_CriarTipoTelefone]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_CriarTipoTelefone]
GO

CREATE PROCEDURE [dbo].[SP_CriarTipoTelefone]
	@Tipo VARCHAR(20)
AS
	/* 
	Documentação
	Módulo............: Tipo_Telefone
	Objetivo..........: Criar um novo tipo de telefone
	EX................: EXEC [dbo].[SP_CriarTipoTelefone] 'Celular'
	*/
	BEGIN
		INSERT INTO Tipo_Telefone
		(Tipo)
		VALUES
		(@Tipo)
	END
