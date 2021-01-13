IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_CriarDepartamento]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_CriarDepartamento]
GO

CREATE PROCEDURE [dbo].[SP_CriarDepartamento]
	@Nome VARCHAR(20)
AS
	/* 
	Documentação
	Módulo............: Departamento
	Objetivo..........: Criar um novo departamento
	EX................: EXEC [dbo].[SP_CriarDepartamento] 'Vendas'
	*/
	BEGIN
		INSERT INTO Departamento
		(Nome)
		VALUES
		(@Nome)
	END
