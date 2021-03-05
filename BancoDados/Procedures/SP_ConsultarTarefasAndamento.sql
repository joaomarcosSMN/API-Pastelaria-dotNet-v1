CREATE OR ALTER PROCEDURE [dbo].[SP_ConsultarTarefasAndamento]
	@IdUsuario SMALLINT

AS
	/* 
	Documentação
	Módulo............: Tarefa
	Objetivo..........: Consultar tarefas atrasadas, futuras e agendadas
	EX................: EXEC [dbo].[SP_ConsultarTarefasAndamento] 4
	*/
	BEGIN

		EXEC [dbo].[SP_VerificarAtraso] @IdUsuario

		SELECT t.IdTarefa, 
			   t.Descricao, 
			   t.DataCadastro, 
			   t.DataLimite, 
			   t.DataConclusao, 
			   t.DataCancelada, 
			   t.IdGestor, 
			   t.IdSubordinado, 
			   t.IdStatusTarefa,
			   st.Nome

			FROM [dbo].[Tarefa] AS t
				INNER JOIN [dbo].[StatusTarefa] AS st
					ON t.IdStatusTarefa = st.IdStatusTarefa
			WHERE t.IdStatusTarefa IN (2,3,4) 
				AND (IdGestor = @IdUsuario OR IdSubordinado = @IdUsuario)

	END
