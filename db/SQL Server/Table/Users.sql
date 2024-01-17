
DROP TABLE IF EXISTS Users

CREATE TABLE Users
(
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

	CONSTRAINT PK_Users_IdUser PRIMARY KEY (IdUser),
	CONSTRAINT FK_Users_Genders FOREIGN KEY (Gender) REFERENCES Genders (IdGender)
);

CREATE NONCLUSTERED INDEX IX_Users_IdUser ON Users (IdUser);
CREATE UNIQUE INDEX UQ_Users_Email ON Users (Email);
CREATE UNIQUE INDEX UQ_Users_PhoneNumber ON Users (PhoneNumber);
