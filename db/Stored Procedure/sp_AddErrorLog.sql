
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_AddErrorLog
	@TraceId VARCHAR(36),
	@Type VARCHAR(50),
	@Message NVARCHAR(MAX),
	@StackTrace NVARCHAR(MAX),
	@Query NVARCHAR(MAX),
	@Parameters NVARCHAR(MAX)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Success INT = 0;
	DECLARE @ErrorMessage NVARCHAR(MAX) = NULL;

	BEGIN TRY
		BEGIN TRANSACTION;
		
		INSERT INTO ErrorLog (TraceId, TimeSpan, Type, Message, StackTrace, Query, Parameters)
		VALUES (@TraceId, GETDATE(), @Type, @Message, @StackTrace, @Query, @Parameters);

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
