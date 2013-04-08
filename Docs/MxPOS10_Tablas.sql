
/*
	Este documento utiliza un estándar de codificación SQL Server (ligeramente modificado) desarrollado y distribuido por Pinal Dave.
	El estándar se encuentra disponible en la página web del mismo autor en http://www.SQLAuthority.com
	
	CodeViewMX
*/

/*
	Pendientes:
		1. Los campos de log llevan defaults
		2. Tablas para errores y logs
		3. Tabla de idioma es un Nice To Have
*/

CREATE DATABASE MxPOSv1r1
GO
USE MxPOSv1r1
GO

/*
	Elemento: Configuraciones
	Descripción: Representa perfiles de configuración aplicables al sistema en general
	Desarrollado por: Juan David Pantoja Valle
	
	Revisión: N/A
	Revisado por: N/A
	
	Notas: N/A
	Pendientes: N/A
*/
CREATE TABLE Configuraciones
(
	-- Control
	IDConfiguracion INT IDENTITY(1, 1) NOT NULL,
	RegistroActivo BIT NOT NULL DEFAULT 1,
	
	-- MxPOS10
	Dumb VARCHAR(MAX) NULL,
	
	-- Llaves e índices
	CONSTRAINT PK_Configuraciones PRIMARY KEY (IDConfiguracion)
)

/*
	Elemento: Errores
	Descripción: Representa una lista de errores conocidos en los módulos del sistema
	Desarrollado por: Juan David Pantoja Valle
	
	Revisión: N/A
	Revisado por: N/A
	
	Notas: N/A
	Pendientes: N/A
*/
CREATE TABLE Errores
(
	-- Control
	IDError INT IDENTITY(1, 1) NOT NULL,
	RegistroActivo BIT NOT NULL DEFAULT 1,
	
	-- MxPOS10
	Dumb VARCHAR(MAX) NULL,
	CodigoError INT NOT NULL,
	MensajeError VARCHAR(MAX) NOT NULL,
	SolucionError VARCHAR(MAX) NOT NULL,
	Modulo VARCHAR(MAX) NOT NULL,
		
	-- Llaves e índices
	CONSTRAINT PK_Errores PRIMARY KEY (IDError)
)

/*
	Elemento: Logs
	Descripción: Representa un registro de todas las acciones en el sistema y sus resultados
	Desarrollado por: Juan David Pantoja Valle
	
	Revisión: N/A
	Revisado por: N/A
	
	Notas: N/A
	Pendientes: N/A
*/
CREATE TABLE Logs
(
	-- Control
	IDLog INT IDENTITY(1, 1) NOT NULL,
	RegistroActivo BIT NOT NULL DEFAULT 1,
	
	-- MxPOS10
	Dumb VARCHAR(MAX) NULL,
	Fecha DATETIME NOT NULL,
	Usuario VARCHAR(MAX) NOT NULL,
	Descripcion VARCHAR(MAX) NOT NULL,
	Accion VARCHAR(MAX) NOT NULL,
	Parametros VARCHAR(MAX) NOT NULL,
	Resultado VARCHAR(MAX) NOT NULL,
		
	-- Llaves e índices
	CONSTRAINT PK_Logs PRIMARY KEY (IDLog)
)

/*
	Elemento: Emisores
	Descripción: Nodo requerido para expresar la información del contribuyente emisor del comprobante
	Desarrollado por: Juan David Pantoja Valle
	
	Revisión: N/A
	Revisado por: N/A
	
	Notas: N/A
	Pendientes: N/A
*/
CREATE TABLE Emisores
(
	-- Control
	IDEmisor INT IDENTITY(1, 1) NOT NULL,
	RegistroActivo BIT NOT NULL DEFAULT 1,
	
	-- MxPOS10
	Dumb VARCHAR(MAX) NULL,
	
	-- SAT Anexo 20
	CFDI32_Req_RFC VARCHAR(MAX) NOT NULL,
	CFDI32_Opc_Nombre VARCHAR(MAX) NULL,
	
	-- Llaves e índices
	CONSTRAINT PK_Emisores PRIMARY KEY (IDEmisor)
)

