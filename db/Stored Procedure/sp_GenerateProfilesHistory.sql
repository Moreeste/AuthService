
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_GenerateProfilesHistory
	@IdProfile VARCHAR(36)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO ProfilesHistory (IdProfile, Description, Active, RegistrationDate, RegistrationUser, UpdateDate, UpdateUser)
	SELECT TOP 1 IdProfile, Description, Active, RegistrationDate, RegistrationUser, UpdateDate, UpdateUser
	FROM Profiles WHERE IdProfile = @IdProfile;
END
GO
