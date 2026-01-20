IF OBJECT_ID(N'dbo.RevokedTokens', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.RevokedTokens (
        Id                  BIGINT          IDENTITY(1,1)   PRIMARY KEY,
        ApplicationName     NVARCHAR(80)    NOT NULL,
        Expire              DATETIME        NOT NULL,
        Token               NVARCHAR(MAX)   NOT NULL
    );

    CREATE INDEX IX_RevokedTokens_Expire ON dbo.RevokedTokens (Expire DESC);
END
