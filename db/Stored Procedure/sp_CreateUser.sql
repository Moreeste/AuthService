
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_CreateUser
	@IdUser VARCHAR(36),
	@FirstName NVARCHAR(30),
	@MiddleName NVARCHAR(30),
	@LastName NVARCHAR(30),
	@SecondLastName NVARCHAR(30),
	@Gender INT,
	@BirthDate DATE,
	@Email VARCHAR(100),
	@PhoneNumber NVARCHAR(20),
	@RegistrationUser VARCHAR(36),
	@Password VARCHAR(128),
	@Salt NVARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Success INT = 0;
	DECLARE @ErrorMessage NVARCHAR(MAX) = NULL;

	BEGIN TRY
		BEGIN TRANSACTION;
		DECLARE @DefaultStatus INT = 1;
		DECLARE @DefaultProfile VARCHAR(36) = '8D5A1FBE-CC7E-4B9B-88A6-3F2E1D9C05A2';
		
		INSERT INTO Users (IdUser, FirstName, MiddleName, LastName, SecondLastName, Gender, BirthDate, Email, PhoneNumber, RegistrationDate, RegistrationUser) 
		VALUES (@IdUser, UPPER(@FirstName), UPPER(@MiddleName), UPPER(@LastName), UPPER(@SecondLastName), @Gender, @BirthDate, @Email, @PhoneNumber, GETDATE(), @RegistrationUser);

		EXECUTE sp_GenerateUsersHistory @IdUser;

		INSERT INTO Passwords (IdUser, Password, Salt, CreationDate, ExpirationDate, FailedAttempts, LastAttemptDate)
		VALUES (@IdUser, @Password, @Salt, GETDATE(), DATEADD(YEAR, 1, GETDATE()), 0, NULL);

		EXECUTE sp_GeneratePasswordHistory @IdUser;

		INSERT INTO UserProperties (IdUser, Status, Profile, CreationDate)
		VALUES(@IdUser, @DefaultStatus, @DefaultProfile, GETDATE());

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
