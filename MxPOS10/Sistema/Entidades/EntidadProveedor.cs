
/*
 * MxPOS 1.0
 * 
 * Elemento: EntidadProveedor
 * Tipo: Clase
 * Descripción: Representa todas las operaciones que se pueden realizar sobre los proveedores en el sistema
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
using MxPOS10.Sistema.Vistas;

namespace MxPOS10.Sistema.Entidades
{
    public class EntidadProveedor
    {
        private MxPOSv10r1Entidades entidades;

        /// <summary>
        /// Constructor
        /// </summary>
        public EntidadProveedor()
        {
            entidades = new MxPOSv10r1Entidades();
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        //      MÉTODOS PARA LA ENTIDAD PROVEEDOR
        //----------------------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Devuelve una lista con todos los proveedores en el sistema
        /// </summary>
        /// <returns>Una lista con todos los proveedores en el sistema</returns>
        public List<VistaProveedor> ObtenerProveedores()
        {
            var query = from p in entidades.Proveedores
                        select new VistaProveedor
                        {
                            IDProveedor = p.IDProveedor,
                            RFC = p.RFC,
                            Nombre = p.Nombre
                        };

            return query.ToList();
        }

        /// <summary>
        /// Devuelve una lista con todos los proveedores activos en el sistema
        /// </summary>
        /// <returns>Una lista con todos los proveedores activos en el sistema</returns>
        public List<VistaProveedor> ObtenerProveedoresActivos()
        {
            var query = from p in entidades.Proveedores
                        where p.RegistroActivo == true
                        select new VistaProveedor
                        {
                            IDProveedor = p.IDProveedor,
                            RFC = p.RFC,
                            Nombre = p.Nombre
                        };

            return query.ToList();
        }

        /// <summary>
        /// Devuelve una lista con todos los proveedores inactivos en el sistema
        /// </summary>
        /// <returns>Una lista con todos los proveedores inactivos en el sistema</returns>
        public List<VistaProveedor> ObtenerProveedoresInactivos()
        {
            var query = from p in entidades.Proveedores
                        where p.RegistroActivo == false
                        select new VistaProveedor
                        {
                            IDProveedor = p.IDProveedor,
                            RFC = p.RFC,
                            Nombre = p.Nombre
                        };

            return query.ToList();
        }

        /// <summary>
        /// Devuelve un proveedor identificado por ID
        /// </summary>
        /// <param name="idProveedor">El ID del proveedor</param>
        /// <returns>El proveedor con el ID especificado</returns>
        public VistaProveedor BuscarProveedor(int idProveedor)
        {
            var query = from p in entidades.Proveedores
                        where p.IDProveedor == idProveedor
                        select new VistaProveedor
                        {
                            IDProveedor = p.IDProveedor,
                            RFC = p.RFC,
                            Nombre = p.Nombre
                        };

            return query.SingleOrDefault();
        }

        /// <summary>
        /// Devuelve una entidad proveedor identificado por ID
        /// </summary>
        /// <param name="idProveedor">El ID del proveedor</param>
        /// <returns>El proveedor con el ID especificado</returns>
        public Proveedores BuscarProveedorEntidad(int idProveedor)
        {
            var query = from p in entidades.Proveedores
                        where p.IDProveedor == idProveedor
                        select p;

            return query.SingleOrDefault();
        }

        /// <summary>
        /// Activará o desactivará un proveedor identificado por ID, representa una alta / baja lógica
        /// </summary>
        /// <param name="idProveedor">El ID del proveedor</param>
        /// <param name="activo">El estado del registro del proveedor</param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        /// <summary>
        public bool EstablecerProveedorActivo(int idProveedor, bool activo, out string mensaje)
        {
            try
            {
                Proveedores proveedor = BuscarProveedorEntidad(idProveedor);

                proveedor.RegistroActivo = activo;

                if (activo)
                {
                    mensaje = "Proveedor activado correctamente";
                }
                else
                {
                    mensaje = "Proveedor desactivado correctamente";
                }

                entidades.SaveChanges();
                return true;
            }
            catch (Exception p)
            {
                mensaje = p.Message + ": " + p.InnerException.Message;
                return false;
            }
        }

        /// <summary>
        /// Agregará un nuevo proveedor al sistema
        /// </summary>
        /// <param name="rfc">El RFC del proveedor, requerido</param>
        /// <param name="nombre">El nombre del proveedor, opcional</param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        /// <summary>
        public bool AgregarProveedor(string rfc, string nombre, out string mensaje)
        {
            try
            {
                Proveedores proveedor = new Proveedores();

                proveedor.RFC = rfc;
                proveedor.Nombre = nombre;

                proveedor.RegistroActivo = true;
                entidades.Proveedores.AddObject(proveedor);
                entidades.SaveChanges();

                mensaje = "Proveedor agregado correctamente";
                return true;
            }
            catch (Exception p)
            {
                mensaje = p.Message + ": " + p.InnerException.Message;
                return false;
            }
        }

        /// <summary>
        /// Actualizará un proveedor identificado por ID
        /// </summary>
        /// <param name="idProveedor">El ID del proveedor</param>
        /// <param name="rfc">El RFC del proveedor, requerido</param>
        /// <param name="nombre">El nombre del proveedor, opcional</param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        /// <summary>
        public bool ActualizarProveedor(int idProveedor, string rfc, string nombre, out string mensaje)
        {
            try
            {
                Proveedores proveedor = BuscarProveedorEntidad(idProveedor);

                proveedor.RFC = rfc;
                proveedor.Nombre = nombre;

                entidades.SaveChanges();

                mensaje = "Proveedor actualizado correctamente";
                return true;
            }
            catch (Exception p)
            {
                mensaje = p.Message + ": " + p.InnerException.Message;
                return false;
            }

        }

        /// <summary>
        /// Eliminara un proveedor identificado por ID
        /// </summary>
        /// <param name="idProveedor">El ID del proveedor</param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        /// <summary>
        public bool EliminarProveedor(int idProveedor, out string mensaje)
        {
            try
            {
                Proveedores proveedor = BuscarProveedorEntidad(idProveedor);

                entidades.Proveedores.DeleteObject(proveedor);

                entidades.SaveChanges();

                mensaje = "Proveedor eliminado correctamente";
                return true;
            }
            catch (Exception p)
            {
                mensaje = p.Message + ": " + p.InnerException.Message;
                return false;
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        //      MÉTODOS PARA LAS ENTIDADES DE NAVEGACIÓN
        //----------------------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Devuelve un domicilio de proveedor específico del proveedor identificado por ID
        /// </summary>
        /// <param name="idProveedor">El ID del proveedor</param>
        /// <param name="idProveedorDomicilio">El ID del domicilio de proveedor</param>
        /// <returns>El domicilio identificado por ID del proveedor identificado por ID</returns>
        public VistaProveedorDomicilio ObtenerDomicilio(int idProveedor, int idProveedorDomicilio)
        {
            var query = from pd in entidades.ProveedoresDomicilios
                        where pd.IDProveedor == idProveedor && pd.IDProveedorDomicilio == idProveedorDomicilio
                        select new VistaProveedorDomicilio
                        {
                            IDDomicilio = pd.IDProveedorDomicilio,
                            IDReceptor = pd.IDProveedor,
                            Seleccionado = pd.Seleccionado,
                            Calle = pd.Calle,
                            NoExterior = pd.NoExterior,
                            NoInterior = pd.NoInterior,
                            Colonia = pd.Colonia,
                            Localidad = pd.Localidad,
                            Referencia = pd.Referencia,
                            Municipio = pd.Municipio,
                            Estado = pd.Estado,
                            Pais = pd.Pais,
                            CodigoPostal = pd.CodigoPostal
                        };

            return query.SingleOrDefault();
        }

        /// <summary>
        /// Devuelve una lista con los domicilios del proveedor identificado por ID
        /// </summary>
        /// <param name="idProveedor">El ID del proveedor</param>
        /// <returns>Una lista con los domicilios del proveedor identificado por ID</returns>
        public List<VistaProveedorDomicilio> ObtenerDomicilios(int idProveedor)
        {
            Proveedores proveedor = BuscarProveedorEntidad(idProveedor);
            var query = from pd in proveedor.ProveedoresDomicilios
                        select new VistaProveedorDomicilio
                        {
                            IDDomicilio = pd.IDProveedorDomicilio,
                            IDReceptor = pd.IDProveedor,
                            Seleccionado = pd.Seleccionado,
                            Calle = pd.Calle,
                            NoExterior = pd.NoExterior,
                            NoInterior = pd.NoInterior,
                            Colonia = pd.Colonia,
                            Localidad = pd.Localidad,
                            Referencia = pd.Referencia,
                            Municipio = pd.Municipio,
                            Estado = pd.Estado,
                            Pais = pd.Pais,
                            CodigoPostal = pd.CodigoPostal
                        };

            return query.ToList();
        }

        /// <summary>
        /// Devuelve una lista con los domicilios activos del proveedor identificado por ID
        /// </summary>
        /// <param name="idProveedor">El ID del proveedor</param>
        /// <returns>Una lista con los domicilios activos del proveedor identificado por ID</returns>
        public List<VistaProveedorDomicilio> ObtenerDomiciliosActivos(int idProveedor)
        {
            var query = from pd in entidades.ProveedoresDomicilios
                        where pd.IDProveedor == idProveedor && pd.RegistroActivo == true
                        select new VistaProveedorDomicilio
                        {
                            IDDomicilio = pd.IDProveedorDomicilio,
                            IDReceptor = pd.IDProveedor,
                            Seleccionado = pd.Seleccionado,
                            Calle = pd.Calle,
                            NoExterior = pd.NoExterior,
                            NoInterior = pd.NoInterior,
                            Colonia = pd.Colonia,
                            Localidad = pd.Localidad,
                            Referencia = pd.Referencia,
                            Municipio = pd.Municipio,
                            Estado = pd.Estado,
                            Pais = pd.Pais,
                            CodigoPostal = pd.CodigoPostal
                        };

            return query.ToList();
        }

        /// <summary>
        /// Devuelve una lista con los domicilios inactivos del proveedor identificado por ID
        /// </summary>
        /// <param name="idProveedor">El ID del proveedor</param>
        /// <returns>Una lista con los domicilios inactivos del proveedor identificado por ID</returns>
        public List<VistaProveedorDomicilio> ObtenerDomiciliosInactivos(int idProveedor)
        {
            var query = from pd in entidades.ProveedoresDomicilios
                        where pd.IDProveedor == idProveedor && pd.RegistroActivo == false
                        select new VistaProveedorDomicilio
                        {
                            IDDomicilio = pd.IDProveedorDomicilio,
                            IDReceptor = pd.IDProveedor,
                            Seleccionado = pd.Seleccionado,
                            Calle = pd.Calle,
                            NoExterior = pd.NoExterior,
                            NoInterior = pd.NoInterior,
                            Colonia = pd.Colonia,
                            Localidad = pd.Localidad,
                            Referencia = pd.Referencia,
                            Municipio = pd.Municipio,
                            Estado = pd.Estado,
                            Pais = pd.Pais,
                            CodigoPostal = pd.CodigoPostal
                        };

            return query.ToList();
        }

        /// <summary>
        /// Activará o desactivará un domicilio de proveedor identificado por ID
        /// </summary>
        /// <param name="idProveedor">El ID del proveedor con el domicilio de proveedor</param>
        /// <param name="idProveedorDomicilio">El ID del domicilio de proveedor</param>
        /// <param name="activo">El estado del registro del domicilio de proveedor</param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        /// <summary>
        public bool EstablecerDomicilioActivo(int idProveedor, int idProveedorDomicilio, bool activo, out string mensaje)
        {
            try
            {
                var query = from pd in entidades.ProveedoresDomicilios
                            where pd.IDProveedor == idProveedor && pd.IDProveedorDomicilio == idProveedorDomicilio
                            select pd;

                ProveedoresDomicilios domicilio = query.SingleOrDefault();

                domicilio.RegistroActivo = activo;

                if (activo)
                {
                    mensaje = "Domicilio de proveedor activado correctamente";
                }
                else
                {
                    mensaje = "Domicilio de proveedor desactivado correctamente";
                }

                entidades.SaveChanges();
                return true;
            }
            catch (Exception p)
            {
                mensaje = p.Message + ": " + p.InnerException.Message;
                return false;
            }
        }

        /// <summary>
        /// Establecerá un domicilio de proveedor identificado por ID como el domicilio seleccionado
        /// </summary>
        /// <param name="idProveedor">El ID del proveedor con el domicilio de proveedor</param>
        /// <param name="idProveedorDomicilio">El ID del domicilio de proveedor</param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        /// <summary>
        public bool EstablecerDomicilioSeleccionado(int idProveedor, int idProveedorDomicilio, out string mensaje)
        {
            try
            {
                var query = from pd in entidades.ProveedoresDomicilios
                            select pd;

                List<ProveedoresDomicilios> prvDmc = query.ToList();

                foreach (ProveedoresDomicilios pd in prvDmc)
                {
                    pd.Seleccionado = false;
                    entidades.SaveChanges();
                }
                
                query = from pd in entidades.ProveedoresDomicilios
                        where pd.IDProveedor == idProveedor && pd.IDProveedorDomicilio == idProveedorDomicilio
                        select pd;

                ProveedoresDomicilios domicilio = query.SingleOrDefault();

                domicilio.Seleccionado = true;
                mensaje = "Domicilio de proveedor seleccionado como domicilio por defecto correctamente";

                entidades.SaveChanges();
                return true;
            }
            catch (Exception p)
            {
                mensaje = p.Message + ": " + p.InnerException.Message;
                return false;
            }
        }

        /// <summary>
        /// Agregará un nuevo domicilio de proveedor al proveedor identificado por ID
        /// </summary>
        /// <param name="idProveedor">El ID del proveedor</param>
        /// <param name="calle">La calle del domicilio de proveedor, requerido</param>
        /// <param name="noExterior">El número exterior del domicilio de proveedor, opcional</param>
        /// <param name="noInterior">El número interior del domicilio de proveedor, opcional</param>
        /// <param name="colonia">La colonia del domicilio de proveedor, opcional</param>
        /// <param name="localidad">La localidad del domicilio de proveedor, opcional</param>
        /// <param name="referencia">La referencia del domicilio de proveedor, opcional</param>
        /// <param name="municipio">El municipio del domicilio de proveedor, requerido</param>
        /// <param name="estado">El estado del domicilio de proveedor, requerido</param>
        /// <param name="pais">El pais del domicilio de proveedor, requerido</param>
        /// <param name="codigoPostal">El código postal del domicilio de proveedor, requerido</param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        public bool AgregarDomicilio(int idProveedor, string calle, string noExterior, string noInterior, string colonia, string localidad, string referencia, string municipio, string estado, string pais, string codigoPostal, out string mensaje)
        {
            try
            {
                ProveedoresDomicilios domicilio = new ProveedoresDomicilios();

                domicilio.IDProveedor = idProveedor;
                domicilio.Calle = calle;
                domicilio.NoExterior = noExterior;
                domicilio.NoInterior = noInterior;
                domicilio.Colonia = colonia;
                domicilio.Localidad = localidad;
                domicilio.Referencia = referencia;
                domicilio.Municipio = municipio;
                domicilio.Estado = estado;
                domicilio.Pais = pais;
                domicilio.CodigoPostal = codigoPostal;

                domicilio.RegistroActivo = true;
                entidades.ProveedoresDomicilios.AddObject(domicilio);
                entidades.SaveChanges();

                mensaje = "Domicilio de proveedor agregado correctamente";
                return false;
            }
            catch (Exception p)
            {
                mensaje = p.Message + ": " + p.InnerException.Message;
                return false;
            }
        }

        /// <summary>
        /// Actualizará un domicilio de proveedor identificado por ID
        /// </summary>
        /// <param name="idProveedor">El ID del proveedor con el domicilio de proveedor</param>
        /// <param name="idProveedorDomicilio">El ID del domicilio de proveedor</param>
        /// <param name="calle">La calle del domicilio de proveedor, requerido</param>
        /// <param name="noExterior">El número exterior del domicilio de proveedor, opcional</param>
        /// <param name="noInterior">El número interior del domicilio de proveedor, opcional</param>
        /// <param name="colonia">La colonia del domicilio de proveedor, opcional</param>
        /// <param name="localidad">La localidad del domicilio de proveedor, opcional</param>
        /// <param name="referencia">La referencia del domicilio de proveedor, opcional</param>
        /// <param name="municipio">El municipio del domicilio de proveedor, requerido</param>
        /// <param name="estado">El estado del domicilio de proveedor, requerido</param>
        /// <param name="pais">El pais del domicilio de proveedor, requerido</param>
        /// <param name="codigoPostal">El código postal del domicilio de proveedor, requerido</param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        public bool ActualizarDomicilio(int idProveedor, int idProveedorDomicilio, string calle, string noExterior, string noInterior, string colonia, string localidad, string referencia, string municipio, string estado, string pais, string codigoPostal, out string mensaje)
        {
            try
            {
                var query = from pd in entidades.ProveedoresDomicilios
                            where pd.IDProveedor == idProveedor && pd.IDProveedorDomicilio == idProveedorDomicilio
                            select pd;

                ProveedoresDomicilios domicilio = query.SingleOrDefault();

                domicilio.Calle = calle;
                domicilio.NoExterior = noExterior;
                domicilio.NoInterior = noInterior;
                domicilio.Colonia = colonia;
                domicilio.Localidad = localidad;
                domicilio.Referencia = referencia;
                domicilio.Municipio = municipio;
                domicilio.Estado = estado;
                domicilio.Pais = pais;
                domicilio.CodigoPostal = codigoPostal;

                entidades.SaveChanges();

                mensaje = "Domicilio de proveedor actualizado correctamente";
                return false;
            }
            catch (Exception p)
            {
                mensaje = p.Message + ": " + p.InnerException.Message;
                return false;
            }
        }

        /// <summary>
        /// Eliminara un domicilio de proveedor identificado por ID
        /// </summary>
        /// <param name="idProveedor">El ID del proveedor con el domicilio de proveedor</param>
        /// <param name="idProveedorDomicilio">El ID del domicilio de proveedor</param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        /// <summary>
        public bool EliminarDomicilio(int idProveedor, int idProveedorDomicilio, out string mensaje)
        {
            try
            {
                var query = from pd in entidades.ProveedoresDomicilios
                            where pd.IDProveedor == idProveedor && pd.IDProveedorDomicilio == idProveedorDomicilio
                            select pd;

                ProveedoresDomicilios domicilio = query.SingleOrDefault();

                entidades.ProveedoresDomicilios.DeleteObject(domicilio);
                entidades.SaveChanges();

                mensaje = "Domicilio de proveedor eliminado correctamente";
                return true;
            }
            catch (Exception p)
            {
                mensaje = p.Message + ": " + p.InnerException.Message;
                return false;
            }
        }
    }
}