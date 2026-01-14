IF OBJECT_ID(N'dbo.ApplicationTokens', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.ApplicationTokens (
        ApplicationName  NVARCHAR(128) NOT NULL,
        Expire           DATETIME      NOT NULL
    );

    ALTER TABLE dbo.ApplicationTokens 
    ADD CONSTRAINT PK_ApplicationTokens PRIMARY KEY (ApplicationName);

    CREATE INDEX IX_ApplicationTokens_ApplicationName ON dbo.ApplicationTokens (ApplicationName);
END
