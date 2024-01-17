
DROP TABLE IF EXISTS Genders

CREATE TABLE Genders
(
	IdGender INT NOT NULL,
	Description VARCHAR(30) NOT NULL,

	CONSTRAINT PK_Genders_IdGender PRIMARY KEY (IdGender)
);
