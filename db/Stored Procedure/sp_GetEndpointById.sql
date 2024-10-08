
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_GetEndpointById
	@IdEndpoint VARCHAR(36)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT IdEndpoint, Method, Path, IsPublic, IsForEveryone, Active 
	FROM Endpoints 
	WHERE IdEndpoint = @IdEndpoint;

END
GO
