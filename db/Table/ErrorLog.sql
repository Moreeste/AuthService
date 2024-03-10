
DROP TABLE IF EXISTS ErrorLog

CREATE TABLE ErrorLog
(
	TraceId VARCHAR(36) NOT NULL,
	TimeSpan DATETIME NOT NULL,
	Type VARCHAR(50) NOT NULL,
	Message NVARCHAR(MAX),
	StackTrace NVARCHAR(MAX),
	Query NVARCHAR(MAX),
	Parameters NVARCHAR(MAX),

	CONSTRAINT PK_ErrorLog_TraceId PRIMARY KEY (TraceId)
);

CREATE NONCLUSTERED INDEX IX_ErrorLog_TraceId ON ErrorLog (TraceId);
CREATE NONCLUSTERED INDEX IX_ErrorLog_Type ON ErrorLog (Type);
