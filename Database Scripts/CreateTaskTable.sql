USE [tasksDB]
GO

/****** Object:  Table [dbo].[Task]    Script Date: 9/8/2013 1:01:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Task](
	[id] [int] NOT NULL,
	[description] [varchar](255) NULL,
	[notes] [varchar](255) NULL,
	[estimateId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [estimate_fk] FOREIGN KEY([estimateId])
REFERENCES [dbo].[Estimate] ([id])
GO

ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [estimate_fk]
GO

