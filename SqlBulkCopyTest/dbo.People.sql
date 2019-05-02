USE [SandBox]
GO

/****** Object: Table [dbo].[People] Script Date: 5/2/2019 12:42:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[People] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Gender]        VARCHAR (10)  NULL,
    [NameSet]       VARCHAR (50)  NULL,
    [StreetAddress] VARCHAR (255) NULL,
    [City]          VARCHAR (100) NULL,
    [EmailAddress]  VARCHAR (255) NULL,
    [ZipCode]       NCHAR (10)    NULL
);


