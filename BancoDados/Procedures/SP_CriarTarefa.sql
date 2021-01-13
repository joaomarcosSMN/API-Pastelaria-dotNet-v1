IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_CriarTarefa]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_CriarTarefa]
GO
CREATE PROCEDURE [dbo].[SP_CriarTarefa]
	@Descricao VARCHAR(300),
	@DataLimite DATETIME,
	--@DataConclusao DATETIME = NULL,
	--@DataCancelada DATETIME = NULL,
	@IdGestor SMALLINT,
	@IdSubordinado SMALLINT,
	@IdStatusTarefa TINYINT

AS
	/* 
	Documentação
	Módulo............: Tarefa
	Objetivo..........: Criar uma tarefa
	EX................: EXEC [dbo].[SP_CriarTarefa] 'Fritar massas de pastel', '20201215 02:30:00 PM', 1, 2, 2 
	*/
	BEGIN
		INSERT INTO [dbo].[Tarefa]
		(Descricao, DataLimite, IdGestor, IdSubordinado, IdStatusTarefa)
		VALUES
		(@Descricao, @DataLimite, @IdGestor, @IdSubordinado, @IdStatusTarefa)	

	END
