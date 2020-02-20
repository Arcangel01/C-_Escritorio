CREATE DATABASE BD_Persona
USE BD_Persona
go
create table Users 
(
 Id varchar(20),
 nombre varchar(20),
 apellido varchar(20),
 edad int, 
)
go
INSERT INTO Users (Id,nombre,apellido,edad) values
('1045738333','Johan','Cataño',30),('103567849','Julian','Guevara',25)
INSERT INTO Users (Id,nombre,apellido,edad) values
('1020','juan camilo','mendez',18),('32456','michel','molina',12)
go
CREATE PROCEDURE SP_INSERT_USER
(
@Id varchar(20),
@nombre varchar(20),
@apellido varchar(20),
@edad int
)
AS 
BEGIN
INSERT INTO Users (Id,nombre,apellido,edad)VALUES
 (@Id,@nombre,@apellido,@edad)
 END
 go
 CREATE PROCEDURE SP_UPDATE_USER
(
@Id varchar(20),
@nombre varchar(20),
@apellido varchar(20),
@edad int
)
AS
BEGIN
UPDATE Users SET nombre=@nombre,apellido=@apellido,edad=@edad where Id=@Id
END
go
 CREATE PROCEDURE SP_BUSCAR_USER
(
@Id varchar(20)
)
AS
BEGIN
 SELECT * FROM Users where Id=@Id 
END
execute SP_BUSCAR_USER '1122'
go
 CREATE PROCEDURE SP_DELETE_USER
(
@Id varchar(20)
)
AS
BEGIN
 DELETE Users where Id=@Id 
END
go
CREATE PROCEDURE SP_LISTAR
AS BEGIN
SELECT * FROM Users
END

