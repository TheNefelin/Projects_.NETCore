
-- Tables -------------------------------------------------------
-- --------------------------------------------------------------

CREATE TABLE F1_Flags (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(50) NOT NULL,
	ImgFlag VARCHAR(50) NOT NULL,
)
GO

CREATE TABLE F1_Teams (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(50) NOT NULL,
	ImgCar VARCHAR(50) NOT NULL,
	Id_Flag INT NOT NULL,
	FOREIGN KEY (Id_Flag) REFERENCES F1_Flags(Id),
)
GO

CREATE TABLE F1_Circuits (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(256) NOT NULL,
	Id_Flag INT NOT NULL,
	FOREIGN KEY (Id_Flag) REFERENCES F1_Flags(Id),
)
GO

CREATE TABLE F1_Racing (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Dates DATETIME NOT NULL,
	Climate VARCHAR(256) NOT NULL,
	Id_Circuit INT NOT NULL,
	FOREIGN KEY (Id_Circuit) REFERENCES F1_Circuits(Id),
)
GO

CREATE TABLE F1_Pilots (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(100) NOT NULL,
	DateBirth DATE NOT NULL,
	Height REAL NOT NULL,
	Weight  REAL NOT NULL,
	Dorsal INT NOT NULL,
	ImgProfile  VARCHAR(50) NOT NULL,
	IsAlive BIT NOT NULL,
	Points INT NOT NULL,
	Id_Flag INT NOT NULL,
	Id_Team INT NOT NULL,
	--FOREIGN KEY (Id_Flag) REFERENCES F1_Flags(Id),
	FOREIGN KEY (Id_Team) REFERENCES F1_Teams(Id),
)
GO

DROP TABLE F1_Pilots
DROP TABLE F1_Racing
DROP TABLE F1_Circuits
DROP TABLE F1_Teams
DROP TABLE F1_Flags

-- Data ---------------------------------------------------------
-- --------------------------------------------------------------

SET IDENTITY_INSERT F1_Flags ON
GO
INSERT INTO F1_Flags
    (Id, Name, ImgFlag)
VALUES
    (1,'Finlandia','flag_finland_100x100.webp'),
    (2,'China','flag_china_100x100.webp'),
    (3,'Francia','flag_france_100x100.webp'),
    (4,'Austria','flag_austria_100x100.webp'),
    (5,'Japón','flag_japan_100x100.webp'),
	(6,'Canadá','flag_canada_100x100.webp'),
	(7,'España','flag_spain_100x100.webp'),
	(8,'Mónaco','flag_monaco_100x100.webp'),
	(9,'Dinamarca','flag_denmark_100x100.webp'),
	(10,'Alemania','flag_germany_100x100.webp'),
	(11,'Reino Unido','flag_uk_100x100.webp'),
	(12,'Australia','flag_australia_100x100.webp'),
	(13,'Bélgica','flag_belgium_100x100.webp'),
	(14,'México','flag_mexico_100x100.webp'),
	(15,'Estados Unidos','flag_usa_100x100.webp'),
	(16,'Suiza','flag_swiss_100x100.webp'),
	(17,'Italia','flag_italy_100x100.webp'),
	(18,'Bahréin','flag_bahrain_100x100.webp'),
	(19,'Arabia Saudita','flag_saudiarabia_100x100.webp'),
	(20,'Azerbaiyan','flag_azerbaijan_100x100.webp'),
	(21,'Hungria','flag_hungary_100x100.webp'),
	(22,'Holanda','flag_holland_100x100.webp'),
	(23,'Singapore','flag_singapore_100x100.webp'),
	(24,'Qatar','flag_qatar_100x100.webp'),
	(25,'Brazil','flag_brazil_100x100.webp'),
	(26,'AbuDhabi','flag_abudhabi_100x100.webp')
SET IDENTITY_INSERT F1_Flags OFF
GO

SET IDENTITY_INSERT F1_Teams ON
GO
INSERT INTO F1_Teams
	(Id, Name, ImgCar, Id_Flag)
VALUES
	(1,'VCARB','car_01.webp',17),
	(2,'Alpine','car_02.webp',3),
	(3,'Stake F1 Team','car_03.webp',16),
	(4,'Aston Martin','car_04.webp',11),
	(5,'Ferrari','car_05.webp',17),
	(6,'Haas','car_06.webp',15),
	(7,'McLaren','car_07.webp',11),
	(8,'Mercedes','car_08.webp',10),
	(9,'Red Bull','car_09.webp',4),
	(10,'Williams','car_10.webp',11)
SET IDENTITY_INSERT F1_Teams OFF
GO

SET IDENTITY_INSERT F1_Circuits ON
GO
INSERT INTO F1_Circuits
	(Id, Name, Id_Flag)
