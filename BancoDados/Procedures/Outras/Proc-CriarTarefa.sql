IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_CriarTarefa]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_CriarTarefa]
GO

CREATE PROCEDURE [dbo].[SP_CriarTarefa]
	@Titulo VARCHAR(50),
	@Descricao VARCHAR(300),
	@Data_Limite DATETIME,
	@Fk_Criador SMALLINT,
	@Fk_Status_Tarefa TINYINT

AS
	/* 
	Documentação
	Módulo............: Tarefa
	Objetivo..........: Criar um nova Tarefa
	EX................: EXEC [dbo].[SP_CriarTarefa] 'Planejamento mensal', 'Planejar o mes de Janeiro', '20210110 02:30:00PM', 1, 1
	*/

	BEGIN
		INSERT INTO Tarefa
		(Titulo, Descricao, Data_Limite, Fk_Criador, Fk_Status_Tarefa) 
		VALUES
		(@Titulo, @Descricao, @Data_Limite, @Fk_Criador, @Fk_Status_Tarefa) 
	END
