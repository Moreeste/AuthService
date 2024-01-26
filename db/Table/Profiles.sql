
DROP TABLE IF EXISTS Profiles

CREATE TABLE Profiles
(
	IdProfile VARCHAR(36) NOT NULL,
	Description VARCHAR(50) NOT NULL,
	Active BIT NOT NULL,
	RegistrationDate DATETIME NOT NULL,
	RegistrationUser VARCHAR(36) NOT NULL,
	UpdateDate DATETIME,
	UpdateUser VARCHAR(36),

	CONSTRAINT PK_Profiles_IdProfile PRIMARY KEY (IdProfile)
);
