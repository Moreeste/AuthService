
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_GetUserStatus
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT	IdStatus, 
			Description
	FROM UserStatus;

END
GO
