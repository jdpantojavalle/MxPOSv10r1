using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxPOS10.Sistema.Entidades;
using MxPOS10.Sistema.Vistas;
using MxPOS10.Sistema.Utilidades;

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

            if (!IsPostBack)
            {
                SeleccionarProveedorPorIndice(0);
            }
        }

        protected void gvwProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeleccionarProveedorPorIndice(gvwProveedores.SelectedIndex);
        }

        protected void btnReporteProveedores_Click(object sender, EventArgs e)
        {
            VerReporteProveedores();
        }

        protected void btnProveedoresDomicilios_Click(object sender, EventArgs e)
        {
            int idProveedor = int.Parse(gvwProveedores.SelectedRow.Cells[1].Text);
            VerDomicilios(idProveedor);
        }

        protected void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            AgregarProveedor(txtRFC.Text, txtNombre.Text);
        }

        protected void btnActualizarProveedor_Click(object sender, EventArgs e)
        {
            int idProveedor = int.Parse(gvwProveedores.SelectedRow.Cells[1].Text);
            ActualizarProveedor(idProveedor, txtRFC.Text, txtNombre.Text);
        }

        protected void btnEliminarProveedor_Click(object sender, EventArgs e)
        {
            int idProveedor = int.Parse(gvwProveedores.SelectedRow.Cells[1].Text);
            EliminarProveedor(idProveedor);
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        //      FUNCIONES DE LA PÁGINA
        //----------------------------------------------------------------------------------------------------------------------------------------------------------

        public void CargarProveedores()
        {
            try
            {
                EntidadProveedor proveedores = new EntidadProveedor();
                List<VistaProveedor> proveedoresActivos = proveedores.ObtenerProveedoresActivos();

                gvwProveedores.DataSource = proveedores.ObtenerProveedoresActivos();
                gvwProveedores.DataBind();

                if (proveedoresActivos.Count > 0)
                {
                    HabilitarControles();
                }
                else
                {
                    DesHabilitarControles();
                }

            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message + ": " + ex.InnerException.Message);
            }
        }

        public void SeleccionarProveedorPorIndice(int indiceProveedor)
        {
            try
            {
                if (gvwProveedores.Rows.Count > 0)
                {
                    gvwProveedores.SelectedIndex = indiceProveedor;
                    gvwProveedores.SelectedRow.BackColor = System.Drawing.Color.Orange;
                    int idProveedor = int.Parse(gvwProveedores.SelectedRow.Cells[1].Text);
                    SeleccionarProveedorPorID(idProveedor);
                }
                else
                {
                    LimpiarDatos();
                }
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message + ": " + ex.InnerException.Message);
            }
        }

        public void SeleccionarProveedorPorID(int idProveedor)
        {
            try
            {
                EntidadProveedor entidadProveedor = new EntidadProveedor();
                VistaProveedor proveedor = entidadProveedor.BuscarProveedor(idProveedor);
                lblID.Text = proveedor.IDProveedor.ToString();
                txtRFC.Text = proveedor.RFC;
                txtNombre.Text = proveedor.Nombre;
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message + ": " + ex.InnerException.Message);
            }
        }

        public void AgregarProveedor(string rfc, string nombre)
        {
            try
            {
                string mensaje;
                EntidadProveedor proveedor = new EntidadProveedor();
                proveedor.AgregarProveedor(rfc, nombre, out mensaje);
                Mensaje.Mostrar(this, mensaje);
                CargarProveedores();
                SeleccionarProveedorPorIndice(gvwProveedores.Rows.Count - 1);
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message + ": " + ex.InnerException.Message);
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
                SeleccionarProveedorPorIndice(gvwProveedores.SelectedIndex);
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message + ": " + ex.InnerException.Message);
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
                SeleccionarProveedorPorIndice(0);
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message + ": " + ex.InnerException.Message);
            }
        }

        public void VerReporteProveedores()
        {
            Response.Redirect("~/Sistema/Reportes/Proveedores/ReporteProveedor.aspx");
        }

        public void VerDomicilios(int idProveedor)
        {
            Response.Redirect("~/Sistema/Paginas/PaginaDomicilioProveedor.aspx?idProveedor=" + idProveedor);
        }

        public void HabilitarControles()
        {
            btnReporteProveedores.Enabled = true;
            btnProveedoresDomicilios.Enabled = true;
            btnActualizarProveedor.Enabled = true;
            btnEliminarProveedor.Enabled = true;
        }

        public void DesHabilitarControles()
        {
            btnReporteProveedores.Enabled = false;
            btnProveedoresDomicilios.Enabled = false;
            btnActualizarProveedor.Enabled = false;
            btnEliminarProveedor.Enabled = false;
        }

        public void LimpiarDatos()
        {
            lblID.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtRFC.Text = string.Empty;
        }
    }
}