USE [Database]
GO

/****** Object: Table [dbo].[Login] Script Date: 18.10.2021 01:53:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Login] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [Username] VARCHAR (24) NOT NULL,
    [Password] NCHAR (48)   NOT NULL
);


SET IDENTITY_INSERT [dbo].[Login] ON
INSERT INTO [dbo].[Login] ([Id], [Username], [Password]) VALUES (1, N'admin', N'12456seven                                            ')
INSERT INTO [dbo].[Login] ([Id], [Username], [Password]) VALUES (2, N'user1', N'qwerty                                          ')
SET IDENTITY_INSERT [dbo].[Login] OFF
