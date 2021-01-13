
/*Verifica se a procedure existe se existe da um drop apagando*/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_Procedure]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_Procedure]
GO
CREATE PROCEDURE [dbo].[SP_Procedure]
	
AS
	/* 
	Documentação
	Módulo............: Tabela
	Objetivo..........: O que faz?
	EX................: EXEC [dbo].[SP_Execução]
	*/
	BEGIN

		QUERY
		
	END
