SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1),
	[Login] [nvarchar](256) NOT NULL,
	[PasswordHash] [nvarchar](512) NULL,
	[PasswordSalt] [nvarchar](512) NULL,
	[CreateDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL DEFAULT 0,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
))