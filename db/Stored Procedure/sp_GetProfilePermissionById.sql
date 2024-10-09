
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_GetProfilePermissionById
	@IdPermission VARCHAR(36)
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
	WHERE PP.IdPermission = @IdPermission;

END
GO
