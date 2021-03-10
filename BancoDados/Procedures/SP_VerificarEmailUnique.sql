CREATE OR ALTER PROCEDURE [dbo].[SP_VerificarEmailUnique]
    @Email VARCHAR(254)
    
AS
    /* 
    Documentação
    Módulo............: Email
    Objetivo..........: Verificar se ja existe um email no banco de dados
    EX................: EXEC [dbo].[SP_VerificarEmailUnique] "min_pastelaria@gmail.com"
    */
    BEGIN
		DECLARE @checarEmail VARCHAR(254)
		
        SELECT @checarEmail = EnderecoEmail FROM Email
            WHERE EnderecoEmail = @Email
		IF @checarEmail = @Email
			SELECT 1 AS Resultado
		ELSE
			SELECT 0 AS Resultado
        
    END