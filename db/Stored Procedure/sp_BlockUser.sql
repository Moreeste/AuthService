
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_BlockUser
	@IdUser VARCHAR(36)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Success INT = 0;
	DECLARE @ErrorMessage NVARCHAR(MAX) = NULL;

	BEGIN TRY
		BEGIN TRANSACTION;
		DECLARE @BlockedStatus INT = 3;

		UPDATE UserProperties 
		SET	Status = @BlockedStatus, 
			UpdateDate = GETDATE(), 
			UpdateUser = @IdUser 
		WHERE IdUser = @IdUser;

		EXECUTE sp_GenerateUserPropertiesHistory @IdUser;

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
