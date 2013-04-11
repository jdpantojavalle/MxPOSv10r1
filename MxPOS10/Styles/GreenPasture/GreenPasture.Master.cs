using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxPOS10.Styles.Greenpasture
{
    public partial class Greenpasture : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Creacion del menu. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Init(object sender, EventArgs e)
        {
            //By Mary Rios 09/04/2013

            string menu ="";
            phlMenu.Controls.Add(new LiteralControl("<ul>"));
            menu = "<li " + CurrentPage("PaginaEmisor.aspx") + ">  <a href=\"PaginaEmisor.aspx\" accesskey=\"1\" title=\"\">EMISORES</a></li>" +
                    "<li " + CurrentPage("PaginaReceptor.aspx") + ">  <a href=\"PaginaReceptor.aspx\" accesskey=\"2\" title=\"\">RECEPTORES</a></li> " +
                    "<li " + CurrentPage("") + ">  <a href=\"#\" accesskey=\"3\" title=\"\">PRÓXIMAMENTE</a></li>" +
                    "<li " + CurrentPage("") + ">  <a href=\"#\" accesskey=\"4\" title=\"\">PRÓXIMAMENTE</a></li>" +
                    "<li " + CurrentPage("") + ">  <a href=\"#\" accesskey=\"5\" title=\"\">PRÓXIMAMENTE</a></li>";
            
            phlMenu.Controls.Add(new LiteralControl(menu));
            phlMenu.Controls.Add(new LiteralControl("</ul>"));
        }

        /// <summary>
        /// Verifica si la pagina que recibe es la pagina actual.
        /// </summary>
        /// <param name="page">URL</param>
        /// <returns>True:La pagina es la actual. False:La pagina no es la actual</returns>
        public string CurrentPage (string page)
        {
            if (("/Sistema/Paginas/" + page).Equals(Request.Path))
                return "class=\"current_page_item\"";
            return "";
        }
    }
}