/*----------------- CRIAÇÃO DO BANCO DE DADOS -------------*/
CREATE DATABASE DB_Guru;

/*----------------- CRIAÇÃO DAS TABELAS -------------------*/

CREATE TABLE Usuario
(
	UsuarioID INT,
	Email VARCHAR(200),
	Nome VARCHAR(200),
	Imagem VARCHAR(50),
	Senha VARCHAR(100),
	DataNascimento date,
	PaypalToken VARCHAR(200),
	TipoID INT,
	PRIMARY KEY (UsuarioID)
);

CREATE TABLE UsuarioTipo
(
	UsuarioTipoID INT,
	Tipo VARCHAR(30),
	PRIMARY KEY (UsuarioTipoID)
);

CREATE TABLE Categoria
(
	CategoriaID INT,
	CategoriaParent INT,
	Nome VARCHAR(200),
	PRIMARY KEY (CategoriaID),
	FOREIGN KEY (CategoriaParent) REFERENCES Categoria(CategoriaID)
);

CREATE TABLE UsuarioCategoria
(
	UsuarioID INT,
	CategoriaID INT,
	FOREIGN KEY (UsuarioID)	REFERENCES Usuario(UsuarioID),
	FOREIGN KEY (CategoriaID) REFERENCES Categoria(CategoriaID)
);

/*------Verificar-----*/
CREATE TABLE UsuarioCredito
(
	UsuarioCreditoID INT,
	Valor FLOAT,
	UsuarioID INT,
	Data DATE,
	PRIMARY KEY (UsuarioCreditoID),
	FOREIGN KEY (UsuarioID)	REFERENCES Usuario(UsuarioID)
);
/*--------------------*/

CREATE TABLE Pergunta
(
	PerguntaID INT,
	UsuarioID INT,
	CategoriaID INT,
	Imagem VARCHAR(50),
	Texto VARCHAR(300),
	Status CHAR(1),
	Data DATE,
	PRIMARY KEY (PerguntaID),
	FOREIGN KEY (UsuarioID)	REFERENCES Usuario (UsuarioID),
	FOREIGN KEY (CategoriaID)	REFERENCES Categoria (CategoriaID)
);

CREATE TABLE Resposta
(
	RespostaID INT,
	PerguntaID INT,
	UsuarioID INT,
	Texto TEXT,
	Data DATE,
	Avaliacao BIT,
	FOREIGN KEY (UsuarioID) REFERENCES Usuario(UsuarioID),
	FOREIGN KEY (PerguntaID) REFERENCES Pergunta(PerguntaID)
);
