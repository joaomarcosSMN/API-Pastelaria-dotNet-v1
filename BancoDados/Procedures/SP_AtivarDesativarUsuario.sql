/*Verifica se a procedure existe se existe da um drop apagando*/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_AtivarDesativarUsuario]') AND objectproperty(id, N'IsPROCEDURE')=1)
    DROP PROCEDURE [dbo].[SP_AtivarDesativarUsuario]
GO
CREATE PROCEDURE [dbo].[SP_AtivarDesativarUsuario]
    @IdUsuario SMALLINT
AS
    /* 
    Documentação
    Módulo............: Usuario
    Objetivo..........: Desativa o usuario ativado ou ativa o usuario desativado
    EX................: EXEC [dbo].[SP_AtivarDesativarUsuario] 2
    */
    BEGIN

        DECLARE @AtivoDesativo BIT
        SELECT @AtivoDesativo =  EstaAtivo FROM Usuario where IdUsuario = @IdUsuario
        
        IF @AtivoDesativo = 1
            BEGIN
                UPDATE Usuario
                    SET EstaAtivo = 0
                    WHERE IdUsuario = @IdUsuario
            END
        ELSE
            BEGIN
                UPDATE Usuario
                    SET EstaAtivo = 1
                    WHERE IdUsuario = @IdUsuario
            END
    END