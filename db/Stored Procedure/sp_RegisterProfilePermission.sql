
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_RegisterProfilePermission
	@IdPermission VARCHAR(36),
	@IdProfile VARCHAR(36),
	@IdEndpoint VARCHAR(36),
	@RegistrationUser VARCHAR(36)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Success INT = 0;
	DECLARE @ErrorMessage NVARCHAR(MAX) = NULL;

	BEGIN TRY
		BEGIN TRANSACTION;
		
		INSERT INTO ProfilePermissions (IdPermission, IdProfile, IdEndpoint, Active, RegistrationDate, RegistrationUser)
		VALUES (@IdPermission, @IdProfile, @IdEndpoint, 1, GETDATE(), @RegistrationUser);

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
