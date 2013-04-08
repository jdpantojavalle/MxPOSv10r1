
/*
	Este documento utiliza un est�ndar de codificaci�n SQL Server (ligeramente modificado) desarrollado y distribuido por Pinal Dave.
	El est�ndar se encuentra disponible en la p�gina web del mismo autor en http://www.SQLAuthority.com
	
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
	Descripci�n: Representa perfiles de configuraci�n aplicables al sistema en general
	Desarrollado por: Juan David Pantoja Valle
	
	Revisi�n: N/A
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
	
	-- Llaves e �ndices
	CONSTRAINT PK_Configuraciones PRIMARY KEY (IDConfiguracion)
)

/*
	Elemento: Errores
	Descripci�n: Representa una lista de errores conocidos en los m�dulos del sistema
	Desarrollado por: Juan David Pantoja Valle
	
	Revisi�n: N/A
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
		
	-- Llaves e �ndices
	CONSTRAINT PK_Errores PRIMARY KEY (IDError)
)

/*
	Elemento: Logs
	Descripci�n: Representa un registro de todas las acciones en el sistema y sus resultados
	Desarrollado por: Juan David Pantoja Valle
	
	Revisi�n: N/A
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
		
	-- Llaves e �ndices
	CONSTRAINT PK_Logs PRIMARY KEY (IDLog)
)

/*
	Elemento: Emisores
	Descripci�n: Nodo requerido para expresar la informaci�n del contribuyente emisor del comprobante
	Desarrollado por: Juan David Pantoja Valle
	
	Revisi�n: N/A
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
	
	-- Llaves e �ndices
	CONSTRAINT PK_Emisores PRIMARY KEY (IDEmisor)
)

/*
	Elemento: DomiciliosFiscales
	Descripci�n: Nodo opcional para precisar la informaci�n de ubicaci�n del domicilio fiscal del contribuyente emisor
	Desarrollado por: Juan David Pantoja Valle
	
	Revisi�n: N/A
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
	
	-- Llaves e �ndices
	CONSTRAINT PK_EmisoresDomiciliosFiscales PRIMARY KEY (IDEmisorDomicilioFiscal),
	CONSTRAINT FK_Emisores FOREIGN KEY (IDEmisor) REFERENCES Emisores(IDEmisor)
)

/*
	Elemento: ExpedidosEn
	Descripci�n: Nodo opcional para precisar la informaci�n de ubicaci�n del domicilio en donde es emitido el comprobante fiscal en caso de que sea distinto del domicilio fiscal del contribuyente emisor
	Desarrollado por: Juan David Pantoja Valle
	
	Revisi�n: N/A
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
	
	-- Llaves e �ndices
	CONSTRAINT PK_ExpedidosEn PRIMARY KEY (IDExpedidoEn),
	CONSTRAINT FK_Emisores FOREIGN KEY (IDEmisor) REFERENCES Emisores(IDEmisor)
)

/*
	Elemento: RegimenesFiscales
	Descripci�n: Nodo requerido para incorporar los reg�menes en los que tributa el contribuyente emisor, puede contener m�s de un r�gimen
	Desarrollado por: Juan David Pantoja Valle
	
	Revisi�n: N/A
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
	
	-- Llaves e �ndices
	CONSTRAINT PK_RegimenesFiscales PRIMARY KEY (IDRegimenFiscal),
	CONSTRAINT FK_Emisores FOREIGN KEY (IDEmisor) REFERENCES Emisores(IDEmisor)
)

/*
	Elemento: Receptores
	Descripci�n: Nodo requerido para precisar la informaci�n del contribuyente receptor del comprobante
	Desarrollado por: Juan David Pantoja Valle
	
	Revisi�n: N/A
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
	
	-- Llaves e �ndices
	CONSTRAINT PK_Receptores PRIMARY KEY (IDReceptor)
)

/*
	Elemento: Domicilios
	Descripci�n: Nodo opcional para la definici�n de la ubicaci�n donde se da el domicilio del receptor del comprobante fiscal
	Desarrollado por: Juan David Pantoja Valle
	
	Revisi�n: N/A
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
	
	-- Llaves e �ndices
	CONSTRAINT PK_ReceptoresDomicilios PRIMARY KEY (IDReceptorDomicilio),
	CONSTRAINT FK_Receptores FOREIGN KEY (ReceptorID) REFERENCES Receptores(IDReceptor)
)

/*
	Elemento: Comprobantes
	Descripci�n: Est�ndar de Comprobante fiscal digital a trav�s de Internet
	Desarrollado por: Juan David Pantoja Valle
	
	Revisi�n: N/A
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
	
	-- Llaves e �ndices
	CONSTRAINT PK_Comprobantes PRIMARY KEY (IDComprobante),
	CONSTRAINT FK_Emisores FOREIGN KEY (IDEmisor) REFERENCES Emisores(IDEmisor),
	CONSTRAINT FK_Receptores FOREIGN KEY (IDReceptor) REFERENCES Receptores(IDReceptor)
)

/*
	Elemento: Conceptos
	Descripci�n: Nodo para introducir la informaci�n detallada de un bien o servicio amparado en el comprobante
	Desarrollado por: Juan David Pantoja Valle
	
	Revisi�n: N/A
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
	
	-- Llaves e �ndices
	CONSTRAINT PK_Conceptos PRIMARY KEY (IDConcepto),
	CONSTRAINT FK_Comprobantes FOREIGN KEY (IDComprobante) REFERENCES Comprobantes(IDComprobante)
)
