using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MxPOS10.Sistema.Datos;
using MxPOS10.Sistema.Vistas;

namespace MxPOS10.Sistema.Entidades
{
    public class EntidadCompra
    {
        private MxPOSv10r1Entidades entidades;

        /// <summary>
        /// Constructor
        /// </summary>
        public EntidadCompra() 
        {
            entidades = new MxPOSv10r1Entidades();
        }

        /// <summary>
        /// Devuelve una lista con todos las compras
        /// </summary>
        /// <returns>Una lista con todos las compras</returns>
        public List<VistaCompra> ObtenerCompras()
        {
            var query = from p in entidades.Compras
                        select new VistaCompra
                        {
                            IDCompra = p.IDCompra,
                            IDEStatusCompra = p.IDEstatusCompra,
                            IDProveedor = p.IDProveedor,
                            MotivoDescuento = p.MotivoDescuento,
                            Descuento = p.Descuento,
                            Dumb = p.Dumb,
                            Fecha = p.Fecha,
                            IVA = p.IVA,
                            Folio = p.Folio,
                            Serie = p.Serie,
                            Subtotal = p.Subtotal,
                            Total = p.Total
                        };

            return query.ToList();
        }

        /// <summary>
        /// Devuelve una lista con todas las compras activas en el sistema
        /// </summary>
        /// <returns>Una lista con todos las compras activas en el sistema</returns>
        public List<VistaCompra> ObtenerComprasActivas()
        {
            var query = from p in entidades.Compras
                        where p.RegistroActivo == true
                        select new VistaCompra
                        {
                            IDCompra = p.IDCompra,
                            IDEStatusCompra = p.IDEstatusCompra,
                            IDProveedor = p.IDProveedor,
                            MotivoDescuento = p.MotivoDescuento,
                            Descuento = p.Descuento,
                            Dumb = p.Dumb,
                            Fecha = p.Fecha,
                            IVA = p.IVA,
                            Folio = p.Folio,
                            Serie = p.Serie,
                            Subtotal = p.Subtotal,
                            Total = p.Total
                        };

            return query.ToList();
        }

        /// <summary>
        /// Devuelve una lista con todos las compras inactivos en el sistema
        /// </summary>
        /// <returns>Una lista con todos los estados de compra inactivos en el sistema</returns>
        public List<VistaCompra> ObtenerCompraInactivos()
        {
            var query = from p in entidades.Compras
                        where p.RegistroActivo == false
                        select new VistaCompra
                        {
                            IDCompra = p.IDCompra,
                            IDEStatusCompra = p.IDEstatusCompra,
                            IDProveedor = p.IDProveedor,
                            MotivoDescuento = p.MotivoDescuento,
                            Descuento = p.Descuento,
                            Dumb = p.Dumb,
                            Fecha = p.Fecha,
                            IVA = p.IVA,
                            Folio = p.Folio,
                            Serie = p.Serie,
                            Subtotal = p.Subtotal,
                            Total = p.Total
                        };

            return query.ToList();
        }

        /// <summary>
        /// Devuelve una compra identificado por ID
        /// </summary>
        /// <param name="idCompra">El ID de la compra</param>
        /// <returns>La compra con el ID especificado</returns>
        public VistaCompra BuscarCompra(int idCompra)
        {
            var query = from p in entidades.Compras
                        where p.IDCompra == idCompra
                        select new VistaCompra
                        {
                            IDCompra = p.IDCompra,
                            IDEStatusCompra = p.IDEstatusCompra,
                            IDProveedor = p.IDProveedor,
                            MotivoDescuento = p.MotivoDescuento,
                            Descuento = p.Descuento,
                            Dumb = p.Dumb,
                            Fecha = p.Fecha,
                            IVA = p.IVA,
                            Folio = p.Folio,
                            Serie = p.Serie,
                            Subtotal = p.Subtotal,
                            Total = p.Total
                        };

            return query.SingleOrDefault();
        }

        /// <summary>
        /// Devuelve una entidad de compras identificado por ID
        /// </summary>
        /// <param name="idCompra">El ID de la compra</param>
        /// <returns>La compra con el ID compra</returns>
        public Compras BuscarCompraEntidad(int idCompra)
        {
            var query = from p in entidades.Compras
                        where p.IDCompra == idCompra
                        select p;

            return query.SingleOrDefault();
        }

