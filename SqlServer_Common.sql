
-- Tablas -------------------------------------------------------
-- --------------------------------------------------------------

CREATE TABLE Mae_Config (
	Id INT PRIMARY KEY IDENTITY(1,1),
	ApiKey varchar(256) NOT NULL
)
GO

DROP TABLE __EFMigrationsHistory
GO
DROP TABLE Mae_Config
GO

DROP TABLE F1_Pilots
GO
DROP TABLE F1_Racing
GO
DROP TABLE F1_Circuits
GO
DROP TABLE F1_Teams
GO
DROP TABLE F1_Flags
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
DROP TABLE GG_Users
GO

DROP TABLE PF_Pro_Tec
GO
DROP TABLE PF_Pro_Leng
GO
DROP TABLE PF_Technologies
GO
DROP TABLE PF_Languages
GO
DROP TABLE PF_Projects
GO
DROP TABLE PF_UrlGrp
GO
DROP TABLE PF_Url
GO

-- Data ---------------------------------------------------------
-- --------------------------------------------------------------

SET IDENTITY_INSERT Mae_Config ON
GO
INSERT INTO Mae_Config
	(Id, ApiKey)
VALUES
	(1, 'ApiKey-Secret-777')
SET IDENTITY_INSERT Mae_Config OFF
GO

-- Stored Procedure ---------------------------------------------
-- --------------------------------------------------------------

DROP PROCEDURE GG_Login
GO
DROP PROCEDURE GG_GuidesUser_Set
GO
DROP PROCEDURE GG_AdventuresUser_Set
GO

-- Query --------------------------------------------------------
-- --------------------------------------------------------------

-- --------------------------------------------------------------
-- --------------------------------------------------------------