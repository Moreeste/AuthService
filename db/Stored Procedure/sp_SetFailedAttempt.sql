
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_SetFailedAttempt
	@IdUser VARCHAR(36)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Success INT = 0;
	DECLARE @ErrorMessage NVARCHAR(MAX) = NULL;

	BEGIN TRY
		BEGIN TRANSACTION;
		
		UPDATE Passwords 
		SET	FailedAttempts = FailedAttempts + 1, 
			LastAttemptDate = GETDATE() 
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
