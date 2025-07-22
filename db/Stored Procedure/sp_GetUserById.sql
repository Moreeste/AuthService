
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_GetUserById
	@IdUser VARCHAR(36)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT	IdUser, 
			FirstName, 
			LastName, 
			Gender, 
			BirthDate, 
			Email, 
			PhoneNumber, 
			RegistrationDate, 
			RegistrationUser, 
			UpdateDate, 
			UpdateUser 
	FROM Users 
	WHERE IdUser = @IdUser;

END
GO
