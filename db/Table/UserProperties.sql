
DROP TABLE IF EXISTS UserProperties

CREATE TABLE UserProperties
(
	IdUser VARCHAR(36) NOT NULL,
	Status INT NOT NULL,
	Profile VARCHAR(36) NOT NULL,
	CreationDate DATETIME NOT NULL,
	CreationUser VARCHAR(36) NOT NULL,
	UpdateDate DATETIME,
	UpdateUser VARCHAR(36),

	CONSTRAINT PK_UserProperties_IdUser PRIMARY KEY (IdUser),
	CONSTRAINT FK_UserProperties_Status FOREIGN KEY (Status) REFERENCES UserStatus (IdStatus),
	CONSTRAINT FK_UserProperties_Profile FOREIGN KEY (Profile) REFERENCES Profiles (IdProfile)
);

CREATE NONCLUSTERED INDEX IX_UserProperties_IdUser ON UserProperties (IdUser);
