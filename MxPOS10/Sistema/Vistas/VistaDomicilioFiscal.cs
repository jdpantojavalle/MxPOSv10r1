
/*
 * MxPOS 1.0
 * 
 * Elemento: VistaDomicilioFiscal
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
    public class VistaDomicilioFiscal
    {
        private int _IDDomicilioFiscal;

        public int IDDomicilioFiscal
        {
            get { return _IDDomicilioFiscal; }
            set { _IDDomicilioFiscal = value; }
        }

        private int _IDEmisor;

	    public int IDEmisor
	    {
		    get { return _IDEmisor;}
		    set { _IDEmisor = value;}
	    }

        private string _req_Calle;

        public string req_Calle
        {
            get { return _req_Calle; }
            set { _req_Calle = value; }
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

        private string _req_Municipio;

        public string req_Municipio
        {
            get { return _req_Municipio; }
            set { _req_Municipio = value; }
        }

        private string _req_Estado;

        public string req_Estado
        {
            get { return _req_Estado; }
            set { _req_Estado = value; }
        }

        private string _req_Pais;

        public string req_Pais
        {
            get { return _req_Pais; }
            set { _req_Pais = value; }
        }

        private string _req_CodigoPostal;

        public string req_CodigoPostal
        {
            get { return _req_CodigoPostal; }
            set { _req_CodigoPostal = value; }
        }
        
    }
}