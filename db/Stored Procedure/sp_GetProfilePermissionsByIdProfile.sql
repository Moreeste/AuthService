
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_GetProfilePermissionsByIdProfile
	@IdProfile VARCHAR(36)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @Profile VARCHAR(50) = (SELECT TOP 1 Description FROM Profiles WHERE IdProfile = @IdProfile);
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
	SELECT	CASE
				WHEN IsPublic = 1 THEN 'Public'
				WHEN IsForEveryone = 1 THEN 'ForEveryone'
			END,
			@IdProfile,
			@Profile,
			IdEndpoint,
			Path,
			Active
	FROM Endpoints
	WHERE IsPublic = 1 OR IsForEveryone = 1;

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
	WHERE PP.IdProfile = @IdProfile;

	IF @IdProfile = '00000000-0000-0000-0000-000000000000'
	BEGIN
		INSERT INTO @Permissions
		SELECT	'AutoForAdmins',
				@IdProfile,
				@Profile,
				IdEndpoint,
				Path,
				Active
		FROM Endpoints
		WHERE IsPublic = 0 AND IsForEveryone = 0;
	END
		
	SELECT * FROM @Permissions ORDER BY Endpoint;
END
GO
