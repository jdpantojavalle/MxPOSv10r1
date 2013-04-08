using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MxPOS10.Sistema.Datos;
using MxPOS10.Sistema.Vistas;

namespace MxPOS10.Sistema.Reportes.Emisores
{
    public partial class ReporteEmisor
    {
        private MxPOSv10r1Entidades entidades;

        /// <summary>
        /// Constructor
        /// </summary>
        public ReporteEmisor()
        {
            entidades = new MxPOSv10r1Entidades();
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        //      MÉTODOS PARA LA ENTIDAD EMISOR
        //----------------------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Devuelve un objeto List con una vista de un emisor identificado por ID en el sistema
        /// </summary>
        /// <returns>Una lista con una vista de un emisor identificado por ID</returns>
        public List<VistaEmisor> ObtenerEmisor(int idEmisor)
        {
            var query = from e in entidades.Emisores
                        where e.IDEmisor == idEmisor
                        select new VistaEmisor
                        {
                            IDEmisor = e.IDEmisor,
                            req_RFC = e.CFDI32_Req_RFC,
                            opc_Nombre = e.CFDI32_Opc_Nombre
                        };

            return query.ToList();
        }

        /// <summary>
        /// Devuelve un objeto List con vistas de todos los emisores en el sistema
        /// </summary>
        /// <returns>Una lista con todos los emisores</returns>
        public List<VistaEmisor> ObtenerEmisores()
        {
            var query = from e in entidades.Emisores
                        select new VistaEmisor
                        {
                            IDEmisor = e.IDEmisor,
                            req_RFC = e.CFDI32_Req_RFC,
                            opc_Nombre = e.CFDI32_Opc_Nombre
                        };

            return query.ToList();
        }

        /// <summary>
        /// Devuelve un objeto List con vistas de todos los emisores activos en el sistema
        /// </summary>
        /// <returns>Una lista con todos los emisores activos</returns>
        public List<VistaEmisor> ObtenerEmisoresActivos()
        {
            var query = from e in entidades.Emisores
                        where e.RegistroActivo == true
                        select new VistaEmisor
                        {
                            IDEmisor = e.IDEmisor,
                            req_RFC = e.CFDI32_Req_RFC,
                            opc_Nombre = e.CFDI32_Opc_Nombre
                        };

            return query.ToList();
        }

        /// <summary>
        /// Devuelve un objeto List con vistas de todos los emisores inactivos en el sistema
        /// </summary>
        /// <returns>Una lista con todos los emisores inactivos</returns>
        public List<VistaEmisor> ObtenerEmisoresInactivos()
        {
            var query = from e in entidades.Emisores
                        where e.RegistroActivo == false
                        select new VistaEmisor
                        {
                            IDEmisor = e.IDEmisor,
                            req_RFC = e.CFDI32_Req_RFC,
                            opc_Nombre = e.CFDI32_Opc_Nombre
                        };

            return query.ToList();
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        //      MÉTODOS PARA LAS ENTIDADES DE NAVEGACIÓN
        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        
        /// <summary>
        /// Devuelve un objeto List con vistas de todos los domicilios fiscales del emisor identificado por ID en el sistema
        /// </summary>
        /// <returns>Una lista con todos los domicilios fiscales del emisor</returns>
        public List<VistaDomicilioFiscal> ObtenerDomiciliosFiscales(int idEmisor)
        {
            var query = from df in entidades.DomiciliosFiscales
                        where df.IDEmisor == idEmisor
                        select new VistaDomicilioFiscal
                        {
                            IDDomicilioFiscal = df.IDDomicilioFiscal,
                            IDEmisor = df.IDEmisor,
                            req_Calle = df.CFDI32_Req_Calle,
                            opc_NoExterior = df.CFDI32_Opc_NoExterior,
                            opc_NoInterior = df.CFDI32_Opc_NoInterior,
                            opc_Colonia = df.CFDI32_Opc_Colonia,
                            opc_Localidad = df.CFDI32_Opc_Localidad,
                            opc_Referencia = df.CFDI32_Opc_Referencia,
                            req_Municipio = df.CFDI32_Req_Municipio,
                            req_Estado = df.CFDI32_Req_Estado,
                            req_Pais = df.CFDI32_Req_Pais,
                            req_CodigoPostal = df.CFDI32_Req_CodigoPostal
                        };

            return query.ToList();
        }

        /// <summary>
        /// Devuelve un objeto List con vistas de todos los domicilios fiscales activos del emisor identificado por ID en el sistema
        /// </summary>
        /// <returns>Una lista con todos los domicilios fiscales activos del emisor</returns>
        public List<VistaDomicilioFiscal> ObtenerDomiciliosFiscalesActivos(int idEmisor)
        {
            var query = from df in entidades.DomiciliosFiscales
                        where df.IDEmisor == idEmisor && df.RegistroActivo == true
                        select new VistaDomicilioFiscal
                        {
                            IDDomicilioFiscal = df.IDDomicilioFiscal,
                            IDEmisor = df.IDEmisor,
                            req_Calle = df.CFDI32_Req_Calle,
                            opc_NoExterior = df.CFDI32_Opc_NoExterior,
                            opc_NoInterior = df.CFDI32_Opc_NoInterior,
                            opc_Colonia = df.CFDI32_Opc_Colonia,
                            opc_Localidad = df.CFDI32_Opc_Localidad,
                            opc_Referencia = df.CFDI32_Opc_Referencia,
                            req_Municipio = df.CFDI32_Req_Municipio,
                            req_Estado = df.CFDI32_Req_Estado,
                            req_Pais = df.CFDI32_Req_Pais,
                            req_CodigoPostal = df.CFDI32_Req_CodigoPostal
                        };

            return query.ToList();
        }

        /// <summary>
        /// Devuelve un objeto List con vistas de todos los domicilios fiscales inactivos del emisor identificado por ID en el sistema
        /// </summary>
        /// <returns>Una lista con todos los domicilios fiscales inactivos del emisor</returns>
        public List<VistaDomicilioFiscal> ObtenerDomiciliosFiscalesInactivos(int idEmisor)
        {
            var query = from df in entidades.DomiciliosFiscales
                        where df.IDEmisor == idEmisor && df.RegistroActivo == false
                        select new VistaDomicilioFiscal
                        {
                            IDDomicilioFiscal = df.IDDomicilioFiscal,
                            IDEmisor = df.IDEmisor,
                            req_Calle = df.CFDI32_Req_Calle,
                            opc_NoExterior = df.CFDI32_Opc_NoExterior,
                            opc_NoInterior = df.CFDI32_Opc_NoInterior,
                            opc_Colonia = df.CFDI32_Opc_Colonia,
                            opc_Localidad = df.CFDI32_Opc_Localidad,
                            opc_Referencia = df.CFDI32_Opc_Referencia,
                            req_Municipio = df.CFDI32_Req_Municipio,
                            req_Estado = df.CFDI32_Req_Estado,
                            req_Pais = df.CFDI32_Req_Pais,
                            req_CodigoPostal = df.CFDI32_Req_CodigoPostal
                        };

            return query.ToList();
        }
    }
}