/*
	Elemento: DomiciliosFiscales
	Descripción: Nodo opcional para precisar la información de ubicación del domicilio fiscal del contribuyente emisor
	Desarrollado por: Juan David Pantoja Valle
	
	Revisión: N/A
	Revisado por: N/A
	
	Notas: N/A
	Pendientes: N/A
*/
CREATE TABLE DomiciliosFiscales
(
	-- Control
	IDEmisorDomicilioFiscal INT IDENTITY(1, 1) NOT NULL,
	IDEmisor INT NOT NULL DEFAULT -1,
	RegistroActivo BIT NOT NULL DEFAULT 1,
	
	-- MxPOS10
	Dumb VARCHAR(MAX) NULL,
		
	-- SAT Anexo 20
	CFDI32_Req_Calle VARCHAR(MAX) NOT NULL,
	CFDI32_Opc_NoExterior VARCHAR(MAX) NULL,
	CFDI32_Opc_NoInterior VARCHAR(MAX) NULL,
	CFDI32_Opc_Colonia VARCHAR(MAX) NULL,
	CFDI32_Opc_Localidad VARCHAR(MAX) NULL,
	CFDI32_Opc_Referencia VARCHAR(MAX) NULL,
	CFDI32_Req_Municipio VARCHAR(MAX) NOT NULL,
	CFDI32_Req_Estado VARCHAR(MAX) NOT NULL,
	CFDI32_Req_Pais VARCHAR(MAX) NOT NULL,
	CFDI32_Req_CodigoPostal VARCHAR(MAX) NOT NULL,
	
	-- Llaves e índices
	CONSTRAINT PK_EmisoresDomiciliosFiscales PRIMARY KEY (IDEmisorDomicilioFiscal),
	CONSTRAINT FK_Emisores FOREIGN KEY (IDEmisor) REFERENCES Emisores(IDEmisor)
)

/*
	Elemento: ExpedidosEn
	Descripción: Nodo opcional para precisar la información de ubicación del domicilio en donde es emitido el comprobante fiscal en caso de que sea distinto del domicilio fiscal del contribuyente emisor
	Desarrollado por: Juan David Pantoja Valle
	
	Revisión: N/A
	Revisado por: N/A
	
	Notas: N/A
	Pendientes: N/A
*/
CREATE TABLE ExpedidosEn
(
	-- Control
	IDExpedidoEn INT IDENTITY(1, 1) NOT NULL,
	IDEmisor INT NOT NULL DEFAULT -1,
	RegistroActivo BIT NOT NULL DEFAULT 1,
	
	-- MxPOS10
	Dumb VARCHAR(MAX) NULL,
	
	-- SAT Anexo 20
	CFDI32_Opc_Calle VARCHAR(MAX) NULL,
	CFDI32_Opc_NoExterior VARCHAR(MAX) NULL,
	CFDI32_Opc_NoInterior VARCHAR(MAX) NULL,
	CFDI32_Opc_Colonia VARCHAR(MAX) NULL,
	CFDI32_Opc_Localidad VARCHAR(MAX) NULL,
	CFDI32_Opc_Referencia VARCHAR(MAX) NULL,
	CFDI32_Opc_Municipio VARCHAR(MAX) NULL,
	CFDI32_Opc_Estado VARCHAR(MAX) NULL,
	CFDI32_Req_Pais VARCHAR(MAX) NOT NULL,
	CFDI32_Opc_CodigoPostal VARCHAR(MAX) NULL,
	
	-- Llaves e índices
	CONSTRAINT PK_ExpedidosEn PRIMARY KEY (IDExpedidoEn),
	CONSTRAINT FK_Emisores FOREIGN KEY (IDEmisor) REFERENCES Emisores(IDEmisor)
)

