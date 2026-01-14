IF OBJECT_ID(N'dbo.Applications', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Applications (
        ApplicationName     NVARCHAR(80)   NOT NULL
    );

    ALTER TABLE dbo.Applications 
    ADD CONSTRAINT PK_Applications PRIMARY KEY (ApplicationName);

    CREATE INDEX IX_Applications_ApplicationName ON dbo.Applications (ApplicationName);
END
