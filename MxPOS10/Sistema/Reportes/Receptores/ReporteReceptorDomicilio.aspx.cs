using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxPOS10.Sistema.Utilidades;
using Microsoft.Reporting.WebForms;

namespace MxPOS10.Sistema.Reportes.Receptores
{
    public partial class ReporteReceptorDomicilio : System.Web.UI.Page
    {
        public int idReceptor;
        public ReporteReceptor reporte;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["idReceptor"] != null)
            {
                idReceptor = int.Parse(Request.QueryString["idReceptor"]);
                reporte = new ReporteReceptor();
                rpvReceptoresDomicilios.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(ProcesarSubreporte);
            }
            else
            {
                Mensaje.Mostrar(this, "Parece que has llegado a esta página por error, el ID del receptor no es válido");
            }
        }

        void ProcesarSubreporte(object sender, SubreportProcessingEventArgs e)
        {
            e.DataSources.Add(new ReportDataSource("dsReceptoresDomiciliosSubreportes", reporte.ObtenerDomiciliosActivos(idReceptor)));
        }
    }
}