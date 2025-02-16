﻿
-- Tables -------------------------------------------------------
-- --------------------------------------------------------------

CREATE TABLE PM_Core (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Data01 VARCHAR(256) NOT NULL,
	Data02 VARCHAR(256) NOT NULL,
	Data03 VARCHAR(256) NOT NULL,
	Id_User VARCHAR(256) NOT NULL
	FOREIGN KEY (Id_User) REFERENCES Auth_Users(Id)
)
GO

-- Data ---------------------------------------------------------
-- --------------------------------------------------------------

-- Stored Procedure ---------------------------------------------
-- --------------------------------------------------------------

-- Query --------------------------------------------------------
-- --------------------------------------------------------------

UPDATE Auth_Users SET HashPM = NULL, SaltPM = NULL WHERE Id = 'cddf8d84-37d4-4c53-be39-53c95cb10a65'

SELECT
	a.Id,
	a.Email,
	a.HashLogin,
	a.SaltLogin,
	a.HashPM,
	a.SaltPM,
	a.SqlToken,
	b.Name AS Role
FROM Auth_Users a
	INNER JOIN Auth_Profiles b ON a.Id_Profile = b.Id

SELECT Id, Data01, Data02, Data03, Id_User 
FROM PM_Core 
WHERE Id_User = 'cddf8d84-37d4-4c53-be39-53c95cb10a65'

-- --------------------------------------------------------------
-- --------------------------------------------------------------
