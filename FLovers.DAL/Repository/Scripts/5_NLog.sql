use FLovers;
go

/****** Object:  Table [dbo].[NLog_Error]    Script Date: 2020/04/16 10:15:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NLog_Error](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[time_stamp] [datetime] NOT NULL,
	[host] [nvarchar](max) NOT NULL,
	[type] [nvarchar](50) NOT NULL,
	[source] [nvarchar](50) NOT NULL,
	[message] [nvarchar](max) NOT NULL,
	[level] [nvarchar](50) NOT NULL,
	[logger] [nvarchar](50) NOT NULL,
	[stacktrace] [nvarchar](max) NOT NULL,
	[allxml] [ntext] NOT NULL,
 CONSTRAINT [PK_NLogError] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[NLog_Error] ADD  CONSTRAINT [DF_NLogError_time_stamp]  DEFAULT (getdate()) FOR [time_stamp]
GO

ALTER TABLE [dbo].[NLog_Error] ADD  CONSTRAINT [DF_NLogError_host]  DEFAULT ('default') FOR [host]
GO

ALTER TABLE [dbo].[NLog_Error] ADD  CONSTRAINT [DF_NLogError_type]  DEFAULT ('default') FOR [type]
GO

ALTER TABLE [dbo].[NLog_Error] ADD  CONSTRAINT [DF_NLogError_source]  DEFAULT ('default') FOR [source]
GO

ALTER TABLE [dbo].[NLog_Error] ADD  CONSTRAINT [DF_NLogError_level]  DEFAULT ('none') FOR [level]
GO

ALTER TABLE [dbo].[NLog_Error] ADD  CONSTRAINT [DF_NLogError_logger]  DEFAULT ('none') FOR [logger]
GO

ALTER TABLE [dbo].[NLog_Error] ADD  CONSTRAINT [DF_NLogError_stacktrace]  DEFAULT ('default') FOR [stacktrace]
GO
