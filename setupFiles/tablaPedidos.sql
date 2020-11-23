USE [Sistemas]
GO
CREATE TABLE [dbo].[Pedidos]
(
    [NPedido] [int] IDENTITY(1,1) NOT NULL,
    [Num_Cli] [int] NULL,
    [Fecha] [datetime] NULL,
	[Estado] [nchar](30) NULL,
    CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED 
(
	[NPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF , ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Pedidos] ADD
CONSTRAINT [DF_Pedidos_Num_Cli] DEFAULT ((0)) FOR [Num_Cli]
GO
ALTER TABLE [dbo].[Pedidos] ADD
CONSTRAINT [DF_Pedidos_Fecha] DEFAULT (getdate()) FOR [Fecha]
GO
ALTER TABLE [dbo].[Pedidos] ADD
CONSTRAINT [DF_Pedidos_Estado] DEFAULT ('Solicitado') FOR [Estado]
GO