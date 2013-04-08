
/*
 * MxPOS 1.0
 * 
 * Elemento: VistaReceptor
 * Tipo: Clase
 * Descripción: Representa todas las propiedades de un objeto receptor
 * Desarrollado por: Juan David Pantoja Valle
 *
 * Revisión: N/A
 * Revisado por: N/A
 * 
 * Notas: N/A
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MxPOS10.Sistema.Vistas
{
    public class VistaReceptor
    {
        private int _IDReceptor;

        public int IDReceptor
        {
            get { return _IDReceptor; }
            set { _IDReceptor = value; }
        }
        

        private string _req_RFC;

        public string req_RFC
        {
            get { return _req_RFC; }
            set { _req_RFC = value; }
        }

        private string _opc_Nombre;

        public string opc_Nombre
        {
            get { return _opc_Nombre; }
            set { _opc_Nombre = value; }
        }
    }
}