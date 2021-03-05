CREATE OR ALTER PROCEDURE [dbo].[SP_AtualizarUsuario]
	@IdUsuario SMALLINT, 
	@Nome VARCHAR(30), 
	@Sobrenome VARCHAR(50), 
	@Senha VARCHAR(50)
	
AS
	/* 
	Documentação
	Módulo............: Usuario
	Objetivo..........: Atualiza os campos Nome, Sobrenome e Senha da tabela Usuario
	EX................: EXEC [dbo].[SP_AtualizarUsuario] 1, 'Ianko', 'Felipe', '07c97032a8e6a6ab42290ff5d9089216'
	*/
	BEGIN

		UPDATE Usuario
			SET Nome = @Nome, 
				Sobrenome = @Sobrenome, 
				Senha = @Senha
			WHERE IdUsuario = @IdUsuario
		
	END