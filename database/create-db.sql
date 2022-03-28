CREATE DATABASE escola;
USE escola;


CREATE TABLE TipoUsuario(
	TipoUsuarioID INT IDENTITY(1,1),
	Nome VARCHAR (15),
	CONSTRAINT PK_TipoUsuario PRIMARY KEY (TipoUsuarioID)
	);

CREATE TABLE Usuario  (
	UsuarioID INT IDENTITY(1,1),
	Nome VARCHAR (MAX),
	Email VARCHAR (MAX),
	Senha VARCHAR (MAX),
	TipoUsuarioID INT ,
	CONSTRAINT PK_Usuario PRIMARY KEY (UsuarioID),
	FOREIGN KEY (TipoUsuarioID) REFERENCES TipoUsuario(TipoUsuarioID)
	);

CREATE TABLE Turma(
	TurmaID INT IDENTITY(1,1),
	Nome VARCHAR (MAX),
	UsuarioID INT,
	CONSTRAINT PK_Turma PRIMARY KEY (TurmaID),
	FOREIGN KEY (UsuarioID) REFERENCES Usuario(UsuarioID)
	);

CREATE TABLE TurmaAlunos(
	TurmaID INT,
	UsuarioID INT,
	CONSTRAINT UC_TurmaAlunosID UNIQUE (TurmaID,UsuarioID)
	);

CREATE TABLE Prova(
	ProvaID INT IDENTITY(1,1),
	Nome VARCHAR (MAX),
	TurmaID INT,
	CONSTRAINT PK_ProvaID PRIMARY KEY (ProvaID),
	FOREIGN KEY (TurmaID) REFERENCES Turma(TurmaID));
		
CREATE TABLE Questao(
	QuestaoID INT IDENTITY(1,1),
	ProvaID INT, 
	Enunciado VARCHAR (MAX),
	CONSTRAINT PK_QuestaoID PRIMARY KEY (QuestaoID),
	FOREIGN KEY (ProvaID) REFERENCES Prova(ProvaID)
	);

CREATE TABLE QuestaoAlternativa(
	QuestaoAlternativaID INT IDENTITY(1,1),
	QuestaoID INT,
	Resposta VARCHAR(MAX),
	Correta BIT,
	CONSTRAINT PK_QuestaoAlternativaID PRIMARY KEY (QuestaoAlternativaID),
	FOREIGN KEY (QuestaoID) REFERENCES Questao(QuestaoID)
	);

CREATE TABLE ProvaAluno (
	ProvaAlunoID INT IDENTITY(1,1),
	UsuarioID INT,
	ProvaID INT,
	Nota FLOAT,
	CONSTRAINT PK_ProvaAluno PRIMARY KEY (ProvaAlunoID),
	FOREIGN KEY (UsuarioID) REFERENCES Usuario(UsuarioID),
	FOREIGN KEY (ProvaID) REFERENCES Prova(ProvaID)
	);

CREATE TABLE RespostaQuestaoAluno(
	RespostaQuestaoAlunoID INT IDENTITY(1,1), 
	QuestaoID INT, 
	QuestaoAlternativaID INT,
	CONSTRAINT  PK_RespostaQuestaoAluno PRIMARY KEY (RespostaQuestaoAlunoID),
	FOREIGN KEY (QuestaoID) REFERENCES Questao(QuestaoID),
	FOREIGN KEY (QuestaoAlternativaID) REFERENCES QuestaoAlternativa(QuestaoAlternativaID)
	);