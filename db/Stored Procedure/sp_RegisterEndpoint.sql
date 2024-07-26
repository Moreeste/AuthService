
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_RegisterEndpoint
	@IdEndpoint VARCHAR(36),
	@Method VARCHAR(10),
	@Path NVARCHAR(100),
	@RegistrationUser VARCHAR(36)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Success INT = 0;
	DECLARE @ErrorMessage NVARCHAR(MAX) = NULL;

	BEGIN TRY
		BEGIN TRANSACTION;
		
		INSERT INTO Endpoints (IdEndpoint, Method, Path, Active, RegistrationDate, RegistrationUser)
		VALUES (@IdEndpoint, UPPER(@Method), @Path, 1, GETDATE(), @RegistrationUser);

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
