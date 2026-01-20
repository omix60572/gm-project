IF OBJECT_ID(N'dbo.Movies', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Movies (
        Id              BIGINT          IDENTITY(1,1)   PRIMARY KEY,
        ImageUrl        NVARCHAR(MAX)   NULL,
        Title           NVARCHAR(200)   NOT NULL,
        [Description]   NVARCHAR(MAX)   NOT NULL,
        ReleaseYear     SMALLINT        NOT NULL,
        SourceUrl       NVARCHAR(MAX)   NULL
    );

    CREATE INDEX IX_Movies_Id ON dbo.Movies (Id);
END
