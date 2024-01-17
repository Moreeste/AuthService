
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_GetUserByPhone
	@Phone VARCHAR(10)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT	IdUser, 
			FirstName, 
			MiddleName, 
			LastName, 
			SecondLastName, 
			UPPER(G.Description) AS Gender, 
			BirthDate, 
			Email, 
			PhoneNumber, 
			RegistrationDate, 
			RegistrationUser, 
			UpdateDate, 
			UpdateUser
	FROM Users U
	LEFT JOIN Genders G ON G.IdGender = U.Gender
	WHERE PhoneNumber = @Phone;
END
GO
