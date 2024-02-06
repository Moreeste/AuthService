
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_GeneratePasswordHistory
	@IdUser VARCHAR(36)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO PasswordsHistory (IdUser, Password, Salt, CreationDate, ExpirationDate, FailedAttempts, LastAttemptDate)
	SELECT TOP 1 IdUser, Password, Salt, CreationDate, ExpirationDate, FailedAttempts, LastAttemptDate
	FROM Passwords WHERE IdUser = @IdUser;
END
GO
