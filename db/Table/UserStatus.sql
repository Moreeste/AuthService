
DROP TABLE IF EXISTS UserStatus

CREATE TABLE UserStatus
(
	IdStatus INT NOT NULL,
	Description VARCHAR(30) NOT NULL,

	CONSTRAINT PK_UserStatus_IdStatus PRIMARY KEY (IdStatus)
);
