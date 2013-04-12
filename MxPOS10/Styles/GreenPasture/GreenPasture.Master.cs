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

<<<<<<< HEAD
        /// <summary>
        /// Creacion del menu. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Init(object sender, EventArgs e)
        {
            //By Mary Rios 09/04/2013

=======
        protected void Page_Init(object sender, EventArgs e)
        {
            //string url = Request.Path;
>>>>>>> 0369f36ace47b082342787a9a158a23a1f3de338
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

<<<<<<< HEAD
        /// <summary>
        /// Verifica si la pagina que recibe es la pagina actual.
        /// </summary>
        /// <param name="page">URL</param>
        /// <returns>True:La pagina es la actual. False:La pagina no es la actual</returns>
=======
>>>>>>> 0369f36ace47b082342787a9a158a23a1f3de338
        public string CurrentPage (string page)
        {
            if (("/Sistema/Paginas/" + page).Equals(Request.Path))
                return "class=\"current_page_item\"";
            return "";
        }
    }
}