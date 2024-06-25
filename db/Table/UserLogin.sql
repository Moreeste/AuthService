
DROP TABLE IF EXISTS UserLogin

CREATE TABLE UserLogin
(
	Id VARCHAR(36) DEFAULT LOWER(NEWID()),  
	IdUser VARCHAR(36) NOT NULL,
	LoginDate DATETIME NOT NULL,
	Token NVARCHAR(500) NOT NULL,
	TokenExpiration DATETIME NOT NULL,
	RefreshToken NVARCHAR(200) NOT NULL,
	RefreshTokenExpiration DATETIME NOT NULL,
	Refreshed BIT NOT NULL,
	RefreshedBy NVARCHAR(200),

	CONSTRAINT PK_UserLogin_Id PRIMARY KEY (Id)
);

CREATE NONCLUSTERED INDEX IX_UserLogin_IdUser ON UserLogin (IdUser);
CREATE NONCLUSTERED INDEX IX_UserLogin_Token ON UserLogin (Token);
CREATE NONCLUSTERED INDEX IX_UserLogin_RefreshToken ON UserLogin (RefreshToken);
CREATE NONCLUSTERED INDEX IX_UserLogin_RefreshedBy ON UserLogin (RefreshedBy);
CREATE NONCLUSTERED INDEX IX_UserLogin_IdUser_Token ON UserLogin (IdUser, Token);
CREATE NONCLUSTERED INDEX IX_UserLogin_IdUser_RefreshToken ON UserLogin (IdUser, RefreshToken);
CREATE NONCLUSTERED INDEX IX_UserLogin_IdUser_Refreshed ON UserLogin (IdUser, Refreshed);
CREATE NONCLUSTERED INDEX IX_UserLogin_IdUser_RefreshedBy ON UserLogin (IdUser, RefreshedBy)
CREATE NONCLUSTERED INDEX IX_UserLogin_Token_RefreshToken ON UserLogin (Token, RefreshToken);
CREATE NONCLUSTERED INDEX IX_UserLogin_IdUser_Token_RefreshToken ON UserLogin (IdUser, Token, RefreshToken);
