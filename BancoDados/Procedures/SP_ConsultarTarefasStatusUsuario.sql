CREATE OR ALTER PROCEDURE [dbo].[SP_ConsultarTarefasStatusUsuario]
	@IdUsuario SMALLINT, 
	@IdStatusTarefa TINYINT

AS
	/* 
	Documentação
	Módulo............: Tarefa
	Objetivo..........: Consulta as tarefas de um usuário específico, que possuem um status específico
	EX................: EXEC [dbo].[SP_ConsultarTarefasStatusUsuario] 28, 2
	*/
	BEGIN

		EXEC [dbo].[SP_VerificarAtraso] @IdUsuario

		SELECT IdTarefa, Descricao, DataCadastro, DataLimite, DataConclusao, DataCancelada, IdGestor, IdSubordinado, IdStatusTarefa  
			FROM Tarefa 
			WHERE IdSubordinado = @IdUsuario AND IdStatusTarefa = @IdStatusTarefa
	END