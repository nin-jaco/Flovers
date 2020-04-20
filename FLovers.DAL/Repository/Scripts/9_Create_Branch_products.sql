USE [FLovers]
GO

/****** Object:  Table [dbo].[Branch_Product]    Script Date: 2020/04/21 01:30:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Branch_Product](
	[BranchId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Branch_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Branch_Product]  WITH CHECK ADD  CONSTRAINT [FK_Branch_Product_Branches] FOREIGN KEY([BranchId])
REFERENCES [dbo].[Branches] ([Id])
GO

ALTER TABLE [dbo].[Branch_Product] CHECK CONSTRAINT [FK_Branch_Product_Branches]
GO

ALTER TABLE [dbo].[Branch_Product]  WITH CHECK ADD  CONSTRAINT [FK_Branch_Product_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO

ALTER TABLE [dbo].[Branch_Product] CHECK CONSTRAINT [FK_Branch_Product_Products]
GO


