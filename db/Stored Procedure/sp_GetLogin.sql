
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_GetLogin
	@IdUser VARCHAR(36),
	@Token NVARCHAR(500),
	@RefreshToken NVARCHAR(200)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT	LoginDate, 
			TokenExpiration, 
			RefreshTokenExpiration 
	FROM UserLogin
	WHERE IdUser = @IdUser AND Token = @Token AND RefreshToken = @RefreshToken;

END
GO