VALUES
	(1,'Gulf Air Bahrain GP, Bahrain International Circuit',18),
	(2,'STC Saudi Arabian GP, Jeddah Street Circuit',19),
	(3,'Rolex Australian GP, Circuito Grand Prix Melbourne',4),
	(4,'GP de Azerbaiyán, Baku City Circuit',20),
	(5,'Crypto.com Miami GP, Miami International Autodrome',15),
	(6,'Made in Italy Emilia Romagna GP, Autodromo Enzo e Dino Ferrari',17),
	(7,'GP de Mónaco, Circuit de Monaco',8),
	(8,'AWS Spanish GP, Circuit de Barcelona-Catalunya',7),
	(9,'Pirelli Canada GP, Circuit Gilles-Villeneuve',6),
	(10,'GP de Austria, Red Bull Ring',12),
	(11,'Aramco British GP, Silverstone Circuit',11),
	(12,'GP de Hungría, Hungaroring',21),
	(13,'GP de Bélgica, Circuit de Spa-Francorchamps',13),
	(14,'Heineken Dutch GP, Circuit Park Zandvoort',22),
	(15,'Pirelli Italian GP, Autodromo Nazionale Monza',17),
	(16,'Singapore Airlines Singapore GP, Marina Bay Street Circuit',23),
	(17,'Lenovo Japanese GP, Suzuka International Racing Course',5),
	(18,'Qatar GP, Losail International Circuit',24),
	(19,'Lenovo United States GP, Circuit of the Americas',15),
	(20,'Mexico GP, Autodromo Hermanos Rodriguez',14),
	(21,'Rolex Brazil GP, Autodromo Jose Carlos Pace',25),
	(22,'Heineken Las Vegas GP, Las Vegas Street Circuit',15),
	(23,'Etihad Airways Abu Dhabi GP, Yas Marina Circuit',26)
SET IDENTITY_INSERT F1_Circuits OFF
GO

SET IDENTITY_INSERT F1_Pilots ON
GO
INSERT INTO F1_Pilots
	(Id, Name, DateBirth, Height, Weight, Dorsal, ImgProfile, IsAlive, Points, Id_Flag, Id_Team)
VALUES
	(1,'Valtteri Bottas','19890828',1.73,70,77,'pilot_valtteri_bottas_460x346.webp',1,0,1,3),
	(2,'Guanyu Zhou','19990530',1.75,63,24,'pilot_guanyu_zhou_460x346.webp',1,0,2,3),
	(3,'Esteban Ocon','19960917',1.86,66,31,'pilot_esteban_ocon_460x346.webp',1,0,3,2),
	(4,'Pierre Gasly','19960217',1.77,70,10,'pilot_pierre_gasly_460x346.webp',1,0,3,2),
	(5,'Daniel Ricciardo','19890701',1.79,71,3,'pilot_daniel_ricciardo_460x346.webp',1,0,4,1),
	(6,'Yuki Tsunoda','20000511',1.59,54,22,'pilot_yuki_tsunoda_460x346.webp',1,0,5,1),
	(7,'Lance Stroll','19981029',1.82,70,18,'pilot_lance_stroll_460x346.webp',1,0,6,4),
	(8,'Fernando Alonso','19810729',1.71,68,14,'pilot_fernando_alonso_460x346.webp',1,0,7,4),
	(9,'Charles Leclerc','19971016',1.8,65,16,'pilot_charles_leclerc_460x346.webp',1,0,8,5),
	(10,'Carlos Sainz','19940901',1.77,66,55,'pilot_carlos_sainz_460x346.webp',1,0,7,5),
	(11,'Kevin Magnussen','19921005',1.74,68,20,'pilot_kevin_magnussen_460x346.webp',1,0,9,6),
	(12,'Nico Hulkenberg','19870819',1.85,74,27,'pilot_nico_hulkenberg_460x346.webp',1,0,10,6),
	(13,'Lando Norris','19991113',1.7,68,4,'pilot_lando_norris_460x346.webp',1,0,11,7),
	(14,'Oscar Piastri','20010406',1.78,68,81,'pilot_oscar_piastri_460x346.webp',1,0,12,7),
	(15,'Lewis Hamilton','19850107',1.74,68,44,'pilot_lewis_hamilton_460x346.webp',1,0,12,8),
	(16,'George Russell','19980215',1.85,70,63,'pilot_george_russell_460x346.webp',1,0,11,8),
	(17,'Max Verstappen','19970930',1.8,67,1,'pilot_max_verstappen_460x346.webp',1,0,13,9),
	(18,'Sergio Pérez','19900126',1.73,64,11,'pilot_sergio_perez_460x346.webp',1,0,14,9),
	(19,'Alexander Albon','19960323',1.86,71,23,'pilot_alexander_albon_460_346.webp',1,0,11,10),
	(20,'Logan Sargeant','20001231',1.81,71,2,'pilot_logan_sargeant_460_346.webp',1,0,15,10)
SET IDENTITY_INSERT F1_Pilots OFF
GO


SELECT * 
	--'(' + LTRIM(STR(Id)) + ',''' + Nombre + ''',' + LTRIM(STR(IdPais)) + '),'
FROM F1Carreras

-- Stored Procedure ---------------------------------------------
-- --------------------------------------------------------------

-- Query --------------------------------------------------------
-- --------------------------------------------------------------

SELECT * FROM F1_Flags
SELECT * FROM F1_Teams
SELECT * FROM F1_Circuits
SELECT * FROM F1_Pilots

-- --------------------------------------------------------------
-- --------------------------------------------------------------
