
/*
 * MxPOS 1.0
 * 
 * Elemento: VistaDomicilio
 * Tipo: Clase
 * Descripción: Representa todas las propiedades de un objeto emisor
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
    public class VistaDomicilio
    {
        private int _IDDomicilio;

        public int IDDomicilio
        {
            get { return _IDDomicilio; }
            set { _IDDomicilio = value; }
        }

        private int _IDReceptor;

	    public int IDReceptor
	    {
		    get { return _IDReceptor;}
		    set { _IDReceptor = value;}
	    }

        private string _opc_Calle;

        public string opc_Calle
        {
            get { return _opc_Calle; }
            set { _opc_Calle = value; }
        }

        private string _opc_NoExterior;

        public string opc_NoExterior
        {
            get { return _opc_NoExterior; }
            set { _opc_NoExterior = value; }
        }

        private string _opc_NoInterior;

        public string opc_NoInterior
        {
            get { return _opc_NoInterior; }
            set { _opc_NoInterior = value; }
        }

        private string _opc_Colonia;

        public string opc_Colonia
        {
            get { return _opc_Colonia; }
            set { _opc_Colonia = value; }
        }

        private string _opc_Localidad;

        public string opc_Localidad
        {
            get { return _opc_Localidad; }
            set { _opc_Localidad = value; }
        }

        private string _opc_Referencia;

        public string opc_Referencia
        {
            get { return _opc_Referencia; }
            set { _opc_Referencia = value; }
        }

        private string _opc_Municipio;

        public string opc_Municipio
        {
            get { return _opc_Municipio; }
            set { _opc_Municipio = value; }
        }

        private string _opc_Estado;

        public string opc_Estado
        {
            get { return _opc_Estado; }
            set { _opc_Estado = value; }
        }

        private string _req_Pais;

        public string req_Pais
        {
            get { return _req_Pais; }
            set { _req_Pais = value; }
        }

        private string _opc_CodigoPostal;

        public string opc_CodigoPostal
        {
            get { return _opc_CodigoPostal; }
            set { _opc_CodigoPostal = value; }
        }
        
    }
}