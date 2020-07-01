CREATE TABLE [dbo].[ClothingRule](
	[Id] [uniqueidentifier] NOT NULL,
	[IsRaining] [bit] NULL,
	[FromTemperature] [int] NOT NULL,
	[ToTemperature] [int] NOT NULL,
	[Clothes] [nvarchar](max) NOT NULL,
	[UserId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_ClothingRule] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[ClothingRule]  WITH CHECK ADD  CONSTRAINT [FK_ClothingRule_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[ClothingRule] CHECK CONSTRAINT [FK_ClothingRule_User]
GO