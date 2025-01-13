USE db_testing

-- Tables -------------------------------------------------------
-- --------------------------------------------------------------

CREATE TABLE GJ_Juegos (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(50) NOT NULL,
	Descripcion VARCHAR(256) NOT NULL,
	ImgUrl VARCHAR(256) NOT NULL,
	Activo BIT NOT NULL
)
GO

DROP TABLE __EFMigrationsHistory
GO
DROP TABLE GJ_Juegos
GO

-- Data ---------------------------------------------------------
-- --------------------------------------------------------------

INSERT INTO GJ_Juegos
	(Nombre, Descripcion, ImgUrl, Activo)
VALUES
	('Chrono Cross', 'Lejos el mejor RPG en mi opinion personal. Precisamente, este juego, me inspiro hacer esta pagina.', 'cover_cc.webp', 1),
	('Comrades', 'Creo que soy el único que juega a esto, los servidores siempre están vacíos.', 'cover_com.webp', 1),
	('Darksiders 2', 'Un MANJAR de los dioses.', 'cover_ds2.webp', 1),
	('FFIX', 'Uno de los trofeos mas duros de conseguir', 'cover_ffix.webp', 1);

-- Query --------------------------------------------------------
-- --------------------------------------------------------------

SELECT * FROM GJ_Juegos

-- --------------------------------------------------------------
-- --------------------------------------------------------------