
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_AddApiLog
	@TraceId VARCHAR(36),
	@TimeElapsed DECIMAL(32,16),
	@ClientIP VARCHAR(15),
	@Path VARCHAR(80),
	@StatusCode INT,
	@ParamSuccess BIT,
	@Error NVARCHAR(MAX),
	@Request NVARCHAR(MAX),
	@Response NVARCHAR(MAX),
	@Result NVARCHAR(MAX),
	@Token NVARCHAR(MAX)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Success INT = 0;
	DECLARE @ErrorMessage NVARCHAR(MAX) = NULL;

	BEGIN TRY
		BEGIN TRANSACTION;
		
		INSERT INTO ApiLog (TraceId, TimeSpan, TimeElapsed, ClientIP, Path, StatusCode, Success, Error, Request, Response, Result, Token)
		VALUES (@TraceId, GETDATE(), @TimeElapsed, @ClientIP, @Path, @StatusCode, @ParamSuccess, @Error, @Request, @Response, @Result, @Token);

		COMMIT;
		SET @Success = 1;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		SET @Success = 0;
		SET @ErrorMessage = ERROR_MESSAGE();
	END CATCH

	SELECT @Success AS 'Success', @ErrorMessage AS 'ErrorMessage';
END
GO
