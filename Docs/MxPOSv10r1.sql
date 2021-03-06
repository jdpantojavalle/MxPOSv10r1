USE [MxPOSv10r1]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 03/24/2013 17:56:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Proveedores](
	[IDProveedor] [int] NOT NULL,
	[RegistroActivo] [bit] NOT NULL,
	[Dumb] [varchar](max) NULL,
	[RFC] [varchar](max) NOT NULL,
	[Nombre] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Proveedores] PRIMARY KEY CLUSTERED 
(
	[IDProveedor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 03/24/2013 17:56:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Productos](
	[IDProducto] [int] IDENTITY(1,1) NOT NULL,
	[RegistroActivo] [bit] NOT NULL,
	[Nombre] [varchar](max) NOT NULL,
	[Imagen] [binary](8000) NULL,
	[Notas] [varchar](max) NULL,
	[Descripcion] [varchar](max) NOT NULL,
	[Unidad] [varchar](max) NOT NULL,
	[Costo] [float] NOT NULL,
	[CostoAnterior] [float] NULL,
	[Precio] [float] NOT NULL,
	[PrecioAnterior] [float] NULL,
	[Entradas] [int] NOT NULL,
	[Salidas] [int] NOT NULL,
	[Saldo] [int] NOT NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[IDProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Logs]    Script Date: 03/24/2013 17:56:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Logs](
	[IDLog] [int] IDENTITY(1,1) NOT NULL,
	[RegistroActivo] [bit] NOT NULL,
	[Dumb] [varchar](max) NULL,
	[Fecha] [timestamp] NOT NULL,
	[Usuario] [varchar](max) NOT NULL,
	[Descripcion] [varchar](max) NOT NULL,
	[Accion] [varchar](max) NOT NULL,
	[Parametros] [varchar](max) NOT NULL,
	[Resultado] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[IDLog] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TiposDeComprobantes]    Script Date: 03/24/2013 17:56:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TiposDeComprobantes](
	[IDTipoDeComprobante] [int] IDENTITY(1,1) NOT NULL,
	[RegistroActivo] [bit] NOT NULL,
	[Dumb] [varchar](max) NULL,
	[CFDI32_Req_TipoDeComprobante] [varchar](max) NOT NULL,
 CONSTRAINT [PK_TiposDeComprobantes] PRIMARY KEY CLUSTERED 
(
	[IDTipoDeComprobante] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Receptores]    Script Date: 03/24/2013 17:56:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Receptores](
	[IDReceptor] [int] IDENTITY(1,1) NOT NULL,
	[RegistroActivo] [bit] NOT NULL,
	[Dumb] [varchar](max) NULL,
	[CFDI32_Req_RFC] [varchar](max) NOT NULL,
	[CFDI32_Opc_Nombre] [varchar](max) NULL,
 CONSTRAINT [PK_Receptores] PRIMARY KEY CLUSTERED 
(
	[IDReceptor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Configuraciones]    Script Date: 03/24/2013 17:56:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Configuraciones](
	[IDConfiguracion] [int] IDENTITY(1,1) NOT NULL,
	[RegistroActivo] [bit] NOT NULL,
	[Seleccionado] [bit] NOT NULL,
	[Dumb] [varchar](max) NULL,
	[IVA] [float] NOT NULL,
	[DescuentoMinimo] [float] NOT NULL,
	[DescuentoMaximo] [float] NOT NULL,
	[DescuentoPassword] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Configuraciones] PRIMARY KEY CLUSTERED 
(
	[IDConfiguracion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EstatusCompra]    Script Date: 03/24/2013 17:56:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EstatusCompra](
	[IDEstatusCompra] [int] NOT NULL,
	[RegistroActivo] [bit] NOT NULL,
	[Descripcion] [varchar](max) NOT NULL,
	[Leyenda] [varchar](max) NOT NULL,
 CONSTRAINT [PK_EstatusCompra] PRIMARY KEY CLUSTERED 
(
	[IDEstatusCompra] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Errores]    Script Date: 03/24/2013 17:56:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Errores](
	[IDError] [int] IDENTITY(1,1) NOT NULL,
	[RegistroActivo] [bit] NOT NULL,
	[Dumb] [varchar](max) NULL,
	[Usuario] [varchar](max) NOT NULL,
	[CodigoError] [int] NOT NULL,
	[MensajeError] [varchar](max) NOT NULL,
	[SolucionError] [varchar](max) NOT NULL,
	[Modulo] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Errores] PRIMARY KEY CLUSTERED 
(
	[IDError] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Emisores]    Script Date: 03/24/2013 17:56:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Emisores](
	[IDEmisor] [int] IDENTITY(1,1) NOT NULL,
	[RegistroActivo] [bit] NOT NULL,
	[Seleccionado] [bit] NOT NULL,
	[Dumb] [varchar](max) NULL,
	[CFDI32_Req_RFC] [varchar](max) NOT NULL,
	[CFDI32_Opc_Nombre] [varchar](max) NULL,
 CONSTRAINT [PK_Emisores] PRIMARY KEY CLUSTERED 
(
	[IDEmisor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DomiciliosFiscales]    Script Date: 03/24/2013 17:56:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DomiciliosFiscales](
	[IDEmisorDomicilioFiscal] [int] IDENTITY(1,1) NOT NULL,
	[IDEmisor] [int] NOT NULL,
	[RegistroActivo] [bit] NOT NULL,
	[Seleccionado] [bit] NOT NULL,
	[Dumb] [varchar](max) NULL,
	[CFDI32_Req_Calle] [varchar](max) NOT NULL,
	[CFDI32_Opc_NoExterior] [varchar](max) NULL,
	[CFDI32_Opc_NoInterior] [varchar](max) NULL,
	[CFDI32_Opc_Colonia] [varchar](max) NULL,
	[CFDI32_Opc_Localidad] [varchar](max) NULL,
	[CFDI32_Opc_Referencia] [varchar](max) NULL,
	[CFDI32_Req_Municipio] [varchar](max) NOT NULL,
	[CFDI32_Req_Estado] [varchar](max) NOT NULL,
	[CFDI32_Req_Pais] [varchar](max) NOT NULL,
	[CFDI32_Req_CodigoPostal] [varchar](max) NOT NULL,
 CONSTRAINT [PK_EmisoresDomiciliosFiscales] PRIMARY KEY CLUSTERED 
(
	[IDEmisorDomicilioFiscal] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Domicilios]    Script Date: 03/24/2013 17:56:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Domicilios](
	[IDReceptorDomicilio] [int] IDENTITY(1,1) NOT NULL,
	[IDReceptor] [int] NOT NULL,
	[RegistroActivo] [bit] NOT NULL,
	[Seleccionado] [bit] NOT NULL,
	[Dumb] [varchar](max) NULL,
	[CFDI32_Opc_Calle] [varchar](max) NULL,
	[CFDI32_Opc_NoExterior] [varchar](max) NULL,
	[CFDI32_Opc_NoInterior] [varchar](max) NULL,
	[CFDI32_Opc_Colonia] [varchar](max) NULL,
	[CFDI32_Opc_Localidad] [varchar](max) NULL,
	[CFDI32_Opc_Referencia] [varchar](max) NULL,
	[CFDI32_Opc_Municipio] [varchar](max) NULL,
	[CFDI32_Opc_Estado] [varchar](max) NULL,
	[CFDI32_Req_Pais] [varchar](max) NOT NULL,
	[CFDI32_Opc_CodigoPostal] [varchar](max) NULL,
 CONSTRAINT [PK_ReceptoresDomicilios] PRIMARY KEY CLUSTERED 
(
	[IDReceptorDomicilio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Comprobantes]    Script Date: 03/24/2013 17:56:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Comprobantes](
	[IDComprobante] [int] IDENTITY(1,1) NOT NULL,
	[IDEmisor] [int] NOT NULL,
	[IDReceptor] [int] NOT NULL,
	[IDTipoComprobante] [int] NOT NULL,
	[IDEstatusComprobante] [int] NOT NULL,
	[RegistroActivo] [bit] NOT NULL,
	[Dumb] [varchar](max) NULL,
	[CFDI32_Req_Version] [varchar](max) NOT NULL,
	[CFDI32_Opc_Serie] [varchar](max) NULL,
	[CFDI32_Opc_Folio] [varchar](max) NULL,
	[CFDI32_Req_Fecha] [datetime] NOT NULL,
	[CFDI32_Req_Sello] [varchar](max) NOT NULL,
	[CFDI32_Req_FormaDePago] [varchar](max) NOT NULL,
	[CFDI32_Req_NoCertificado] [varchar](max) NOT NULL,
	[CFDI32_Req_Certificado] [varchar](max) NOT NULL,
	[CFDI32_Opc_CondicionesDePago] [varchar](max) NULL,
	[CFDI32_Req_Subtotal] [float] NOT NULL,
	[CFDI32_Opc_Descuento] [float] NULL,
	[CFDI32_Opc_MotivoDescuento] [varchar](max) NULL,
	[CFDI32_Opc_TipoCambio] [varchar](max) NULL,
	[CFDI32_Req_Total] [float] NOT NULL,
	[CFDI32_Req_TipoDeComprobante] [varchar](max) NOT NULL,
	[CFDI32_Req_MetodoDePago] [varchar](max) NOT NULL,
	[CFDI32_Req_LugarExpedicion] [varchar](max) NOT NULL,
	[CFDI32_Opc_NumCtaPago] [varchar](max) NULL,
	[CFDI32_Opc_FolioFiscalOrig] [varchar](max) NULL,
	[CFDI32_Opc_SerieFolioFiscalOrig] [varchar](max) NULL,
	[CFDI32_Opc_FechaFolioFiscalOrig] [datetime] NULL,
	[CFDI32_Opc_MontoFolioFiscalOrig] [float] NULL,
	[IVA] [float] NOT NULL,
 CONSTRAINT [PK_Comprobantes] PRIMARY KEY CLUSTERED 
(
	[IDComprobante] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Compras]    Script Date: 03/24/2013 17:56:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Compras](
	[IDCompra] [int] NOT NULL,
	[IDProveedor] [int] NOT NULL,
	[IDEstatusCompra] [int] NOT NULL,
	[RegistroActivo] [bit] NOT NULL,
	[Dumb] [varchar](max) NULL,
	[Folio] [varchar](max) NOT NULL,
	[Serie] [varchar](max) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Subtotal] [float] NOT NULL,
	[Descuento] [float] NOT NULL,
	[MotivoDescuento] [varchar](max) NOT NULL,
	[IVA] [float] NOT NULL,
	[Total] [float] NOT NULL,
 CONSTRAINT [PK_Compras] PRIMARY KEY CLUSTERED 
(
	[IDCompra] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProveedoresDomicilios]    Script Date: 03/24/2013 17:56:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProveedoresDomicilios](
	[IDProveedorDomicilio] [int] NOT NULL,
	[IDProveedor] [int] NOT NULL,
	[RegistroActivo] [bit] NOT NULL,
	[Seleccionado] [bit] NOT NULL,
	[Dumb] [varchar](max) NULL,
	[Calle] [varchar](max) NULL,
	[NoExterior] [varchar](max) NULL,
	[NoInterior] [varchar](max) NULL,
	[Colonia] [varchar](max) NULL,
	[Localidad] [varchar](max) NULL,
	[Referencia] [varchar](max) NULL,
	[Municipio] [varchar](max) NULL,
	[Estado] [varchar](max) NULL,
	[Pais] [varchar](max) NULL,
	[CodigoPostal] [varchar](max) NULL,
 CONSTRAINT [PK_ProveedoresDomicilios] PRIMARY KEY CLUSTERED 
(
	[IDProveedorDomicilio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProveedoresContacto]    Script Date: 03/24/2013 17:56:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProveedoresContacto](
	[IDProveedorContacto] [int] NOT NULL,
	[IDProveedor] [int] NOT NULL,
	[Seleccionado] [bit] NOT NULL,
	[Dumb] [varchar](max) NULL,
	[Telefono1] [varchar](max) NULL,
	[Telefono2] [varchar](max) NULL,
	[Email1] [varchar](max) NULL,
	[Email2] [varchar](max) NULL,
 CONSTRAINT [PK_ProveedoresContacto] PRIMARY KEY CLUSTERED 
(
	[IDProveedorContacto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RegimenesFiscales]    Script Date: 03/24/2013 17:56:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RegimenesFiscales](
	[IDRegimenFiscal] [int] IDENTITY(1,1) NOT NULL,
	[IDEmisor] [int] NOT NULL,
	[RegistroActivo] [bit] NOT NULL,
	[Seleccionado] [bit] NOT NULL,
	[Dumb] [varchar](max) NULL,
	[CFDI32_Req_Regimen] [varchar](max) NOT NULL,
 CONSTRAINT [PK_RegimenesFiscales] PRIMARY KEY CLUSTERED 
(
	[IDRegimenFiscal] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ReceptoresContactos]    Script Date: 03/24/2013 17:56:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ReceptoresContactos](
	[IDReceptorContacto] [int] IDENTITY(1,1) NOT NULL,
	[IDReceptor] [int] NOT NULL,
	[Seleccionado] [bit] NOT NULL,
	[Dumb] [varchar](max) NULL,
	[Telefono1] [varchar](max) NULL,
	[Telefono2] [varchar](max) NULL,
	[Email1] [varchar](max) NULL,
	[Email2] [varchar](max) NULL,
 CONSTRAINT [PK_ReceptoresContactos] PRIMARY KEY CLUSTERED 
(
	[IDReceptorContacto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SerieFolio]    Script Date: 03/24/2013 17:56:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SerieFolio](
	[IDSerieFolio] [int] IDENTITY(1,1) NOT NULL,
	[IDDomicilioFiscal] [int] NOT NULL,
	[RegistroActivo] [bit] NOT NULL,
	[Seleccionado] [bit] NOT NULL,
	[Dumb] [varchar](max) NULL,
	[Serie] [varchar](max) NOT NULL,
	[FolioInicio] [int] NOT NULL,
	[FolioLimite] [int] NOT NULL,
	[FolioActual] [int] NOT NULL,
 CONSTRAINT [PK_SerieFolio] PRIMARY KEY CLUSTERED 
(
	[IDSerieFolio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ExpedidoEn]    Script Date: 03/24/2013 17:56:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ExpedidoEn](
	[IDExpedidoEn] [int] IDENTITY(1,1) NOT NULL,
	[IDComprobante] [int] NOT NULL,
	[RegistroActivo] [bit] NOT NULL,
	[Dumb] [varchar](max) NULL,
	[CFDI32_Opc_Calle] [varchar](max) NULL,
	[CFDI32_Opc_NoExterior] [varchar](max) NULL,
	[CFDI32_Opc_NoInterior] [varchar](max) NULL,
	[CFDI32_Opc_Colonia] [varchar](max) NULL,
	[CFDI32_Opc_Localidad] [varchar](max) NULL,
	[CFDI32_Opc_Referencia] [varchar](max) NULL,
	[CFDI32_Opc_Municipio] [varchar](max) NULL,
	[CFDI32_Opc_Estado] [varchar](max) NULL,
	[CFDI32_Req_Pais] [varchar](max) NOT NULL,
	[CFDI32_Opc_CodigoPostal] [varchar](max) NULL,
 CONSTRAINT [PK_ExpedidosEn] PRIMARY KEY CLUSTERED 
(
	[IDExpedidoEn] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EstatusComprobante]    Script Date: 03/24/2013 17:56:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EstatusComprobante](
	[IDEstatusComprobante] [int] IDENTITY(1,1) NOT NULL,
	[RegistroActivo] [bit] NOT NULL,
	[Descripcion] [varchar](max) NOT NULL,
	[Leyenda] [varchar](max) NOT NULL,
 CONSTRAINT [PK_EstatusComprobante] PRIMARY KEY CLUSTERED 
(
	[IDEstatusComprobante] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Conceptos]    Script Date: 03/24/2013 17:56:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Conceptos](
	[IDConcepto] [int] IDENTITY(1,1) NOT NULL,
	[IDComprobante] [int] NOT NULL,
	[IDProducto] [int] NOT NULL,
	[RegistroActivo] [bit] NOT NULL,
	[Dumb] [varchar](max) NULL,
	[CFDI32_Req_Cantidad] [float] NOT NULL,
	[CFDI32_Req_Unidad] [varchar](max) NOT NULL,
	[CFDI32_Opc_NoIdentificacion] [varchar](max) NULL,
	[CFDI32_Req_Descripcion] [varchar](max) NOT NULL,
	[CFDI32_Req_ValorUnitario] [float] NOT NULL,
	[CFDI32_Req_Importe] [float] NOT NULL,
	[Descuento] [float] NOT NULL,
	[DescuentoMotivo] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Conceptos] PRIMARY KEY CLUSTERED 
(
	[IDConcepto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ComprasDetalles]    Script Date: 03/24/2013 17:56:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ComprasDetalles](
	[IDCompraDetalle] [int] NOT NULL,
	[IDCompra] [int] NOT NULL,
	[IDProducto] [int] NOT NULL,
	[RegistroActivo] [bit] NOT NULL,
	[Dumb] [varchar](max) NULL,
	[Cantidad] [float] NOT NULL,
	[Unidad] [varchar](max) NOT NULL,
	[Descripcion] [varchar](max) NOT NULL,
	[Precio] [float] NOT NULL,
	[Descuento] [float] NOT NULL,
	[DescuentoMotivo] [varchar](max) NOT NULL,
	[Importe] [float] NOT NULL,
 CONSTRAINT [PK_ComprasDetalles] PRIMARY KEY CLUSTERED 
(
	[IDCompraDetalle] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF_Compras_RegistroActivo]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[Compras] ADD  CONSTRAINT [DF_Compras_RegistroActivo]  DEFAULT ((1)) FOR [RegistroActivo]
GO
/****** Object:  Default [DF_ComprasDetalles_RegistroActivo]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[ComprasDetalles] ADD  CONSTRAINT [DF_ComprasDetalles_RegistroActivo]  DEFAULT ((1)) FOR [RegistroActivo]
GO
/****** Object:  Default [DF__Comproban__Regis__145C0A3F]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[Comprobantes] ADD  CONSTRAINT [DF__Comproban__Regis__145C0A3F]  DEFAULT ((1)) FOR [RegistroActivo]
GO
/****** Object:  Default [DF__Conceptos__Regis__164452B1]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[Conceptos] ADD  CONSTRAINT [DF__Conceptos__Regis__164452B1]  DEFAULT ((1)) FOR [RegistroActivo]
GO
/****** Object:  Default [DF__Configura__Regis__173876EA]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[Configuraciones] ADD  CONSTRAINT [DF__Configura__Regis__173876EA]  DEFAULT ((1)) FOR [RegistroActivo]
GO
/****** Object:  Default [DF_Configuraciones_Seleccionada1]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[Configuraciones] ADD  CONSTRAINT [DF_Configuraciones_Seleccionada1]  DEFAULT ((0)) FOR [Seleccionado]
GO
/****** Object:  Default [DF__Domicilio__IDRec__182C9B23]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[Domicilios] ADD  CONSTRAINT [DF__Domicilio__IDRec__182C9B23]  DEFAULT ((-1)) FOR [IDReceptor]
GO
/****** Object:  Default [DF__Domicilio__Regis__1920BF5C]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[Domicilios] ADD  CONSTRAINT [DF__Domicilio__Regis__1920BF5C]  DEFAULT ((1)) FOR [RegistroActivo]
GO
/****** Object:  Default [DF_Domicilios_Seleccionado]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[Domicilios] ADD  CONSTRAINT [DF_Domicilios_Seleccionado]  DEFAULT ((0)) FOR [Seleccionado]
GO
/****** Object:  Default [DF__Domicilio__IDEmi__1A14E395]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[DomiciliosFiscales] ADD  CONSTRAINT [DF__Domicilio__IDEmi__1A14E395]  DEFAULT ((-1)) FOR [IDEmisor]
GO
/****** Object:  Default [DF__Domicilio__Regis__1B0907CE]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[DomiciliosFiscales] ADD  CONSTRAINT [DF__Domicilio__Regis__1B0907CE]  DEFAULT ((1)) FOR [RegistroActivo]
GO
/****** Object:  Default [DF_DomiciliosFiscales_Seleccionado]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[DomiciliosFiscales] ADD  CONSTRAINT [DF_DomiciliosFiscales_Seleccionado]  DEFAULT ((0)) FOR [Seleccionado]
GO
/****** Object:  Default [DF__Emisores__Regist__1BFD2C07]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[Emisores] ADD  CONSTRAINT [DF__Emisores__Regist__1BFD2C07]  DEFAULT ((1)) FOR [RegistroActivo]
GO
/****** Object:  Default [DF_Emisores_Seleccionado]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[Emisores] ADD  CONSTRAINT [DF_Emisores_Seleccionado]  DEFAULT ((0)) FOR [Seleccionado]
GO
/****** Object:  Default [DF__Errores__Registr__1CF15040]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[Errores] ADD  CONSTRAINT [DF__Errores__Registr__1CF15040]  DEFAULT ((1)) FOR [RegistroActivo]
GO
/****** Object:  Default [DF_EstatusCompra_RegistroActivo]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[EstatusCompra] ADD  CONSTRAINT [DF_EstatusCompra_RegistroActivo]  DEFAULT ((1)) FOR [RegistroActivo]
GO
/****** Object:  Default [DF_EstatusComprobante_RegistroActivo]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[EstatusComprobante] ADD  CONSTRAINT [DF_EstatusComprobante_RegistroActivo]  DEFAULT ((1)) FOR [RegistroActivo]
GO
/****** Object:  Default [DF__Expedidos__Regis__1ED998B2]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[ExpedidoEn] ADD  DEFAULT ((1)) FOR [RegistroActivo]
GO
/****** Object:  Default [DF__Logs__RegistroAc__1FCDBCEB]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[Logs] ADD  CONSTRAINT [DF__Logs__RegistroAc__1FCDBCEB]  DEFAULT ((1)) FOR [RegistroActivo]
GO
/****** Object:  Default [DF_Productos_RegistroActivo]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[Productos] ADD  CONSTRAINT [DF_Productos_RegistroActivo]  DEFAULT ((1)) FOR [RegistroActivo]
GO
/****** Object:  Default [DF_Proveedores_RegistroActivo]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[Proveedores] ADD  CONSTRAINT [DF_Proveedores_RegistroActivo]  DEFAULT ((1)) FOR [RegistroActivo]
GO
/****** Object:  Default [DF_ProveedoresContacto_Seleccionado]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[ProveedoresContacto] ADD  CONSTRAINT [DF_ProveedoresContacto_Seleccionado]  DEFAULT ((0)) FOR [Seleccionado]
GO
/****** Object:  Default [DF_ProveedoresDomicilios_IDReceptor]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[ProveedoresDomicilios] ADD  CONSTRAINT [DF_ProveedoresDomicilios_IDReceptor]  DEFAULT ((-1)) FOR [IDProveedor]
GO
/****** Object:  Default [DF_ProveedoresDomicilios_RegistroActivo]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[ProveedoresDomicilios] ADD  CONSTRAINT [DF_ProveedoresDomicilios_RegistroActivo]  DEFAULT ((1)) FOR [RegistroActivo]
GO
/****** Object:  Default [DF_ProveedoresDomicilios_Seleccionado]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[ProveedoresDomicilios] ADD  CONSTRAINT [DF_ProveedoresDomicilios_Seleccionado]  DEFAULT ((0)) FOR [Seleccionado]
GO
/****** Object:  Default [DF__Receptore__Regis__20C1E124]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[Receptores] ADD  DEFAULT ((1)) FOR [RegistroActivo]
GO
/****** Object:  Default [DF_ReceptoresContactos_Seleccionado]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[ReceptoresContactos] ADD  CONSTRAINT [DF_ReceptoresContactos_Seleccionado]  DEFAULT ((0)) FOR [Seleccionado]
GO
/****** Object:  Default [DF__Regimenes__IDEmi__21B6055D]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[RegimenesFiscales] ADD  CONSTRAINT [DF__Regimenes__IDEmi__21B6055D]  DEFAULT ((-1)) FOR [IDEmisor]
GO
/****** Object:  Default [DF__Regimenes__Regis__22AA2996]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[RegimenesFiscales] ADD  CONSTRAINT [DF__Regimenes__Regis__22AA2996]  DEFAULT ((1)) FOR [RegistroActivo]
GO
/****** Object:  Default [DF_RegimenesFiscales_Seleccionado]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[RegimenesFiscales] ADD  CONSTRAINT [DF_RegimenesFiscales_Seleccionado]  DEFAULT ((0)) FOR [Seleccionado]
GO
/****** Object:  Default [DF_SerieFolio_RegistroActivo]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[SerieFolio] ADD  CONSTRAINT [DF_SerieFolio_RegistroActivo]  DEFAULT ((1)) FOR [RegistroActivo]
GO
/****** Object:  Default [DF_SerieFolio_Seleccionado]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[SerieFolio] ADD  CONSTRAINT [DF_SerieFolio_Seleccionado]  DEFAULT ((0)) FOR [Seleccionado]
GO
/****** Object:  Default [DF_SerieFolio_FolioInicio]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[SerieFolio] ADD  CONSTRAINT [DF_SerieFolio_FolioInicio]  DEFAULT ((1)) FOR [FolioInicio]
GO
/****** Object:  Default [DF_SerieFolio_FolioLimite]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[SerieFolio] ADD  CONSTRAINT [DF_SerieFolio_FolioLimite]  DEFAULT ((1000)) FOR [FolioLimite]
GO
/****** Object:  Default [DF_SerieFolio_FolioActual]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[SerieFolio] ADD  CONSTRAINT [DF_SerieFolio_FolioActual]  DEFAULT ((1)) FOR [FolioActual]
GO
/****** Object:  Default [DF_TiposDeComprobantes_RegistroActivo]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[TiposDeComprobantes] ADD  CONSTRAINT [DF_TiposDeComprobantes_RegistroActivo]  DEFAULT ((1)) FOR [RegistroActivo]
GO
/****** Object:  ForeignKey [FK_Compras_EstatusCompra]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_Compras_EstatusCompra] FOREIGN KEY([IDEstatusCompra])
REFERENCES [dbo].[EstatusCompra] ([IDEstatusCompra])
GO
ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK_Compras_EstatusCompra]
GO
/****** Object:  ForeignKey [FK_Compras_Proveedores]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_Compras_Proveedores] FOREIGN KEY([IDProveedor])
REFERENCES [dbo].[Proveedores] ([IDProveedor])
GO
ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK_Compras_Proveedores]
GO
/****** Object:  ForeignKey [FK_ComprasDetalles_Compras]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[ComprasDetalles]  WITH CHECK ADD  CONSTRAINT [FK_ComprasDetalles_Compras] FOREIGN KEY([IDCompra])
REFERENCES [dbo].[Compras] ([IDCompra])
GO
ALTER TABLE [dbo].[ComprasDetalles] CHECK CONSTRAINT [FK_ComprasDetalles_Compras]
GO
/****** Object:  ForeignKey [FK_ComprasDetalles_Productos]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[ComprasDetalles]  WITH CHECK ADD  CONSTRAINT [FK_ComprasDetalles_Productos] FOREIGN KEY([IDProducto])
REFERENCES [dbo].[Productos] ([IDProducto])
GO
ALTER TABLE [dbo].[ComprasDetalles] CHECK CONSTRAINT [FK_ComprasDetalles_Productos]
GO
/****** Object:  ForeignKey [FK_Comprobantes_Emisores]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[Comprobantes]  WITH CHECK ADD  CONSTRAINT [FK_Comprobantes_Emisores] FOREIGN KEY([IDEmisor])
REFERENCES [dbo].[Emisores] ([IDEmisor])
GO
ALTER TABLE [dbo].[Comprobantes] CHECK CONSTRAINT [FK_Comprobantes_Emisores]
GO
/****** Object:  ForeignKey [FK_Comprobantes_Receptores]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[Comprobantes]  WITH CHECK ADD  CONSTRAINT [FK_Comprobantes_Receptores] FOREIGN KEY([IDReceptor])
REFERENCES [dbo].[Receptores] ([IDReceptor])
GO
ALTER TABLE [dbo].[Comprobantes] CHECK CONSTRAINT [FK_Comprobantes_Receptores]
GO
/****** Object:  ForeignKey [FK_Comprobantes_TiposDeComprobantes]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[Comprobantes]  WITH CHECK ADD  CONSTRAINT [FK_Comprobantes_TiposDeComprobantes] FOREIGN KEY([IDTipoComprobante])
REFERENCES [dbo].[TiposDeComprobantes] ([IDTipoDeComprobante])
GO
ALTER TABLE [dbo].[Comprobantes] CHECK CONSTRAINT [FK_Comprobantes_TiposDeComprobantes]
GO
/****** Object:  ForeignKey [FK_Conceptos_Comprobantes]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[Conceptos]  WITH CHECK ADD  CONSTRAINT [FK_Conceptos_Comprobantes] FOREIGN KEY([IDComprobante])
REFERENCES [dbo].[Comprobantes] ([IDComprobante])
GO
ALTER TABLE [dbo].[Conceptos] CHECK CONSTRAINT [FK_Conceptos_Comprobantes]
GO
/****** Object:  ForeignKey [FK_Conceptos_Productos]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[Conceptos]  WITH CHECK ADD  CONSTRAINT [FK_Conceptos_Productos] FOREIGN KEY([IDProducto])
REFERENCES [dbo].[Productos] ([IDProducto])
GO
ALTER TABLE [dbo].[Conceptos] CHECK CONSTRAINT [FK_Conceptos_Productos]
GO
/****** Object:  ForeignKey [FK_Domicilios_Receptores]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[Domicilios]  WITH CHECK ADD  CONSTRAINT [FK_Domicilios_Receptores] FOREIGN KEY([IDReceptor])
REFERENCES [dbo].[Receptores] ([IDReceptor])
GO
ALTER TABLE [dbo].[Domicilios] CHECK CONSTRAINT [FK_Domicilios_Receptores]
GO
/****** Object:  ForeignKey [FK_Emisores]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[DomiciliosFiscales]  WITH CHECK ADD  CONSTRAINT [FK_Emisores] FOREIGN KEY([IDEmisor])
REFERENCES [dbo].[Emisores] ([IDEmisor])
GO
ALTER TABLE [dbo].[DomiciliosFiscales] CHECK CONSTRAINT [FK_Emisores]
GO
/****** Object:  ForeignKey [FK_EstatusComprobante_Comprobantes]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[EstatusComprobante]  WITH CHECK ADD  CONSTRAINT [FK_EstatusComprobante_Comprobantes] FOREIGN KEY([IDEstatusComprobante])
REFERENCES [dbo].[Comprobantes] ([IDComprobante])
GO
ALTER TABLE [dbo].[EstatusComprobante] CHECK CONSTRAINT [FK_EstatusComprobante_Comprobantes]
GO
/****** Object:  ForeignKey [FK_ExpedidoEn_Comprobantes]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[ExpedidoEn]  WITH CHECK ADD  CONSTRAINT [FK_ExpedidoEn_Comprobantes] FOREIGN KEY([IDComprobante])
REFERENCES [dbo].[Comprobantes] ([IDComprobante])
GO
ALTER TABLE [dbo].[ExpedidoEn] CHECK CONSTRAINT [FK_ExpedidoEn_Comprobantes]
GO
/****** Object:  ForeignKey [FK_ProveedoresContacto_Proveedores]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[ProveedoresContacto]  WITH CHECK ADD  CONSTRAINT [FK_ProveedoresContacto_Proveedores] FOREIGN KEY([IDProveedor])
REFERENCES [dbo].[Proveedores] ([IDProveedor])
GO
ALTER TABLE [dbo].[ProveedoresContacto] CHECK CONSTRAINT [FK_ProveedoresContacto_Proveedores]
GO
/****** Object:  ForeignKey [FK_ProveedoresDomicilios_Proveedores]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[ProveedoresDomicilios]  WITH CHECK ADD  CONSTRAINT [FK_ProveedoresDomicilios_Proveedores] FOREIGN KEY([IDProveedor])
REFERENCES [dbo].[Proveedores] ([IDProveedor])
GO
ALTER TABLE [dbo].[ProveedoresDomicilios] CHECK CONSTRAINT [FK_ProveedoresDomicilios_Proveedores]
GO
/****** Object:  ForeignKey [FK_ReceptoresContactos_Receptores]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[ReceptoresContactos]  WITH CHECK ADD  CONSTRAINT [FK_ReceptoresContactos_Receptores] FOREIGN KEY([IDReceptor])
REFERENCES [dbo].[Receptores] ([IDReceptor])
GO
ALTER TABLE [dbo].[ReceptoresContactos] CHECK CONSTRAINT [FK_ReceptoresContactos_Receptores]
GO
/****** Object:  ForeignKey [FK_RegimenesFiscales_Emisores]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[RegimenesFiscales]  WITH CHECK ADD  CONSTRAINT [FK_RegimenesFiscales_Emisores] FOREIGN KEY([IDEmisor])
REFERENCES [dbo].[Emisores] ([IDEmisor])
GO
ALTER TABLE [dbo].[RegimenesFiscales] CHECK CONSTRAINT [FK_RegimenesFiscales_Emisores]
GO
/****** Object:  ForeignKey [FK_SerieFolio_DomiciliosFiscales]    Script Date: 03/24/2013 17:56:08 ******/
ALTER TABLE [dbo].[SerieFolio]  WITH CHECK ADD  CONSTRAINT [FK_SerieFolio_DomiciliosFiscales] FOREIGN KEY([IDDomicilioFiscal])
REFERENCES [dbo].[DomiciliosFiscales] ([IDEmisorDomicilioFiscal])
GO
ALTER TABLE [dbo].[SerieFolio] CHECK CONSTRAINT [FK_SerieFolio_DomiciliosFiscales]
GO
