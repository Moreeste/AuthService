
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_SavePassword
	@IdUser VARCHAR(36),
	@Password VARCHAR(128),
	@Salt NVARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Success INT = 0;
	DECLARE @ErrorMessage NVARCHAR(MAX) = NULL;

	BEGIN TRY
		BEGIN TRANSACTION;
		
		INSERT INTO Passwords (IdUser, Password, Salt, CreationDate, ExpirationDate, FailedAttempts, LastAttemptDate)
		VALUES (@IdUser, @Password, @Salt, GETDATE(), DATEADD(YEAR, 1, GETDATE()), 0, NULL);

		EXECUTE sp_GeneratePasswordHistory @IdUser;

		COMMIT;
		SET @Success = 1;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		SET @Success = 0;
		SET @ErrorMessage = ERROR_MESSAGE();
	END CATCH

	SELECT @Success AS 'Success', @ErrorMessage AS 'ErrorMessage';
END
GO
