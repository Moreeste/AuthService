
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_UpdateUserPropertiesStatus
	@IdUser VARCHAR(36),
	@Status INT,
	@UpdateUser VARCHAR(36)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Success INT = 0;
	DECLARE @ErrorMessage NVARCHAR(MAX) = NULL;

	BEGIN TRY
		BEGIN TRANSACTION;
		
		UPDATE UserProperties
		SET	Status = @Status, 
			UpdateUser = @UpdateUser, 
			UpdateDate = GETDATE() 
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
