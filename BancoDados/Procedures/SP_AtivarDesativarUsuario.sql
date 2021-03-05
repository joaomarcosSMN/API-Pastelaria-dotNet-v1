CREATE OR ALTER PROCEDURE [dbo].[SP_AtivarDesativarUsuario]
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