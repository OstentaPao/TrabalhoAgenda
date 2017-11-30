Create database BancoTrabalho;
/*drop database bancotrabalho;*/
Use BancoTrabalho;

Create table Agenda (
	Codigo int not null primary key AUTO_INCREMENT,
	Nome varchar(100) not null,
    Endereco varchar(100) not null,
    Bairro varchar(100) not null,
    Cidade varchar(100) not null,
	Telefone int not null
);
