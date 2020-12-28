IF OBJECT_ID(N'[__MigrationsHistory]') IS NULL
BEGIN
CREATE TABLE [__MigrationsHistory] (
    [MigrationId] nvarchar(150) NOT NULL,
    CONSTRAINT [PK___MigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__MigrationsHistory] WHERE [MigrationId] = N'20201227_Initial')
BEGIN
    CREATE TABLE [Surveys] (
        [Id] uniqueidentifier NOT NULL,
        [Created] datetimeoffset NOT NULL,
        [Title] nvarchar(150) NOT NULL,
        [ProgressStatus] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_Surveys] PRIMARY KEY ([Id]),
        CONSTRAINT CHK_ProgressStatus CHECK ([ProgressStatus] IN ('InProgress', 'Completed'))
    )
END

BEGIN 
   CREATE TABLE [Pages] (
       [SurveyId] uniqueidentifier NOT NULL,
       [Title] nvarchar(150) NOT NULL,
       [Order] int NOT NULL,
       [PageType] nvarchar(100) NOT NULL,
       [Content] nvarchar(max) NULL,
       [Introduction] nvarchar(max) NULL,
       [Description] nvarchar(max) NULL,
       CONSTRAINT [PK_Pages] PRIMARY KEY ([SurveyId], [Title]),
       CONSTRAINT [FK_Pages_Surveys_SurveyId] FOREIGN KEY ([SurveyId]) REFERENCES [Surveys] ([Id]) ON DELETE CASCADE
   )
END
GO

IF NOT EXISTS(SELECT * FROM [__MigrationsHistory] WHERE [MigrationId] = N'20201227_Initial')
BEGIN
    INSERT INTO [__MigrationsHistory] (MigrationId) VALUES (N'20201227_Initial')
END;
GO

COMMIT;
GO



