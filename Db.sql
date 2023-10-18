create database Trello
go

use Trello
go

create table Card(
	Id int identity primary key,
	Titulo varchar(100) not null,
	Etiqueta int not null,
	DataInicio datetime not null,
	DataEntrega datetime not null
)
go

