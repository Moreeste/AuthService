
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_CreateProfile
	@IdProfile VARCHAR(36),
	@Description VARCHAR(50),
	@RegistrationUser VARCHAR(36)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Success INT = 0;
	DECLARE @ErrorMessage NVARCHAR(MAX) = NULL;

	BEGIN TRY
		BEGIN TRANSACTION;
		
		INSERT INTO Profiles (IdProfile, Description, Active, RegistrationDate, RegistrationUser)
		VALUES (@IdProfile, UPPER(@Description), 1, GETDATE(), @RegistrationUser);

		EXECUTE sp_GenerateProfilesHistory @IdProfile;

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
