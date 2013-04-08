
/*
 * MxPOS 1.0
 * 
 * Elemento: EntidadEmisor
 * Tipo: Clase
 * Descripción: Representa todas las operaciones que se pueden realizar sobre los emisores en el sistema
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
    public class EntidadEmisor
    {
        private MxPOSv10r1Entidades entidades;

        /// <summary>
        /// Constructor
        /// </summary>
        public EntidadEmisor()
        {
            entidades = new MxPOSv10r1Entidades();
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        //      MÉTODOS PARA LA ENTIDAD EMISOR
        //----------------------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Devuelve un objeto List con todos los emisores en el sistema
        /// </summary>
        /// <returns>Una lista con todos los emisores</returns>
        public List<Emisores> Emisores()
        {
            var query = from e in entidades.Emisores
                        select e;

            return query.ToList();
        }

        /// <summary>
        /// Devuelve un objeto List con todos los emisores activos en el sistema
        /// </summary>
        /// <returns>Una lista con todos los emisores activos</returns>
        public List<Emisores> ObtenerEmisoresActivos()
        {
            var query = from e in entidades.Emisores
                        where e.RegistroActivo == true
                        select e;

            return query.ToList();
        }

        /// <summary>
        /// Devuelve un objeto List con todos los emisores inactivos en el sistema
        /// </summary>
        /// <returns>Una lista con todos los emisores inactivos</returns>
        public List<Emisores> ObtenerEmisoresInactivos()
        {
            var query = from e in entidades.Emisores
                        where e.RegistroActivo == false
                        select e;

            return query.ToList();
        }

        /// <summary>
        /// Devuelve un objeto emisor identificado por ID
        /// </summary>
        /// <param name="idEmisor">El ID del emisor</param>
        /// <returns>El emisor con el ID especificado</returns>
        public Emisores BuscarEmisor(int idEmisor)
        {
            var query = from e in entidades.Emisores
                        where e.IDEmisor == idEmisor
                        select e;

            return query.SingleOrDefault();
        }

        /// <summary>
        /// Activará o desactivará un emisor identificado por ID, representa una alta / baja lógica
        /// </summary>
        /// <param name="idEmisor">El ID del emisor</param>
        /// <param name="activo">El estado del registro del emisor</param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        /// <summary>
        public bool EstablecerEmisorActivo(int idEmisor, bool activo, out string mensaje)
        {
            try
            {
                Emisores emisor = BuscarEmisor(idEmisor);

                emisor.RegistroActivo = activo;

                if (activo)
                {
                    mensaje = "Emisor activado correctamente";
                }
                else
                {
                    mensaje = "Emisor desactivado correctamente";
                }

                entidades.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                mensaje = e.Message;
                return false;
            }
        }

        /// <summary>
        /// Agregará un nuevo emisor al sistema
        /// </summary>
        /// <param name="req_rfc">El RFC del emisor, requerido</param>
        /// <param name="opc_nombre">El nombre del emisor, opcional</param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        /// <summary>
        public bool AgregarEmisor(string req_rfc, string opc_nombre, out string mensaje)
        {
            try
            {
                Emisores emisor = new Emisores();

                emisor.CFDI32_Req_RFC = req_rfc;
                emisor.CFDI32_Opc_Nombre = opc_nombre;

                emisor.RegistroActivo = true;
                entidades.Emisores.AddObject(emisor);
                entidades.SaveChanges();

                mensaje = "Emisor agregado correctamente";
                return true;
            }
            catch (Exception e)
            {
                mensaje = e.Message;
                return false;
            }
        }

        /// <summary>
        /// Actualizará un emisor identificado por ID
        /// </summary>
        /// <param name="idEmisor">El ID del emisor</param>
        /// <param name="req_rfc">El RFC del emisor, requerido</param>
        /// <param name="opc_nombre">El nombre del emisor, opcional</param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        /// <summary>
        public bool ActualizarEmisor(int idEmisor, string req_rfc, string opc_nombre, out string mensaje)
        {
            try
            {
                Emisores emisor = BuscarEmisor(idEmisor);
                
                emisor.CFDI32_Req_RFC = req_rfc;
                emisor.CFDI32_Opc_Nombre = opc_nombre;

                emisor.RegistroActivo = true;
                entidades.SaveChanges();
                
                mensaje = "Emisor actualizado correctamente";
                return true;
            }
            catch(Exception e)
            {
                mensaje = e.Message;
                return false;
            }
            
        }

        /// <summary>
        /// Eliminara un emisor identificado por ID
        /// </summary>
        /// <param name="idEmisor">El ID del emisor</param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        /// <summary>
        public bool EliminarEmisor(int idEmisor, out string mensaje)
        {
            try
            {
                Emisores emisor = BuscarEmisor(idEmisor);

                entidades.Emisores.DeleteObject(emisor);

                entidades.SaveChanges();

                mensaje = "Emisor eliminado correctamente";
                return true;
            }
            catch (Exception e)
            {
                mensaje = e.Message;
                return false;
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        //      MÉTODOS PARA LAS ENTIDADES DE NAVEGACIÓN
        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        
        /// <summary>
        /// Devuelve un domicilio fiscal específico del emisor identificado por ID
        /// </summary>
        /// <param name="idEmisor">El ID del emisor</param>
        /// <param name="idDomicilioFiscal">El ID del domicilio fiscal</param>
        /// <returns></returns>
        public DomiciliosFiscales ObtenerDomicilioFiscal(int idEmisor, int idDomicilioFiscal)
        {
            var query = from df in entidades.DomiciliosFiscales
                        where df.IDEmisor == idEmisor && df.IDDomicilioFiscal == idDomicilioFiscal
                        select df;

            return query.SingleOrDefault();
        }

        /// <summary>
        /// Devuelve una lista con los domicilios fiscales del emisor identificado por ID
        /// </summary>
        /// <param name="idEmisor">El ID del emisor</param>
        /// <returns></returns>
        public List<DomiciliosFiscales> ObtenerDomiciliosFiscales(int idEmisor)
        {
            Emisores emisor = BuscarEmisor(idEmisor);
            return emisor.DomiciliosFiscales.ToList();
        }

        /// <summary>
        /// Devuelve una lista con los domicilios fiscales activos del emisor identificado por ID
        /// </summary>
        /// <param name="idEmisor">El ID del emisor</param>
        /// <returns></returns>
        public List<DomiciliosFiscales> ObtenerDomiciliosFiscalesActivos(int idEmisor)
        {
            var query = from dfa in entidades.DomiciliosFiscales
                        where dfa.IDEmisor == idEmisor && dfa.RegistroActivo == true
                        select dfa;

            return query.ToList();
        }

        /// <summary>
        /// Devuelve una lista con los domicilios fiscales inactivos del emisor identificado por ID
        /// </summary>
        /// <param name="idEmisor">El ID del emisor</param>
        /// <returns></returns>
        public List<DomiciliosFiscales> ObtenerDomiciliosFiscalesInactivos(int idEmisor)
        {
            var query = from dfa in entidades.DomiciliosFiscales
                        where dfa.IDEmisor == idEmisor && dfa.RegistroActivo == false
                        select dfa;

            return query.ToList();
        }

        /// <summary>
        /// Activará o desactivará un domicilio fiscal identificado por ID
        /// </summary>
        /// <param name="idEmisor">El ID del emisor con el domicilio fiscal</param>
        /// <param name="idDomicilioFiscal">El ID del domicilio fiscal</param>
        /// <param name="activo">El estado del registro del domicilio fiscal</param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        /// <summary>
        public bool EstablecerDomicilioFiscalActivo(int idEmisor, int idDomicilioFiscal, bool activo, out string mensaje)
        {
            try
            {
                var query = from df in entidades.DomiciliosFiscales
                            where df.IDEmisor == idEmisor && df.IDDomicilioFiscal == idDomicilioFiscal
                            select df;

                DomiciliosFiscales domicilio = query.SingleOrDefault();

                domicilio.RegistroActivo = activo;

                if (activo)
                {
                    mensaje = "Domicilio fiscal activado correctamente";
                }
                else
                {
                    mensaje = "Domicilio fiscal desactivado correctamente";
                }

                entidades.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                mensaje = e.Message;
                return false;
            }
        }

        /// <summary>
        /// Agregará un nuevo domicilio fiscal al emisor identificado por ID
        /// </summary>
        /// <param name="idEmisor">El ID del emisor</param>
        /// <param name="req_calle">La calle del domicilio fiscal, requerido</param>
        /// <param name="opc_noExterior">El número exterior del domicilio fiscal, opcional</param>
        /// <param name="opc_noInterior">El número interior del domicilio fiscal, opcional</param>
        /// <param name="opc_colonia">La colonia del domicilio fiscal, opcional</param>
        /// <param name="opc_localidad">La localidad del domicilio fiscal, opcional</param>
        /// <param name="opc_referencia">La referencia del domicilio fiscal, opcional</param>
        /// <param name="req_municipio">El municipio del domicilio fiscal, requerido</param>
        /// <param name="req_estado">El estado del domicilio fiscal, requerido</param>
        /// <param name="req_pais">El pais del domicilio fiscal, requerido</param>
        /// <param name="req_codigoPostal">El código postal del domicilio fiscal, requerido</param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        public bool AgregarDomicilioFiscal(int idEmisor, string req_calle, string opc_noExterior, string opc_noInterior, string opc_colonia, string opc_localidad, string opc_referencia, string req_municipio, string req_estado, string req_pais, string req_codigoPostal, out string mensaje)
        {
            try
            {
                DomiciliosFiscales domicilioFiscal = new DomiciliosFiscales();

                domicilioFiscal.IDEmisor = idEmisor;
                domicilioFiscal.CFDI32_Req_Calle = req_calle;
                domicilioFiscal.CFDI32_Opc_NoExterior = opc_noExterior;
                domicilioFiscal.CFDI32_Opc_NoInterior = opc_noInterior;
                domicilioFiscal.CFDI32_Opc_Colonia = opc_colonia;
                domicilioFiscal.CFDI32_Opc_Localidad = opc_localidad;
                domicilioFiscal.CFDI32_Opc_Referencia = opc_referencia;
                domicilioFiscal.CFDI32_Req_Municipio = req_municipio;
                domicilioFiscal.CFDI32_Req_Estado = req_estado;
                domicilioFiscal.CFDI32_Req_Pais = req_pais;
                domicilioFiscal.CFDI32_Req_CodigoPostal = req_codigoPostal;

                domicilioFiscal.RegistroActivo = true;
                entidades.DomiciliosFiscales.AddObject(domicilioFiscal);
                entidades.SaveChanges();

                mensaje = "Domicilio fiscal agregado correctamente";
                return false;
            }
            catch (Exception e)
            {
                mensaje = e.Message;
                return false;
            }
        }

        /// <summary>
        /// Actualizará un domicilio fiscal identificado por ID
        /// </summary>
        /// <param name="idEmisor">El ID del emisor con el domicilio fiscal</param>
        /// <param name="idDomicilioFiscal">El ID del domicilio fiscal</param>
        /// <param name="req_calle">La calle del domicilio fiscal, requerido</param>
        /// <param name="opc_noExterior">El número exterior del domicilio fiscal, opcional</param>
        /// <param name="opc_noInterior">El número interior del domicilio fiscal, opcional</param>
        /// <param name="opc_colonia">La colonia del domicilio fiscal, opcional</param>
        /// <param name="opc_localidad">La localidad del domicilio fiscal, opcional</param>
        /// <param name="opc_referencia">La referencia del domicilio fiscal, opcional</param>
        /// <param name="req_municipio">El municipio del domicilio fiscal, requerido</param>
        /// <param name="req_estado">El estado del domicilio fiscal, requerido</param>
        /// <param name="req_pais">El pais del domicilio fiscal, requerido</param>
        /// <param name="req_codigoPostal">El código postal del domicilio fiscal, requerido</param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        public bool ActualizarDomicilioFiscal(int idEmisor, int idDomicilioFiscal, string req_calle, string opc_noExterior, string opc_noInterior, string opc_colonia, string opc_localidad, string opc_referencia, string req_municipio, string req_estado, string req_pais, string req_codigoPostal, out string mensaje)
        {
            try
            {
                var query = from df in entidades.DomiciliosFiscales
                            where df.IDEmisor == idEmisor && df.IDDomicilioFiscal == idDomicilioFiscal
                            select df;

                DomiciliosFiscales domicilioFiscal = query.SingleOrDefault();

                domicilioFiscal.CFDI32_Req_Calle = req_calle;
                domicilioFiscal.CFDI32_Opc_NoExterior = opc_noExterior;
                domicilioFiscal.CFDI32_Opc_NoInterior = opc_noInterior;
                domicilioFiscal.CFDI32_Opc_Colonia = opc_colonia;
                domicilioFiscal.CFDI32_Opc_Localidad = opc_localidad;
                domicilioFiscal.CFDI32_Opc_Referencia = opc_referencia;
                domicilioFiscal.CFDI32_Req_Municipio = req_municipio;
                domicilioFiscal.CFDI32_Req_Estado = req_estado;
                domicilioFiscal.CFDI32_Req_Pais = req_pais;
                domicilioFiscal.CFDI32_Req_CodigoPostal = req_codigoPostal;

                domicilioFiscal.RegistroActivo = true;
                entidades.SaveChanges();

                mensaje = "Domicilio fiscal actualizado correctamente";
                return false;
            }
            catch (Exception e)
            {
                mensaje = e.Message;
                return false;
            }
        }

        /// <summary>
        /// Eliminara un domicilio fiscal identificado por ID
        /// </summary>
        /// <param name="idEmisor">El ID del emisor con el domicilio fiscal</param>
        /// <param name="idDomicilioFiscal">El ID del domicilio fiscal</param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        /// <summary>
        public bool EliminarDomicilioFiscal(int idEmisor, int idDomicilioFiscal, out string mensaje)
        {
            try
            {
                var query = from df in entidades.DomiciliosFiscales
                            where df.IDEmisor == idEmisor && df.IDDomicilioFiscal == idDomicilioFiscal
                            select df;

                DomiciliosFiscales domicilioFiscal = query.SingleOrDefault();

                entidades.DomiciliosFiscales.DeleteObject(domicilioFiscal);
                entidades.SaveChanges();

                mensaje = "Domicilio fiscal eliminado correctamente";
                return true;
            }
            catch (Exception e)
            {
                mensaje = e.Message;
                return false;
            }
        }
    }
}