create database PPPK_DZ3
go

use PPPK_DZ3
go

create table Student (
	IDStudent int not null identity primary key,
	Ime nvarchar(50),
	Prezime nvarchar(50),
	JMBG nvarchar(50),
	Email nvarchar(50)
	)
go

insert into Student (Ime, Prezime, JMBG, Email) values ('Pero', 'Peric', '123456', 'pero@mail.hr')
insert into Student (Ime, Prezime, JMBG, Email) values ('Ivo', 'Ivic', '223456', 'ivo@mail.hr')
insert into Student (Ime, Prezime, JMBG, Email) values ('Ana', 'Anic', '323456', 'ana@mail.hr')
insert into Student (Ime, Prezime, JMBG, Email) values ('Maja', 'Majic', '423456', 'maja@mail.hr')
insert into Student (Ime, Prezime, JMBG, Email) values ('Marko', 'Markic', '52345', 'marko@mail.hr')

--select * from Student