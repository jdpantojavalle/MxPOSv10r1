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
    public partial class PaginaProveedorDomicilio : System.Web.UI.Page
    {

        int idProveedor;

        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        //      EVENTOS DE LA PÁGINA
        //----------------------------------------------------------------------------------------------------------------------------------------------------------

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["idProveedor"] != null)
            {
                idProveedor = int.Parse(Request.QueryString["idProveedor"]);
                CargarProveedor(idProveedor);
                CargarProveedoresDomicilios(idProveedor);
            }
            else
            {
                btnAgregarDomicilio.Enabled = false;
                btnActualizarDomicilio.Enabled = false;
                btnEliminarDomicilio.Enabled = false;
                Mensaje.Mostrar(this, "Parece que has llegado a esta página por error, el ID del proveedor no es válido");
            }
        }

        protected void btnReporteProveedoresDomicilios_Click(object sender, EventArgs e)
        {
            VerReporteProveedoresDomicilios(idProveedor);
        }

        protected void btnAgregarDomicilio_Click(object sender, EventArgs e)
        {
            AgregarDomicilio(idProveedor, txtCalle.Text, txtNumeroExterior.Text, txtNumeroInterior.Text, txtColonia.Text, txtLocalidad.Text, txtReferencia.Text, txtMunicipio.Text, txtEstado.Text, txtPais.Text, txtCodigoPostal.Text);
            Limpiar();
        }

        protected void btnActualizarDomicilio_Click(object sender, EventArgs e)
        {
            if (gvwProveedoresDomicilios.SelectedRow != null)
            {
                int idDomicilio = int.Parse(gvwProveedoresDomicilios.SelectedRow.Cells[1].Text);
                ActualizarDomicilio(idProveedor, idDomicilio, txtCalle.Text, txtNumeroExterior.Text, txtNumeroInterior.Text, txtColonia.Text, txtLocalidad.Text, txtReferencia.Text, txtMunicipio.Text, txtEstado.Text, txtPais.Text, txtCodigoPostal.Text);
                Limpiar();
            }
        }

        protected void btnEliminarDomicilio_Click(object sender, EventArgs e)
        {
            if (gvwProveedoresDomicilios.SelectedRow != null)
            {
                int idDomicilio = int.Parse(gvwProveedoresDomicilios.SelectedRow.Cells[1].Text);
                EliminarDomicilio(idProveedor, idDomicilio);
                Limpiar();
            }
        }

        protected void gvwProveedoresDomicilios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvwProveedoresDomicilios.SelectedRow != null)
            {
                int idDomicilio = int.Parse(gvwProveedoresDomicilios.SelectedRow.Cells[1].Text);
                SeleccionarDomicilio(idProveedor, idDomicilio);
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        //      FUNCIONES DE LA PÁGINA
        //----------------------------------------------------------------------------------------------------------------------------------------------------------

        public void CargarProveedor(int idProveedor)
        {
            try
            {
                EntidadProveedor entidadProveedor = new EntidadProveedor();
                VistaProveedor proveedor = entidadProveedor.BuscarProveedor(idProveedor);
                lblIDProveedor.Text = proveedor.IDProveedor.ToString();
                lblRFCProveedor.Text = proveedor.RFC;
                lblNombreProveedor.Text = proveedor.Nombre;
            }
            catch (Exception e)
            {
                Mensaje.Mostrar(this, e.Message);
            }
        }

        public void CargarProveedoresDomicilios(int idProveedor)
        {
            try
            {
                EntidadProveedor proveedor = new EntidadProveedor();
                gvwProveedoresDomicilios.DataSource = proveedor.ObtenerDomiciliosActivos(idProveedor);
                gvwProveedoresDomicilios.DataBind();
            }
            catch (Exception e)
            {
                Mensaje.Mostrar(this, e.Message);
            }
        }

        public void SeleccionarDomicilio(int idProveedor, int idDomicilio)
        {
            try
            {
                EntidadProveedor entidadProveedor = new EntidadProveedor();
                VistaProveedorDomicilio domicilio = entidadProveedor.ObtenerDomicilio(idProveedor, idDomicilio);
                txtCalle.Text = domicilio.Calle;
                txtNumeroExterior.Text = domicilio.NoExterior;
                txtNumeroInterior.Text = domicilio.NoInterior;
                txtColonia.Text = domicilio.Colonia;
                txtLocalidad.Text = domicilio.Localidad;
                txtReferencia.Text = domicilio.Referencia;
                txtMunicipio.Text = domicilio.Municipio;
                txtEstado.Text = domicilio.Estado;
                txtPais.Text = domicilio.Pais;
                txtCodigoPostal.Text = domicilio.CodigoPostal;
                gvwProveedoresDomicilios.SelectedRow.BackColor = System.Drawing.Color.Orange;
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message);
            }
        }

        public void AgregarDomicilio(int idProveedor, string calle, string numeroExterior, string numeroInterior, string colonia, string localidad, string referencia, string municipio, string estado, string pais, string codigoPostal)
        {
            try
            {
                EntidadProveedor proveedor = new EntidadProveedor();
                string mensaje;
                proveedor.AgregarDomicilio(idProveedor, calle, numeroExterior, numeroInterior, colonia, localidad, referencia, municipio, estado, pais, codigoPostal, out mensaje);
                Limpiar();
                CargarProveedoresDomicilios(idProveedor);
                Mensaje.Mostrar(this, mensaje);
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message);
            }
        }

        public void ActualizarDomicilio(int idProveedor, int idDomicilio, string calle, string numeroExterior, string numeroInterior, string colonia, string localidad, string referencia, string municipio, string estado, string pais, string codigoPostal)
        {
            try
            {
                EntidadProveedor proveedor = new EntidadProveedor();
                string mensaje;
                proveedor.ActualizarDomicilio(idProveedor, idDomicilio, calle, numeroExterior, numeroInterior, colonia, localidad, referencia, municipio, estado, pais, codigoPostal, out mensaje);
                Limpiar();
                CargarProveedoresDomicilios(idProveedor);
                Mensaje.Mostrar(this, mensaje);
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message);
            }
        }

        public void EliminarDomicilio(int idProveedor, int idDomicilio)
        {
            try
            {
                EntidadProveedor proveedor = new EntidadProveedor();
                string mensaje;
                proveedor.EstablecerDomicilioActivo(idProveedor, idDomicilio, false, out mensaje);
                Limpiar();
                CargarProveedoresDomicilios(idProveedor);
                Mensaje.Mostrar(this, mensaje);
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message);
            }
        }

        protected void VerReporteProveedoresDomicilios(int idProveedor)
        {
            //Response.Redirect("~/Sistema/Reportes/Proveedores/ReporteProveedorDomicilio.aspx?idProveedor=" + idProveedor);
        }

        public void Limpiar()
        {
            txtCalle.Text = string.Empty;
            txtNumeroExterior.Text = string.Empty;
            txtNumeroInterior.Text = string.Empty;
            txtColonia.Text = string.Empty;
            txtLocalidad.Text = string.Empty;
            txtReferencia.Text = string.Empty;
            txtMunicipio.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtPais.Text = string.Empty;
            txtCodigoPostal.Text = string.Empty;
        }
    }
}