
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_GetProfilePermissionsByIdEndpoint
	@IdEndpoint VARCHAR(36)
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @Endpoint NVARCHAR(100) = (SELECT TOP 1 Path FROM Endpoints WHERE IdEndpoint = @IdEndpoint);
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
	LEFT JOIN Endpoints E ON E.IdEndpoint = PP.IdEndpoint 
	WHERE PP.IdEndpoint = @IdEndpoint;

	INSERT INTO @Permissions 
	SELECT CASE 
				WHEN IsPublic = 1 THEN 'Public' 
				WHEN IsForEveryone = 1 THEN 'ForEveryone' 
			END, 
			P.IdProfile, 
			P.Description AS Profile, 
			IdEndpoint, 
			Path AS Endpoint, 
			E.Active 
	FROM Endpoints E, Profiles P 
	WHERE (IsPublic = 1 OR IsForEveryone = 1) AND IdEndpoint = @IdEndpoint;

	INSERT INTO @Permissions 
	SELECT	'AutoForAdmins', 
			'00000000-0000-0000-0000-000000000000', 
			'ADMIN' AS Profile, 
			IdEndpoint, 
			Path AS Endpoint, 
			Active 
	FROM Endpoints Profiles 
	WHERE IdEndpoint = @IdEndpoint AND IsPublic = 0 AND IsForEveryone = 0;

	SELECT * FROM @Permissions ORDER BY Profile;
END
GO
