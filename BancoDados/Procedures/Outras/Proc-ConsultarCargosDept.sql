IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_ConsultarCargoDept]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_ConsultarCargoDept]
GO

CREATE PROCEDURE [dbo].[SP_ConsultarCargoDept]
	@ID_Cargo TINYINT

AS
	/* 
	Documentação
	Módulo............: Cargo e Departamento
	Objetivo..........: Consultar os cargos e respectivos departamentos
	EX................: EXEC [dbo].[SP_ConsultarCargoDept] 1
	*/
	BEGIN
		SELECT C.ID_Cargo AS ID, C.Nome AS Cargo, C.Descricao AS Descricao, D.ID_Departamento AS IdDept, D.Nome AS Departamento
		FROM Cargo AS C
		INNER JOIN Departamento AS D
		ON C.Fk_Departamento = D.ID_Departamento
		WHERE C.ID_Cargo = @ID_Cargo
	END