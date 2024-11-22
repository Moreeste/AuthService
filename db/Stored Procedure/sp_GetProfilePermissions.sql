
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_GetProfilePermissions
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @Permissions AS TABLE 
	(
		IdPermission VARCHAR(36) NOT NULL, 
		IdProfile VARCHAR(36) NOT NULL, 
		Profile VARCHAR(50) NOT NULL, 
		IdEndpoint VARCHAR(36) NOT NULL, 
		Endpoint NVARCHAR(100) NOT NULL, 
		Active BIT NOT NULL
	);

	INSERT INTO @Permissions 
	SELECT	PP.IdPermission, 
			PP.IdProfile, 
			P.Description AS Profile, 
			PP.IdEndpoint, 
			E.Path AS Endpoint, 
			PP.Active 
	FROM ProfilePermissions PP 
	LEFT JOIN Profiles P ON P.IdProfile = PP.IdProfile 
	LEFT JOIN Endpoints E ON E.IdEndpoint = PP.IdEndpoint;

	SELECT * FROM @Permissions ORDER BY Endpoint;
END
GO
