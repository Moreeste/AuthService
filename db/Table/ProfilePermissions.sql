
DROP TABLE IF EXISTS ProfilePermissions

CREATE TABLE ProfilePermissions
(
	IdPermission VARCHAR(36) NOT NULL,
	IdProfile VARCHAR(36) NOT NULL,
	IdEndpoint VARCHAR(36) NOT NULL,
	Active BIT NOT NULL,
	RegistrationDate DATETIME NOT NULL,
	RegistrationUser VARCHAR(36) NOT NULL,
	UpdateDate DATETIME,
	UpdateUser VARCHAR(36),

	CONSTRAINT PK_ProfilePermissions_IdPermission PRIMARY KEY (IdPermission)
);

CREATE NONCLUSTERED INDEX IX_ProfilePermissions_IdPermission ON ProfilePermissions (IdPermission);
CREATE NONCLUSTERED INDEX IX_ProfilePermissions_IdProfile ON ProfilePermissions (IdProfile);
CREATE NONCLUSTERED INDEX IX_ProfilePermissions_IdEndpoint ON ProfilePermissions (IdEndpoint);
CREATE NONCLUSTERED INDEX IX_ProfilePermissions_IdProfileIdEndpoint ON ProfilePermissions (IdProfile, IdEndpoint);
