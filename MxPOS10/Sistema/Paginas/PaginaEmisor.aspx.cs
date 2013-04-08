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
    public partial class NEW__PaginaEmisor : System.Web.UI.Page
    {

        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        //      EVENTOS DE LA PÁGINA
        //----------------------------------------------------------------------------------------------------------------------------------------------------------

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarEmisores();
        }

        protected void gvwEmisores_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idEmisor = int.Parse(gvwEmisores.SelectedRow.Cells[1].Text);
            SeleccionarEmisor(idEmisor);
        }

        protected void btnAgregarEmisor_Click(object sender, EventArgs e)
        {
            AgregarEmisor(txtRFC.Text, txtNombre.Text);
            Limpiar();
        }

        protected void btnActualizarEmisor_Click(object sender, EventArgs e)
        {
            if (gvwEmisores.SelectedRow != null)
            {
                int idEmisor = int.Parse(gvwEmisores.SelectedRow.Cells[1].Text);
                ActualizarEmisor(idEmisor, txtRFC.Text, txtNombre.Text);
                Limpiar();
            }
        }

        protected void btnEliminarEmisor_Click(object sender, EventArgs e)
        {
            if (gvwEmisores.SelectedRow != null)
            {
                int idEmisor = int.Parse(gvwEmisores.SelectedRow.Cells[1].Text);
                EliminarEmisor(idEmisor);
                Limpiar();
            }
        }

        protected void btnReporteEmisores_Click(object sender, EventArgs e)
        {
            VerReporteEmisores();
        }

        protected void btnDomiciliosFiscales_Click(object sender, EventArgs e)
        {
            if (gvwEmisores.SelectedRow != null)
            {
                int idEmisor = int.Parse(gvwEmisores.SelectedRow.Cells[1].Text);
                VerDomiciliosFiscales(idEmisor);
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        //      FUNCIONES DE LA PÁGINA
        //----------------------------------------------------------------------------------------------------------------------------------------------------------

        public void CargarEmisores()
        {
            try
            {
                EntidadEmisor emisores = new EntidadEmisor();
                gvwEmisores.DataSource = emisores.ObtenerEmisoresActivos();
                gvwEmisores.DataBind();
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message);
            }
        }

        public void SeleccionarEmisor(int idEmisor)
        {
            try
            {
                EntidadEmisor entidadEmisor = new EntidadEmisor();
                Emisores emisor = entidadEmisor.BuscarEmisor(idEmisor);
                lblID.Text = emisor.IDEmisor.ToString();
                txtRFC.Text = emisor.CFDI32_Req_RFC;
                txtNombre.Text = emisor.CFDI32_Opc_Nombre;
                gvwEmisores.SelectedRow.BackColor = System.Drawing.Color.Orange;

            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message);
            }
        }

        public void AgregarEmisor(string rfc, string nombre)
        {
            try
            {
                EntidadEmisor emisor = new EntidadEmisor();
                string mensaje;
                emisor.AgregarEmisor(rfc, nombre, out mensaje);
                Mensaje.Mostrar(this, mensaje);
                CargarEmisores();
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message);
            }
        }

        public void ActualizarEmisor(int idEmisor, string rfc, string nombre)
        {
            try
            {
                string mensaje;
                EntidadEmisor emisor = new EntidadEmisor();
                emisor.ActualizarEmisor(idEmisor, rfc, nombre, out mensaje);
                Mensaje.Mostrar(this, mensaje);
                CargarEmisores();
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message);
            }
        }

        public void EliminarEmisor(int idEmisor)
        {
            try
            {
                string mensaje;
                EntidadEmisor emisor = new EntidadEmisor();
                emisor.EstablecerEmisorActivo(idEmisor, false, out mensaje);
                Mensaje.Mostrar(this, mensaje);
                CargarEmisores();
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message);
            }
        }

        public void VerReporteEmisores()
        {
            Response.Redirect("~/Sistema/Reportes/Emisores/ReporteEmisor.aspx");
        }

        public void VerDomiciliosFiscales(int idEmisor)
        {
            Limpiar();
            Response.Redirect("~/Sistema/Paginas/PaginaDomicilioFiscal.aspx?idEmisor=" + idEmisor);
        }

        public void Limpiar()
        {
            lblID.Text = string.Empty;
            txtRFC.Text = string.Empty;
            txtNombre.Text = string.Empty;
        }
    }
}