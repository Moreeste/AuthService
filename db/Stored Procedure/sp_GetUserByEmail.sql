
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_GetUserByEmail
	@Email VARCHAR(100)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT	Users.IdUser, 
			FirstName, 
			LastName, 
			Gender, 
			BirthDate, 
			Email, 
			PhoneNumber, 
			RegistrationDate, 
			RegistrationUser, 
			Users.UpdateDate, 
			Users.UpdateUser, 
			Profile AS IdProfile
	FROM Users 
	INNER JOIN UserProperties ON UserProperties.IdUser = Users.IdUser
	WHERE Email = @Email;

END
GO
