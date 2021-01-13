IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_ConsultarInfoGestor]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_ConsultarInfoGestor]
GO

CREATE PROCEDURE [dbo].[SP_ConsultarInfoGestor]
	@ID_Cargo TINYINT

AS
	/* 
	Documentação
	Módulo............: Usuarios
	Objetivo..........: Consultar os usuarios que são gestores
	EX................: EXEC [dbo].[SP_ConsultarInfoGestor] 1
	*/

	BEGIN
		SELECT U.ID_Usuario AS ID, U.Nome, U.Data_Nascimento AS Nasceu, U.Fk_Cargo AS IdCargo, C.Nome AS Cargo, D.Nome AS Departamento
		FROM Usuario AS U
		INNER JOIN Cargo AS C
		ON U.Fk_Cargo = C.ID_Cargo
		INNER JOIN Departamento AS D
		ON C.Fk_Departamento = D.ID_Departamento 
		WHERE C.ID_Cargo = @ID_Cargo

	END