        /// <summary>
        /// Activará o desactivará una compra identificado por ID, representa una alta / baja lógica
        /// </summary>
        /// <param name="idCompra">El ID de la compra</param>
        /// <param name="activo">El estado del registro de la compra</param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        /// <summary>
        public bool EstablecerCompraActivo(int idCompra, bool activo, out string mensaje)
        {
            try
            {
                Compras estatusCompra = BuscarCompraEntidad(idCompra);

                estatusCompra.RegistroActivo = activo;

                if (activo)
                {
                    mensaje = "Compra activada correctamente";
                }
                else
                {
                    mensaje = "Compra desactivada correctamente";
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
        /// Agregara una nueva compra al sistema
        /// </summary>
        /// <param name="idEstatusCompra"></param>
        /// <param name="idProveedor"></param>
        /// <param name="motivoDescuento"></param>
        /// <param name="descuento"></param>
        /// <param name="dumb"></param>
        /// <param name="fecha"></param>
        /// <param name="iva"></param>
        /// <param name="folio"></param>
        /// <param name="serie"></param>
        /// <param name="subtotal"></param>
        /// <param name="total"></param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        public bool AgregarCompra(int idEstatusCompra, int idProveedor, string motivoDescuento, float descuento,
            string dumb,DateTime fecha,double iva, string folio, string serie, float subtotal,float total, out string mensaje)
        {
            try
            {
                Compras compra = new Compras();

                compra.IDEstatusCompra = idEstatusCompra;
                compra.IDProveedor = idProveedor;
                compra.MotivoDescuento = motivoDescuento;
                compra.Descuento = descuento;
                compra.Dumb = dumb;
                compra.Fecha = fecha;
                compra.IVA = iva;
                compra.Folio = folio;
                compra.Serie = serie;
                compra.Subtotal = subtotal;
                compra.Total = total;
                compra.RegistroActivo = true;

                entidades.Compras.AddObject(compra);
                entidades.SaveChanges();

                mensaje = "Compra agregada correctamente";
                return true;
            }
            catch (Exception p)
            {
                mensaje = p.Message;
                return false;
            }
        }

        /// <summary>
        /// Actualizará una compra identificada por ID
        /// </summary>
        /// <param name="idCompra"></param>
        /// <param name="idEstatusCompra"></param>
        /// <param name="idProveedor"></param>
        /// <param name="motivoDescuento"></param>
        /// <param name="descuento"></param>
        /// <param name="dumb"></param>
        /// <param name="fecha"></param>
        /// <param name="iva"></param>
        /// <param name="folio"></param>
        /// <param name="serie"></param>
        /// <param name="subtotal"></param>
        /// <param name="total"></param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        public bool ActualizarCompra(int idCompra, int idEstatusCompra, int idProveedor, string motivoDescuento, float descuento,
            string dumb, DateTime fecha, double iva, string folio, string serie, float subtotal, float total, out string mensaje)
        {
            try
            {
                Compras compra = BuscarCompraEntidad(idCompra);
                compra.IDEstatusCompra = idEstatusCompra;
                compra.IDProveedor = idProveedor;
                compra.MotivoDescuento = motivoDescuento;
                compra.Descuento = descuento;
                compra.Dumb = dumb;
                compra.Fecha = fecha;
                compra.IVA = iva;
                compra.Folio = folio;
                compra.Serie = serie;
                compra.Subtotal = subtotal;
                compra.Total = total;
                compra.RegistroActivo = true;
                entidades.SaveChanges();

                mensaje = "Compra actualizada correctamente";
                return true;
            }
            catch (Exception p)
            {
                mensaje = p.Message;
                return false;
            }

        }

        /// <summary>
        /// Eliminara una compra identificado por ID
        /// </summary>
        /// <param name="idEstatusCompra">El ID de la compra</param>
        /// <param name="mensaje">Un mensaje con el resultado de la operación</param>
        /// <returns>Devuelve true si no ocurrió ningun error durante la operación, false de lo contrario</returns>
        /// <summary>
        public bool EliminarCompra(int idCompra, out string mensaje)
        {
            try
            {
                Compras compra = BuscarCompraEntidad(idCompra);

                entidades.Compras.DeleteObject(compra);

                entidades.SaveChanges();

                mensaje = "La compra ha sido eliminada correctamente";
                return true;
            }
            catch (Exception p)
            {
                mensaje = p.Message;
                return false;
            }
        }
    }


}