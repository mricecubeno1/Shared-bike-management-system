CREATE TABLE [dbo].[bike] (
    [bid]       INT         IDENTITY (1, 1) NOT NULL,
    [area]      NCHAR (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [available] NCHAR (10)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [damage]    NCHAR (10)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    PRIMARY KEY CLUSTERED ([bid] ASC)
);

