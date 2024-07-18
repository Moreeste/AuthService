
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_ChangePassword
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
		
		UPDATE Passwords
		SET	Password = @Password,
			Salt = @Salt,
			CreationDate = GETDATE(),
			ExpirationDate = DATEADD(YEAR, 1, GETDATE()),
			FailedAttempts = 0,
			LastAttemptDate = NULL
		WHERE IdUser = @IdUser;

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
