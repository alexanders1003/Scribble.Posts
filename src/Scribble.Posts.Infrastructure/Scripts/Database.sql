IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'Scribble.Posts')
  BEGIN

    CREATE DATABASE [Scribble.Posts]

        USE [Scribble.Posts]

    CREATE TABLE [dbo].[Posts] (
        [Id] [UNIQUEIDENTIFIER] NOT NULL PRIMARY KEY DEFAULT NEWID(),
        [AuthorId] [UNIQUEIDENTIFIER] NOT NULL,
        [Title] [NVARCHAR](500) NOT NULL,
        [Content] [NVARCHAR](MAX) NOT NULL,
        [CreatedAt] [DATETIME] NOT NULL,
        [UpdateAt] [DATETIME] NULL,
        [PostedAt] [DATETIME] NULL,
        [IsPosted] [BIT] NOT NULL
    )

    CREATE TABLE [dbo].[PostsTags] (
        [PostId] [UNIQUEIDENTIFIER] NOT NULL,
        [TagId] [UNIQUEIDENTIFIER] NOT NULL
        CONSTRAINT [FK_PostId] FOREIGN KEY (PostId)
            REFERENCES [dbo].[Posts] (Id)
    )

    CREATE TABLE [dbo].[PostsComments] (
        [PostId] [UNIQUEIDENTIFIER] NOT NULL,
        [CommentId] [UNIQUEIDENTIFIER] NOT NULL
        CONSTRAINT [FK_PostId] FOREIGN KEY (PostId)
            REFERENCES [dbo].[Posts] (Id)
            ON DELETE CASCADE
    );

  END