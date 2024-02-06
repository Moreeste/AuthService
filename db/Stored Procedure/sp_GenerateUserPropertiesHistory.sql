
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_GenerateUserPropertiesHistory
	@IdUser VARCHAR(36)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO UserPropertiesHistory (IdUser, Status, Profile, CreationDate, UpdateDate, UpdateUser)
	SELECT TOP 1 IdUser, Status, Profile, CreationDate, UpdateDate, UpdateUser
	FROM UserProperties WHERE IdUser = @IdUser;
END
GO
