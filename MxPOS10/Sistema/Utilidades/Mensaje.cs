
/*
 * MxPOS 1.0
 * 
 * Elemento: Mensaje
 * Tipo: Clase C#
 * 
 * Descripción: Utileria para enviar mensajes al usuario via JavaScript
 * Desarrollado por: Juan David Pantoja Valle
 *
 * Revisión: N/A
 * Revisado por: N/A
 * 
 * Notas: N/A
 * 
 * Pendientes: N/A
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace MxPOS10.Sistema.Utilidades
{
    public static class Mensaje
    {
        public static void Mostrar(Page pagina, string mensaje)
        {
            string alerta = String.Format("<script type='text/javascript' language='javascript'> alert('{0}'); </script>", mensaje);
            pagina.Response.Write(alerta);
        }
    }
}