/*
	Elemento: RegimenesFiscales
	Descripción: Nodo requerido para incorporar los regímenes en los que tributa el contribuyente emisor, puede contener más de un régimen
	Desarrollado por: Juan David Pantoja Valle
	
	Revisión: N/A
	Revisado por: N/A
	
	Notas: N/A
	Pendientes: N/A
*/
CREATE TABLE RegimenesFiscales
(
	-- Control
	IDRegimenFiscal INT IDENTITY(1, 1) NOT NULL,
	IDEmisor INT NOT NULL DEFAULT -1,
	RegistroActivo BIT NOT NULL DEFAULT 1,
	
	-- MxPOS10
	Dumb VARCHAR(MAX) NULL,
	
	-- SAT Anexo 20
	CFDI32_Req_Regimen VARCHAR(MAX) NOT NULL,
	
	-- Llaves e índices
	CONSTRAINT PK_RegimenesFiscales PRIMARY KEY (IDRegimenFiscal),
	CONSTRAINT FK_Emisores FOREIGN KEY (IDEmisor) REFERENCES Emisores(IDEmisor)
)

/*
	Elemento: Receptores
	Descripción: Nodo requerido para precisar la información del contribuyente receptor del comprobante
	Desarrollado por: Juan David Pantoja Valle
	
	Revisión: N/A
	Revisado por: N/A
	
	Notas: N/A
	Pendientes: N/A
*/
CREATE TABLE Receptores
(
	-- Control
	IDReceptor INT IDENTITY(1, 1) NOT NULL,
	RegistroActivo BIT NOT NULL DEFAULT 1,
	
	-- MxPOS10
	Dumb VARCHAR(MAX) NULL,
	
	-- SAT Anexo 20
	CFDI32_Req_RFC VARCHAR(MAX) NOT NULL,
	CFDI32_Opc_Nombre VARCHAR(MAX) NULL,
	
	-- Llaves e índices
	CONSTRAINT PK_Receptores PRIMARY KEY (IDReceptor)
)

/*
	Elemento: Domicilios
	Descripción: Nodo opcional para la definición de la ubicación donde se da el domicilio del receptor del comprobante fiscal
	Desarrollado por: Juan David Pantoja Valle
	
	Revisión: N/A
	Revisado por: N/A
	
	Notas: N/A
	Pendientes: N/A
*/
CREATE TABLE Domicilios
(
	-- Control
	IDReceptorDomicilio INT IDENTITY(1, 1) NOT NULL,
	IDReceptor INT NOT NULL DEFAULT -1,
	RegistroActivo BIT NOT NULL DEFAULT 1,
	
	-- MxPOS10
	Dumb VARCHAR(MAX) NULL,
		
	-- SAT Anexo 20
	CFDI32_Opc_Calle VARCHAR(MAX) NULL,
	CFDI32_Opc_NoExterior VARCHAR(MAX) NULL,
	CFDI32_Opc_NoInterior VARCHAR(MAX) NULL,
	CFDI32_Opc_Colonia VARCHAR(MAX) NULL,
	CFDI32_Opc_Localidad VARCHAR(MAX) NULL,
	CFDI32_Opc_Referencia VARCHAR(MAX) NULL,
	CFDI32_Opc_Municipio VARCHAR(MAX) NULL,
	CFDI32_Opc_Estado VARCHAR(MAX) NULL,
	CFDI32_Req_Pais VARCHAR(MAX) NOT NULL,
	CFDI32_Opc_CodigoPostal VARCHAR(MAX) NULL,
	
	-- Llaves e índices
	CONSTRAINT PK_ReceptoresDomicilios PRIMARY KEY (IDReceptorDomicilio),
	CONSTRAINT FK_Receptores FOREIGN KEY (ReceptorID) REFERENCES Receptores(IDReceptor)
)

