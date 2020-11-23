USE [Sistemas]
GO
CREATE TABLE [dbo].[Pedidos_Detalle]
(
    [NItem] [int] IDENTITY(1,1) NOT NULL,
    [NPedido] [int] NULL,
    [Item] [varchar](100) NULL,
	[Cantidad] [int] NULL,
    CONSTRAINT [PK_Pedidos_Detalle] PRIMARY KEY CLUSTERED 
(
	[NItem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF , ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Pedidos_Detalle] ADD
CONSTRAINT [DF_Pedidos_Detalle_NPedido] DEFAULT ((0)) FOR [NPedido]
GO
ALTER TABLE [dbo].[Pedidos_Detalle] ADD
CONSTRAINT [DF_Pedidos_Detalle_Item] DEFAULT ('') FOR [Item]
GO
ALTER TABLE [dbo].[Pedidos_Detalle] ADD
CONSTRAINT [DF_Pedidos_Detalle_Cantidad] DEFAULT ((0)) FOR [Cantidad]
GO