
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_GetUsersByProfile
	@IdProfile VARCHAR(36)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT	Users.IdUser, 
			FirstName, 
			MiddleName, 
			LastName, 
			SecondLastName, 
			Gender, 
			BirthDate, 
			Email, 
			PhoneNumber 
	FROM Users 
	INNER JOIN UserProperties ON UserProperties.IdUser = Users.IdUser
	WHERE UserProperties.Profile = @IdProfile;

END
GO
