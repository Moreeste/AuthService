
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_GetUsers
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
			UserProperties.Profile
	FROM Users
	LEFT JOIN UserProperties ON UserProperties.IdUser = Users.IdUser;

END
GO
