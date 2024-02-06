
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_GetPassword
	@IdUser VARCHAR(36)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT	Password, 
			Salt, 
			CreationDate, 
			ExpirationDate, 
			FailedAttempts, 
			LastAttemptDate, 
			Blocked 
	FROM Passwords 
	WHERE IdUser = @IdUser;

END
GO
