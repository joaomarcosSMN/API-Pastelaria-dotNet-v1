IF EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[TG_AttStatusTarefa]'))
	DROP TRIGGER [dbo].[TG_AttStatusTarefa]
GO

CREATE TRIGGER [dbo].[TG_AttStatusTarefa]
	ON Tarefa
	AFTER UPDATE 
AS
	/* 
	Documentação
	Módulo............: Tarefa -> Atualizacao
	Objetivo..........: Inserir uma Atualizacao após atualizar campo Status_Tarefa em Tarefa
	EX................: EXEC [dbo].[SP_CriarAtualizacao] 'Faltou Energia', 1, 2
	*/

	--UPDATE Tarefa SET Fk_Status_Tarefa = 2 WHERE ID_Tarefa = 1
	
	BEGIN		
	SET NOCOUNT ON;
	IF UPDATE(Fk_Status_Tarefa)
		DECLARE @ID_Tarefa SMALLINT, @Motivo VARCHAR(200), 
		@ID_Status_Tarefa SMALLINT, @ID_Usuario SMALLINT

		SELECT @ID_Tarefa = ID_Tarefa FROM DELETED
		SELECT @ID_Status_Tarefa = Fk_Status_Tarefa FROM INSERTED

		INSERT INTO Atualizacao
		(Motivo, Fk_Tarefa, Fk_Usuario) 
		VALUES
		(@Motivo, @ID_Tarefa, @ID_Usuario) 
	END
