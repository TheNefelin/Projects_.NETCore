USE db_testing

-- Tables -------------------------------------------------------
-- --------------------------------------------------------------

CREATE TABLE GG_Games (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(50) NOT NULL,
	Description VARCHAR(256) NOT NULL,
	ImgUrl VARCHAR(256) NOT NULL,
	IdActive BIT NOT NULL
)
GO

CREATE TABLE GG_Characters (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(50) NOT NULL,
	Description VARCHAR(256) NOT NULL,
	ImgUrl VARCHAR(256) NOT NULL,
	Id_Game INT NOT NULL
	FOREIGN KEY (Id_Game) REFERENCES GG_Games(Id),
)
GO

CREATE TABLE GG_Sources (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(50) NOT NULL,
	ImgUrl VARCHAR(256) NOT NULL,
	Id_Game INT NOT NULL
	FOREIGN KEY (Id_Game) REFERENCES GG_Games(Id),
)
GO

CREATE TABLE GG_BackgroundImg (
	Id INT PRIMARY KEY IDENTITY(1,1),
	ImgUrl VARCHAR(256) NOT NULL,
	Id_Game INT NOT NULL
	FOREIGN KEY (Id_Game) REFERENCES GG_Games(Id),
)
GO

DROP TABLE __EFMigrationsHistory
GO
DROP TABLE GG_BackgroundImg
GO
DROP TABLE GG_Sources
GO
DROP TABLE GG_Characters
GO
DROP TABLE GG_Games
GO

-- Data ---------------------------------------------------------
-- --------------------------------------------------------------

SET IDENTITY_INSERT GG_Games ON
GO
INSERT INTO GG_Games
	(Id, Name, Description, ImgUrl, IdActive)
VALUES
	(1, 'Chrono Cross', 'Lejos el mejor RPG en mi opinion personal. Precisamente, este juego, me inspiro hacer esta pagina.', 'cover_cc.webp', 1),
	(2, 'Comrades', 'Creo que soy el único que juega a esto, los servidores siempre están vacíos.', 'cover_com.webp', 1),
	(3, 'Darksiders 2', 'Un MANJAR de los dioses.', 'cover_ds2.webp', 1),
	(4, 'FFIX', 'Uno de los trofeos mas duros de conseguir', 'cover_ffix.webp', 1);
GO
SET IDENTITY_INSERT GG_Games OFF
GO

SET IDENTITY_INSERT GG_Characters ON
GO
INSERT INTO GG_Characters
	(Id, Name, Description, ImgUrl, Id_Game)
VALUES
	(1,'Serge','Se obtiene al inciar la aventura','cc_character_serge.webp',1),
	(2,'Mojo','Se obtiene con el Shark Tooth Amulet','cc_character_mojo.webp',1),
	(3,'Leena','Se obtiene rechazando a Kid 3 veces','cc_character_leena.webp',1),
	(4,'Poshul','Se obtiene rechazando a Kid 3 veces o en Arni Village dandole el hueso','cc_character_poshul.webp',1),
	(5,'Kid','Se obtiene en Termina o Cape Howl','cc_character_kid.webp',1),
	(6,'Guile','Se obtiene en Termina hablando con él en el bar','cc_character_guile.webp',1),
	(7,'Nikki','Se obtiene en Termina hablando con Miki en el barco de Magical Dreamers','cc_character_nikki.webp',1),
	(8,'Pierre','Se obtiene en Termina entregandole el Heros Medal en la herreria','cc_character_pierre.webp',1),
	(9,'Glenn','Se obtiene en Termina al decidir No salvar a Kid','cc_character_glenn.webp',1),
	(10,'Macha','Se obtiene en Termina al decidir No salvar a Kid','cc_character_macha.webp',1),
	(11,'Doc','Se obtiene en Termina al decidir No salvar a Kid','cc_character_doc.webp',1),
	(12,'Korcha','Se obtiene en Termina al decidir salvar a Kid','cc_character_korcha.webp',1),
	(13,'Greco','Se obtiene en Termina al decidir salvar a Kid','cc_character_greco.webp',1),
	(14,'Razzly','Se obtiene en Hydra Marsh al decidir salvar a Kid','cc_character_razzly.webp',1),
	(15,'Mel','Se obtiene en Guldove, despue se capturarla y salir de la isla','cc_character_mel.webp',1),
	(16,'Pip','Se obtiene en el barco fantasma','cc_character_pip.webp',1),
	(17,'Luccia','Se obtiene en Viper Manor al ir nuevamente','cc_character_luccia.webp',1),
	(18,'Lynx','Se obtiene despues del evento en Fort Dragonia','cc_character_lynx.webp',1),
	(19,'Sprigg','Se obtiene en el Mundo Abstracto','cc_character_sprigg.webp',1),
	(20,'Harle','Se obtiene en el Mundo Abstracto','cc_character_harle.webp',1),
	(21,'Radius','Se obtiene al vencerlo en Arni Village','cc_character_radius.webp',1),
	(22,'Zappa','Se obtiene en Termina con Lynx','cc_character_zappa.webp',1),
	(23,'Van','Se obtiene en Termina con Lynx','cc_character_van.webp',1),
	(24,'Norris','Se obtiene en Viper Manor si Radius esta en tu equipo','cc_character_norris.webp',1),
	(25,'Starky','Se obtiene venciendolo en la isla de Sky Dragon','cc_character_starky.webp',1),
	(26,'Janice','Se obtiene en el Zelbess al ganar el SLAM de combate','cc_character_janice.webp',1),
	(27,'Sneff','Se obtiene en Zelbess despues de derrotar al sabio','cc_character_sneff.webp',1),
	(28,'Irenes','Se obtiene en Zelbess despues de derrotar al sabio','cc_character_irenes.webp',1),
	(29,'Miki','Se obtiene en Zelbess despues de derrotar al sabio','cc_character_miki.webp',1),
	(30,'Zoah','Se obtiene en el bar de Termina, habitacion oculta','cc_character_zoah.webp',1),
	(31,'Karsh','Se obtiene en el bar de Termina, habitacion oculta','cc_character_karsh.webp',1),
	(32,'Orcha','Se obtiene en Viper Manor despues de rescatar a Riddel','cc_character_orcha.webp',1),
	(33,'Grobyc','Se obtiene en Viper Manor despues del combate con el Mecha','cc_character_grobyc.webp',1),
	(34,'Skelly','Se obtiene al conseguir todos sus huesos, son 6 en total','cc_character_skelly.webp',1),
	(35,'Riddel','Se obtiene al rescatarla del ejercito en Viper Manor','cc_character_riddel.webp',1),
	(36,'Viper','Se obtiene despues de rescatar a Riddel en Viper Manor','cc_character_viper.webp',1),
	(37,'Fargo','Se obtiene despues de rescatar a Riddel en Viper Manor','cc_character_fargo.webp',1),
	(38,'Marcy','Se obtiene despues de rescatar a Riddel en Viper Manor','cc_character_marcy.webp',1),
	(39,'Turnip','Se obtiene en Hermits Hideaway (AW), (HW), utilizando Ice Gun o Ice Breath con Poshul en tu equip','cc_character_turnip.webp',1),
	(40,'Funguy','Se obtiene en Shadow Forest al darle el Mushroom al hombre de la cueva en la cascada','cc_character_funguy.webp',1),
	(41,'Neofio','Se obtiene en la pileta de Viper Manor con la Life Sparkle','cc_character_neofio.webp',1),
	(42,'Leah','Se obtiene al llegar a la isla de Gaeas Navel','cc_character_leah.webp',1),
	(43,'Steena','Se obtiene en Guldove al mostrarle el Dragon Emblem','cc_character_steena.webp',1),
	(44,'Draggy','Se obtiene al poner el huevo gigante en Fort Dragonia','cc_character_draggy.webp',1),
	(45,'Orlha','Se obtiene en Guldove devolviendole el Sapphire Brooch como Serge','cc_character_orlha.webp',1)
