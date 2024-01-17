
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
			MiddleName, 
			LastName, 
			SecondLastName, 
			G.Description AS Gender, 
			BirthDate, 
			Email, 
			PhoneNumber, 
			RegistrationDate, 
			RegistrationUser, 
			UpdateDate, 
			UpdateUser
	FROM Users U
	LEFT JOIN Genders G ON G.IdGender = U.Gender
	WHERE IdUser = @IdUser;
END
GO
