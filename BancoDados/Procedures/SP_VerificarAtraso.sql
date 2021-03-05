CREATE OR ALTER PROCEDURE [dbo].[SP_VerificarAtraso]
(@IdUsuario SMALLINT)	
AS
	/* 
	Documenta��o
	M�dulo............: Tarefa
	Objetivo..........: Verifica se as tarefas de um usu�ri est�o atrasadas
	EX................: EXEC [dbo].[SP_VerificarAtraso] 11
	*/
	BEGIN

		UPDATE TAREFA
			SET IdStatusTarefa = 4
			WHERE (IdGestor = @IdUsuario OR IdSubordinado = @IdUsuario)
			AND DataLimite < GETDATE()
			AND IdStatusTarefa IN (2,3)
		
	END
