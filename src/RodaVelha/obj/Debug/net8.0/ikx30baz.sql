IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Users] (
    [ID] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Photo] nvarchar(max) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([ID])
);
GO

CREATE TABLE [Events] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [StartDate] datetime2 NOT NULL,
    [EndDate] datetime2 NULL,
    [Location] nvarchar(max) NOT NULL,
    [Organizer] nvarchar(max) NULL,
    [Likes] int NOT NULL,
    [Photo] nvarchar(max) NOT NULL,
    [Phone] nvarchar(max) NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_Events] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Events_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([ID])
);
GO

CREATE TABLE [Likes] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [EventId] int NOT NULL,
    CONSTRAINT [PK_Likes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Likes_Events_EventId] FOREIGN KEY ([EventId]) REFERENCES [Events] ([Id]),
    CONSTRAINT [FK_Likes_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([ID]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Events_UserId] ON [Events] ([UserId]);
GO

CREATE INDEX [IX_Likes_EventId] ON [Likes] ([EventId]);
GO

CREATE INDEX [IX_Likes_UserId] ON [Likes] ([UserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240418011502_InitialCreate', N'8.0.4');
GO

COMMIT;
GO

