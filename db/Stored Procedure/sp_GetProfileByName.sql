
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_GetProfileByName
	@Description VARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT IdProfile, Description, Active
	FROM Profiles
	WHERE Description = @Description;

END
GO
