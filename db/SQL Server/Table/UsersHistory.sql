
DROP TABLE IF EXISTS UsersHistory

CREATE TABLE UsersHistory
(
	Id UNIQUEIDENTIFIER DEFAULT NEWID(), 
	IdUser VARCHAR(36) NOT NULL,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(30),
	LastName NVARCHAR(30) NOT NULL,
	SecondLastName NVARCHAR(30),
	Gender INT NOT NULL,
	BirthDate DATE NOT NULL,
	Email VARCHAR(100) NOT NULL,
	PhoneNumber VARCHAR(10) NOT NULL,
	RegistrationDate DATETIME NOT NULL,
	RegistrationUser VARCHAR(36) NOT NULL,
	UpdateDate DATETIME,
	UpdateUser VARCHAR(36),

	CONSTRAINT PK_UsersHistory_Id PRIMARY KEY (Id)
);

CREATE NONCLUSTERED INDEX IX_UsersHistory_IdUser ON UsersHistory (IdUser);