GO
SET IDENTITY_INSERT GG_Characters OFF
GO

SET IDENTITY_INSERT GG_Sources ON
GO
INSERT INTO GG_Sources
	(Id, Name, ImgUrl, Id_Game)
VALUES
	(1,'Guia','https://guiamania.com/41154/',1),
	(2,'Window Frame','https://www.ign.com/wikis/chrono-cross/Window_Frames/',1),
	(3,'Finales','https://game8.co/games/Chrono-Cross-Radical-Dreamers-Edition/archives/375630/',1),
	(4,'Items','https://game8.co/games/Chrono-Cross-Radical-Dreamers-Edition/archives/371977/',1),
	(6,'Dragones','https://chrono.fandom.com/wiki/Chronopedia/',1),
	(7,'Tecnicas','https://guiltybit.com/como-conseguir-las-tecnicas-definitivas-de-todos-los-personajes-en-chrono-cross/',1),
	(8,'Criosphinx','https://chrono.fandom.com/wiki/Criosphinx/',1),
	(9,'Bend of Time','https://chrono.fandom.com/wiki/Bend_of_Time/',1),
	(10,'Triple Tech Delta Force','https://www.trueachievements.com/a356989/deadly-delta-achievement/',1),
	(11,'Triple Tech Z-Slash','https://www.trueachievements.com/a356990/z-one-and-only-achievement/',1),
	(12,'Guia Paso a Paso','https://www.youtube.com/watch?v=ZVTfcjFNVcU&list=PLUEaSJ4rKZoL5SJjw7ryjUI2NAztObT8F&index=1',4),
	(13,'Trofeo: Mister Nice Guy (  angelo noctis)','https://www.youtube.com/watch?v=RWI-uaZsYAY&t=912s',4),
	(14,'Trofeo: Beating the rigtime blues (angelo noctis)','https://www.youtube.com/watch?v=RWI-uaZsYAY&lc=UgxWdOT4ZJzoZmeEJix4AaABAg.9xkQXwbhDhM9xkVq_TWzy0',4),
	(15,'Trofeo: A clean bill of health (chibikei)','https://www.youtube.com/watch?v=Vrh5KILchfc',4)	
GO
SET IDENTITY_INSERT GG_Sources OFF
GO

SET IDENTITY_INSERT GG_BackgroundImg ON
GO
INSERT INTO GG_BackgroundImg
	(Id, ImgUrl, Id_Game)
VALUES
	(1,'cc_background_01.webp',1),
	(2,'cc_background_02.webp',1),
	(3,'com_background_01.webp',2),
	(4,'ds2_background_01.webp',3),
	(5,'ds2_background_02.webp',3),
	(6,'ds2_background_03.webp',3),
	(7,'ds2_background_04.webp',3),
	(8,'ds2_background_05.webp',3),
	(9,'ffix_background_01.webp',4),
	(10,'com_background_02.webp',2),
	(11,'ffix_background_02.webp',4)	
GO
SET IDENTITY_INSERT GG_BackgroundImg OFF
GO

-- Query --------------------------------------------------------
-- --------------------------------------------------------------

SELECT * FROM GG_Games
SELECT * FROM GG_Characters
SELECT * FROM GG_Sources
SELECT * FROM GG_BackgroundImg

-- --------------------------------------------------------------
-- --------------------------------------------------------------