
	
	/* Drop Database if exists */
	USE master
	IF DB_ID('IncidentesAppDB') IS NOT NULL
		ALTER DATABASE IncidentesAppDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE

	DROP DATABASE IF EXISTS IncidentesAppDB


	/* Create Database */
	CREATE DATABASE [IncidentesAppDB]
	GO


	USE IncidentesAppDB



	/* Create Tables */


	--Persona
	CREATE TABLE Persona(
		PersonaID INT IDENTITY PRIMARY KEY,	
		Nombre VARCHAR(50) NOT NULL,
		ApellidoPaterno VARCHAR(50) NOT NULL,
		ApellidoMaterno VARCHAR(50) NOT NULL,
		Edad TINYINT
	)

	INSERT INTO Persona(Nombre, ApellidoPaterno, ApellidoMaterno, Edad)
	VALUES ('Alex', 'Córdova', 'Córdova', 23)


	--Rol
	CREATE TABLE Rol(
		RolID INT IDENTITY PRIMARY KEY,	
		NombreRol VARCHAR(20) NOT NULL
	)
	
	INSERT INTO Rol(NombreRol)
	VALUES ('ADMIN'),('USUARIO')

	--Usuario
	CREATE TABLE Usuario(
		UsuarioID INT IDENTITY PRIMARY KEY,	
		Usuario VARCHAR(50) NOT NULL,
		Contraseña VARBINARY(100) NOT NULL,
		RolID INT NOT NULL,
		PersonaID INT
	)
	
	ALTER TABLE Usuario
	ADD CONSTRAINT FK_Rol_RolID FOREIGN KEY (RolID)
		REFERENCES Rol(RolID);

	ALTER TABLE Usuario
	ADD CONSTRAINT FK_Persona_PersonaID FOREIGN KEY (PersonaID)
		REFERENCES Persona(PersonaID);

	INSERT INTO Usuario(Usuario, Contraseña, RolID, PersonaID) 
	VALUES ('admin', HASHBYTES('SHA2_512', 'admin'), 1, 1),
		   ('user', HASHBYTES('SHA2_512', 'user'), 2, 1)


	--Coordenadas
	CREATE TABLE Coordenadas(
		CoordenadasID INT IDENTITY PRIMARY KEY,
		LatitudGrados TINYINT NOT NULL,
		LatitudMinutos TINYINT NOT NULL,
		LatitudSegundos TINYINT NOT NULL,
		LongitudGrados TINYINT NOT NULL,
		LongitudMinutos TINYINT NOT NULL,
		LongitudSegundos TINYINT NOT NULL,
		Altitud SMALLINT NOT NULL
	)

	SET IDENTITY_INSERT Coordenadas ON

	INSERT INTO Coordenadas(CoordenadasID, LatitudGrados, LatitudMinutos, LatitudSegundos, LongitudGrados, LongitudMinutos, LongitudSegundos, Altitud)
	VALUES 
		(1, 19, 12, 20, 99, 15, 24, 3930),
		(2, 19, 06, 32, 99, 01, 49, 3690),
		(3, 19, 09, 00, 99, 13, 00, 3620),
		(4, 19, 06, 07, 99, 59, 22, 3550),
		(5, 19, 17, 22, 99, 18, 00, 3530),
		(6, 19, 09, 16, 99, 06, 20, 3510),
		(7, 19, 05, 24, 99, 08, 06, 3490),
		(8, 19, 06, 59, 99, 09, 44, 3320),
		(9, 19, 02, 54, 99, 03, 36, 3150),
		(10, 19, 05, 47, 99, 13, 31, 3100),
		(11, 19, 10, 08, 99, 27, 12, 2900),
		(12, 19, 19, 22, 99, 59, 56, 2820),
		(13, 19, 31, 53, 99, 07, 48, 2730),
		(14, 19, 13, 29, 99, 01, 51, 2710),
		(15, 19, 19, 00, 99, 01, 50, 2560),
		(16, 19, 20, 33, 99, 05, 19, 2450),
		(17, 19, 25, 22, 99, 10, 28, 2280)

	SET IDENTITY_INSERT Coordenadas OFF

	--CentroAtencion
	CREATE TABLE CentroAtencion(
		CentroAtencionID INT IDENTITY PRIMARY KEY,	
		Nombre VARCHAR(50) NOT NULL,
		CoordenadasID INT
	)

	ALTER TABLE CentroAtencion
	ADD CONSTRAINT FK_Coordenadas_CoordenadasID FOREIGN KEY (CoordenadasID) 
	REFERENCES Coordenadas(CoordenadasID)

	INSERT INTO CentroAtencion(Nombre, CoordenadasID)
	VALUES
		('Volcán Ajusco', 1),
		('Volcán Tlaloc', 2),
		('Volcán Pelado', 3),
		('Cerro Cilcuayo', 4),
		('Cerro el Charco', 5),
		('Volcán Cuautzin', 6),
		('Volcán Chichinautzin', 7),
		('Volcán Acopiaxco', 8),
		('Volcán Otlayucan', 9),
		('Volcán Tezoyo', 10),
		('Cerro Ayaqueme', 11),
		('Volcán Guadalupe (El Borrego)', 12),
		('Cerro del Chiquihuite', 13),
		('Volcán Teuhtli', 14),
		('Volcán Xaltepec', 15),
		('Cerro de la Estrella', 16),
		('Cerro de Chapultepec', 17)




	--Tipo asistencia
	CREATE TABLE TipoAsistencia(
		TipoAsistenciaID INT IDENTITY PRIMARY KEY,
		Nombre VARCHAR(30),
		Descripcion VARCHAR(100)
	)

	SET IDENTITY_INSERT TipoAsistencia ON

	INSERT INTO TipoAsistencia(TipoAsistenciaID, Nombre, Descripcion)
	VALUES 
		(1, 'Policía', ''),
		(2, 'Bomberos', ''),
		(3, 'Ambulancias', '')

	SET IDENTITY_INSERT TipoAsistencia OFF



	--Incidente
	CREATE TABLE Incidente(
		IncidenteID INT IDENTITY PRIMARY KEY,	
		Descripcion VARCHAR(150) NOT NULL,
		Lugar VARCHAR(50) NOT NULL,
		Latitud NUMERIC(23, 20) NOT NULL,
		DistanciaKM NUMERIC(8, 3),
		Longitud NUMERIC(23, 20) NOT NULL,
		DireccionCardinal VARCHAR(10),
		TiempoEstimadoMinutos NUMERIC(14,10),
		HoraEstimadaLlegada DATETIME,
		UsuarioID INT NOT NULL,
		TipoAsistenciaID INT NOT NULL,
		CentroAtencionID INT NOT NULL
	)

	ALTER TABLE Incidente
	ADD CONSTRAINT FK_Usuario_UsuarioID FOREIGN KEY (UsuarioID)
		REFERENCES Usuario(UsuarioID)

	ALTER TABLE Incidente
	ADD CONSTRAINT FK_TipoAsistencia_TipoAsistenciaID FOREIGN KEY (TipoAsistenciaID)
		REFERENCES TipoAsistencia(TipoAsistenciaID)

	ALTER TABLE Incidente
	ADD CONSTRAINT FK_CentroAtencion_TipoAsistenciaID FOREIGN KEY (CentroAtencionID)
		REFERENCES CentroAtencion(CentroAtencionID)



