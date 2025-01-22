USE db_testing

-- Tables -------------------------------------------------------
-- --------------------------------------------------------------

CREATE TABLE GG_Games (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(50) NOT NULL,
	Description VARCHAR(256) NOT NULL,
	ImgUrl VARCHAR(256) NOT NULL,
	IsActive BIT NOT NULL
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

CREATE TABLE GG_GuidesUser (
	Id_Guide INT NOT NULL,
	Id_User VARCHAR(256) NOT NULL,
	IsCheck BIT NOT NULL,
	PRIMARY KEY (Id_Guide, Id_User),
	FOREIGN KEY (Id_Guide) REFERENCES GG_Guides(Id),
)
GO

CREATE TABLE GG_Adventures (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Description VARCHAR(800) NOT NULL,
	IsImportant BIT NOT NULL,
	Sort INT NOT NULL,
	Id_Guide INT NOT NULL,
	FOREIGN KEY (Id_Guide) REFERENCES GG_Guides(Id),
)
GO

CREATE TABLE GG_AdventuresUser (
	Id_Adventure INT NOT NULL,
	Id_User VARCHAR(256) NOT NULL,
	IsCheck BIT NOT NULL,
	PRIMARY KEY (Id_Adventure, Id_User),
	FOREIGN KEY (Id_Adventure) REFERENCES GG_Adventures(Id),
)
GO

CREATE TABLE GG_AdventuresImg (
	Id INT PRIMARY KEY IDENTITY(1,1),
	ImgUrl VARCHAR(256) NOT NULL,
	Sort INT NOT NULL,
	Id_Adventure INT NOT NULL,
	FOREIGN KEY (Id_Adventure) REFERENCES GG_Adventures(Id),
)
GO

DROP TABLE __EFMigrationsHistory
GO
DROP TABLE GG_AdventuresImg
GO
DROP TABLE GG_AdventuresUser
GO
DROP TABLE GG_Adventures
GO
DROP TABLE GG_GuidesUser
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
	(Id, Name, Description, ImgUrl, IsActive)
VALUES
	(1, 'Chrono Cross', 'Lejos el mejor RPG en mi opinion personal. Precisamente, este juego, me inspiro hacer esta pagina.', 'cover_cc_617x617.webp', 1),
	(2, 'Comrades', 'Creo que soy el único que juega a esto, los servidores siempre están vacíos.', 'cover_com_617x617.webp', 1),
	(3, 'Darksiders 2', 'Un MANJAR de los dioses.', 'cover_ds2_617x617.webp', 1),
	(4, 'FFIX', 'Uno de los trofeos mas duros de conseguir', 'cover_ffix_617x617.webp', 1);
GO
SET IDENTITY_INSERT GG_Games OFF
GO

SET IDENTITY_INSERT GG_Characters ON
GO
INSERT INTO GG_Characters
	(Id, Name, Description, ImgUrl, Id_Game)
VALUES
	(1,'Serge','Se obtiene al inciar la aventura','character_cc_serge_288x288.webp',1),
	(2,'Mojo','Se obtiene con el Shark Tooth Amulet','character_cc_288x288_mojo.webp',1),
	(3,'Leena','Se obtiene rechazando a Kid 3 veces','character_cc_leena_288x288.webp',1),
	(4,'Poshul','Se obtiene rechazando a Kid 3 veces o en Arni Village dandole el hueso','character_cc_poshul_288x288.webp',1),
	(5,'Kid','Se obtiene en Termina o Cape Howl','character_cc_kid_288x288.webp',1),
	(6,'Guile','Se obtiene en Termina hablando con él en el bar','character_cc_guile_288x288.webp',1),
	(7,'Nikki','Se obtiene en Termina hablando con Miki en el barco de Magical Dreamers','character_cc_nikki_288x288.webp',1),
	(8,'Pierre','Se obtiene en Termina entregandole el Heros Medal en la herreria','character_cc_pierre_288x288.webp',1),
	(9,'Glenn','Se obtiene en Termina al decidir No salvar a Kid','character_cc_glenn_288x288.webp',1),
	(10,'Macha','Se obtiene en Termina al decidir No salvar a Kid','character_cc_macha_288x288.webp',1),
	(11,'Doc','Se obtiene en Termina al decidir No salvar a Kid','character_cc_doc_288x288.webp',1),
	(12,'Korcha','Se obtiene en Termina al decidir salvar a Kid','character_cc_korcha_288x288.webp',1),
	(13,'Greco','Se obtiene en Termina al decidir salvar a Kid','character_cc_greco_288x288.webp',1),
	(14,'Razzly','Se obtiene en Hydra Marsh al decidir salvar a Kid','character_cc_razzly_288x288.webp',1),
	(15,'Mel','Se obtiene en Guldove, despue se capturarla y salir de la isla','character_cc_mel_288x288.webp',1),
	(16,'Pip','Se obtiene en el barco fantasma','character_cc_pip_288x288.webp',1),
	(17,'Luccia','Se obtiene en Viper Manor al ir nuevamente','character_cc_luccia_288x288.webp',1),
	(18,'Lynx','Se obtiene despues del evento en Fort Dragonia','character_cc_lynx_288x288.webp',1),
	(19,'Sprigg','Se obtiene en el Mundo Abstracto','character_cc_sprigg_288x288.webp',1),
	(20,'Harle','Se obtiene en el Mundo Abstracto','character_cc_harle_288x288.webp',1),
	(21,'Radius','Se obtiene al vencerlo en Arni Village','character_cc_radius_288x288.webp',1),
	(22,'Zappa','Se obtiene en Termina con Lynx','character_cc_zappa_288x288.webp',1),
	(23,'Van','Se obtiene en Termina con Lynx','character_cc_van_288x288.webp',1),
	(24,'Norris','Se obtiene en Viper Manor si Radius esta en tu equipo','character_cc_norris_288x288.webp',1),
	(25,'Starky','Se obtiene venciendolo en la isla de Sky Dragon','character_cc_starky_288x288.webp',1),
	(26,'Janice','Se obtiene en el Zelbess al ganar el SLAM de combate','character_cc_janice_288x288.webp',1),
	(27,'Sneff','Se obtiene en Zelbess despues de derrotar al sabio','character_cc_sneff_288x288.webp',1),
	(28,'Irenes','Se obtiene en Zelbess despues de derrotar al sabio','character_cc_irenes_288x288.webp',1),
	(29,'Miki','Se obtiene en Zelbess despues de derrotar al sabio','character_cc_miki_288x288.webp',1),
	(30,'Zoah','Se obtiene en el bar de Termina, habitacion oculta','character_cc_zoah_288x288.webp',1),
	(31,'Karsh','Se obtiene en el bar de Termina, habitacion oculta','character_cc_karsh_288x288.webp',1),
	(32,'Orcha','Se obtiene en Viper Manor despues de rescatar a Riddel','character_cc_orcha_288x288.webp',1),
	(33,'Grobyc','Se obtiene en Viper Manor despues del combate con el Mecha','character_cc_grobyc_288x288.webp',1),
	(34,'Skelly','Se obtiene al conseguir todos sus huesos, son 6 en total','character_cc_skelly_288x288.webp',1),
	(35,'Riddel','Se obtiene al rescatarla del ejercito en Viper Manor','character_cc_riddel_288x288.webp',1),
	(36,'Viper','Se obtiene despues de rescatar a Riddel en Viper Manor','character_cc_viper_288x288.webp',1),
	(37,'Fargo','Se obtiene despues de rescatar a Riddel en Viper Manor','character_cc_fargo_288x288.webp',1),
	(38,'Marcy','Se obtiene despues de rescatar a Riddel en Viper Manor','character_cc_marcy_288x288.webp',1),
	(39,'Turnip','Se obtiene en Hermits Hideaway (AW), (HW), utilizando Ice Gun o Ice Breath con Poshul en tu equip','character_cc_turnip_288x288.webp',1),
	(40,'Funguy','Se obtiene en Shadow Forest al darle el Mushroom al hombre de la cueva en la cascada','character_cc_funguy_288x288.webp',1),
	(41,'Neofio','Se obtiene en la pileta de Viper Manor con la Life Sparkle','character_cc_neofio_288x288.webp',1),
	(42,'Leah','Se obtiene al llegar a la isla de Gaeas Navel','character_cc_leah_288x288.webp',1),
	(43,'Steena','Se obtiene en Guldove al mostrarle el Dragon Emblem','character_cc_steena_288x288.webp',1),
	(44,'Draggy','Se obtiene al poner el huevo gigante en Fort Dragonia','character_cc_draggy_288x288.webp',1),
	(45,'Orlha','Se obtiene en Guldove devolviendole el Sapphire Brooch como Serge','character_cc_orlha_288x288.webp',1)
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
	(1,'background_cc_01_1280x720.webp',1),
	(2,'background_cc_02_1280x720.webp',1),
	(3,'background_com_01_1280x720.webp',2),
	(4,'background_com_02_1280x720.webp',2),
	(5,'background_ds2_01_1280x720.webp',3),
	(6,'background_ds2_02_1280x720.webp',3),
	(7,'background_ffix_01_1280x720.webp',4),
	(8,'background_ffix_02_1280x720.webp',4)
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
SELECT * FROM GG_GuidesUser
SELECT * FROM GG_Adventures
SELECT * FROM GG_AdventuresUser
SELECT * FROM GG_AdventuresImg

-- --------------------------------------------------------------
-- --------------------------------------------------------------