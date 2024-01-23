
DROP TABLE IF EXISTS Passwords

CREATE TABLE Passwords
(
	IdUser VARCHAR(36) NOT NULL,
	Password VARCHAR(128) NOT NULL,
	Salt NVARCHAR(128) NOT NULL,
	CreationDate DATETIME NOT NULL,
	ExpirationDate DATETIME NOT NULL,
	FailedAttempts INT NOT NULL,
	LastAttemptDate DATETIME,
	Blocked BIT NOT NULL,

	CONSTRAINT PK_Passwords_IdUser PRIMARY KEY (IdUser),
);

CREATE NONCLUSTERED INDEX IX_Passwords_IdUser ON Passwords (IdUser);
