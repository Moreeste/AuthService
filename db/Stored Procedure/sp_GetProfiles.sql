
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_GetProfiles
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT	IdProfile, 
			Description, 
			Active
	FROM Profiles;

END
GO
