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
    public partial class PaginaReceptor : System.Web.UI.Page
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        //      EVENTOS DE LA PÁGINA
        //----------------------------------------------------------------------------------------------------------------------------------------------------------

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarReceptores();
        }

        protected void gvwReceptores_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idReceptor = int.Parse(gvwReceptores.SelectedRow.Cells[1].Text);
            SeleccionarReceptor(idReceptor);
        }

        protected void btnAgregarReceptor_Click(object sender, EventArgs e)
        {
            AgregarReceptor(txtRFC.Text, txtNombre.Text);
            Limpiar();
        }

        protected void btnActualizarReceptor_Click(object sender, EventArgs e)
        {
            if (gvwReceptores.SelectedRow != null)
            {
                int idReceptor = int.Parse(gvwReceptores.SelectedRow.Cells[1].Text);
                ActualizarReceptor(idReceptor, txtRFC.Text, txtNombre.Text);
                Limpiar();
            }
        }

        protected void btnEliminarReceptor_Click(object sender, EventArgs e)
        {
            if (gvwReceptores.SelectedRow != null)
            {
                int idReceptor = int.Parse(gvwReceptores.SelectedRow.Cells[1].Text);
                EliminarReceptor(idReceptor);
                Limpiar();
            }
        }

        protected void btnDomiciliosFiscales_Click(object sender, EventArgs e)
        {
            if (gvwReceptores.SelectedRow != null)
            {
                int idReceptor = int.Parse(gvwReceptores.SelectedRow.Cells[1].Text);
                VerDomicilios(idReceptor);
            }
        }

        protected void btnReporteReceptores_Click(object sender, EventArgs e)
        {
            VerReporteReceptores();
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        //      FUNCIONES DE LA PÁGINA
        //----------------------------------------------------------------------------------------------------------------------------------------------------------

        public void CargarReceptores()
        {
            try
            {
                EntidadReceptor receptores = new EntidadReceptor();
                gvwReceptores.DataSource = receptores.ObtenerReceptoresActivos();
                gvwReceptores.DataBind();
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message);
            }
        }

        public void SeleccionarReceptor(int idReceptor)
        {
            try
            {
                EntidadReceptor entidadReceptor = new EntidadReceptor();
                Receptores receptor = entidadReceptor.BuscarReceptor(idReceptor);
                lblID.Text = receptor.IDReceptor.ToString();
                txtRFC.Text = receptor.CFDI32_Req_RFC;
                txtNombre.Text = receptor.CFDI32_Opc_Nombre;
                gvwReceptores.SelectedRow.BackColor = System.Drawing.Color.Orange;

            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message);
            }
        }

        public void AgregarReceptor(string rfc, string nombre)
        {
            try
            {
                EntidadReceptor receptor = new EntidadReceptor();
                string mensaje;
                receptor.AgregarReceptor(rfc, nombre, out mensaje);
                Mensaje.Mostrar(this, mensaje);
                CargarReceptores();
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message);
            }
        }

        public void ActualizarReceptor(int idReceptor, string rfc, string nombre)
        {
            try
            {
                string mensaje;
                EntidadReceptor receptor = new EntidadReceptor();
                receptor.ActualizarReceptor(idReceptor, rfc, nombre, out mensaje);
                Mensaje.Mostrar(this, mensaje);
                CargarReceptores();
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message);
            }
        }

        public void EliminarReceptor(int idReceptor)
        {
            try
            {
                string mensaje;
                EntidadReceptor receptor = new EntidadReceptor();
                receptor.EstablecerReceptorActivo(idReceptor, false, out mensaje);
                Mensaje.Mostrar(this, mensaje);
                CargarReceptores();
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(this, ex.Message);
            }
        }

        public void VerReporteReceptores()
        {
            Response.Redirect("~/Sistema/Reportes/Receptores/ReporteReceptor.aspx");
        }

        public void VerDomicilios(int idReceptor)
        {
            Limpiar();
            Response.Redirect("~/Sistema/Paginas/PaginaDomicilio.aspx?idReceptor=" + idReceptor);
        }

        public void Limpiar()
        {
            lblID.Text = string.Empty;
            txtRFC.Text = string.Empty;
            txtNombre.Text = string.Empty;
        }
    }
}