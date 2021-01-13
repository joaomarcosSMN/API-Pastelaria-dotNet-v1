IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_CriarCargo]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_CriarCargo]
GO

CREATE PROCEDURE [dbo].[SP_CriarCargo]
	@Nome VARCHAR(20),
	@Descricao VARCHAR(50),
	@Fk_Departamento TINYINT
AS
	/* 
	Documentação
	Módulo............: Cargo
	Objetivo..........: Criar um novo cargo
	EX................: EXEC [dbo].[SP_CriarCargo] 'Gerente', 'Gerenciar atividades', 1
	*/
	BEGIN
		INSERT INTO Cargo
		(Nome, Descricao, Fk_Departamento)
		VALUES
		(@Nome, @Descricao, @Fk_Departamento)
		
	END
