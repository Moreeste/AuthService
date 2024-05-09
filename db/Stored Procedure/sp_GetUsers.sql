
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_GetUsers
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT	IdUser, 
			FirstName, 
			MiddleName, 
			LastName, 
			SecondLastName, 
			Gender, 
			BirthDate, 
			Email, 
			PhoneNumber, 
			RegistrationDate, 
			RegistrationUser, 
			UpdateDate, 
			UpdateUser 
	FROM Users;

END
GO
