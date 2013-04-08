
/*
 * MxPOS 1.0
 * 
 * Elemento: EntidadReceptor
 * Tipo: Clase
 * Descripción: Representa todas las operaciones que se pueden realizar sobre los receptores en el sistema
 * Desarrollado por: Juan David Pantoja Valle
 *
 * Revisión: N/A
 * Revisado por: N/A
 * 
 * Notas: N/A
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MxPOS10.Sistema.Datos;

namespace MxPOS10.Sistema.Entidades
{
    public class EntidadReceptor
    {
        private MxPOSv10r1Entidades entidades;

        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        //      MÉTODOS PARA LA ENTIDAD RECEPTOR
        //----------------------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Constructor
        /// </summary>
        public EntidadReceptor()
        {
            entidades = new MxPOSv10r1Entidades();
        }

        /// <summary>
        /// Devuelve un objeto List con todos los receptores en el sistema
        /// </summary>
        /// <returns>Una lista con todos los receptores</returns>
        public List<Receptores> Receptores()
        {
            var query = from r in entidades.Receptores
                        select r;

            return query.ToList();
        }

        /// <summary>
        /// Devuelve un objeto List con todos los receptores activos en el sistema
        /// </summary>
        /// <returns>Una lista con todos los receptores activos</returns>
        public List<Receptores> ObtenerReceptoresActivos()
        {
            var query = from r in entidades.Receptores
                        where r.RegistroActivo == true
                        select r;

            return query.ToList();
        }

        /// <summary>
        /// Devuelve un objeto List con todos los receptores inactivos en el sistema
        /// </summary>
        /// <returns>Una lista con todos los receptores inactivos</returns>
        public List<Receptores> ObtenerReceptoresInactivos()
        {
            var query = from r in entidades.Receptores
                        where r.RegistroActivo == false
                        select r;

            return query.ToList();
        }

        /// <summary>
        /// Devuelve un objeto receptor identificado por ID
        /// </summary>
        /// <param name="idReceptor">El ID del receptor</param>
        /// <returns>El receptor con el ID especificado</returns>
        public Receptores BuscarReceptor(int idReceptor)
        {
            var query = from r in entidades.Receptores
                        where r.IDReceptor == idReceptor
                        select r;

            return query.SingleOrDefault();
        }

        /// <summary>
        /// Activará o desactivará un receptor identificado por ID, representa una alta / baja lógica
        /// </summary>
        /// <param name="idReceptor">El ID del receptor</param>
        /// <param name="activo">El estado del registro del receptor</param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        /// <summary>
        public bool EstablecerReceptorActivo(int idReceptor, bool activo, out string mensaje)
        {
            try
            {
                Receptores receptor = BuscarReceptor(idReceptor);

                receptor.RegistroActivo = activo;

                if (activo)
                {
                    mensaje = "Receptor activado correctamente";
                }
                else
                {
                    mensaje = "Receptor desactivado correctamente";
                }

                entidades.SaveChanges();
                return true;
            }
            catch (Exception r)
            {
                mensaje = r.Message;
                return false;
            }
        }

        /// <summary>
        /// Agregará un nuevo receptor al sistema
        /// </summary>
        /// <param name="req_rfc">El RFC del receptor, requerido</param>
        /// <param name="opc_nombre">El nombre del receptor, opcional</param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        /// <summary>
        public bool AgregarReceptor(string req_rfc, string opc_nombre, out string mensaje)
        {
            try
            {
                Receptores receptor = new Receptores();

                receptor.CFDI32_Req_RFC = req_rfc;
                receptor.CFDI32_Opc_Nombre = opc_nombre;

                receptor.RegistroActivo = true;
                entidades.Receptores.AddObject(receptor);
                entidades.SaveChanges();

                mensaje = "Receptor agregado correctamente";
                return true;
            }
            catch (Exception r)
            {
                mensaje = r.Message;
                return false;
            }
        }

        /// <summary>
        /// Actualizará un receptor identificado por ID
        /// </summary>
        /// <param name="idReceptor">El ID del receptor</param>
        /// <param name="req_rfc">El RFC del receptor, requerido</param>
        /// <param name="opc_nombre">El nombre del receptor, opcional</param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        /// <summary>
        public bool ActualizarReceptor(int idReceptor, string req_rfc, string opc_nombre, out string mensaje)
        {
            try
            {
                Receptores receptor = BuscarReceptor(idReceptor);

                receptor.CFDI32_Req_RFC = req_rfc;
                receptor.CFDI32_Opc_Nombre = opc_nombre;

                receptor.RegistroActivo = true;
                entidades.SaveChanges();

                mensaje = "Receptor actualizado correctamente";
                return true;
            }
            catch (Exception r)
            {
                mensaje = r.Message;
                return false;
            }

        }

        /// <summary>
        /// Eliminara un receptor identificado por ID
        /// </summary>
        /// <param name="idReceptor">El ID del receptor</param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        /// <summary>
        public bool EliminarReceptor(int idReceptor, out string mensaje)
        {
            try
            {
                Receptores receptor = BuscarReceptor(idReceptor);

                entidades.Receptores.DeleteObject(receptor);

                entidades.SaveChanges();

                mensaje = "Receptor eliminado correctamente";
                return true;
            }
            catch (Exception r)
            {
                mensaje = r.Message;
                return false;
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        //      MÉTODOS PARA LAS ENTIDADES DE NAVEGACIÓN
        //----------------------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Devuelve un domicilio específico del receptor identificado por ID
        /// </summary>
        /// <param name="idReceptor">El ID del receptor</param>
        /// <param name="idDomicilio">El ID del domicilio</param>
        /// <returns></returns>
        public Domicilios ObtenerDomicilio(int idReceptor, int idDomicilio)
        {
            var query = from d in entidades.Domicilios
                        where d.IDReceptor == idReceptor && d.IDDomicilio == idDomicilio
                        select d;

            return query.SingleOrDefault();
        }

        /// <summary>
        /// Devuelve una lista con los domicilios del receptor identificado por ID
        /// </summary>
        /// <param name="idReceptor">El ID del receptor</param>
        /// <returns></returns>
        public List<Domicilios> ObtenerDomicilios(int idReceptor)
        {
            Receptores receptor = BuscarReceptor(idReceptor);
            return receptor.Domicilios.ToList();
        }

        /// <summary>
        /// Devuelve una lista con los domicilios activos del receptor identificado por ID
        /// </summary>
        /// <param name="idReceptor">El ID del receptor</param>
        /// <returns></returns>
        public List<Domicilios> ObtenerDomiciliosActivos(int idReceptor)
        {
            var query = from d in entidades.Domicilios
                        where d.IDReceptor == idReceptor && d.RegistroActivo == true
                        select d;

            return query.ToList();
        }

        /// <summary>
        /// Devuelve una lista con los domicilios inactivos del receptor identificado por ID
        /// </summary>
        /// <param name="idReceptor">El ID del receptor</param>
        /// <returns></returns>
        public List<Domicilios> ObtenerDomiciliosInactivos(int idReceptor)
        {
            var query = from d in entidades.Domicilios
                        where d.IDReceptor == idReceptor && d.RegistroActivo == false
                        select d;

            return query.ToList();
        }

        /// <summary>
        /// Activará o desactivará un domicilio identificado por ID
        /// </summary>
        /// <param name="idReceptor">El ID del receptor con el domicilio</param>
        /// <param name="idDomicilio">El ID del domicilio</param>
        /// <param name="activo">El estado del registro del domicilio</param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        /// <summary>
        public bool EstablecerDomicilioActivo(int idReceptor, int idDomicilio, bool activo, out string mensaje)
        {
            try
            {
                var query = from d in entidades.Domicilios
                            where d.IDReceptor == idReceptor && d.IDDomicilio == idDomicilio
                            select d;

                Domicilios domicilio = query.SingleOrDefault();

                domicilio.RegistroActivo = activo;

                if (activo)
                {
                    mensaje = "Domicilio activado correctamente";
                }
                else
                {
                    mensaje = "Domicilio desactivado correctamente";
                }

                entidades.SaveChanges();
                return true;
            }
            catch (Exception r)
            {
                mensaje = r.Message;
                return false;
            }
        }

        /// <summary>
        /// Agregará un nuevo domicilio al receptor identificado por ID
        /// </summary>
        /// <param name="idReceptor">El ID del receptor</param>
        /// <param name="req_calle">La calle del domicilio, requerido</param>
        /// <param name="opc_noExterior">El número exterior del domicilio, opcional</param>
        /// <param name="opc_noInterior">El número interior del domicilio, opcional</param>
        /// <param name="opc_colonia">La colonia del domicilio, opcional</param>
        /// <param name="opc_localidad">La localidad del domicilio, opcional</param>
        /// <param name="opc_referencia">La referencia del domicilio, opcional</param>
        /// <param name="req_municipio">El municipio del domicilio, requerido</param>
        /// <param name="req_estado">El estado del domicilio, requerido</param>
        /// <param name="req_pais">El pais del domicilio, requerido</param>
        /// <param name="req_codigoPostal">El código postal del domicilio, requerido</param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        public bool AgregarDomicilio(int idReceptor, string opc_calle, string opc_noExterior, string opc_noInterior, string opc_colonia, string opc_localidad, string opc_referencia, string opc_municipio, string opc_estado, string req_pais, string opc_codigoPostal, out string mensaje)
        {
            try
            {
                Domicilios domicilioFiscal = new Domicilios();

                domicilioFiscal.IDReceptor = idReceptor;
                domicilioFiscal.CFDI32_Opc_Calle = opc_calle;
                domicilioFiscal.CFDI32_Opc_NoExterior = opc_noExterior;
                domicilioFiscal.CFDI32_Opc_NoInterior = opc_noInterior;
                domicilioFiscal.CFDI32_Opc_Colonia = opc_colonia;
                domicilioFiscal.CFDI32_Opc_Localidad = opc_localidad;
                domicilioFiscal.CFDI32_Opc_Referencia = opc_referencia;
                domicilioFiscal.CFDI32_Opc_Municipio = opc_municipio;
                domicilioFiscal.CFDI32_Opc_Estado = opc_estado;
                domicilioFiscal.CFDI32_Req_Pais = req_pais;
                domicilioFiscal.CFDI32_Opc_CodigoPostal = opc_codigoPostal;

                domicilioFiscal.RegistroActivo = true;
                entidades.Domicilios.AddObject(domicilioFiscal);
                entidades.SaveChanges();

                mensaje = "Domicilio agregado correctamente";
                return false;
            }
            catch (Exception r)
            {
                mensaje = r.Message;
                return false;
            }
        }

        /// <summary>
        /// Actualizará un domicilio identificado por ID
        /// </summary>
        /// <param name="idReceptor">El ID del receptor con el domicilio</param>
        /// <param name="idDomicilio">El ID del domicilio</param>
        /// <param name="req_calle">La calle del domicilio, requerido</param>
        /// <param name="opc_noExterior">El número exterior del domicilio, opcional</param>
        /// <param name="opc_noInterior">El número interior del domicilio, opcional</param>
        /// <param name="opc_colonia">La colonia del domicilio, opcional</param>
        /// <param name="opc_localidad">La localidad del domicilio, opcional</param>
        /// <param name="opc_referencia">La referencia del domicilio, opcional</param>
        /// <param name="req_municipio">El municipio del domicilio, requerido</param>
        /// <param name="req_estado">El estado del domicilio, requerido</param>
        /// <param name="req_pais">El pais del domicilio, requerido</param>
        /// <param name="req_codigoPostal">El código postal del domicilio, requerido</param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        public bool ActualizarDomicilio(int idReceptor, int idDomicilio, string opc_calle, string opc_noExterior, string opc_noInterior, string opc_colonia, string opc_localidad, string opc_referencia, string opc_municipio, string opc_estado, string req_pais, string opc_codigoPostal, out string mensaje)
        {
            try
            {
                var query = from d in entidades.Domicilios
                            where d.IDReceptor == idReceptor && d.IDDomicilio == idDomicilio
                            select d;

                Domicilios domicilioFiscal = query.SingleOrDefault();

                domicilioFiscal.CFDI32_Opc_Calle = opc_calle;
                domicilioFiscal.CFDI32_Opc_NoExterior = opc_noExterior;
                domicilioFiscal.CFDI32_Opc_NoInterior = opc_noInterior;
                domicilioFiscal.CFDI32_Opc_Colonia = opc_colonia;
                domicilioFiscal.CFDI32_Opc_Localidad = opc_localidad;
                domicilioFiscal.CFDI32_Opc_Referencia = opc_referencia;
                domicilioFiscal.CFDI32_Opc_Municipio = opc_municipio;
                domicilioFiscal.CFDI32_Opc_Estado = opc_estado;
                domicilioFiscal.CFDI32_Req_Pais = req_pais;
                domicilioFiscal.CFDI32_Opc_CodigoPostal = opc_codigoPostal;

                domicilioFiscal.RegistroActivo = true;
                entidades.SaveChanges();

                mensaje = "Domicilio actualizado correctamente";
                return false;
            }
            catch (Exception r)
            {
                mensaje = r.Message;
                return false;
            }
        }

        /// <summary>
        /// Eliminara un domicilio identificado por ID
        /// </summary>
        /// <param name="idReceptor">El ID del receptor con el domicilio</param>
        /// <param name="idDomicilio">El ID del domicilio</param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        /// <summary>
        public bool EliminarDomicilio(int idReceptor, int idDomicilio, out string mensaje)
        {
            try
            {
                var query = from d in entidades.Domicilios
                            where d.IDReceptor == idReceptor && d.IDDomicilio == idDomicilio
                            select d;

                Domicilios domicilioFiscal = query.SingleOrDefault();

                entidades.Domicilios.DeleteObject(domicilioFiscal);
                entidades.SaveChanges();

                mensaje = "Domicilio eliminado correctamente";
                return true;
            }
            catch (Exception r)
            {
                mensaje = r.Message;
                return false;
            }
        }
    }
}