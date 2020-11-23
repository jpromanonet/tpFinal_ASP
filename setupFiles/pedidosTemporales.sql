USE [Sistemas]
GO
CREATE TABLE [dbo].[Pedidos_Temporal]
(
    [NItem] [int] IDENTITY(1,1) NOT NULL,
    [Num_Cli] [int] NULL,
    [Item] [varchar](100) NULL,
	[Cantidad] [int] NULL,
    CONSTRAINT [PK_Pedidos_Temporal] PRIMARY KEY CLUSTERED 
(
	[NItem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF , ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Pedidos_Temporal] ADD
CONSTRAINT [DF_Pedidos_Temporal_Num_Cli] DEFAULT ((0)) FOR [Num_Cli]
GO
ALTER TABLE [dbo].[Pedidos_Temporal] ADD
CONSTRAINT [DF_Pedidos_Temporal_Item] DEFAULT ('') FOR [Item]
GO
ALTER TABLE [dbo].[Pedidos_Temporal] ADD
CONSTRAINT [DF_Pedidos_Temporal_Cantidad] DEFAULT ((0))) FOR [Cantidad]
GO