using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxPOS10.Sistema.Utilidades;
using Microsoft.Reporting.WebForms;

namespace MxPOS10.Sistema.Reportes.Emisores
{
    public partial class ReporteEmisorDomicilioFiscal : System.Web.UI.Page
    {
        public int idEmisor;
        public ReporteEmisor reporte;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["idEmisor"] != null)
            {
                idEmisor = int.Parse(Request.QueryString["idEmisor"]);
                reporte = new ReporteEmisor();
                rpvEmisoresDomiciliosFiscales.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(ProcesarSubreporte);
            }
            else
            {
                Mensaje.Mostrar(this, "Parece que has llegado a esta página por error, el ID del emisor no es válido");
            }
        }

        void ProcesarSubreporte(object sender, SubreportProcessingEventArgs e)
        {
            e.DataSources.Add(new ReportDataSource("dsEmisoresDomiciliosFiscalesSubreportes", reporte.ObtenerDomiciliosFiscalesActivos(idEmisor)));
        }
    }
}