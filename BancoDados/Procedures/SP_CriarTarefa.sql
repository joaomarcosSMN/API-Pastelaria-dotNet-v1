CREATE OR ALTER PROCEDURE [dbo].[SP_CriarTarefa]
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
	EX................: EXEC [dbo].[SP_CriarTarefa] 'Limpar a cozinha denovo 3 ', '20201215 02:30:00 PM', 1, 15, 2
	*/
	BEGIN
		INSERT INTO [dbo].[Tarefa]
			(Descricao, DataLimite, IdGestor, IdSubordinado, IdStatusTarefa)
			VALUES
			(@Descricao, @DataLimite, @IdGestor, @IdSubordinado, @IdStatusTarefa)	

		SELECT SCOPE_IDENTITY() AS IdTarefa
	END
