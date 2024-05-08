
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_GetUserProperties
	@IdUser VARCHAR(36)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT	IdUser, 
			Status, 
			Profile, 
			CreationDate, 
			UpdateDate, 
			UpdateUser 
	FROM UserProperties 
	WHERE IdUser = @IdUser;

END
GO