GO


DROP PROCEDURE IF EXISTS sp_ConsultarIncidentes


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Alex Córdova>
-- Create date: <31/Enero/2023>
-- Description:	<Consultar Incidentes por Id de Usuario>
-- =============================================
CREATE PROCEDURE sp_ConsultarIncidentes
	@CentroAtencionID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		I.IncidenteID, I.Descripcion, I.Lugar, I.Latitud, I.DistanciaKM, I.Longitud, I.DireccionCardinal, I.TiempoEstimadoMinutos, I.HoraEstimadaLlegada,
		TA.TipoAsistenciaID, TA.Nombre, TA.Descripcion,
		CA.CentroAtencionID, CA.Nombre, CA.CoordenadasID,
		US.UsuarioID, US.Usuario,
		P.PersonaID, P.Nombre, P.ApellidoPaterno, P.ApellidoMaterno, P.Edad
	FROM Incidente I
	INNER JOIN TipoAsistencia TA
		ON I.TipoAsistenciaID = TA.TipoAsistenciaID
	INNER JOIN CentroAtencion CA
		ON I.CentroAtencionID = CA.CentroAtencionID
	INNER JOIN Usuario US
		ON I.UsuarioID = US.UsuarioID
	INNER JOIN Persona P
		ON US.PersonaID = P.PersonaID
	WHERE CA.CentroAtencionID = ISNULL(@CentroAtencionID, CA.CentroAtencionID)

END
GO
