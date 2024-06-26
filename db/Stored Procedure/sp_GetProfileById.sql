
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_GetProfileById
	@IdProfile VARCHAR(36)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT IdProfile, Description, Active
	FROM Profiles
	WHERE IdProfile = @IdProfile;

END
GO
