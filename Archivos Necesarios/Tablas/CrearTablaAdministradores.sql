CREATE TABLE [dbo].[Administradores]
(
    [idAdmin] [int] IDENTITY(1,1) NOT NULL,
    [Nombre] [varchar](30) NULL DEFAULT (''),
    [Apellido] [varchar](30) NULL DEFAULT (''),
    [tDoc] [char](3) NULL DEFAULT ('DNI'),
    [Documento] [varchar](8) NULL DEFAULT ((0)),
    [Usuario] [nvarchar](10) NOT NULL,
    [Clave] [nvarchar](10) NOT NULL,
    [Activo] [bit] NULL DEFAULT ((1)),
    [EMail] [varchar](70) NULL DEFAULT (''),
    [idProv] [tinyint]NULL DEFAULT ((1)),
    [Localidad] [varchar](25) NULL DEFAULT (''),
    [Domicilio] [varchar](100) NULL DEFAULT (''),
    [Telefono] [varchar](25) NULL DEFAULT (''),
    [FAlta][datetime] NULL DEFAULT (getdate()),
    [fNacimiento] [date] NULL DEFAULT (getdate()),
    CONSTRAINT [PK_Administradores] PRIMARY KEY CLUSTERED 
(
	[idAdmin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF , ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
) ON [PRIMARY]

GO