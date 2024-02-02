
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_GetUserByEmail
	@Email VARCHAR(100)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT	U.IdUser, 
			U.FirstName, 
			U.MiddleName, 
			U.LastName, 
			U.SecondLastName, 
			G.Description AS Gender, 
			U.BirthDate, 
			U.Email, 
			U.PhoneNumber, 
			U.RegistrationDate, 
			U.RegistrationUser, 
			U.UpdateDate, 
			U.UpdateUser, 
			P.Status, 
			P.Profile 
	FROM Users U 
	LEFT JOIN Genders G ON G.IdGender = U.Gender 
	INNER JOIN UserProperties P ON P.IdUser = U.IdUser 
	WHERE U.Email = @Email;
END
GO
