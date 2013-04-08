using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MxPOS10.Sistema.Datos;
using MxPOS10.Sistema.Vistas;

namespace MxPOS10.Sistema.Reportes.Receptores
{
    public partial class ReporteReceptor
    {
        private MxPOSv10r1Entidades entidades;

        /// <summary>
        /// Constructor
        /// </summary>
        public ReporteReceptor()
        {
            entidades = new MxPOSv10r1Entidades();
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        //      MÉTODOS PARA LA ENTIDAD RECEPTOR
        //----------------------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Devuelve un objeto List con una vista de un receptor identificado por ID en el sistema
        /// </summary>
        /// <returns>Una lista con una vista de un receptor identificado por ID</returns>
        public List<VistaReceptor> ObtenerReceptor(int idReceptor)
        {
            var query = from r in entidades.Receptores
                        where r.IDReceptor == idReceptor
                        select new VistaReceptor
                        {
                            IDReceptor = r.IDReceptor,
                            req_RFC = r.CFDI32_Req_RFC,
                            opc_Nombre = r.CFDI32_Opc_Nombre
                        };

            return query.ToList();
        }

        /// <summary>
        /// Devuelve un objeto List con vistas de todos los receptores en el sistema
        /// </summary>
        /// <returns>Una lista con todos los receptores</returns>
        public List<VistaReceptor> ObtenerReceptores()
        {
            var query = from r in entidades.Receptores
                        select new VistaReceptor
                        {
                            IDReceptor = r.IDReceptor,
                            req_RFC = r.CFDI32_Req_RFC,
                            opc_Nombre = r.CFDI32_Opc_Nombre
                        };

            return query.ToList();
        }

        /// <summary>
        /// Devuelve un objeto List con vistas de todos los receptores activos en el sistema
        /// </summary>
        /// <returns>Una lista con todos los receptores activos</returns>
        public List<VistaReceptor> ObtenerReceptoresActivos()
        {
            var query = from r in entidades.Receptores
                        where r.RegistroActivo == true
                        select new VistaReceptor
                        {
                            IDReceptor = r.IDReceptor,
                            req_RFC = r.CFDI32_Req_RFC,
                            opc_Nombre = r.CFDI32_Opc_Nombre
                        };

            return query.ToList();
        }

        /// <summary>
        /// Devuelve un objeto List con vistas de todos los receptores inactivos en el sistema
        /// </summary>
        /// <returns>Una lista con todos los receptores inactivos</returns>
        public List<VistaReceptor> ObtenerReceptoresInactivos()
        {
            var query = from r in entidades.Receptores
                        where r.RegistroActivo == false
                        select new VistaReceptor
                        {
                            IDReceptor = r.IDReceptor,
                            req_RFC = r.CFDI32_Req_RFC,
                            opc_Nombre = r.CFDI32_Opc_Nombre
                        };

            return query.ToList();
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        //      MÉTODOS PARA LAS ENTIDADES DE NAVEGACIÓN
        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        
        /// <summary>
        /// Devuelve un objeto List con vistas de todos los domicilios del receptor identificado por ID en el sistema
        /// </summary>
        /// <returns>Una lista con todos los domicilios del receptor</returns>
        public List<VistaDomicilio> ObtenerDomicilios(int idReceptor)
        {
            var query = from d in entidades.Domicilios
                        where d.IDReceptor == idReceptor
                        select new VistaDomicilio
                        {
                            IDDomicilio = d.IDDomicilio,
                            IDReceptor = d.IDReceptor,
                            opc_Calle = d.CFDI32_Opc_Calle,
                            opc_NoExterior = d.CFDI32_Opc_NoExterior,
                            opc_NoInterior = d.CFDI32_Opc_NoInterior,
                            opc_Colonia = d.CFDI32_Opc_Colonia,
                            opc_Localidad = d.CFDI32_Opc_Localidad,
                            opc_Referencia = d.CFDI32_Opc_Referencia,
                            opc_Municipio = d.CFDI32_Opc_Municipio,
                            opc_Estado = d.CFDI32_Opc_Estado,
                            req_Pais = d.CFDI32_Req_Pais,
                            opc_CodigoPostal = d.CFDI32_Opc_CodigoPostal
                        };

            return query.ToList();
        }

        /// <summary>
        /// Devuelve un objeto List con vistas de todos los domicilios activos del receptor identificado por ID en el sistema
        /// </summary>
        /// <returns>Una lista con todos los domicilios activos del receptor</returns>
        public List<VistaDomicilio> ObtenerDomiciliosActivos(int idReceptor)
        {
            var query = from d in entidades.Domicilios
                        where d.IDReceptor == idReceptor && d.RegistroActivo == true
                        select new VistaDomicilio
                        {
                            IDDomicilio = d.IDDomicilio,
                            IDReceptor = d.IDReceptor,
                            opc_Calle = d.CFDI32_Opc_Calle,
                            opc_NoExterior = d.CFDI32_Opc_NoExterior,
                            opc_NoInterior = d.CFDI32_Opc_NoInterior,
                            opc_Colonia = d.CFDI32_Opc_Colonia,
                            opc_Localidad = d.CFDI32_Opc_Localidad,
                            opc_Referencia = d.CFDI32_Opc_Referencia,
                            opc_Municipio = d.CFDI32_Opc_Municipio,
                            opc_Estado = d.CFDI32_Opc_Estado,
                            req_Pais = d.CFDI32_Req_Pais,
                            opc_CodigoPostal = d.CFDI32_Opc_CodigoPostal
                        };

            return query.ToList();
        }

        /// <summary>
        /// Devuelve un objeto List con vistas de todos los domicilios inactivos del receptor identificado por ID en el sistema
        /// </summary>
        /// <returns>Una lista con todos los domicilios inactivos del receptor</returns>
        public List<VistaDomicilio> ObtenerDomiciliosInactivos(int idReceptor)
        {
            var query = from d in entidades.Domicilios
                        where d.IDReceptor == idReceptor && d.RegistroActivo == false
                        select new VistaDomicilio
                        {
                            IDDomicilio = d.IDDomicilio,
                            IDReceptor = d.IDReceptor,
                            opc_Calle = d.CFDI32_Opc_Calle,
                            opc_NoExterior = d.CFDI32_Opc_NoExterior,
                            opc_NoInterior = d.CFDI32_Opc_NoInterior,
                            opc_Colonia = d.CFDI32_Opc_Colonia,
                            opc_Localidad = d.CFDI32_Opc_Localidad,
                            opc_Referencia = d.CFDI32_Opc_Referencia,
                            opc_Municipio = d.CFDI32_Opc_Municipio,
                            opc_Estado = d.CFDI32_Opc_Estado,
                            req_Pais = d.CFDI32_Req_Pais,
                            opc_CodigoPostal = d.CFDI32_Opc_CodigoPostal
                        };

            return query.ToList();
        }
    }
}