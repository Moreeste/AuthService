
DROP TABLE IF EXISTS UserLogin

CREATE TABLE UserLogin
(
	Id VARCHAR(36) DEFAULT LOWER(NEWID()),  
	IdUser VARCHAR(36) NOT NULL,
	LoginDate DATETIME NOT NULL,
	Token NVARCHAR(500),
	TokenExpiration DATETIME,
	RefreshToken NVARCHAR(200),
	RefreshTokenExpiration DATETIME

	CONSTRAINT PK_UserLogin_Id PRIMARY KEY (Id)
);

CREATE NONCLUSTERED INDEX IX_UserLogin_IdUser ON UserLogin (IdUser);
CREATE NONCLUSTERED INDEX IX_UserLogin_Token ON UserLogin (Token);
CREATE NONCLUSTERED INDEX IX_UserLogin_RefreshToken ON UserLogin (RefreshToken);
CREATE NONCLUSTERED INDEX IX_UserLogin_IdUser_Token ON UserLogin (IdUser, Token);
CREATE NONCLUSTERED INDEX IX_UserLogin_IdUser_RefreshToken ON UserLogin (IdUser, RefreshToken);
CREATE NONCLUSTERED INDEX IX_UserLogin_Token_RefreshToken ON UserLogin (Token, RefreshToken);
CREATE NONCLUSTERED INDEX IX_UserLogin_IdUser_Token_RefreshToken ON UserLogin (IdUser, Token, RefreshToken);
