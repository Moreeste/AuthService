
DROP TABLE IF EXISTS ApiLog

CREATE TABLE ApiLog
(
	TraceId VARCHAR(36) NOT NULL,
	TimeSpan DATETIME NOT NULL,
	TimeElapsed DECIMAL(32,16) NOT NULL,
	ClientIP VARCHAR(15) NOT NULL,
	Path VARCHAR(80) NOT NULL,
	StatusCode INT NOT NULL,
	Request NVARCHAR(MAX),
	Response NVARCHAR(MAX),
	Token NVARCHAR(MAX),

	CONSTRAINT PK_ApiLog_TraceId PRIMARY KEY (TraceId)
);

CREATE NONCLUSTERED INDEX IX_ApiLog_TraceId ON ApiLog (TraceId);
