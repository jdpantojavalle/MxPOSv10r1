using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxPOS10.Sistema.Datos;
using MxPOS10.Sistema.Entidades;
using MxPOS10.Sistema.Utilidades;

namespace MxPOS10.Sistema.Paginas
{
    public partial class PaginaDomicilio : System.Web.UI.Page
    {
        public int idReceptor;

        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        //      EVENTOS DE LA PÁGINA
        //----------------------------------------------------------------------------------------------------------------------------------------------------------

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["idReceptor"] != null)
            {
                idReceptor = int.Parse(Request.QueryString["idReceptor"]);
                CargarReceptor(idReceptor);
                CargarDomicilios(idReceptor);
            }
            else
            {
                btnAgregarDomicilio.Enabled = false;
                btnActualizarDomicilio.Enabled = false;
                btnEliminarDomicilio.Enabled = false;
                Mensaje.Mostrar(this, "Parece que has llegado a esta página por error, el ID del receptor no es válido");
            }
        }

        protected void btnAgregarDomicilio_Click(object sender, EventArgs e)
        {
            AgregarDomicilio(idReceptor, txtCalle.Text, txtNumeroExterior.Text, txtNumeroInterior.Text, txtColonia.Text, txtLocalidad.Text, txtReferencia.Text, txtMunicipio.Text, txtEstado.Text, txtPais.Text, txtCodigoPostal.Text);
            Limpiar();
        }

        protected void btnActualizarDomicilio_Click(object sender, EventArgs e)
        {
            if (gvwDomicilios.SelectedRow != null)
            {
                int idDomicilio = int.Parse(gvwDomicilios.SelectedRow.Cells[1].Text);
                ActualizarDomicilio(idReceptor, idDomicilio, txtCalle.Text, txtNumeroExterior.Text, txtNumeroInterior.Text, txtColonia.Text, txtLocalidad.Text, txtReferencia.Text, txtMunicipio.Text, txtEstado.Text, txtPais.Text, txtCodigoPostal.Text);
                Limpiar();
            }
        }

        protected void btnEliminarDomicilio_Click(object sender, EventArgs e)
        {
            if (gvwDomicilios.SelectedRow != null)
            {
                int idDomicilio = int.Parse(gvwDomicilios.SelectedRow.Cells[1].Text);
                EliminarDomicilio(idReceptor, idDomicilio);
                Limpiar();
            }
        }

        protected void gvwDomicilios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvwDomicilios.SelectedRow != null)
            {
                int idDomicilio = int.Parse(gvwDomicilios.SelectedRow.Cells[1].Text);
                SeleccionarDomicilio(idReceptor, idDomicilio);
            }
        }

        protected void btnReporteDomicilios_Click(object sender, EventArgs e)
        {
            VerReporteDomicilios(idReceptor);
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        //      FUNCIONES DE LA PÁGINA
        //----------------------------------------------------------------------------------------------------------------------------------------------------------

        public void CargarReceptor(int idReceptor)
        {
            try
            {
                EntidadReceptor entidadReceptor = new EntidadReceptor();
                Receptores receptor = entidadReceptor.BuscarReceptor(idReceptor);
                lblIDReceptor.Text = receptor.IDReceptor.ToString();
                lblRFCReceptor.Text = receptor.CFDI32_Req_RFC;
                lblNombreReceptor.Text = receptor.CFDI32_Opc_Nombre;
            }
            catch (Exception e)
            {
                Mensaje.Mostrar(this, e.Message);
            }
        }

        public void CargarDomicilios(int idReceptor)
        {
            try
            {
                EntidadReceptor receptor = new EntidadReceptor();
                gvwDomicilios.DataSource = receptor.ObtenerDomiciliosActivos(idReceptor);
                gvwDomicilios.DataBind();
            }
            catch (Exception e)
            {
                Mensaje.Mostrar(this, e.Message);
            }
        }

        public void SeleccionarDomicilio(int idReceptor, int idDomicilio)
        {
            try
            {
                EntidadReceptor entidadReceptor = new EntidadReceptor();
                Domicilios domicilio = entidadReceptor.ObtenerDomicilio(idReceptor, idDomicilio);
                txtCalle.Text = domicilio.CFDI32_Opc_Calle;
                txtNumeroExterior.Text = domicilio.CFDI32_Opc_NoExterior;
                txtNumeroInterior.Text = domicilio.CFDI32_Opc_NoInterior;
                txtColonia.Text = domicilio.CFDI32_Opc_Colonia;
                txtLocalidad.Text = domicilio.CFDI32_Opc_Localidad;
                txtReferencia.Text = domicilio.CFDI32_Opc_Referencia;
                txtMunicipio.Text = domicilio.CFDI32_Opc_Municipio;
                txtEstado.Text = domicilio.CFDI32_Opc_Estado;
                txtPais.Text = domicilio.CFDI32_Req_Pais;
                txtCodigoPostal.Text = domicilio.CFDI32_Opc_CodigoPostal;
                gvwDomicilios.SelectedRow.BackColor = System.Drawing.Color.Orange;
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message);
            }
        }

        public void AgregarDomicilio(int idReceptor, string calle, string numeroExterior, string numeroInterior, string colonia, string localidad, string referencia, string municipio, string estado, string pais, string codigoPostal)
        {
            try
            {
                EntidadReceptor receptor = new EntidadReceptor();
                string mensaje;
                receptor.AgregarDomicilio(idReceptor, calle, numeroExterior, numeroInterior, colonia, localidad, referencia, municipio, estado, pais, codigoPostal, out mensaje);
                Limpiar();
                CargarDomicilios(idReceptor);
                Mensaje.Mostrar(this, mensaje);
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message);
            }
        }

        public void ActualizarDomicilio(int idReceptor, int idDomicilio, string calle, string numeroExterior, string numeroInterior, string colonia, string localidad, string referencia, string municipio, string estado, string pais, string codigoPostal)
        {
            try
            {
                EntidadReceptor receptor = new EntidadReceptor();
                string mensaje;
                receptor.ActualizarDomicilio(idReceptor, idDomicilio, calle, numeroExterior, numeroInterior, colonia, localidad, referencia, municipio, estado, pais, codigoPostal, out mensaje);
                Limpiar();
                CargarDomicilios(idReceptor);
                Mensaje.Mostrar(this, mensaje);
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message);
            }
        }

        public void EliminarDomicilio(int idReceptor, int idDomicilio)
        {
            try
            {
                EntidadReceptor receptor = new EntidadReceptor();
                string mensaje;
                receptor.EstablecerDomicilioActivo(idReceptor, idDomicilio, false, out mensaje);
                Limpiar();
                CargarDomicilios(idReceptor);
                Mensaje.Mostrar(this, mensaje);
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message);
            }
        }

        protected void VerReporteDomicilios(int idReceptor)
        {
            Response.Redirect("~/Sistema/Reportes/Receptores/ReporteReceptorDomicilio.aspx?idReceptor=" + idReceptor);
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