IF OBJECT_ID(N'dbo.Users', N'U') IS NULL
BEGIN -- TODO: Fix table creation script
    CREATE TABLE dbo.Users (
        Id                  BIGINT          IDENTITY(1,1)   PRIMARY KEY,
        ApplicationName     NVARCHAR(80)    NOT NULL,
        Expire              DATETIME        NOT NULL,
        Token               NVARCHAR(MAX)   NOT NULL
    );
END
