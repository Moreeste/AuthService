
DROP TABLE IF EXISTS Endpoints

CREATE TABLE Endpoints
(
	IdEndpoint VARCHAR(36) NOT NULL,
	Path NVARCHAR(100) NOT NULL,
	Active BIT NOT NULL,
	RegistrationDate DATETIME NOT NULL,
	RegistrationUser VARCHAR(36) NOT NULL,
	UpdateDate DATETIME,
	UpdateUser VARCHAR(36),

	CONSTRAINT PK_Endpoints_IdEndpoint PRIMARY KEY (IdEndpoint)
);

CREATE NONCLUSTERED INDEX IX_Endpoints_IdEndpoint ON Endpoints (IdEndpoint);
CREATE NONCLUSTERED INDEX IX_Endpoints_Path ON Endpoints (Path);
CREATE UNIQUE INDEX UQ_Endpoints_Path ON Endpoints (Path);
