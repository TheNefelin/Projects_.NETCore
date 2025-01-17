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
	Id_Game INT NOT NULL,
	FOREIGN KEY (Id_Game) REFERENCES GG_Games(Id)
)
GO

CREATE TABLE GG_Sources (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(50) NOT NULL,
	ImgUrl VARCHAR(256) NOT NULL,
	Id_Game INT NOT NULL,
	FOREIGN KEY (Id_Game) REFERENCES GG_Games(Id)
)
GO

CREATE TABLE GG_Backgrounds (
	Id INT PRIMARY KEY IDENTITY(1,1),
	ImgUrl VARCHAR(256) NOT NULL,
	Id_Game INT NOT NULL,
	FOREIGN KEY (Id_Game) REFERENCES GG_Games(Id)
)
GO

CREATE TABLE GG_Guides (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(100) NOT NULL,
	Sort INT NOT NULL,
	Id_Game INT NOT NULL,
	FOREIGN KEY (Id_Game) REFERENCES GG_Games(Id),
)
GO

DROP TABLE __EFMigrationsHistory
GO
DROP TABLE GG_Guides
GO
DROP TABLE GG_Backgrounds
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

SET IDENTITY_INSERT GG_Backgrounds ON
GO
INSERT INTO GG_Backgrounds
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
SET IDENTITY_INSERT GG_Backgrounds OFF
GO

SET IDENTITY_INSERT GG_Guides ON
GO
INSERT INTO GG_Guides
	(Id, Name, Sort, Id_Game)
