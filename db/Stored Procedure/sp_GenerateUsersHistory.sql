
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_GenerateUsersHistory
	@IdUser VARCHAR(36)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO UsersHistory (IdUser,  FirstName, MiddleName, LastName, SecondLastName, Gender, BirthDate, Email, PhoneNumber, RegistrationDate, RegistrationUser, UpdateDate, UpdateUser) 
	SELECT TOP 1 IdUser, FirstName, MiddleName, LastName, SecondLastName, Gender, BirthDate, Email, PhoneNumber, RegistrationDate, RegistrationUser, UpdateDate, UpdateUser
	FROM Users WHERE IdUser = @IdUser;
END
GO
