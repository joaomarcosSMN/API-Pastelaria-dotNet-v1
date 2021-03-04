
/*Verifica se a procedure existe se existe da um drop apagando*/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_VerificarAtraso]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_VerificarAtraso]
GO
CREATE PROCEDURE [dbo].[SP_VerificarAtraso]
(@IdUsuario SMALLINT)	
AS
	/* 
	Documentação
	Módulo............: Tarefa
	Objetivo..........: Verifica se as tarefas de um usuári estão atrasadas
	EX................: EXEC [dbo].[SP_VerificarAtraso] 11
	*/
	BEGIN

		UPDATE TAREFA
			SET IdStatusTarefa = 4
			WHERE (IdGestor = @IdUsuario OR IdSubordinado = @IdUsuario)
			AND DataLimite < GETDATE()
			AND IdStatusTarefa IN (2,3)
		
	END