VALUES
	(1,'El Sueño',1,1),
	(2,'Final oculto: Programmers Ending (Final 1/11)',2,1),
	(3,'(HW) Arni Village',3,1),
	(4,'(HW) Lizard Rock',4,1),
	(5,'(AW) Another World',5,1),
	(6,'(AW) Hydra Swamp',6,1),
	(7,'(AW) Fossil Valley',7,1),
	(8,'(AW) Termina',8,1),
	(9,'Final oculto: General Kid (Final 2/11)',9,1),
	(10,'(AW) Infiltración a Viper Manor',10,1),
	(11,'(AW) Viper Manor',11,1),
	(12,'Final oculto: The True Hero (Final 3/11)',12,1),
	(13,'(AW) Guldove',13,1),
	(14,'(HW) Bosque Hydra',14,1),
	(15,'(AW) Piratas Fantasmas',15,1),
	(16,'(AW) Guldove | Termina | Viper Manor',16,1),
	(17,'(HW) Arni Village',17,1),
	(18,'(AW) Costa Este de El Nido',18,1),
	(19,'Final oculto: The Magical Dreamers (Final 4/11)',19,1),
	(20,'(AW) Fort Dragonia',20,1),
	(21,'Mundo Abstracto y el Más Allá',21,1),
	(22,'Final oculto: New Beginnings (Final 5/11)',22,1),
	(23,'(HW) Termina',23,1),
	(24,'(HW) Viper Manor',24,1),
	(25,'(HW) Nido Triangle | Sky Dragon Isle | Marbule',25,1),
	(26,'(HW) El Zelbess de Fargo',26,1),
	(27,'(HW) Mar del Edén',27,1),
	(28,'(HW) Isla Maldita',28,1),
	(29,'(HW) Mar del Edén',29,1),
	(30,'(AW) Hydra Swamp | Termina',30,1),
	(31,'(AW) Viper Manor',31,1),
	(32,'Final oculto: Onward Dragoons (Final 6/11)',32,1),
	(33,'(AW) Guldove | Water Dragon Isle | Isle of the Damned | Termina',33,1),
	(34,'(AW) Hermits Hideaway',34,1),
	(35,'Final oculto: Darkened Fate (Final 7/11)',35,1),
	(36,'(AW) Isla del Dragón del Cielo',36,1),
	(37,'(HW) Preparación',37,1),
	(38,'(HW) Dragón Verde',38,1),
	(39,'(HW) Dragón de Agua',39,1),
	(40,'(HW) Dragón de Tierra',40,1),
	(41,'(AW) Dragón de Fuego',41,1),
	(42,'(AW) Dragón Negro',42,1),
	(43,'(AW) Dragón del Cielo',43,1),
	(44,'(AW) Criosphinx',44,1),
	(45,'(AW) Guldove',45,1),
	(46,'(HW) Fuerte Dragonian',46,1),
	(47,'(AW) La Búsqueda de la Masamune',47,1),
	(48,'Final oculto: Career Change (Final 8/11)',48,1),
	(49,'(HW) Mar de Edén',49,1),
	(50,'(HW) Chronopolis',50,1),
	(51,'(AW) Cascadas Divinas de los Dragones',51,1),
	(52,'Cosas por Hacer',52,1),
	(53,'(AW) Hermits Hideaway',53,1),
	(54,'(AW) El Nido Triangle',54,1),
	(55,'Final oculto: Return of the Downtrodden (Final 9/11)',55,1),
	(56,'(AW) Dinopolis y Terra Tower',56,1),
	(57,'(HW) Playa Opassa',57,1),
	(58,'Final: True Ending (Final 10/11)',58,1),
	(59,'Final: Bad Ending (Final 11/11)',59,1),
	(60,'Consideraciones',60,1),
	(61,'Lanza - Bigote de Dragón (1)',1,2),
	(62,'Lanza - Bigote de Dragón (2)',2,2),
	(63,'Mazo - Mjolnir',3,2),
	(64,'Katana - Mumeito (1)',4,2),
	(65,'Katana - Mumeito (2)',5,2),
	(66,'Escudo - Égida',6,2),
	(67,'SET Equipo de combate',7,2),
	(68,'The Forge Land',1,3),
	(69,'The Forge Land - The Cauldron',2,3),
	(70,'The Forge Land - The Drenchfort',3,3),
	(71,'The Forge Land - The Foundry',4,3),
	(72,'The Forge Land - The Lost Temple',5,3),
	(73,'The Forge Land - The Nook',6,3),
	(74,'The Forge Land - The Scar',7,3),
	(75,'The Forge Land - The Shattered Forge',8,3),
	(76,'The Forge Land - The Weeping Crag',9,3),
	(77,'The Forge Land - Tri-Stone',10,3),
	(78,'Kingdom of the Dead',11,3),
	(79,'Kingdom of the Dead - Boneriven',12,3),
	(80,'Kingdom of the Dead - Breach',13,3),
	(81,'Kingdom of the Dead - City of the Dead',14,3),
	(82,'Kingdom of the Dead - Eternal Throne',15,3),
	(83,'Kingdom of the Dead - Gilded Arena',16,3),
	(84,'Kingdom of the Dead - Judicators Tomb',17,3),
	(85,'Kingdom of the Dead - Lair of the Deposed King',18,3),
	(86,'Kingdom of the Dead - Phariseers Tomb',19,3),
	(87,'Kingdom of the Dead - Psychameron',20,3),
	(88,'Kingdom of the Dead - Sentinels Gaza',21,3),
	(89,'Bezswietle',22,3),
	(90,'Bezswietle - Earth',23,3),
	(91,'Bezswietle - The Ivory Citadel',24,3),
	(92,'Shadows Edge',25,3),
	(93,'Shadows Edge - The Black Stone',26,3),
	(94,'El concurso de Ragtime',1,4)	
GO
SET IDENTITY_INSERT GG_Guides OFF
GO

-- Query --------------------------------------------------------
-- --------------------------------------------------------------

SELECT * FROM GG_Games
SELECT * FROM GG_Characters
SELECT * FROM GG_Sources
SELECT * FROM GG_Backgrounds
SELECT * FROM GG_Guides

-- --------------------------------------------------------------
-- --------------------------------------------------------------