/*
	Elemento: Comprobantes
	Descripción: Estándar de Comprobante fiscal digital a través de Internet
	Desarrollado por: Juan David Pantoja Valle
	
	Revisión: N/A
	Revisado por: N/A
	
	Notas: N/A
	Pendientes: N/A
*/
CREATE TABLE Comprobantes
(
	-- Control
	IDComprobante INT IDENTITY(1, 1) NOT NULL,
	IDEmisor INT NOT NULL DEFAULT -1,
	IDReceptor INT NOT NULL DEFAULT -1,
	RegistroActivo BIT NOT NULL DEFAULT 1,
	
	-- MxPOS10
	Dumb VARCHAR(MAX) NULL,
	
	-- SAT Anexo 20
	CFDI32_Req_Version VARCHAR(MAX) NOT NULL,
	CFDI32_Opc_Serie VARCHAR(MAX) NULL,
	CFDI32_Opc_Folio VARCHAR(MAX) NULL,
	CFDI32_Req_Fecha DATETIME NOT NULL,
	CFDI32_Req_Sello VARCHAR(MAX) NOT NULL,
	CFDI32_Req_FormaDePago VARCHAR(MAX) NOT NULL,
	CFDI32_Req_NoCertificado VARCHAR(MAX) NOT NULL,
	CFDI32_Req_Certificado VARCHAR(MAX) NOT NULL,
	CFDI32_Opc_CondicionesDePago VARCHAR(MAX) NULL,
	CFDI32_Req_Subtotal FLOAT NOT NULL,
	CFDI32_Opc_Descuento FLOAT NULL,
	CFDI32_Opc_MotivoDescuento VARCHAR(MAX) NULL,
	CFDI32_Opc_TipoCambio VARCHAR(MAX) NULL,
	CFDI32_Req_Total FLOAT NOT NULL,
	CFDI32_Req_TipoDeComprobante VARCHAR(MAX) NOT NULL,
	CFDI32_Req_MetodoDePago VARCHAR(MAX) NOT NULL,
	CFDI32_Req_LugarExpedicion VARCHAR(MAX) NOT NULL,
	CFDI32_Opc_NumCtaPago VARCHAR(MAX) NULL,
	CFDI32_Opc_FolioFiscalOrig VARCHAR(MAX) NULL,
	CFDI32_Opc_SerieFolioFiscalOrig VARCHAR(MAX) NULL,
	CFDI32_Opc_FechaFolioFiscalOrig DATETIME NULL,
	CFDI32_Opc_MontoFolioFiscalOrig FLOAT NULL,
	
	-- Llaves e índices
	CONSTRAINT PK_Comprobantes PRIMARY KEY (IDComprobante),
	CONSTRAINT FK_Emisores FOREIGN KEY (IDEmisor) REFERENCES Emisores(IDEmisor),
	CONSTRAINT FK_Receptores FOREIGN KEY (IDReceptor) REFERENCES Receptores(IDReceptor)
)

/*
	Elemento: Conceptos
	Descripción: Nodo para introducir la información detallada de un bien o servicio amparado en el comprobante
	Desarrollado por: Juan David Pantoja Valle
	
	Revisión: N/A
	Revisado por: N/A
	
	Notas: N/A
	Pendientes: N/A
*/
CREATE TABLE Conceptos
(
	-- Control
	IDConcepto INT IDENTITY(1, 1) NOT NULL,
	IDComprobante INT NOT NULL DEFAULT -1,
	RegistroActivo BIT NOT NULL DEFAULT 1,
	
	-- MxPOS10
	Dumb VARCHAR(MAX) NULL,
	
	-- SAT Anexo 20
	CFDI32_Req_Cantidad FLOAT NOT NULL,
	CFDI32_Req_Unidad VARCHAR(MAX) NOT NULL,
	CFDI32_Opc_NoIdentificacion VARCHAR(MAX) NULL,
	CFDI32_Req_Descripcion VARCHAR(MAX) NOT NULL,
	CFDI32_Req_ValorUnitario FLOAT NOT NULL,
	CFDI32_Req_Importe FLOAT NOT NULL,
	
	-- Llaves e índices
	CONSTRAINT PK_Conceptos PRIMARY KEY (IDConcepto),
	CONSTRAINT FK_Comprobantes FOREIGN KEY (IDComprobante) REFERENCES Comprobantes(IDComprobante)
)
