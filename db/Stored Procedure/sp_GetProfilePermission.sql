
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_GetProfilePermission
	@IdProfile VARCHAR(36),
	@IdEndpoint VARCHAR(36)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT	PP.IdPermission, 
			PP.IdProfile, 
			P.Description AS Profile,
			PP.IdEndpoint, 
			E.Path AS Endpoint,
			PP.Active
	FROM ProfilePermissions PP
	LEFT JOIN Profiles P ON P.IdProfile = PP.IdProfile
	LEFT JOIN Endpoints E ON E.IdEndpoint = PP.IdEndpoint
	WHERE PP.IdProfile = @IdProfile AND PP.IdEndpoint = @IdEndpoint;

END
GO
