IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_CriarStatusTarefa]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_CriarStatusTarefa]
GO

CREATE PROCEDURE [dbo].[SP_CriarStatusTarefa]
	@Nome VARCHAR(20)
AS
	/* 
	Documentação
	Módulo............: Status_Tarefa
	Objetivo..........: Criar um novo status de tarefa
	EX................: EXEC [dbo].[SP_CriarStatusTarefa] 'Em andamento'
	*/
	BEGIN
		INSERT INTO Status_Tarefa
		(Nome)
		VALUES
		(@Nome)
		
	END
