using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxPOS10.Sistema.Entidades;
using MxPOS10.Sistema.Utilidades;
using MxPOS10.Sistema.Vistas;

namespace MxPOS10.Sistema.Paginas
{
    public partial class PaginaProveedor : System.Web.UI.Page
    {

        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        //      EVENTOS DE LA PÁGINA
        //----------------------------------------------------------------------------------------------------------------------------------------------------------

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarProveedores();
        }

        protected void gvwProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProveedor = int.Parse(gvwProveedores.SelectedRow.Cells[1].Text);
            SeleccionarProveedor(idProveedor);
        }

        protected void btnReporteProveedores_Click(object sender, EventArgs e)
        {
            // Agregar reporte aquí
        }

        protected void btnProveedoresDomicilios_Click(object sender, EventArgs e)
        {
            // Agregar domicilios aquí
        }

        protected void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            AgregarProveedor(txtRFC.Text, txtNombre.Text);
            Limpiar();
        }

        protected void btnActualizarProveedor_Click(object sender, EventArgs e)
        {
            if (gvwProveedores.SelectedRow != null)
            {
                int idProveedor = int.Parse(gvwProveedores.SelectedRow.Cells[1].Text);
                ActualizarProveedor(idProveedor, txtRFC.Text, txtNombre.Text);
                Limpiar();
            }
        }

        protected void btnEliminarProveedor_Click(object sender, EventArgs e)
        {
            if (gvwProveedores.SelectedRow != null)
            {
                int idProveedor = int.Parse(gvwProveedores.SelectedRow.Cells[1].Text);
                EliminarProveedor(idProveedor);
                Limpiar();
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        //      FUNCIONES DE LA PÁGINA
        //----------------------------------------------------------------------------------------------------------------------------------------------------------

        public void CargarProveedores()
        {
            try
            {
                EntidadProveedor proveedores = new EntidadProveedor();
                gvwProveedores.DataSource = proveedores.ObtenerProveedoresActivos();
                gvwProveedores.DataBind();
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message);
            }
        }

        public void SeleccionarProveedor(int idProveedor)
        {
            try
            {
                EntidadProveedor entidadProveedor = new EntidadProveedor();
                VistaProveedor proveedor = entidadProveedor.BuscarProveedor(idProveedor);
                lblID.Text = proveedor.IDProveedor.ToString();
                txtRFC.Text = proveedor.RFC;
                txtNombre.Text = proveedor.Nombre;
                gvwProveedores.SelectedRow.BackColor = System.Drawing.Color.Orange;

            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message);
            }
        }

        public void AgregarProveedor(string rfc, string nombre)
        {
            try
            {
                EntidadProveedor proveedor = new EntidadProveedor();
                string mensaje;
                proveedor.AgregarProveedor(rfc, nombre, out mensaje);
                Mensaje.Mostrar(this, mensaje);
                CargarProveedores();
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message);
            }
        }

        public void ActualizarProveedor(int idProveedor, string rfc, string nombre)
        {
            try
            {
                string mensaje;
                EntidadProveedor emisor = new EntidadProveedor();
                emisor.ActualizarProveedor(idProveedor, rfc, nombre, out mensaje);
                Mensaje.Mostrar(this, mensaje);
                CargarProveedores();
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message);
            }
        }

        public void EliminarProveedor(int idProveedor)
        {
            try
            {
                string mensaje;
                EntidadProveedor emisor = new EntidadProveedor();
                emisor.EstablecerProveedorActivo(idProveedor, false, out mensaje);
                Mensaje.Mostrar(this, mensaje);
                CargarProveedores();
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message);
            }
        }

        public void VerReporteProveedores()
        {
            //Response.Redirect("~/Sistema/Reportes/Proveedores/ReporteEmisor.aspx");
        }

        public void VerDomicilios(int idEmisor)
        {
            Limpiar();
            //Response.Redirect("~/Sistema/Paginas/PaginaDomicilioFiscal.aspx?idEmisor=" + idEmisor);
        }

        public void Limpiar()
        {
            lblID.Text = string.Empty;
            txtRFC.Text = string.Empty;
            txtNombre.Text = string.Empty;
        }
    }
}