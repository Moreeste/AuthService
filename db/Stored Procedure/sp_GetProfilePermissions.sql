
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
			P.Description, 
			PP.IdEndpoint, 
			E.Path, 
			PP.Active 
	FROM ProfilePermissions PP 
	LEFT JOIN Profiles P ON P.IdProfile = PP.IdProfile 
	LEFT JOIN Endpoints E ON E.IdEndpoint = PP.IdEndpoint;

	INSERT INTO @Permissions 
	SELECT	CASE 
				WHEN E.IsPublic = 1 THEN 'Public' 
				WHEN E.IsForEveryone = 1 THEN 'ForEveryone' 
			END, 
			P.IdProfile, 
			P.Description, 
			E.IdEndpoint, 
			E.Path, 
			E.Active 
			FROM Profiles P, Endpoints E 
	WHERE E.IsPublic = 1 OR E.IsForEveryone = 1;

	INSERT INTO @Permissions 
	SELECT	'AutoForAdmins', 
			'00000000-0000-0000-0000-000000000000', 
			'ADMIN', 
			IdEndpoint, 
			Path, 
			Active 
	FROM Endpoints 
	WHERE IsPublic = 0 AND IsForEveryone = 0;

	SELECT * FROM @Permissions ORDER BY Endpoint;
END
GO
