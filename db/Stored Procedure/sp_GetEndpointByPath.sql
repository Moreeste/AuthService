
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_GetEndpointByPath
	@Path NVARCHAR(100)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT IdEndpoint, Method, Path, IsPublic, IsForEveryone, Active 
	FROM Endpoints 
	WHERE Path = @Path;

END
GO
