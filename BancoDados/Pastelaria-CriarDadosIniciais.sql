USE PastelariaSMN

INSERT INTO Administrador
(Email, Senha)
VALUES
('oportunidades@smn.com.br', 'aa1bf4646de67fd9086cf6c79007026c')

INSERT INTO TipoTelefone
VALUES
('Residencial'),
('Celular'),
('Emergencial'),
('Corporativo')

INSERT INTO StatusTarefa
VALUES
('Concluída'),
('Futura'),
('Agendada'),
('Atrasada'),
('Cancelada')

-- Primeiro usuário Admin
INSERT INTO Usuario
	(Nome, 
	Sobrenome, 
	DataNascimento,
	Senha,
	EGestor,
	EstaAtivo,
	IdGestor)
VALUES
	('Admin', 
	'Sistema',
	'01/01/1900',
	'07dfef27f5c34f2740933c6ef56f57d4', 
	1, 
	1, 
	NULL)

INSERT INTO Email
	(EnderecoEmail, 
	IdUsuario)
VALUES
	('admin_pastelaria@gmail.com', 
	1)

INSERT INTO Telefone
	(Numero, 
	DDD, 
	IdTipoTelefone, 
	IdUsuario)
VALUES
	('-', 
	'-', 
	1, 
	1)

INSERT INTO Endereco
	(Rua, 
	Bairro, 
	Numero, 
	Complemento, 
	CEP, 
	Cidade, 
	UF, 
	IdUsuario)
VALUES
	('-', 
	'-', 
	'-', 
	'-', 
	'-', 
	'-', 
	'-', 
	1)

