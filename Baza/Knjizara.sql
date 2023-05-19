create database Knjizara
use Knjizara


drop table strip


create table strip
(
	Id int Primary Key Identity(1, 1),
	Naziv nvarchar(100),
	Izdavac nvarchar (100),
	Cena decimal(18, 2)
)

SELECT * FROM strip