CREATE TABLE [dbo].[Productos]
(
    [idProducto] [int] IDENTITY(1,1) NOT NULL,
    [CodigoProducto] [nvarchar](30) NULL,
	[NombreProducto] [nvarchar](30) NULL,
    [MarcaProducto] [nvarchar](30) NOT NULL,
    [DescripcionProducto] [nvarchar](200) NULL default '',
    [ImagenProducto] [nvarchar](30) NULL,
	[PrecioProducto] [money] NULL default 0,
    [StockProducto] [int] NULL default 0,
    [CategoriaProducto] [nvarchar](30) NOT NULL,
	[Estado] [bit] NULL default 0,
    CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF , ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
) ON [PRIMARY]

GO