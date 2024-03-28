
DROP TABLE IF EXISTS ProfilesHistory

CREATE TABLE ProfilesHistory
(
	Id VARCHAR(36) DEFAULT LOWER(NEWID()), 
	IdProfile VARCHAR(36) NOT NULL,
	Description VARCHAR(50) NOT NULL,
	Active BIT NOT NULL,
	RegistrationDate DATETIME NOT NULL,
	RegistrationUser VARCHAR(36) NOT NULL,
	UpdateDate DATETIME,
	UpdateUser VARCHAR(36),

	CONSTRAINT PK_ProfilesHistory_Id PRIMARY KEY (Id)
);
