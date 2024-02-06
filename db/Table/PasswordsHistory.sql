
DROP TABLE IF EXISTS PasswordsHistory

CREATE TABLE PasswordsHistory
(
	Id UNIQUEIDENTIFIER DEFAULT NEWID(), 
	IdUser VARCHAR(36) NOT NULL,
	Password VARCHAR(128) NOT NULL,
	Salt NVARCHAR(128) NOT NULL,
	CreationDate DATETIME NOT NULL,
	ExpirationDate DATETIME NOT NULL,
	FailedAttempts INT NOT NULL,
	LastAttemptDate DATETIME

	CONSTRAINT PK_PasswordsHistory_Id PRIMARY KEY (Id)
);

CREATE NONCLUSTERED INDEX IX_PasswordsHistory_IdUser ON PasswordsHistory (IdUser);
