using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MxPOS10.Sistema.Datos;
using MxPOS10.Sistema.Vistas;

namespace MxPOS10.Sistema.Entidades
{
    public class EntidadEstatusCompra
    {
        private MxPOSv10r1Entidades entidades;

        /// <summary>
        /// Constructor
        /// </summary>
        public EntidadEstatusCompra() 
        {
            entidades = new MxPOSv10r1Entidades();
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        //      MÉTODOS PARA LA ENTIDAD ESTATUS PROVEEDOR
        //----------------------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Devuelve una lista con todos los Estados de compra
        /// </summary>
        /// <returns>Una lista con todos los Estados de compra</returns>
        public List<VistaEstatusCompra> ObtenerEstatusCompra()
        {
            var query = from p in entidades.EstatusCompra
                        select new VistaEstatusCompra
                        {
                            IDEstatusCompra = p.IDEstatusCompra,
                            Leyenda = p.Leyenda,
                            Descripcion = p.Descripcion
                        };

            return query.ToList();
        }

        /// <summary>
        /// Devuelve una lista con todos los estados de compra activos en el sistema
        /// </summary>
        /// <returns>Una lista con todos los estados de compra activos en el sistema</returns>
        public List<VistaEstatusCompra> ObtenerEstatusCompraActivos()
        {
            var query = from p in entidades.EstatusCompra
                        where p.RegistroActivo == true
                        select new VistaEstatusCompra
                        {
                            IDEstatusCompra = p.IDEstatusCompra,
                            Leyenda = p.Leyenda,
                            Descripcion = p.Descripcion
                        };

            return query.ToList();
        }

        /// <summary>
        /// Devuelve una lista con todos los estados de compra inactivos en el sistema
        /// </summary>
        /// <returns>Una lista con todos los estados de compra inactivos en el sistema</returns>
        public List<VistaEstatusCompra> ObtenerEstatusCompraInactivos()
        {
            var query = from p in entidades.EstatusCompra
                        where p.RegistroActivo == false
                        select new VistaEstatusCompra
                        {
                            IDEstatusCompra = p.IDEstatusCompra,
                            Leyenda = p.Leyenda,
                            Descripcion = p.Descripcion
                        };

            return query.ToList();
        }

        /// <summary>
        /// Devuelve un estado de compra identificado por ID
        /// </summary>
        /// <param name="idProveedor">El ID del estado de compra</param>
        /// <returns>El estado de compra con el ID especificado</returns>
        public VistaEstatusCompra BuscarEstatusCompra(int idEstatusCompra)
        {
            var query = from p in entidades.EstatusCompra
                        where p.IDEstatusCompra == idEstatusCompra
                        select new VistaEstatusCompra
                        {
                            IDEstatusCompra = p.IDEstatusCompra,
                            Leyenda = p.Leyenda,
                            Descripcion = p.Descripcion
                        };

            return query.SingleOrDefault();
        }

        /// <summary>
        /// Devuelve una entidad estatus compra identificado por ID
        /// </summary>
        /// <param name="idProveedor">El ID del estatus compra</param>
        /// <returns>El status compra con el ID estatus compra</returns>
        public EstatusCompra BuscarEstatusCompraEntidad(int idEstatusCompra)
        {
            var query = from p in entidades.EstatusCompra
                        where p.IDEstatusCompra == idEstatusCompra
                        select p;

            return query.SingleOrDefault();
        }

        /// <summary>
        /// Activará o desactivará un estatus compra identificado por ID, representa una alta / baja lógica
        /// </summary>
        /// <param name="idEstatusCompra">El ID del estatus compra</param>
        /// <param name="activo">El estado del registro del estatus compra</param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        /// <summary>
        public bool EstablecerProveedorActivo(int idEstatusCompra, bool activo, out string mensaje)
        {
            try
            {
                EstatusCompra estatusCompra = BuscarEstatusCompraEntidad(idEstatusCompra);

                estatusCompra.RegistroActivo = activo;

                if (activo)
                {
                    mensaje = "Estatus compra activado correctamente";
                }
                else
                {
                    mensaje = "Estatus compra desactivado correctamente";
                }

                entidades.SaveChanges();
                return true;
            }
            catch (Exception p)
            {
                mensaje = p.Message;
                return false;
            }
        }

        /// <summary>
        /// Agregará un nuevo estatus compra al sistema
        /// </summary>
        /// <param name="leyenda">El Leyenda del estatus compra</param>
        /// <param name="descripcion">La descripcion del estatus compra</param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        /// <summary>
        public bool AgregarEstatusCompra(string leyenda, string descripcion, out string mensaje)
        {
            try
            {
                EstatusCompra estatusCompra = new EstatusCompra();

                estatusCompra.Leyenda = leyenda;
                estatusCompra.Descripcion = descripcion;

                estatusCompra.RegistroActivo = true;
                entidades.EstatusCompra.AddObject(estatusCompra);
                entidades.SaveChanges();

                mensaje = "Estatus compra agregado correctamente";
                return true;
            }
            catch (Exception p)
            {
                mensaje = p.Message;
                return false;
            }
        }

        /// <summary>
        /// Actualizará un estatus compra identificado por ID
        /// </summary>
        /// <param name="idEstatusCompra">El ID del estatus compra</param>
        /// <param name="leyenda">El Leyenda del estatus compra</param>
        /// <param name="descripcion">El descripcion del estatus compra</param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        /// <summary>
        public bool ActualizarProveedor(int idEstatusCompra, string leyenda, string descripcion, out string mensaje)
        {
            try
            {
                EstatusCompra estatusCompra = BuscarEstatusCompraEntidad(idEstatusCompra);

                estatusCompra.Leyenda = leyenda;
                estatusCompra.Descripcion = descripcion;

                estatusCompra.RegistroActivo = true;
                entidades.SaveChanges();

                mensaje = "Estatus compra actualizado correctamente";
                return true;
            }
            catch (Exception p)
            {
                mensaje = p.Message;
                return false;
            }

        }

        /// <summary>
        /// Eliminara un estatus compra identificado por ID
        /// </summary>
        /// <param name="idEstatusCompra">El ID del estatus compra</param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        /// <summary>
        public bool EliminarEstatusCompra(int idEstatusCompra, out string mensaje)
        {
            try
            {
                EstatusCompra estatusCompra = BuscarEstatusCompraEntidad(idEstatusCompra);

                entidades.EstatusCompra.DeleteObject(estatusCompra);

                entidades.SaveChanges();

                mensaje = "Estatus compra ha sido eliminado correctamente";
                return true;
            }
            catch (Exception p)
            {
                mensaje = p.Message;
                return false;
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        //      MÉTODOS PARA LAS ENTIDADES DE PROVEEDOR DOMICILIOS
        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        /*
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
                mensaje = p.Message;
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
                mensaje = p.Message;
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

                domicilio.RegistroActivo = true;
                entidades.SaveChanges();

                mensaje = "Domicilio de proveedor actualizado correctamente";
                return false;
            }
            catch (Exception p)
            {
                mensaje = p.Message;
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
                mensaje = p.Message;
                return false;
            }
        }*/
    }
}