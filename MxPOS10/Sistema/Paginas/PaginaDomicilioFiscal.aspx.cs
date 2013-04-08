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
    public partial class NEW__DomicilioFiscal : System.Web.UI.Page
    {
        public int idEmisor;

        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        //      EVENTOS DE LA PÁGINA
        //----------------------------------------------------------------------------------------------------------------------------------------------------------

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["idEmisor"] != null)
            {
                idEmisor = int.Parse(Request.QueryString["idEmisor"]);
                CargarEmisor(idEmisor);
                CargarDomiciliosFiscales(idEmisor);
            }
            else
            {
                btnAgregarDomicilioFiscal.Enabled = false;
                btnActualizarDomicilioFiscal.Enabled = false;
                btnEliminarDomicilioFiscal.Enabled = false;
                Mensaje.Mostrar(this, "Parece que has llegado a esta página por error, el ID del emisor no es válido");
            }
        }
        
        protected void btnAgregarDomicilioFiscal_Click(object sender, EventArgs e)
        {
            AgregarDomicilioFiscal(idEmisor, txtCalle.Text, txtNumeroExterior.Text, txtNumeroInterior.Text, txtColonia.Text, txtLocalidad.Text, txtReferencia.Text, txtMunicipio.Text, txtEstado.Text, txtPais.Text, txtCodigoPostal.Text);
            Limpiar();
        }

        protected void btnActualizarDomicilioFiscal_Click(object sender, EventArgs e)
        {
            if (gvwDomiciliosFiscales.SelectedRow != null)
            {
                int idDomicilioFiscal = int.Parse(gvwDomiciliosFiscales.SelectedRow.Cells[1].Text);
                ActualizarDomicilioFiscal(idEmisor, idDomicilioFiscal, txtCalle.Text, txtNumeroExterior.Text, txtNumeroInterior.Text, txtColonia.Text, txtLocalidad.Text, txtReferencia.Text, txtMunicipio.Text, txtEstado.Text, txtPais.Text, txtCodigoPostal.Text);
                Limpiar();
            }
        }

        protected void btnEliminarDomicilioFiscal_Click(object sender, EventArgs e)
        {
            if (gvwDomiciliosFiscales.SelectedRow != null)
            {
                int idDomicilioFiscal = int.Parse(gvwDomiciliosFiscales.SelectedRow.Cells[1].Text);
                EliminarDomicilioFiscal(idEmisor, idDomicilioFiscal);
                Limpiar();
            }
        }

        protected void gvwDomiciliosFiscales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvwDomiciliosFiscales.SelectedRow != null)
            {
                int idDomicilioFiscal = int.Parse(gvwDomiciliosFiscales.SelectedRow.Cells[1].Text);
                SeleccionarDomicilioFiscal(idEmisor, idDomicilioFiscal);
            }
        }

        protected void ReporteDomiciliosFiscales_Click(object sender, EventArgs e)
        {
            VerReporteDomiciliosFiscales(idEmisor);
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        //      FUNCIONES DE LA PÁGINA
        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        
        public void CargarEmisor(int idEmisor)
        {
            try
            {
                EntidadEmisor entidadEmisor = new EntidadEmisor();
                Emisores emisor = entidadEmisor.BuscarEmisor(idEmisor);
                lblIDEmisor.Text = emisor.IDEmisor.ToString();
                lblRFCEmisor.Text = emisor.CFDI32_Req_RFC;
                lblNombreEmisor.Text = emisor.CFDI32_Opc_Nombre;
            }
            catch (Exception e)
            {
                Mensaje.Mostrar(this, e.Message);
            }
        }

        public void CargarDomiciliosFiscales(int idEmisor)
        {
            try
            {
                EntidadEmisor emisor = new EntidadEmisor();
                gvwDomiciliosFiscales.DataSource = emisor.ObtenerDomiciliosFiscalesActivos(idEmisor);
                gvwDomiciliosFiscales.DataBind();
            }
            catch (Exception e)
            {
                Mensaje.Mostrar(this, e.Message);
            }
        }

        public void SeleccionarDomicilioFiscal(int idEmisor, int idDomicilioFiscal)
        {
            try
            {
                EntidadEmisor entidadEmisor = new EntidadEmisor();
                DomiciliosFiscales domicilioFiscal = entidadEmisor.ObtenerDomicilioFiscal(idEmisor, idDomicilioFiscal);
                txtCalle.Text = domicilioFiscal.CFDI32_Req_Calle;
                txtNumeroExterior.Text = domicilioFiscal.CFDI32_Opc_NoExterior;
                txtNumeroInterior.Text = domicilioFiscal.CFDI32_Opc_NoInterior;
                txtColonia.Text = domicilioFiscal.CFDI32_Opc_Colonia;
                txtLocalidad.Text = domicilioFiscal.CFDI32_Opc_Localidad;
                txtReferencia.Text = domicilioFiscal.CFDI32_Opc_Referencia;
                txtMunicipio.Text = domicilioFiscal.CFDI32_Req_Municipio;
                txtEstado.Text = domicilioFiscal.CFDI32_Req_Estado;
                txtPais.Text = domicilioFiscal.CFDI32_Req_Pais;
                txtCodigoPostal.Text = domicilioFiscal.CFDI32_Req_CodigoPostal;
                gvwDomiciliosFiscales.SelectedRow.BackColor = System.Drawing.Color.Orange;
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message);
            }
        }

        public void AgregarDomicilioFiscal(int idEmisor, string calle, string numeroExterior, string numeroInterior, string colonia, string localidad, string referencia, string municipio, string estado, string pais, string codigoPostal)
        {
            try
            {
                EntidadEmisor emisor = new EntidadEmisor();
                string mensaje;
                emisor.AgregarDomicilioFiscal(idEmisor, calle, numeroExterior, numeroInterior, colonia, localidad, referencia, municipio, estado, pais, codigoPostal, out mensaje);
                Limpiar();
                CargarDomiciliosFiscales(idEmisor);
                Mensaje.Mostrar(this, mensaje);
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message);
            }
        }

        public void ActualizarDomicilioFiscal(int idEmisor, int idDomicilioFiscal, string calle, string numeroExterior, string numeroInterior, string colonia, string localidad, string referencia, string municipio, string estado, string pais, string codigoPostal)
        {
            try
            {
                EntidadEmisor emisor = new EntidadEmisor();
                string mensaje;
                emisor.ActualizarDomicilioFiscal(idEmisor, idDomicilioFiscal, calle, numeroExterior, numeroInterior, colonia, localidad, referencia, municipio, estado, pais, codigoPostal, out mensaje);
                Limpiar();
                CargarDomiciliosFiscales(idEmisor);
                Mensaje.Mostrar(this, mensaje);
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message);
            }
        }

        public void EliminarDomicilioFiscal(int idEmisor, int idDomicilioFiscal)
        {
            try
            {
                EntidadEmisor emisor = new EntidadEmisor();
                string mensaje;
                emisor.EstablecerDomicilioFiscalActivo(idEmisor, idDomicilioFiscal, false, out mensaje);
                Limpiar();
                CargarDomiciliosFiscales(idEmisor);
                Mensaje.Mostrar(this, mensaje);
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message);
            }
        }

        public void VerReporteDomiciliosFiscales(int idEmisor)
        {
            Response.Redirect("~/Sistema/Reportes/Emisores/ReporteEmisorDomicilioFiscal.aspx?idEmisor=" + idEmisor);
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