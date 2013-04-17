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
    public partial class PaginaDomicilioProveedor : System.Web.UI.Page
    {
        public int idProveedor;

        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        //      EVENTOS DE LA PÁGINA
        //----------------------------------------------------------------------------------------------------------------------------------------------------------

        protected void Page_Load(object sender, EventArgs ex)
        {
            if (Request.QueryString["idProveedor"] != null)
            {
                idProveedor = int.Parse(Request.QueryString["idProveedor"]);
                CargarProveedor(idProveedor);
                CargarDomicilios(idProveedor);

                if (!IsPostBack)
                {
                    SeleccionarDomicilioPorIndice(0);
                }
            }
            else
            {
                Mensaje.Mostrar(this, "Parece que has llegado a esta página por error ya que no se proporciono un ID de proveedor, serás redireccionado a la página de proveedores");
                Response.Redirect("~/Sistema/Paginas/PaginaProveedor.aspx");
            }
        }

        protected void btnAgregarDomicilio_Click(object sender, EventArgs ex)
        {
            AgregarDomicilio(idProveedor, txtCalle.Text, txtNumeroExterior.Text, txtNumeroInterior.Text, txtColonia.Text, txtLocalidad.Text, txtReferencia.Text, txtMunicipio.Text, txtEstado.Text, txtPais.Text, txtCodigoPostal.Text);
        }

        protected void btnActualizarDomicilio_Click(object sender, EventArgs ex)
        {
            if (gvwDomicilios.SelectedRow != null)
            {
                int idDomicilio = int.Parse(gvwDomicilios.SelectedRow.Cells[1].Text);
                ActualizarDomicilio(idProveedor, idDomicilio, txtCalle.Text, txtNumeroExterior.Text, txtNumeroInterior.Text, txtColonia.Text, txtLocalidad.Text, txtReferencia.Text, txtMunicipio.Text, txtEstado.Text, txtPais.Text, txtCodigoPostal.Text);
            }
        }

        protected void btnEliminarDomicilio_Click(object sender, EventArgs ex)
        {
            if (gvwDomicilios.SelectedRow != null)
            {
                int idDomicilio = int.Parse(gvwDomicilios.SelectedRow.Cells[1].Text);
                EliminarDomicilio(idProveedor, idDomicilio);
            }
        }

        protected void gvwDomicilios_SelectedIndexChanged(object sender, EventArgs ex)
        {
            SeleccionarDomicilioPorIndice(gvwDomicilios.SelectedIndex);
        }

        protected void btnReporteDomicilios_Click(object sender, EventArgs ex)
        {
            VerReporteDomicilios(idProveedor);
        }

        protected void btnSeleccionarDomicilio_Click(object sender, EventArgs e)
        {
            if (gvwDomicilios.SelectedRow != null)
            {
                int idDomicilio = int.Parse(gvwDomicilios.SelectedRow.Cells[1].Text);
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
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, "Parece que has llegado a esta página por error ya que el ID del proveedor no es válido o no existe, serás redireccionado a la página de proveedores");
                Response.Redirect("~/Sistema/Paginas/PaginaProveedor.aspx");
            }
        }

        public void CargarDomicilios(int idProveedor)
        {
            try
            {
                EntidadProveedor proveedor = new EntidadProveedor();
                List<VistaProveedorDomicilio> domiciliosActivos = proveedor.ObtenerDomiciliosActivos(idProveedor);

                gvwDomicilios.DataSource = proveedor.ObtenerDomiciliosActivos(idProveedor);
                gvwDomicilios.DataBind();

                if (domiciliosActivos.Count > 0)
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

        public void SeleccionarDomicilioPorIndice(int indiceDomicilio)
        {
            try
            {
                if (gvwDomicilios.Rows.Count > 0)
                {
                    gvwDomicilios.SelectedIndex = indiceDomicilio;
                    gvwDomicilios.SelectedRow.BackColor = System.Drawing.Color.Orange;
                    int idDomicilio = int.Parse(gvwDomicilios.SelectedRow.Cells[1].Text);
                    SeleccionarDomicilioPorID(idProveedor, idDomicilio);
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

        public void SeleccionarDomicilioPorID(int idProveedor, int idDomicilio)
        {
            try
            {
                EntidadProveedor entidadProveedor = new EntidadProveedor();
                VistaProveedorDomicilio domicilio = entidadProveedor.ObtenerDomicilio(idProveedor, idDomicilio);
                lblSeleccionado.Text = domicilio.Seleccionado.ToString();
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
                gvwDomicilios.SelectedRow.BackColor = System.Drawing.Color.Orange;
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message + ": " + ex.InnerException.Message);
            }
        }

        public void AgregarDomicilio(int idProveedor, string calle, string numeroExterior, string numeroInterior, string colonia, string localidad, string referencia, string municipio, string estado, string pais, string codigoPostal)
        {
            try
            {
                EntidadProveedor proveedor = new EntidadProveedor();
                string mensaje;
                proveedor.AgregarDomicilio(idProveedor, calle, numeroExterior, numeroInterior, colonia, localidad, referencia, municipio, estado, pais, codigoPostal, out mensaje);
                Mensaje.Mostrar(this, mensaje);
                CargarProveedor(idProveedor);
                CargarDomicilios(idProveedor);
                SeleccionarDomicilioPorIndice(gvwDomicilios.Rows.Count - 1);
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message + ": " + ex.InnerException.Message);
            }
        }

        public void ActualizarDomicilio(int idProveedor, int idDomicilio, string calle, string numeroExterior, string numeroInterior, string colonia, string localidad, string referencia, string municipio, string estado, string pais, string codigoPostal)
        {
            try
            {
                EntidadProveedor proveedor = new EntidadProveedor();
                string mensaje;
                proveedor.ActualizarDomicilio(idProveedor, idDomicilio, calle, numeroExterior, numeroInterior, colonia, localidad, referencia, municipio, estado, pais, codigoPostal, out mensaje);
                Mensaje.Mostrar(this, mensaje);
                CargarProveedor(idProveedor);
                CargarDomicilios(idProveedor);
                SeleccionarDomicilioPorIndice(gvwDomicilios.SelectedIndex);
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message + ": " + ex.InnerException.Message);
            }
        }

        public void EliminarDomicilio(int idProveedor, int idDomicilio)
        {
            try
            {
                EntidadProveedor proveedor = new EntidadProveedor();
                string mensaje;
                proveedor.EstablecerDomicilioActivo(idProveedor, idDomicilio, false, out mensaje);
                Mensaje.Mostrar(this, mensaje);
                CargarProveedor(idProveedor);
                CargarDomicilios(idProveedor);
                SeleccionarDomicilioPorIndice(0);
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message + ": " + ex.InnerException.Message);
            }
        }

        public void SeleccionarDomicilio(int idProveedor, int idDomicilio)
        {
            try
            {
                EntidadProveedor proveedor = new EntidadProveedor();
                string mensaje;
                proveedor.EstablecerDomicilioSeleccionado(idProveedor, idDomicilio, out mensaje);
                Mensaje.Mostrar(this, mensaje);
                CargarProveedor(idProveedor);
                CargarDomicilios(idProveedor);
                SeleccionarDomicilioPorIndice(gvwDomicilios.SelectedIndex);
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message + ": " + ex.InnerException.Message);
            }
        }

        protected void VerReporteDomicilios(int idProveedor)
        {
            Response.Redirect("~/Sistema/Reportes/Proveedores/ReporteProveedorDomicilio.aspx?idProveedor=" + idProveedor);
        }

        public void HabilitarControles()
        {
            btnReporteDomicilios.Enabled = true;
            btnSeleccionarDomicilio.Enabled = true;
            btnActualizarDomicilio.Enabled = true;
            btnEliminarDomicilio.Enabled = true;
        }

        public void DesHabilitarControles()
        {
            btnReporteDomicilios.Enabled = false;
            btnSeleccionarDomicilio.Enabled = false;
            btnActualizarDomicilio.Enabled = false;
            btnEliminarDomicilio.Enabled = false;
        }

        public void LimpiarDatos()
        {
            lblSeleccionado.Text = string.Empty;
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