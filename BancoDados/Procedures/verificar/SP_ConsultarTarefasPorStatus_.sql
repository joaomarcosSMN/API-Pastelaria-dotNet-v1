CREATE OR ALTER PROCEDURE [dbo].[SP_ConsultarTarefasPorStatus]
	@IdUsuario SMALLINT, 
	@IdStatusTarefa TINYINT

AS
	/* 
	Documenta��o
	M�dulo............: Tarefa
	Objetivo..........: Consulta as tarefas de um usu�rio espec�fico, que possuem um status espec�fico
	EX................: EXEC [dbo].[SP_ConsultarTarefasPorStatus] 28, 2
	*/
	BEGIN
		
		EXEC [dbo].[SP_VerificarAtraso] @IdUsuario

		SELECT IdTarefa, Descricao, DataCadastro, DataLimite, DataConclusao, DataCancelada, IdGestor, IdSubordinado, IdStatusTarefa  
			FROM Tarefa 
			WHERE (IdGestor = @IdUsuario OR IdSubordinado = @IdUsuario) 
				AND IdStatusTarefa = @IdStatusTarefa
	END