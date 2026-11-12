CREATE DATABASE ProgramacionII
USE ProgramacionII

CREATE TABLE agendaElectronica(
	id int identity (1,1),
	Nombre varchar(30),
	Apellido varchar(40),
	Fecha_Nacimiento varchar(40),
	Direccion varchar(60),
	Genero varchar(15),
	Estado_Civil varchar(15),
	Movil float,
	Telefono float,
	Correo_Electronico varchar(25)
)

CREATE PROCEDURE InsertarContacto
    @Nombre VARCHAR(30),
	@Apellido VARCHAR(40),
	@Fecha_Nacimiento VARCHAR(40),
	@Direccion VARCHAR(60),
	@Genero VARCHAR(15),
	@Estado_Civil VARCHAR(15),
	@Movil float,
    @Telefono float,
	@Correo_Electronico VARCHAR(25)
AS
BEGIN
    INSERT INTO dbo.agendaElectronica (Nombre, Apellido, Fecha_Nacimiento, Direccion, Genero, Estado_Civil, Movil, Telefono, Correo_Electronico)
    VALUES (@Nombre, @Apellido, @Fecha_Nacimiento, @Direccion, @Genero, @Estado_Civil, @Movil, @Telefono, @Correo_Electronico)
END
GO

CREATE PROCEDURE ModificarContacto
    @id INT,
	@Nombre VARCHAR(30),
	@Apellido VARCHAR(40),
	@Fecha_Nacimiento VARCHAR(40),
	@Direccion VARCHAR(60),
	@Genero VARCHAR(15),
	@Estado_Civil VARCHAR(15),
	@Movil float,
    @Telefono float,
	@Correo_Electronico VARCHAR(25)
AS
BEGIN
    UPDATE dbo.agendaElectronica
    SET Nombre = @Nombre,
		Apellido = @Apellido,
		Fecha_Nacimiento = @Fecha_Nacimiento,
		Direccion = @Direccion,
		Genero = @Genero,
		Estado_Civil = @Estado_Civil,
		Movil = @Movil,
		Telefono = @Telefono, 
		Correo_Electronico = @Correo_Electronico
    WHERE id = @id
END
GO

CREATE PROCEDURE EliminarContacto
    @id INT
AS
BEGIN
    DELETE FROM dbo.agendaElectronica WHERE id = @id
END
GO

CREATE PROCEDURE BuscarContacto
    @id INT
AS
BEGIN
    SELECT * FROM dbo.agendaElectronica WHERE id = @id
END
GO

CREATE PROCEDURE ObtenerTodosLosContactos
AS
BEGIN
    SELECT ID, Nombre, Apellido, Fecha_Nacimiento, Direccion, Genero, Estado_Civil, Movil, Telefono, Correo_Electronico
    FROM agendaElectronica
END


