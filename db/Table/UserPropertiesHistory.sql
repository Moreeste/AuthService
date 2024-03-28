
DROP TABLE IF EXISTS UserPropertiesHistory

CREATE TABLE UserPropertiesHistory
(
	Id VARCHAR(36) DEFAULT LOWER(NEWID()), 
	IdUser VARCHAR(36) NOT NULL,
	Status INT NOT NULL,
	Profile VARCHAR(36) NOT NULL,
	CreationDate DATETIME NOT NULL,
	UpdateDate DATETIME,
	UpdateUser VARCHAR(36),

	CONSTRAINT PK_UserPropertiesHistory_Id PRIMARY KEY (Id)
);

CREATE NONCLUSTERED INDEX IX_UserPropertiesHistory_IdUser ON UserPropertiesHistory (IdUser);
