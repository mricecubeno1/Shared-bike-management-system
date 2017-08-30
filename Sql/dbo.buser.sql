CREATE TABLE [dbo].[buser] (
    [buid] INT IDENTITY (1, 1) NOT NULL,
    [uid]  INT NOT NULL,
    [bid]  INT NOT NULL,
    [flee] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([buid] ASC),
    CONSTRAINT [FK_buser_ToTable] FOREIGN KEY ([bid]) REFERENCES [dbo].[bike] ([bid]),
    CONSTRAINT [FK_buser_ToTable_1] FOREIGN KEY ([uid]) REFERENCES [dbo].[users] ([uid])
);

