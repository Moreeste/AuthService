
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE sp_RegisterLogin
	@IdUser VARCHAR(36),
	@LoginDate DATETIME,
	@Token NVARCHAR(500),
	@TokenExpiration DATETIME,
	@RefreshToken NVARCHAR(200),
	@RefreshTokenExpiration DATETIME,
	@Refreshed BIT,
	@RefreshedBy NVARCHAR(200)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Success INT = 0;
	DECLARE @ErrorMessage NVARCHAR(MAX) = NULL;

	BEGIN TRY
		BEGIN TRANSACTION;
		
		INSERT INTO UserLogin (IdUser, LoginDate, Token, TokenExpiration, RefreshToken, RefreshTokenExpiration, Refreshed, RefreshedBy)
		VALUES (@IdUser, @LoginDate, @Token, @TokenExpiration, @RefreshToken, @RefreshTokenExpiration, @Refreshed, @RefreshedBy);

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
